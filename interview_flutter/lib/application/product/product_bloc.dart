import 'package:bloc/bloc.dart';

import '../../domain/models/product.dart';
import '../../infrastructer/repositories/product_repository.dart';
import 'product_event.dart';
import 'product_state.dart';

class ProductBloc extends Bloc<ProductEvent, ProductState> {
  final ProductRepository _productRepository;

  ProductBloc({required ProductRepository productRepository})
      : _productRepository = productRepository,
        super(ProductInitial()) {
    on<ProductEvent>(mapEventToState);
  }

  @override
  void mapEventToState(ProductEvent event, Emitter<ProductState> emit) async {
    if (event is FetchProductsEvent) {
      emit(ProductLoading());

      try {
        final List<Product> products =
            await _productRepository.fetchPizzaProducts();
        emit(ProductLoaded(products));
      } catch (e) {
        emit(ProductError('Failed to fetch pizza products'));
      }
    } else if (event is AddProductEvent) {
      try {
        await _productRepository.addProduct(event.product);
        add(FetchProductsEvent());
        // emit();
      } catch (e) {
        emit(ProductError('Failed to fetch pizza products'));
      }
    }
    // Handle other events if needed
  }
}
