from __future__ import print_function

import logging

import grpc

import poc_pb2
import poc_pb2_grpc

def callHttps():
    ca_cert = 'dev.cer'
    with open('dev.cer','rb') as f:
        root_certs = f.read()

    credentials = grpc.ssl_channel_credentials(root_certs)

    with grpc.secure_channel('localhost:5001', credentials) as channel:
        stub = poc_pb2_grpc.MicroPocStub(channel)
        response = stub.Sum(poc_pb2.SumRequest(first=3,second=4))
    print(response.result)
    
def callHttp():
    with grpc.insecure_channel('localhost:5002') as channel:
        stub = poc_pb2_grpc.MicroPocStub(channel)
        response = stub.Sum(poc_pb2.SumRequest(first=8,second=6))
    print(response.result)


if __name__ == '__main__':
    logging.basicConfig()
    callHttps()
    callHttp()