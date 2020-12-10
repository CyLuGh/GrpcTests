from __future__ import print_function

import logging

import grpc

import poc_pb2
import poc_pb2_grpc

def run():
    with grpc.insecure_channel('localhost:5002') as channel:
        stub = poc_pb2_grpc.MicroPocStub(channel)
        response = stub.Sum(poc_pb2.SumRequest(first=3,second=4))
    print(response.result)

if __name__ == '__main__':
    logging.basicConfig()
    run()