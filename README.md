# GrpcTests

## R Resources

https://github.com/eddelbuettel/rprotobuf

https://github.com/nfultz/grpc

## Python

Install GRPC 

`python -m pip install grpcio`

Install GRPC tools

`python -m pip install grpcio-tools`

Generate python code from proto file

`python -m grpc_tools.protoc -I../GrpcShared --python_out=. --grpc_python_out=. ../GrpcShared/poc.proto`


## Troubleshoot

If GRPC throws an exception related to SSL while testing locally, please try to reset the development certificates.
> https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-5.0&tabs=visual-studio#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos
