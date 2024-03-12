import 'package:flutter/material.dart';
import 'package:app/utils/constants/colors.dart';
import '../../../../../utils/constants/image_strings.dart';

class TopProductsSlider extends StatelessWidget {
  const TopProductsSlider({Key? key});

  @override
  Widget build(BuildContext context) {
    final mediaqueryWidth = MediaQuery.of(context).size.width;
    final mediaqueryHeight = MediaQuery.of(context).size.height;

    return SizedBox(
      width: double.infinity,
      height: 210,
      child: ListView.builder(
        shrinkWrap: true,
        scrollDirection: Axis.horizontal,
        itemCount: 5,
        itemBuilder: (_, index) {
          return Container(
            width: mediaqueryWidth * 0.9,
            height: 210,
            margin: const EdgeInsets.only(right: 16.0, bottom: 16),
            decoration: BoxDecoration(
              color: Colors.white,
              borderRadius: BorderRadius.circular(0),
              boxShadow: [
                BoxShadow(
                  color: Colors.grey.withOpacity(0.5),
                  spreadRadius: 2,
                  blurRadius: 4,
                  offset: const Offset(0, 2),
                ),
              ],
            ),
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                children: [
                  Row(
                    children: [
                      Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Image(
                          image: AssetImage(TImages.p3),
                          width: mediaqueryWidth * 0.3,
                          height: mediaqueryHeight * 0.2,
                          fit: BoxFit.contain,
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.symmetric(vertical: 5),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: [
                            Text(
                              'Product Name',
                              style: Theme.of(context).textTheme.headlineSmall,
                            ),
                            Row(
                              children: [
                                Text(
                                  'Category:',
                                  style: Theme.of(context).textTheme.bodySmall,
                                ),
                                Text(
                                  'Category1',
                                  style: Theme.of(context).textTheme.bodyMedium,
                                ),
                              ],
                            ),
                            Row(
                              children: [
                                Text(
                                  'Rate:',
                                  style: Theme.of(context).textTheme.bodySmall,
                                ),
                                Row(
                                  children: [
                                    Text(
                                      '5',
                                      style:
                                          Theme.of(context).textTheme.bodyLarge,
                                    ),
                                    const Icon(
                                      Icons.star_rate_outlined,
                                      color: Colors.amber,
                                    )
                                  ],
                                ),
                              ],
                            ),
                            SizedBox(height: mediaqueryHeight * 0.01),
                            Row(
                              children: [
                                Text(
                                  'Price:',
                                  style: Theme.of(context).textTheme.bodyLarge,
                                ),
                                Text(
                                  'Rs1200',
                                  style:
                                      Theme.of(context).textTheme.headlineSmall,
                                ),
                              ],
                            ),
                            SizedBox(height: mediaqueryHeight * 0.01),
                            SizedBox(
                              width: mediaqueryWidth * 0.4,
                              height: mediaqueryHeight * 0.07,
                              child: OutlinedButton(
                                onPressed: () {},
                                child: Text(
                                  'Buy Now',
                                  style: Theme.of(context).textTheme.bodyLarge,
                                ),
                              ),
                            )
                          ],
                        ),
                      )
                    ],
                  )
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
