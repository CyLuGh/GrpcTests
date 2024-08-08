import time
import grpc

import demo_pb2
import demo_pb2_grpc

def unary_call():
    print('Testing unary call: summing 3 and 4')
    with grpc.insecure_channel('localhost:5267') as channel:
        stub = demo_pb2_grpc.MiniDemoStub(channel)
        response = stub.Sum(demo_pb2.SumRequestDto(first=3,second=4))
    print('Result is %i' % response.result)
    print()

def unary_call_repeated():
    print('Testing unary call with repeated elements')
    '''https://developers.google.com/protocol-buffers/docs/reference/python-generated#repeated-fields'''
    foo = demo_pb2.SumArrayRequestDto()
    foo.elements[:] = [1,2,3,4,5,6,7,8,9,10]

    with grpc.insecure_channel('localhost:5267') as channel:
        stub = demo_pb2_grpc.MiniDemoStub(channel)
        response = stub.SumArray(foo)
    print('Result is %i' % response.result)
    print()

def generate_client_stream():
    for item in [1,2,3,4,5,6,7,8,9,10]:
        print('Sending %i' % item)
        time.sleep(0.001)
        yield demo_pb2.AccumulatedElementDto(item=item) 

def client_stream():
    print('Testing client stream')
    with grpc.insecure_channel('localhost:5267') as channel:
        stub = demo_pb2_grpc.MiniDemoStub(channel)
        response = stub.SumStream(generate_client_stream())
    print('Result is %i' % response.result)
    print()

def server_stream():
    print('Testing server stream')
    foo = demo_pb2.SumArrayRequestDto()
    foo.elements[:] = [1,2,3,4,5,6,7,8,9,10]

    with grpc.insecure_channel('localhost:5267') as channel:
        stub = demo_pb2_grpc.MiniDemoStub(channel)
        response = stub.SumArrayDetailStream(foo)
        for r in response:
            print('Result is %i' % r.result)
    print()

def bidirectional_stream():
    print('Testing bidirectional stream')

    with grpc.insecure_channel('localhost:5267') as channel:
        stub = demo_pb2_grpc.MiniDemoStub(channel)
        for received in stub.Accumulate(generate_client_stream()):
            print('Result is %i' % received.result)
    print()

if __name__ == '__main__':
    print('Python client')
    input()
    unary_call()
    input()
    unary_call_repeated()
    input()
    client_stream()
    input()
    server_stream()
    input()
    bidirectional_stream()
    input()