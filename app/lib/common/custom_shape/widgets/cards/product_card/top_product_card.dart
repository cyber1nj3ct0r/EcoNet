import 'package:flutter/material.dart';

import '../../../../../utils/constants/image_strings.dart';

class TopProductCard extends StatelessWidget {
  const TopProductCard({super.key, required this.image, required this.index});
  final String image;
  final int index;

  @override
  Widget build(BuildContext context) {
    return Card(
      color: Colors.white,
      margin: const EdgeInsets.all(12.0),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(15.0)),
      child: GestureDetector(
        onTap: () {
          // Handle the onTap action, navigate to a different screen or perform any other action
        },
        child: Column(
          children: [
            Padding(
              padding: const EdgeInsets.all(8.0),
              child: Container(
                width: 90.0,
                height: 80.0,
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(15.0),
                  image:  DecorationImage(
                    image: AssetImage(image),
                    fit: BoxFit.cover,
                  ),
                ),
              ),
            ),
            Padding(
                padding: const EdgeInsets.all(5.0),
                child: SizedBox(
                  width: MediaQuery.of(context).size.width * 0.2,
                  child: Text(
                    'Product ${index}',
                    style: Theme.of(context).textTheme.bodyMedium!,
                    maxLines: 1,
                    overflow: TextOverflow.ellipsis,
                  ),
                )),
          ],
        ),
      ),
    );
  }
}
