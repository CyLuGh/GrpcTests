from __future__ import print_function

import logging

import grpc

import poc_pb2
import poc_pb2_grpc

def remoteSum(x,y):
    ca_cert = 'dev.cer'
    with open('dev.cer','rb') as f:
        root_certs = f.read()

    credentials = grpc.ssl_channel_credentials(root_certs)

    with grpc.secure_channel('localhost:5001', credentials) as channel:
        stub = poc_pb2_grpc.MicroPocStub(channel)
        response = stub.Sum(poc_pb2.SumRequest(first=int(x),second=int(y)))
    return response.result