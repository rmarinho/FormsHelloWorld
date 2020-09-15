import 'package:flutter/material.dart';

const colorBlue = const Color(0xFF2196F3);

void main() {
  runApp(MaterialApp(
    title: 'Flutter layout demo',
    home: Scaffold(
      body: buildLayout(),
    ),
  ));
}

Widget buildLayout() =>
    Column(
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Container(
           decoration: new BoxDecoration(color:colorBlue),
           child:  Padding(
               padding: EdgeInsets.all(34),
               child: Text('Welcome to Flutter',
                   textAlign: TextAlign.center,
                   style: TextStyle(fontSize: 44, color: Colors.white))
           ),
        ),
        Padding(
          padding: EdgeInsets.fromLTRB(30,10,30,10),
          child: Text('Start developing now',
              textAlign: TextAlign.left,
              style: TextStyle(fontSize: 34))
        ),
        Padding(
            padding: EdgeInsets.fromLTRB(30,0,30,0),
            child: Text('Make changes to your dart file and save yo see your UI update on the simulator. Give it a try!',
                textAlign: TextAlign.left,
                style: TextStyle(fontSize: 16)
            )
        ),
        Padding(
            padding: EdgeInsets.fromLTRB(30,24,30,24),
            child: Text.rich(
                    TextSpan(
                        children: [
                          TextSpan(
                            text: 'Learn more at ',
                            style: TextStyle(fontSize: 16),
                          ),
                          TextSpan(
                            text: 'https://flutter.dev/',
                            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                          )
                         ]
                    )
                  )
        ),
        Center(child: RaisedButton(child: Text('Flutter Version')))
      ]
    );

