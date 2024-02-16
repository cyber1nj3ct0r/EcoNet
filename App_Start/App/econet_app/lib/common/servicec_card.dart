import 'package:flutter/material.dart';

class MyServiceCard extends StatelessWidget {
  const MyServiceCard({super.key, required this.name});

  final String name;
  

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Column(
        children: [
          Text(name,style: TextStyle(fontSize: 15),),
          Image(image: AssetImage('')),
          ElevatedButton(onPressed: (){}, child: Text('Submit'))
        ],

      ),
      
    );
  }
}