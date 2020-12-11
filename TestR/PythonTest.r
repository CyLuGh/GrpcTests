library(reticulate)

source_python('poc_client.py')
res <- remoteSum(10,15)

print(res)