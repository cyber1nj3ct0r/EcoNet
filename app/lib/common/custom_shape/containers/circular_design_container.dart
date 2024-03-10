import 'package:app/features/shop/screens/growing_crops/display_all_growing_crops.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

import 'circular_container.dart';

class CircularDesignContainer extends StatelessWidget {
  const CircularDesignContainer({super.key, required this.child});
  final Widget child;

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Positioned(top: -110, left: -5, child: TCircularContainer()),
        Positioned(top: -40, left: -110, child: TCircularContainer()),
        Positioned(
          top: 10,
          right: 20,
          child: TextButton(
              onPressed: () {
                Get.back();
              },
              child:
                  Text('Back', style: Theme.of(context).textTheme.bodyMedium)),
        ),
        Container(
          child: child,
        )
      ],
    );
  }
}
