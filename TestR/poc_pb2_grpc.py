# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
"""Client and server classes corresponding to protobuf-defined services."""
import grpc

import poc_pb2 as poc__pb2


class MicroPocStub(object):
    """Missing associated documentation comment in .proto file."""

    def __init__(self, channel):
        """Constructor.

        Args:
            channel: A grpc.Channel.
        """
        self.Sum = channel.unary_unary(
                '/poc.MicroPoc/Sum',
                request_serializer=poc__pb2.SumRequest.SerializeToString,
                response_deserializer=poc__pb2.SumReply.FromString,
                )


class MicroPocServicer(object):
    """Missing associated documentation comment in .proto file."""

    def Sum(self, request, context):
        """Sum two items!
        """
        context.set_code(grpc.StatusCode.UNIMPLEMENTED)
        context.set_details('Method not implemented!')
        raise NotImplementedError('Method not implemented!')


def add_MicroPocServicer_to_server(servicer, server):
    rpc_method_handlers = {
            'Sum': grpc.unary_unary_rpc_method_handler(
                    servicer.Sum,
                    request_deserializer=poc__pb2.SumRequest.FromString,
                    response_serializer=poc__pb2.SumReply.SerializeToString,
            ),
    }
    generic_handler = grpc.method_handlers_generic_handler(
            'poc.MicroPoc', rpc_method_handlers)
    server.add_generic_rpc_handlers((generic_handler,))


 # This class is part of an EXPERIMENTAL API.
class MicroPoc(object):
    """Missing associated documentation comment in .proto file."""

    @staticmethod
    def Sum(request,
            target,
            options=(),
            channel_credentials=None,
            call_credentials=None,
            insecure=False,
            compression=None,
            wait_for_ready=None,
            timeout=None,
            metadata=None):
        return grpc.experimental.unary_unary(request, target, '/poc.MicroPoc/Sum',
            poc__pb2.SumRequest.SerializeToString,
            poc__pb2.SumReply.FromString,
            options, channel_credentials,
            insecure, call_credentials, compression, wait_for_ready, timeout, metadata)