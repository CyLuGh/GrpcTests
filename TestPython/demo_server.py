from concurrent import futures
import demo_pb2
import demo_pb2_grpc
import grpc


class DemoServer(demo_pb2_grpc.MiniDemoServicer):
    def Sum(self, request, context):
        print("Calling Sum method")
        res = request.first + request.second
        return demo_pb2.SumResultDto(result= res) 
    
    def SumArray(self, request, context):
        print("Calling SumArray method")
        res = sum(list(request.elements))
        return demo_pb2.SumResultDto(result= res) 
    
    def SumStream(self, request_iterator, context):
        print("Calling SumStream method")
        res = 0

        for accumulated_element in request_iterator:
            res += accumulated_element.item

        return demo_pb2.SumResultDto(result= res)

    def SumArrayDetailStream(self, request, context):
        print("Calling SumArrayDetailStream method")
        res = 0
        data = list(request.elements)

        for item in data:
            res += item
            yield demo_pb2.SumResultDto(result= res)

    def Accumulate(self, request_iterator, context):
        print("Calling Accumulate method")
        res = 0

        for accumulated_element in request_iterator:
            res += accumulated_element.item
            yield demo_pb2.SumResultDto(result= res)

    
def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    demo_pb2_grpc.add_MiniDemoServicer_to_server(DemoServer(),server)
    server.add_insecure_port("[::]:5267")
    server.start()
    server.wait_for_termination()

if __name__ == '__main__':
    print('Python server')
    serve()