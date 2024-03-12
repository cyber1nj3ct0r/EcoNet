import 'package:flutter/material.dart';

class Dropdown1 extends StatefulWidget {
  const Dropdown1({super.key, required this.listName});
  final List<String> listName;

  @override
  _Dropdown1State createState() => _Dropdown1State();
}

class _Dropdown1State extends State<Dropdown1> {
  String selectedProduct = ''; // Holds the selected product

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        DropdownButton<String>(
          value: selectedProduct,
          items: widget.listName.map((String product) {
            return DropdownMenuItem<String>(
              value: product,
              child: Text(product),
            );
          }).toList(),
          onChanged: (String? newValue) {
            setState(() {
              selectedProduct = newValue!;
            });
          },
        ),
      ],
    );
  }
}
