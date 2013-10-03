from multiprocessing import current_process


class BaseAppException(Exception):
    msg = "error"

    def __init__(self, exc=None, *args, **kwargs):
        super(BaseAppException, self).__init__(self.msg, *args, **kwargs)
        self.exc = exc

    def __str__(self):
        return self.msg


class ApiErrorException(BaseAppException):
    msg = "the server couldn't fulfill your request"


class ApiUnavailableException(BaseAppException):
    msg = "server not found"


class ApiAuthException(BaseAppException):
    msg = "authentication failed"


class UploadEmptyError(BaseAppException):
    msg = "upload failed"


class WorkerFailureError(BaseAppException):
    msg = "worker '{}' failed"

    def __init__(self, *args, **kwargs):
        super(BaseAppException, self).__init__(self.msg, *args, **kwargs)
        self.msg.format(current_process())
