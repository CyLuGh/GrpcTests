from google.protobuf.internal import containers as _containers
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from typing import ClassVar as _ClassVar, Iterable as _Iterable, Optional as _Optional

DESCRIPTOR: _descriptor.FileDescriptor

class AccumulatedElementDto(_message.Message):
    __slots__ = ["item"]
    ITEM_FIELD_NUMBER: _ClassVar[int]
    item: int
    def __init__(self, item: _Optional[int] = ...) -> None: ...

class SumResultDto(_message.Message):
    __slots__ = ["result"]
    RESULT_FIELD_NUMBER: _ClassVar[int]
    result: int
    def __init__(self, result: _Optional[int] = ...) -> None: ...

class SumArrayRequestDto(_message.Message):
    __slots__ = ["elements"]
    ELEMENTS_FIELD_NUMBER: _ClassVar[int]
    elements: _containers.RepeatedScalarFieldContainer[int]
    def __init__(self, elements: _Optional[_Iterable[int]] = ...) -> None: ...

class SumRequestDto(_message.Message):
    __slots__ = ["first", "second"]
    FIRST_FIELD_NUMBER: _ClassVar[int]
    SECOND_FIELD_NUMBER: _ClassVar[int]
    first: int
    second: int
    def __init__(self, first: _Optional[int] = ..., second: _Optional[int] = ...) -> None: ...
