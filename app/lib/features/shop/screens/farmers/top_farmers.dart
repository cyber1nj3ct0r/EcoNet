import 'package:flutter/material.dart';

import '../../../../../utils/constants/image_strings.dart';

class TopFarmers extends StatelessWidget {
  const TopFarmers({super.key});

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
          return Card(
            color: Colors.white.withOpacity(1),
            margin: const EdgeInsets.all(12.0),
            shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(15.0)),
            child: GestureDetector(
              onTap: () {
                // Handle the onTap action, navigate to a different screen or perform any other action
              },
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Container(
                      width: 80.0,
                      height: 80.0,
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(80.0),
                        image: const DecorationImage(
                          image: AssetImage(TImages.farmer1),
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
                          'Farmer ${index}',
                          style: Theme.of(context).textTheme.bodyMedium!,
                          maxLines: 1,
                          overflow: TextOverflow.ellipsis,
                        ),
                      )),
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
