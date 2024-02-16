import 'package:econet_app/common/servicec_card.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Service App',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: MainScreen(),
    );
  }
}

class MainScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Service App'),
        leading: IconButton(
          icon: Icon(Icons.menu),
          onPressed: () {
            // Handle navigation drawer open
          },
        ),
      ),
      body: Padding(
        padding: EdgeInsets.all(8.0),
        child: Column(
          
          children: <Widget>[
            Expanded(
              child: GridView.count(
                crossAxisCount: 2,
                children: <Widget>[
                  // ServiceCard(
                  //   title: 'Get a ride',
                  //   icon: Icons.directions_car,
                  //   onTap: () {
                  //     // Handle get a ride tap
                  //   },
                  // ),
                  // ServiceCard(
                  //   title: 'Order food',
                  //   icon: Icons.restaurant,
                  //   onTap: () {
                  //     // Handle order food tap
                  //   },
                  // ),
                  // Add more services here


                  MyServiceCard(name: "Kavindu"),
                  MyServiceCard(name: "sanira"),
                  MyServiceCard(name: "dinesh"),
                ],
              ),
            ),
            // Additional sections can be added here
          ],
        ),
      ),
    );
  }
}

class ServiceCard extends StatelessWidget {
  final String title;
  final IconData icon;
  final VoidCallback onTap;

  const ServiceCard({
    Key? key,
    required this.title,
    required this.icon,
    required this.onTap,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: InkWell(
        onTap: onTap,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Icon(icon, size: 50.0),
            Text(title),
          ],
        ),
      ),
    );
  }
}
