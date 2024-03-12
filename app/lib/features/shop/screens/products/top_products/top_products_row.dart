import 'package:app/common/custom_shape/widgets/cards/product_card/top_product_card.dart';
import 'package:flutter/material.dart';

import '../../../../../utils/constants/image_strings.dart';

class TopProducts extends StatelessWidget {
  const TopProducts({super.key});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: double.infinity,
      height: 160,
      child: ListView.builder(
        shrinkWrap: true,
        scrollDirection: Axis.horizontal,
        itemCount: 5,
        itemBuilder: (_, index) {
          return TopProductCard(image: TImages.p3, index: index);
        },
      ),
    );
  }
}
