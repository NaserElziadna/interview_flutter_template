import 'package:interview_flutter/domain/dto/create_product.dart';
import 'package:interview_flutter/domain/models/product.dart';

abstract class ProductEvent {}

class FetchProductsEvent extends ProductEvent {}
class AddProductEvent extends ProductEvent {
  final CreateProductDTO product;

  AddProductEvent(this.product);

}
