import yaml

from lacli.cipher import cipher_modes, new_key
from yaml import SafeLoader
from yaml import SafeDumper
from lacli.exceptions import InvalidArchiveError


class PrettySafeLoader(SafeLoader):
    pass


class BaseYAMLObject(yaml.YAMLObject):
    yaml_loader = PrettySafeLoader
    yaml_dumper = SafeDumper

    @classmethod
    def to_yaml(cls, dumper, data):
        return dumper.represent_mapping(cls.yaml_tag, data.__dict__)


class Archive(BaseYAMLObject):
    """
    >>> meta = Meta('zip', 'aes-256-ctr')
    >>> archive = Archive('title', meta, 'description', tags=['foo', 'bar'])
    >>> archive.title
    'title'
    >>> archive.description
    'description'
    >>> archive.meta.cipher
    'aes-256-ctr'
    >>> archive.tags[1]
    'bar'
    """
    yaml_tag = u'!archive'

    def __init__(self, title, meta, description=None, tags=[]):
        self.title = title
        self.description = description
        self.tags = tags
        if not hasattr(meta, 'format'):
            raise ValueError("invalid meta: " + str(meta))
        self.meta = meta


class Auth(BaseYAMLObject):
    """
    >>> with open('t/data/home/certs/2013-10-13-foobar.adf') as f:
    ...     docs=list(load_all(f))
    ...     for doc in docs:
    ...         if hasattr(doc, 'sha512'):
    ...             auth = Auth(sha512=doc.sha512)
    ...             auth.sha512.encode('hex')[:10]
    'd34a686c5c'
    """
    yaml_tag = u'!auth'

    def __init__(self, *args, **kwargs):
        self.__dict__.update(kwargs)


class Meta(BaseYAMLObject):
    """
    >>> meta = Meta('zip', 'aes-256-ctr')
    >>> meta.format
    'zip'
    >>> meta.cipher
    'aes-256-ctr'
    """
    yaml_tag = u'!meta'

    def __init__(self, format, cipher):
        self.format = format
        self.cipher = cipher


class Format(BaseYAMLObject):
    yaml_tag = u'!format'


class Links(BaseYAMLObject):
    yaml_tag = u'!links'

    def __init__(self, download=None, local=None):
        if download:
            self.download = download
        if local:
            self.local = local


class Cipher(BaseYAMLObject):
    """
    >>> cipher = Cipher('aes-256-ctr', key=2, input='\1\2\3\4'*4)
    >>> cipher.mode
    'aes-256-ctr'
    >>> cipher.key
    2
    >>> cipher.input.encode('hex')
    '01020304010203040102030401020304'
    >>> Cipher('aes-256-ctr', key='foo')
    Traceback (most recent call last):
      File "<stdin>", line 1, in <module>
      File "lacli/adf.py", line 70, in __init__
    ValueError: key must be integer
    >>> Cipher('wtf')
    Traceback (most recent call last):
      File "<stdin>", line 1, in <module>
      File "lacli/adf.py", line 68, in __init__
    ValueError: wtf not recognized
    >>> cipher = Cipher('aes-256-ctr')
    >>> hasattr(cipher, 'key')
    False
    >>> hasattr(cipher, 'input')
    False
    >>> cipher = Cipher('aes-256-ctr', key=1)
    >>> hasattr(cipher, 'key')
    False
    """

    yaml_tag = u'!cipher'

    def __init__(self, mode, key=1, input=None):
        if mode not in cipher_modes():
            raise ValueError("{} not recognized".format(mode))
        if not isinstance(key, int):
            raise ValueError("key must be integer")
        self.mode = mode
        if key > 1:
            self.key = key
        if input:
            self.input = input

    def __setstate__(self, d):
        assert d['mode'] in cipher_modes()
        self.__dict__.update(d)


class DerivedKey(BaseYAMLObject):
    yaml_tag = u'!key'


class Certificate(BaseYAMLObject):
    yaml_tag = u'!certificate'

    def __init__(self):
        self.key = new_key(256)


class MAC(BaseYAMLObject):
    yaml_tag = u'!mac'


class Signature(BaseYAMLObject):
    yaml_tag = u'!signature'


def add_path_resolver(tag, keys):
    yaml.add_path_resolver(tag, keys, dict, Loader=PrettySafeLoader)

add_path_resolver(u'!format', ["meta", "format"])
add_path_resolver(u'!cipher', ["meta", "cipher"])
add_path_resolver(u'!meta', ["meta"])
add_path_resolver(u'!mac', ["mac"])
add_path_resolver(u'!signature', ["signature"])
add_path_resolver(u'!key', ["keys", None])


def load_all(f):
    return yaml.load_all(f, Loader=PrettySafeLoader)


def load_archive(f):
    for o in load_all(f):
        if hasattr(o, 'meta'):
            return o
    raise InvalidArchiveError()


def make_adf(archive=None, canonical=False, out=None):
    """
    >>> from StringIO import StringIO
    >>> archive = Archive('title', Meta('zip', 'aes-256-ctr'))
    >>> out = StringIO()
    >>> make_adf(archive, out=out)
    >>> print out.getvalue()
    !archive
    description: null
    meta: !meta {cipher: aes-256-ctr, format: zip}
    tags: []
    title: title
    <BLANKLINE>
    """

    if not hasattr(archive, '__getitem__'):
        archive = [archive]
    return yaml.safe_dump_all(archive, out, canonical=canonical)
