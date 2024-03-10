import 'package:app/utils/constants/colors.dart';
import 'package:app/utils/constants/image_strings.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:iconsax/iconsax.dart';

import '../../test.dart';

class CommonPost extends StatefulWidget {
  const CommonPost({Key? key}) : super(key: key);

  @override
  _CommonPostState createState() => _CommonPostState();
}

class _CommonPostState extends State<CommonPost> {
  bool showComments = false;

  @override
  Widget build(BuildContext context) {
    final mediaqueryWidth = MediaQuery.of(context).size.width;
    final mediaqueryHeight = MediaQuery.of(context).size.height;

    return InkWell(
      onTap: () {
        setState(() {
          showComments = !showComments;
        });
      },
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Container(
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(15.0),
            color: Colors.white,
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.5),
                spreadRadius: 2,
                blurRadius: 4,
                offset: const Offset(0, 2),
              ),
            ],
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              // Post Section
              Padding(
                padding:
                    const EdgeInsets.symmetric(vertical: 10, horizontal: 15),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          children: [
                            InkWell(
                              onTap: () {
                                Get.to(() => const Test());
                              },
                              child: const CircleAvatar(
                                radius: 24,
                                backgroundImage: AssetImage(TImages.farmer1),
                              ),
                            ),
                            const SizedBox(width: 8),
                            InkWell(
                              onTap: () {
                                Get.to(() => const Test());
                              },
                              child: Text(
                                'Kavindu Kaveesha',
                                style:
                                    Theme.of(context).textTheme.headlineSmall,
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                    SizedBox(
                      height: mediaqueryHeight * .01,
                    ),
                    Text('2 Minutes ago',
                        style: Theme.of(context).textTheme.bodyMedium),
                    const SizedBox(height: 8),
                    Row(
                      children: [
                        Text('Category:',
                            style: Theme.of(context).textTheme.bodySmall),
                        const SizedBox(width: 4),
                        Text('Foods',
                            style: Theme.of(context).textTheme.bodyMedium),
                      ],
                    ),
                    const SizedBox(height: 8),
                    Text(
                      "Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed.",
                      style: Theme.of(context).textTheme.bodyText2,
                      textAlign: TextAlign.justify,
                    ),
                    SizedBox(
                      height: mediaqueryHeight * .01,
                    ),
                  ],
                ),
              ),

              // Comments Section
              if (showComments)
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 10),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text('Comments',
                              style: Theme.of(context).textTheme.headlineSmall),
                          Padding(
                            padding: const EdgeInsets.symmetric(horizontal: 10),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const SizedBox(height: 8),
                                Container(
                                  decoration: BoxDecoration(
                                    border: Border.all(
                                      color: Colors
                                          .grey, // Adjust the border color
                                      width: 1.0, // Adjust the border width
                                    ),
                                    borderRadius: BorderRadius.circular(
                                        8.0), // Adjust the border radius
                                    color: Colors.grey[
                                        200], // Adjust the background color
                                  ),
                                  child: Padding(
                                    padding: const EdgeInsets.symmetric(
                                        horizontal: 10, vertical: 5),
                                    child: Column(
                                      children: [
                                        Row(
                                          children: [
                                            InkWell(
                                              onTap: () {
                                                Get.to(() => const Test());
                                              },
                                              child: const CircleAvatar(
                                                radius: 24,
                                                backgroundImage:
                                                    AssetImage(TImages.farmer1),
                                              ),
                                            ),
                                            const SizedBox(width: 8),
                                            InkWell(
                                              onTap: () {
                                                Get.to(() => const Test());
                                              },
                                              child: Text(
                                                'Kavindu Kaveesha',
                                                style: Theme.of(context)
                                                    .textTheme
                                                    .subtitle1,
                                              ),
                                            ),
                                          ],
                                        ),
                                        const SizedBox(height: 8),
                                        Text(
                                          "Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed.",
                                          style: Theme.of(context)
                                              .textTheme
                                              .bodyText2,
                                          textAlign: TextAlign.justify,
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                                SizedBox(
                                  height: mediaqueryHeight * .01,
                                ),
                                Container(
                                  decoration: BoxDecoration(
                                    border: Border.all(
                                      color: Colors
                                          .grey, // Adjust the border color
                                      width: 1.0, // Adjust the border width
                                    ),
                                    borderRadius: BorderRadius.circular(
                                        8.0), // Adjust the border radius
                                    color: Colors.grey[
                                        200], // Adjust the background color
                                  ),
                                  child: Padding(
                                    padding: const EdgeInsets.symmetric(
                                        horizontal: 10, vertical: 5),
                                    child: Column(
                                      children: [
                                        Row(
                                          children: [
                                            InkWell(
                                              onTap: () {
                                                Get.to(() => const Test());
                                              },
                                              child: const CircleAvatar(
                                                radius: 24,
                                                backgroundImage:
                                                    AssetImage(TImages.farmer1),
                                              ),
                                            ),
                                            const SizedBox(width: 8),
                                            InkWell(
                                              onTap: () {
                                                Get.to(() => const Test());
                                              },
                                              child: Text(
                                                'Kavindu Kaveesha',
                                                style: Theme.of(context)
                                                    .textTheme
                                                    .subtitle1,
                                              ),
                                            ),
                                          ],
                                        ),
                                        const SizedBox(height: 8),
                                        Text(
                                          "Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed. Your long paragraph goes here. Add as much content as needed.",
                                          style: Theme.of(context)
                                              .textTheme
                                              .bodyText2,
                                          textAlign: TextAlign.justify,
                                        ),
                                      ],
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                    ),

                    // Buttons Section
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 15, vertical: 10),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Padding(
                            padding: const EdgeInsets.symmetric(horizontal: 5),
                            child: Text('Add Comment',
                                style: Theme.of(context).textTheme.bodyLarge),
                          ),
                          const Row(
                            children: [
                              Expanded(
                                child: TextField(
                                  decoration: InputDecoration(
                                    hintText: 'Add a comment...',
                                    border: OutlineInputBorder(),
                                  ),
                                ),
                              ),
                              Icon(
                                Iconsax.arrow_right,
                                size: 70,
                                color: TColors.appPrimaryColor,
                              )
                            ],
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
            ],
          ),
        ),
      ),
    );
  }
}
