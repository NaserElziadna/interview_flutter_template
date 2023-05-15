import 'dart:convert';

class CreateProductDTO {
  final String name;
  final double price;

  CreateProductDTO({
    required this.name,
    required this.price,
  });

  CreateProductDTO copyWith({
    String? name,
    double? price,
  }) {
    return CreateProductDTO(
      name: name ?? this.name,
      price: price ?? this.price,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'name': name,
      'price': price,
    };
  }

  factory CreateProductDTO.fromMap(Map<String, dynamic> map) {
    return CreateProductDTO(
      name: map['name'] ?? '',
      price: map['price']?.toDouble() ?? 0.0,
    );
  }

  String toJson() => json.encode(toMap());

  factory CreateProductDTO.fromJson(String source) => CreateProductDTO.fromMap(json.decode(source));

  @override
  String toString() => 'CreateProductDTO(name: $name, price: $price)';

  @override
  bool operator ==(Object other) {
    if (identical(this, other)) return true;
  
    return other is CreateProductDTO &&
      other.name == name &&
      other.price == price;
  }

  @override
  int get hashCode => name.hashCode ^ price.hashCode;
}
