library(RProtoBuf)

readProtoFiles("poc.proto")

p <- new( poc.SumRequest, first = 3, second = 4 )

p$first