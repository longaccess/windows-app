from setuptools import setup, find_packages
from lacli import __version__

setup(version=unicode(__version__),
      name="lacli",
      author="Konstantinos Koukopoulos",
      description="The Long Access client",
      long_description=open('README').read(),
      packages=['lacli', 'lacli.t'],
      install_requires=['boto', 'python-dateutil', 'filechunkio', 'argparse'],
      tests_require=['testtools'],
      test_suite="lacli.t",
      scripts=['bin/laput.py']
)
