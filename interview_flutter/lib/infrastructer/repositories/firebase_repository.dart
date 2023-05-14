import 'package:cloud_firestore/cloud_firestore.dart';

class FirebaseRepository {
  final CollectionReference _collection = FirebaseFirestore.instance.collection('my_collection');

  Stream<List<String>> getSomeData() {
    return _collection.doc('my_document').snapshots().map((docSnapshot) {
      List<String> data = [];
      if (docSnapshot.exists) {
        var docData = docSnapshot.data()! as Map<String, dynamic>;
        if (docData.containsKey('my_list_field')) {
          data = List<String>.from(docData['my_list_field']);
        }
      }
      return data;
    });
  }
}