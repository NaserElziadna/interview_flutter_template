// Bloc
import 'package:bloc/bloc.dart';

import '../../domain/models/order.dart';
import '../../infrastructer/repositories/order_repository.dart';
import 'order_event.dart';
import 'order_state.dart';

class OrderBloc extends Bloc<OrderEvent, OrderState> {
   final OrderRepository _orderRepository;

  OrderBloc({required OrderRepository orderRepository})
      : _orderRepository = orderRepository,
        super(OrderEmpty()) {
    on<OrderEvent>(mapEventToState);
  }
  
  @override
  void mapEventToState(OrderEvent event, Emitter<OrderState> emit) async {
    
    // Handle other events if needed
  }
}