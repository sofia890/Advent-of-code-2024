﻿using AdventLibrary;

namespace Day_18___RAM_Run
{
    internal static class Input
    {
        private static IList<Position> Parse(string value)
        {
            var list = new List<Position>();

            return value.Split("\r\n")
                        .Select(line =>
                        {
                            var components = Parser.ToIntegerArray<int>(line, splitOn: ",");

                            return new Position(components[0], components[1]);
                        })
                        .ToList();
        }
        public static (IList<Position> bytes, int width, int height, int nrofFallenBytes) GetData()
        {
            var data = "51,67\r\n63,57\r\n55,44\r\n37,11\r\n17,13\r\n24,21\r\n7,7\r\n3,26\r\n63,65\r\n69,54\r\n7,24\r\n33,25\r\n62,35\r\n43,61\r\n6,41\r\n30,7\r\n7,49\r\n39,9\r\n7,1\r\n29,28\r\n19,20\r\n3,17\r\n43,66\r\n43,65\r\n30,21\r\n25,29\r\n12,23\r\n43,19\r\n49,53\r\n41,63\r\n11,19\r\n9,4\r\n67,55\r\n1,37\r\n29,10\r\n22,33\r\n21,11\r\n26,13\r\n15,47\r\n53,64\r\n33,4\r\n34,31\r\n9,11\r\n39,19\r\n34,5\r\n23,29\r\n14,49\r\n57,61\r\n32,15\r\n3,34\r\n5,49\r\n59,43\r\n31,17\r\n3,36\r\n14,9\r\n32,9\r\n55,54\r\n58,69\r\n28,19\r\n14,19\r\n3,48\r\n25,36\r\n25,5\r\n59,37\r\n10,11\r\n35,28\r\n59,51\r\n49,47\r\n5,27\r\n53,55\r\n57,67\r\n57,60\r\n6,15\r\n53,59\r\n69,60\r\n29,31\r\n42,61\r\n41,58\r\n27,19\r\n12,49\r\n38,7\r\n17,45\r\n1,3\r\n3,11\r\n1,42\r\n60,69\r\n3,14\r\n59,41\r\n21,15\r\n51,57\r\n67,66\r\n65,68\r\n27,21\r\n17,27\r\n28,5\r\n7,2\r\n39,2\r\n5,54\r\n21,25\r\n33,23\r\n34,17\r\n20,25\r\n26,1\r\n23,2\r\n34,19\r\n37,63\r\n2,39\r\n9,17\r\n69,51\r\n26,33\r\n65,62\r\n53,69\r\n21,27\r\n45,7\r\n21,20\r\n58,43\r\n26,15\r\n41,64\r\n45,53\r\n5,25\r\n63,52\r\n27,13\r\n1,11\r\n44,11\r\n53,45\r\n15,3\r\n45,49\r\n15,26\r\n37,19\r\n35,61\r\n36,13\r\n51,52\r\n25,23\r\n23,26\r\n4,53\r\n23,9\r\n56,43\r\n25,16\r\n53,68\r\n12,47\r\n47,56\r\n25,31\r\n59,61\r\n25,27\r\n33,5\r\n9,51\r\n12,45\r\n6,37\r\n8,15\r\n3,5\r\n23,7\r\n45,9\r\n5,2\r\n5,48\r\n57,48\r\n10,17\r\n31,3\r\n64,57\r\n5,9\r\n14,33\r\n35,10\r\n51,65\r\n32,3\r\n69,49\r\n55,61\r\n30,11\r\n49,59\r\n22,31\r\n38,5\r\n35,33\r\n33,27\r\n39,25\r\n16,1\r\n1,13\r\n26,21\r\n47,62\r\n9,0\r\n69,53\r\n8,3\r\n5,37\r\n27,17\r\n5,51\r\n51,43\r\n63,42\r\n5,55\r\n7,47\r\n35,24\r\n3,3\r\n1,16\r\n55,59\r\n21,9\r\n32,27\r\n21,18\r\n14,21\r\n29,26\r\n4,5\r\n55,58\r\n36,21\r\n10,45\r\n33,29\r\n13,12\r\n21,5\r\n25,26\r\n9,1\r\n23,17\r\n11,1\r\n26,29\r\n21,19\r\n68,55\r\n6,43\r\n11,9\r\n17,19\r\n23,27\r\n23,4\r\n26,7\r\n12,3\r\n58,55\r\n18,1\r\n1,7\r\n9,26\r\n11,42\r\n13,6\r\n27,11\r\n47,59\r\n2,29\r\n47,52\r\n41,10\r\n31,25\r\n19,25\r\n43,13\r\n18,41\r\n9,45\r\n53,42\r\n5,4\r\n69,64\r\n47,9\r\n31,5\r\n31,14\r\n51,60\r\n39,12\r\n23,15\r\n49,57\r\n49,39\r\n35,14\r\n66,65\r\n3,43\r\n67,61\r\n25,17\r\n21,1\r\n1,23\r\n67,51\r\n49,58\r\n67,58\r\n51,51\r\n57,57\r\n9,46\r\n25,15\r\n39,27\r\n6,25\r\n2,7\r\n57,62\r\n41,68\r\n3,27\r\n10,9\r\n8,19\r\n52,63\r\n9,7\r\n23,46\r\n51,9\r\n59,46\r\n7,29\r\n59,66\r\n67,60\r\n29,23\r\n8,11\r\n61,69\r\n13,25\r\n1,1\r\n15,41\r\n43,8\r\n59,56\r\n61,61\r\n37,21\r\n21,4\r\n7,44\r\n10,41\r\n35,7\r\n57,41\r\n39,63\r\n11,45\r\n3,30\r\n18,45\r\n4,45\r\n47,49\r\n31,24\r\n60,61\r\n21,21\r\n61,57\r\n47,63\r\n35,13\r\n13,40\r\n69,52\r\n29,7\r\n59,57\r\n15,34\r\n27,5\r\n29,6\r\n13,39\r\n27,7\r\n11,18\r\n55,68\r\n23,31\r\n5,6\r\n9,48\r\n30,29\r\n5,22\r\n45,63\r\n19,4\r\n3,15\r\n11,30\r\n54,59\r\n17,21\r\n57,35\r\n51,59\r\n1,33\r\n35,9\r\n10,37\r\n61,66\r\n57,69\r\n21,17\r\n6,11\r\n65,55\r\n12,39\r\n22,25\r\n29,36\r\n67,67\r\n15,42\r\n39,56\r\n36,61\r\n50,59\r\n16,9\r\n11,43\r\n47,57\r\n28,31\r\n7,15\r\n40,53\r\n59,58\r\n49,63\r\n27,22\r\n3,41\r\n48,49\r\n17,6\r\n1,38\r\n59,69\r\n25,25\r\n66,51\r\n19,13\r\n11,41\r\n36,35\r\n69,68\r\n33,12\r\n55,64\r\n19,17\r\n55,52\r\n31,2\r\n11,13\r\n31,9\r\n3,44\r\n65,70\r\n11,16\r\n13,47\r\n65,59\r\n32,17\r\n32,31\r\n18,7\r\n43,56\r\n19,5\r\n63,61\r\n29,17\r\n5,12\r\n39,53\r\n47,10\r\n11,32\r\n33,19\r\n26,19\r\n39,26\r\n10,39\r\n4,35\r\n24,1\r\n45,55\r\n11,35\r\n5,45\r\n9,14\r\n59,67\r\n19,15\r\n15,35\r\n61,63\r\n21,10\r\n27,2\r\n6,1\r\n57,43\r\n63,64\r\n21,3\r\n37,5\r\n34,23\r\n9,19\r\n25,1\r\n11,2\r\n16,17\r\n33,7\r\n33,21\r\n31,26\r\n25,21\r\n28,3\r\n6,53\r\n18,27\r\n41,62\r\n70,67\r\n30,19\r\n8,31\r\n11,5\r\n8,49\r\n3,35\r\n14,1\r\n23,14\r\n19,33\r\n12,7\r\n11,7\r\n7,51\r\n28,15\r\n41,55\r\n11,20\r\n55,63\r\n45,60\r\n43,5\r\n4,41\r\n9,23\r\n67,63\r\n41,66\r\n47,54\r\n58,63\r\n7,9\r\n1,32\r\n19,31\r\n0,19\r\n33,13\r\n29,0\r\n7,50\r\n11,37\r\n13,45\r\n13,3\r\n7,18\r\n39,60\r\n60,53\r\n51,47\r\n63,69\r\n66,57\r\n46,65\r\n41,4\r\n51,49\r\n68,65\r\n25,30\r\n39,67\r\n15,43\r\n41,21\r\n41,67\r\n35,31\r\n35,65\r\n39,13\r\n19,23\r\n35,20\r\n3,42\r\n31,15\r\n66,55\r\n47,42\r\n11,21\r\n6,47\r\n22,13\r\n55,41\r\n17,5\r\n10,21\r\n55,47\r\n4,25\r\n39,11\r\n45,65\r\n10,23\r\n53,38\r\n5,11\r\n23,28\r\n25,6\r\n12,19\r\n46,57\r\n5,18\r\n1,4\r\n55,49\r\n17,4\r\n5,8\r\n69,61\r\n33,15\r\n47,60\r\n3,29\r\n12,29\r\n29,3\r\n60,43\r\n65,69\r\n23,25\r\n23,23\r\n57,46\r\n9,8\r\n51,66\r\n6,35\r\n34,7\r\n5,43\r\n65,66\r\n21,12\r\n29,19\r\n27,25\r\n47,51\r\n7,41\r\n50,47\r\n15,21\r\n11,23\r\n4,57\r\n19,7\r\n23,1\r\n13,22\r\n13,43\r\n37,13\r\n23,24\r\n70,47\r\n67,59\r\n19,14\r\n63,67\r\n32,7\r\n18,17\r\n29,11\r\n47,4\r\n49,67\r\n61,51\r\n26,25\r\n16,31\r\n9,5\r\n67,69\r\n34,15\r\n4,21\r\n5,1\r\n9,54\r\n17,17\r\n27,18\r\n7,17\r\n40,19\r\n7,16\r\n67,50\r\n5,29\r\n19,10\r\n59,55\r\n21,8\r\n57,63\r\n9,39\r\n8,23\r\n11,15\r\n19,3\r\n15,19\r\n30,13\r\n35,2\r\n35,27\r\n61,67\r\n11,25\r\n43,7\r\n7,39\r\n56,29\r\n7,21\r\n42,55\r\n19,45\r\n45,11\r\n57,52\r\n47,53\r\n1,26\r\n53,66\r\n33,26\r\n17,14\r\n1,39\r\n33,9\r\n12,35\r\n3,31\r\n13,21\r\n41,15\r\n63,63\r\n35,23\r\n25,13\r\n14,13\r\n35,34\r\n59,40\r\n31,23\r\n58,51\r\n5,47\r\n59,64\r\n45,59\r\n31,18\r\n17,1\r\n18,19\r\n5,5\r\n10,27\r\n9,13\r\n9,44\r\n42,15\r\n2,21\r\n70,51\r\n20,5\r\n5,53\r\n55,69\r\n14,23\r\n12,5\r\n29,22\r\n19,8\r\n8,13\r\n1,41\r\n52,57\r\n32,21\r\n29,5\r\n37,67\r\n34,9\r\n58,59\r\n41,6\r\n9,41\r\n13,15\r\n9,47\r\n13,16\r\n11,3\r\n43,11\r\n45,54\r\n21,23\r\n3,9\r\n53,39\r\n31,21\r\n31,27\r\n40,59\r\n45,57\r\n5,38\r\n38,61\r\n38,21\r\n48,59\r\n33,11\r\n69,63\r\n4,19\r\n51,61\r\n21,6\r\n67,65\r\n43,68\r\n56,47\r\n43,59\r\n44,55\r\n9,21\r\n27,12\r\n9,24\r\n3,54\r\n5,46\r\n29,16\r\n1,35\r\n4,37\r\n3,23\r\n3,40\r\n28,9\r\n47,48\r\n69,55\r\n27,3\r\n31,11\r\n13,14\r\n31,1\r\n33,3\r\n65,61\r\n23,5\r\n41,57\r\n45,61\r\n22,1\r\n57,65\r\n2,15\r\n65,56\r\n9,15\r\n61,59\r\n53,62\r\n53,63\r\n31,29\r\n1,19\r\n45,2\r\n51,44\r\n49,54\r\n47,55\r\n19,11\r\n16,7\r\n9,43\r\n5,39\r\n57,55\r\n50,55\r\n39,64\r\n29,13\r\n64,65\r\n15,28\r\n53,43\r\n38,67\r\n13,1\r\n55,53\r\n19,21\r\n14,51\r\n40,67\r\n5,3\r\n53,67\r\n19,9\r\n20,31\r\n42,17\r\n57,40\r\n35,19\r\n22,21\r\n1,9\r\n31,8\r\n51,53\r\n49,45\r\n59,45\r\n1,17\r\n14,3\r\n57,53\r\n35,30\r\n24,29\r\n41,5\r\n43,60\r\n15,29\r\n35,5\r\n51,39\r\n65,49\r\n49,52\r\n20,27\r\n1,24\r\n29,29\r\n31,7\r\n59,39\r\n51,55\r\n20,15\r\n19,24\r\n5,30\r\n60,59\r\n55,48\r\n3,1\r\n35,3\r\n14,35\r\n27,33\r\n27,1\r\n1,6\r\n21,7\r\n13,9\r\n13,56\r\n1,31\r\n5,28\r\n56,65\r\n57,54\r\n15,5\r\n4,15\r\n13,41\r\n13,44\r\n40,11\r\n1,5\r\n31,31\r\n15,25\r\n7,45\r\n3,37\r\n57,45\r\n3,39\r\n59,59\r\n65,63\r\n37,7\r\n65,67\r\n0,37\r\n21,29\r\n41,13\r\n60,41\r\n55,67\r\n8,33\r\n3,32\r\n11,14\r\n35,12\r\n1,21\r\n63,68\r\n45,62\r\n69,57\r\n8,37\r\n5,21\r\n7,37\r\n69,59\r\n48,51\r\n21,13\r\n35,15\r\n19,1\r\n17,32\r\n61,64\r\n9,38\r\n24,7\r\n69,62\r\n56,57\r\n5,7\r\n19,22\r\n5,23\r\n35,11\r\n62,49\r\n31,33\r\n9,53\r\n66,53\r\n1,10\r\n62,57\r\n44,63\r\n43,57\r\n13,13\r\n13,42\r\n27,27\r\n1,15\r\n43,63\r\n63,62\r\n7,20\r\n14,47\r\n5,10\r\n55,45\r\n1,12\r\n8,41\r\n62,55\r\n27,8\r\n62,61\r\n30,31\r\n7,26\r\n7,31\r\n30,5\r\n61,65\r\n13,30\r\n59,50\r\n66,63\r\n59,48\r\n41,7\r\n13,50\r\n27,23\r\n2,19\r\n62,69\r\n32,11\r\n36,7\r\n25,7\r\n25,3\r\n39,7\r\n13,35\r\n52,55\r\n60,57\r\n13,5\r\n10,51\r\n17,20\r\n27,28\r\n39,18\r\n17,3\r\n38,11\r\n25,4\r\n5,13\r\n56,39\r\n59,49\r\n53,51\r\n19,40\r\n5,41\r\n57,51\r\n11,12\r\n43,64\r\n10,1\r\n29,27\r\n5,19\r\n22,9\r\n69,58\r\n63,55\r\n28,11\r\n1,0\r\n31,64\r\n15,18\r\n55,56\r\n27,4\r\n45,58\r\n7,43\r\n5,57\r\n24,13\r\n55,60\r\n3,12\r\n16,21\r\n55,62\r\n14,7\r\n37,9\r\n69,67\r\n7,13\r\n27,30\r\n43,67\r\n13,11\r\n43,22\r\n9,3\r\n39,5\r\n2,3\r\n3,53\r\n8,29\r\n55,51\r\n10,5\r\n30,1\r\n2,17\r\n59,63\r\n33,0\r\n63,59\r\n22,17\r\n33,28\r\n8,7\r\n32,23\r\n29,14\r\n0,31\r\n37,26\r\n3,7\r\n3,2\r\n1,29\r\n7,33\r\n16,39\r\n37,15\r\n29,1\r\n58,41\r\n60,51\r\n5,50\r\n54,55\r\n15,2\r\n24,17\r\n36,17\r\n7,52\r\n48,61\r\n29,24\r\n5,17\r\n1,27\r\n27,24\r\n3,24\r\n51,45\r\n9,29\r\n33,30\r\n1,22\r\n49,55\r\n67,57\r\n39,15\r\n67,47\r\n51,40\r\n64,59\r\n59,47\r\n3,10\r\n27,39\r\n21,22\r\n0,9\r\n53,41\r\n39,24\r\n19,2\r\n43,58\r\n31,20\r\n27,15\r\n15,49\r\n8,43\r\n52,61\r\n27,9\r\n35,22\r\n42,7\r\n15,4\r\n19,12\r\n28,25\r\n23,21\r\n10,35\r\n61,53\r\n53,52\r\n3,21\r\n1,45\r\n35,25\r\n19,19\r\n8,5\r\n53,70\r\n69,45\r\n58,67\r\n10,31\r\n57,59\r\n53,61\r\n3,8\r\n35,1\r\n29,38\r\n3,33\r\n59,65\r\n9,55\r\n57,68\r\n69,65\r\n24,23\r\n3,28\r\n5,15\r\n57,49\r\n46,51\r\n47,16\r\n29,9\r\n7,40\r\n59,53\r\n1,25\r\n3,47\r\n55,50\r\n14,41\r\n37,16\r\n3,19\r\n53,65\r\n53,58\r\n23,19\r\n66,61\r\n55,65\r\n53,46\r\n31,13\r\n63,60\r\n55,66\r\n7,11\r\n43,51\r\n5,20\r\n7,22\r\n29,33\r\n20,17\r\n11,39\r\n15,7\r\n3,13\r\n6,9\r\n29,15\r\n40,15\r\n68,69\r\n39,8\r\n39,17\r\n2,35\r\n3,58\r\n3,45\r\n41,22\r\n11,31\r\n67,2\r\n54,31\r\n44,35\r\n43,20\r\n31,51\r\n23,42\r\n35,45\r\n37,17\r\n69,16\r\n61,54\r\n57,17\r\n51,0\r\n45,31\r\n25,59\r\n58,27\r\n11,69\r\n41,27\r\n45,6\r\n25,19\r\n4,63\r\n57,13\r\n47,19\r\n42,35\r\n34,49\r\n29,61\r\n62,53\r\n6,33\r\n64,37\r\n69,30\r\n55,9\r\n22,63\r\n43,45\r\n36,47\r\n51,25\r\n17,42\r\n30,63\r\n64,45\r\n35,48\r\n67,4\r\n37,4\r\n31,39\r\n69,1\r\n19,55\r\n13,17\r\n23,57\r\n58,9\r\n45,34\r\n41,53\r\n65,6\r\n4,69\r\n61,28\r\n55,19\r\n19,51\r\n25,56\r\n68,9\r\n67,53\r\n49,21\r\n49,3\r\n61,25\r\n45,42\r\n2,51\r\n57,37\r\n20,61\r\n63,4\r\n55,2\r\n65,28\r\n40,43\r\n18,39\r\n21,53\r\n35,29\r\n63,5\r\n50,65\r\n51,17\r\n27,38\r\n57,31\r\n13,7\r\n47,31\r\n29,63\r\n44,15\r\n27,37\r\n64,15\r\n61,33\r\n47,35\r\n56,37\r\n25,50\r\n59,33\r\n31,34\r\n29,57\r\n63,45\r\n69,24\r\n17,66\r\n43,44\r\n25,53\r\n22,45\r\n27,46\r\n21,59\r\n29,67\r\n69,21\r\n52,29\r\n8,55\r\n21,39\r\n31,41\r\n15,15\r\n22,67\r\n59,6\r\n50,29\r\n58,31\r\n34,45\r\n61,39\r\n49,44\r\n67,38\r\n15,70\r\n11,62\r\n32,51\r\n19,38\r\n5,63\r\n57,33\r\n24,59\r\n6,29\r\n29,25\r\n3,67\r\n41,30\r\n66,17\r\n63,14\r\n17,48\r\n35,51\r\n45,38\r\n65,3\r\n5,35\r\n58,11\r\n20,69\r\n63,51\r\n19,43\r\n22,61\r\n29,47\r\n15,67\r\n65,20\r\n46,35\r\n63,23\r\n20,35\r\n58,5\r\n28,43\r\n49,69\r\n67,33\r\n58,25\r\n3,57\r\n21,51\r\n43,69\r\n19,30\r\n51,69\r\n60,33\r\n63,47\r\n64,53\r\n33,67\r\n13,53\r\n27,69\r\n45,47\r\n43,23\r\n61,22\r\n39,61\r\n1,59\r\n43,55\r\n47,47\r\n15,52\r\n55,13\r\n4,61\r\n67,41\r\n44,49\r\n39,50\r\n23,33\r\n31,35\r\n67,24\r\n57,36\r\n64,33\r\n29,21\r\n67,44\r\n55,37\r\n35,53\r\n16,61\r\n53,17\r\n39,39\r\n9,25\r\n43,28\r\n17,37\r\n11,67\r\n62,39\r\n36,5\r\n47,40\r\n61,20\r\n7,61\r\n52,21\r\n23,37\r\n17,65\r\n55,57\r\n49,18\r\n45,68\r\n34,65\r\n49,35\r\n31,69\r\n19,39\r\n35,41\r\n32,61\r\n53,11\r\n21,35\r\n20,55\r\n53,50\r\n61,21\r\n23,63\r\n18,53\r\n48,33\r\n27,47\r\n13,29\r\n53,2\r\n5,33\r\n27,57\r\n29,62\r\n55,32\r\n61,45\r\n52,5\r\n39,31\r\n48,67\r\n49,11\r\n63,41\r\n49,42\r\n15,27\r\n19,49\r\n37,59\r\n1,68\r\n12,67\r\n62,45\r\n51,70\r\n39,54\r\n39,42\r\n9,56\r\n26,45\r\n69,9\r\n23,51\r\n53,49\r\n57,9\r\n49,15\r\n68,21\r\n59,19\r\n21,49\r\n25,65\r\n39,62\r\n13,60\r\n37,41\r\n11,51\r\n17,49\r\n35,40\r\n28,53\r\n26,53\r\n29,32\r\n41,65\r\n35,43\r\n14,67\r\n11,60\r\n23,65\r\n37,58\r\n67,8\r\n41,29\r\n31,45\r\n9,33\r\n17,33\r\n13,58\r\n65,19\r\n50,23\r\n65,10\r\n67,5\r\n2,69\r\n11,56\r\n4,51\r\n41,38\r\n48,13\r\n31,68\r\n33,61\r\n37,39\r\n42,25\r\n29,65\r\n34,55\r\n31,67\r\n61,27\r\n45,1\r\n55,34\r\n48,21\r\n59,3\r\n28,65\r\n56,11\r\n29,42\r\n25,55\r\n61,37\r\n61,47\r\n13,68\r\n52,13\r\n25,39\r\n38,37\r\n7,23\r\n11,55\r\n38,39\r\n15,17\r\n23,3\r\n45,3\r\n21,28\r\n27,41\r\n69,69\r\n11,63\r\n36,1\r\n44,51\r\n53,10\r\n24,65\r\n49,29\r\n63,49\r\n61,4\r\n55,17\r\n47,61\r\n50,63\r\n65,31\r\n50,67\r\n13,55\r\n41,0\r\n49,13\r\n34,43\r\n60,9\r\n51,3\r\n35,57\r\n21,69\r\n29,45\r\n9,34\r\n9,37\r\n0,65\r\n45,4\r\n55,11\r\n69,18\r\n18,59\r\n42,43\r\n23,59\r\n3,25\r\n44,47\r\n47,43\r\n34,59\r\n12,53\r\n33,1\r\n41,61\r\n31,48\r\n68,39\r\n47,67\r\n41,17\r\n16,65\r\n13,51\r\n25,52\r\n55,5\r\n67,39\r\n39,58\r\n59,34\r\n37,61\r\n8,69\r\n33,40\r\n37,57\r\n46,1\r\n15,59\r\n62,67\r\n64,3\r\n55,24\r\n11,47\r\n27,51\r\n7,65\r\n41,1\r\n67,45\r\n49,25\r\n25,60\r\n31,46\r\n51,37\r\n53,5\r\n24,19\r\n6,59\r\n46,7\r\n62,9\r\n67,21\r\n35,38\r\n15,55\r\n66,27\r\n45,43\r\n37,46\r\n31,19\r\n9,69\r\n47,69\r\n29,39\r\n25,37\r\n52,3\r\n65,15\r\n45,30\r\n38,23\r\n60,15\r\n33,69\r\n7,19\r\n21,66\r\n50,11\r\n67,1\r\n51,12\r\n40,7\r\n47,13\r\n39,49\r\n10,53\r\n17,53\r\n33,57\r\n39,28\r\n35,67\r\n41,59\r\n47,44\r\n53,0\r\n51,16\r\n2,65\r\n39,1\r\n67,27\r\n65,13\r\n61,23\r\n43,1\r\n53,33\r\n39,41\r\n27,50\r\n40,35\r\n61,17\r\n39,51\r\n41,36\r\n1,60\r\n53,23\r\n33,38\r\n19,53\r\n42,51\r\n23,34\r\n47,5\r\n58,33\r\n17,68\r\n24,33\r\n39,29\r\n26,41\r\n38,15\r\n25,41\r\n17,30\r\n53,21\r\n21,67\r\n7,32\r\n33,36\r\n37,53\r\n45,67\r\n49,7\r\n23,55\r\n39,3\r\n17,63\r\n44,29\r\n25,9\r\n64,47\r\n31,43\r\n21,63\r\n2,45\r\n60,3\r\n41,24\r\n47,70\r\n58,1\r\n45,45\r\n41,23\r\n9,57\r\n49,33\r\n7,59\r\n48,9\r\n31,40\r\n27,43\r\n65,1\r\n5,61\r\n33,41\r\n67,17\r\n69,11\r\n55,18\r\n37,31\r\n65,9\r\n56,5\r\n53,37\r\n21,61\r\n3,51\r\n52,9\r\n10,67\r\n63,18\r\n23,70\r\n27,49\r\n33,58\r\n17,25\r\n33,35\r\n43,39\r\n15,33\r\n48,25\r\n5,67\r\n69,32\r\n23,39\r\n61,43\r\n19,61\r\n16,37\r\n24,37\r\n21,65\r\n37,23\r\n46,37\r\n51,18\r\n65,65\r\n29,54\r\n25,61\r\n59,7\r\n68,35\r\n45,69\r\n49,36\r\n43,9\r\n66,33\r\n70,37\r\n52,31\r\n52,17\r\n11,53\r\n57,23\r\n7,53\r\n62,7\r\n25,67\r\n18,67\r\n27,55\r\n59,29\r\n39,35\r\n13,19\r\n69,15\r\n15,37\r\n19,54\r\n61,14\r\n13,31\r\n16,25\r\n65,21\r\n23,41\r\n29,59\r\n48,35\r\n52,53\r\n46,67\r\n51,11\r\n63,53\r\n9,65\r\n1,65\r\n36,33\r\n65,25\r\n55,36\r\n20,47\r\n31,54\r\n41,28\r\n46,17\r\n41,19\r\n63,24\r\n43,2\r\n31,44\r\n43,43\r\n53,26\r\n41,54\r\n34,69\r\n31,53\r\n61,35\r\n43,35\r\n3,65\r\n65,46\r\n40,3\r\n67,32\r\n50,41\r\n39,70\r\n29,40\r\n49,17\r\n66,15\r\n57,39\r\n21,42\r\n55,23\r\n27,64\r\n27,59\r\n57,47\r\n39,23\r\n54,19\r\n35,47\r\n36,63\r\n51,46\r\n68,49\r\n18,57\r\n13,28\r\n23,36\r\n59,11\r\n47,39\r\n29,55\r\n19,59\r\n41,43\r\n65,45\r\n63,37\r\n41,46\r\n43,33\r\n15,54\r\n65,37\r\n62,19\r\n53,1\r\n37,47\r\n31,61\r\n67,12\r\n55,35\r\n29,49\r\n63,29\r\n9,9\r\n11,57\r\n63,43\r\n41,45\r\n47,21\r\n40,45\r\n63,3\r\n15,16\r\n37,1\r\n26,11\r\n52,33\r\n37,27\r\n7,63\r\n57,19\r\n21,31\r\n45,29\r\n51,29\r\n32,41\r\n56,9\r\n41,3\r\n37,2\r\n33,49\r\n41,47\r\n64,35\r\n63,21\r\n14,63\r\n50,7\r\n63,17\r\n23,49\r\n21,41\r\n59,30\r\n39,37\r\n13,33\r\n49,4\r\n63,11\r\n34,57\r\n41,16\r\n21,50\r\n31,47\r\n49,19\r\n59,17\r\n69,6\r\n21,43\r\n43,26\r\n63,27\r\n63,15\r\n14,59\r\n67,43\r\n15,53\r\n33,37\r\n1,63\r\n43,21\r\n47,1\r\n51,31\r\n39,65\r\n69,29\r\n24,11\r\n50,49\r\n35,50\r\n61,15\r\n15,31\r\n27,45\r\n1,51\r\n43,53\r\n29,56\r\n65,39\r\n3,55\r\n14,11\r\n31,63\r\n46,29\r\n66,5\r\n47,45\r\n56,7\r\n69,47\r\n48,39\r\n31,57\r\n34,35\r\n8,63\r\n63,35\r\n6,57\r\n57,5\r\n56,17\r\n48,23\r\n61,1\r\n10,61\r\n51,1\r\n59,25\r\n27,29\r\n65,40\r\n46,47\r\n35,59\r\n48,19\r\n37,45\r\n43,47\r\n62,37\r\n21,57\r\n62,33\r\n32,57\r\n45,24\r\n35,17\r\n19,34\r\n58,19\r\n65,7\r\n57,21\r\n47,3\r\n51,13\r\n39,57\r\n13,23\r\n24,57\r\n49,68\r\n49,49\r\n65,57\r\n34,53\r\n49,5\r\n23,11\r\n25,47\r\n60,45\r\n48,47\r\n54,39\r\n35,37\r\n67,15\r\n53,19\r\n41,34\r\n15,66\r\n59,5\r\n47,27\r\n19,57\r\n17,52\r\n67,30\r\n51,19\r\n67,25\r\n37,68\r\n33,62\r\n25,48\r\n44,9\r\n55,7\r\n8,65\r\n58,17\r\n7,66\r\n27,31\r\n33,51\r\n23,53\r\n65,48\r\n59,21\r\n50,33\r\n19,63\r\n33,45\r\n61,11\r\n55,39\r\n11,59\r\n38,45\r\n47,65\r\n63,7\r\n55,29\r\n17,59\r\n45,13\r\n47,32\r\n31,52\r\n65,5\r\n61,12\r\n68,45\r\n45,17\r\n68,23\r\n20,59\r\n11,58\r\n27,34\r\n1,58\r\n33,70\r\n53,47\r\n53,36\r\n51,41\r\n47,7\r\n66,43\r\n53,31\r\n9,58\r\n15,62\r\n66,35\r\n69,28\r\n70,1\r\n61,9\r\n19,27\r\n25,69\r\n13,63\r\n44,5\r\n7,62\r\n59,31\r\n37,54\r\n55,16\r\n37,33\r\n2,61\r\n5,31\r\n69,25\r\n29,46\r\n64,9\r\n65,42\r\n59,8\r\n43,52\r\n63,40\r\n49,16\r\n47,23\r\n45,33\r\n37,25\r\n47,17\r\n16,13\r\n61,2\r\n1,57\r\n43,32\r\n35,63\r\n19,41\r\n25,68\r\n20,67\r\n15,9\r\n37,55\r\n63,44\r\n31,59\r\n36,67\r\n2,63\r\n35,35\r\n45,27\r\n49,27\r\n49,14\r\n41,25\r\n38,41\r\n39,32\r\n39,47\r\n0,47\r\n18,49\r\n41,51\r\n19,67\r\n63,9\r\n23,13\r\n33,63\r\n24,45\r\n11,33\r\n17,11\r\n15,11\r\n53,9\r\n63,50\r\n39,43\r\n58,3\r\n62,1\r\n34,67\r\n2,49\r\n51,15\r\n11,27\r\n19,47\r\n65,24\r\n65,53\r\n68,3\r\n47,15\r\n39,21\r\n3,49\r\n15,45\r\n15,56\r\n17,9\r\n1,61\r\n25,42\r\n31,49\r\n37,52\r\n65,18\r\n39,52\r\n57,25\r\n63,6\r\n51,5\r\n1,56\r\n22,57\r\n25,51\r\n49,1\r\n29,37\r\n67,31\r\n29,53\r\n17,61\r\n20,53\r\n69,27\r\n54,15\r\n63,26\r\n55,55\r\n41,69\r\n45,22\r\n70,7\r\n53,35\r\n67,42\r\n20,63\r\n69,37\r\n5,68\r\n31,56\r\n11,52\r\n37,43\r\n53,27\r\n32,49\r\n37,44\r\n27,68\r\n69,44\r\n37,37\r\n43,29\r\n9,31\r\n23,45\r\n19,28\r\n27,65\r\n68,13\r\n61,29\r\n40,27\r\n16,57\r\n25,33\r\n50,37\r\n32,67\r\n67,6\r\n44,37\r\n67,49\r\n65,8\r\n45,39\r\n50,27\r\n13,37\r\n67,11\r\n56,25\r\n13,54\r\n65,2\r\n44,23\r\n47,25\r\n12,65\r\n12,9\r\n40,39\r\n3,59\r\n41,33\r\n23,43\r\n45,32\r\n33,54\r\n61,55\r\n45,10\r\n24,51\r\n37,49\r\n9,27\r\n18,33\r\n45,37\r\n67,48\r\n45,15\r\n53,57\r\n27,40\r\n53,34\r\n21,52\r\n61,16\r\n13,26\r\n15,63\r\n52,43\r\n49,31\r\n18,61\r\n9,61\r\n7,57\r\n69,19\r\n65,51\r\n65,35\r\n30,49\r\n45,23\r\n66,21\r\n53,22\r\n55,28\r\n39,45\r\n28,49\r\n38,65\r\n26,55\r\n35,49\r\n65,47\r\n22,53\r\n52,7\r\n57,27\r\n19,37\r\n45,5\r\n37,10\r\n27,35\r\n53,15\r\n47,30\r\n63,1\r\n3,66\r\n43,40\r\n70,41\r\n58,23\r\n59,23\r\n67,28\r\n27,61\r\n33,44\r\n33,55\r\n49,23\r\n54,11\r\n42,13\r\n18,15\r\n15,23\r\n65,27\r\n45,35\r\n12,63\r\n13,65\r\n41,11\r\n29,70\r\n63,31\r\n51,27\r\n15,39\r\n47,41\r\n67,3\r\n8,61\r\n37,50\r\n29,52\r\n50,9\r\n67,23\r\n0,63\r\n27,58\r\n25,35\r\n45,21\r\n57,16\r\n39,69\r\n10,47\r\n60,37\r\n51,14\r\n53,13\r\n53,7\r\n48,29\r\n34,61\r\n31,60\r\n27,63\r\n60,25\r\n21,47\r\n23,69\r\n10,69\r\n45,41\r\n63,13\r\n69,26\r\n41,12\r\n46,27\r\n65,0\r\n65,33\r\n70,21\r\n51,21\r\n17,44\r\n55,30\r\n60,31\r\n57,3\r\n35,55\r\n19,70\r\n32,65\r\n69,3\r\n61,31\r\n20,37\r\n36,41\r\n8,59\r\n6,69\r\n29,58\r\n16,49\r\n55,15\r\n59,27\r\n65,38\r\n15,13\r\n23,62\r\n65,43\r\n11,49\r\n51,23\r\n21,45\r\n37,36\r\n3,69\r\n26,65\r\n53,53\r\n17,24\r\n17,10\r\n49,43\r\n59,20\r\n37,51\r\n46,15\r\n61,7\r\n7,25\r\n46,19\r\n49,61\r\n27,53\r\n20,43\r\n21,55\r\n25,43\r\n25,11\r\n6,63\r\n15,65\r\n55,31\r\n38,33\r\n15,46\r\n16,27\r\n23,35\r\n1,50\r\n63,33\r\n25,49\r\n54,7\r\n67,10\r\n61,19\r\n19,35\r\n23,47\r\n61,30\r\n50,3\r\n15,57\r\n37,35\r\n55,4\r\n39,33\r\n5,69\r\n23,67\r\n23,48\r\n49,6\r\n31,66\r\n68,19\r\n47,12\r\n13,61\r\n13,69\r\n53,25\r\n15,51\r\n29,34\r\n39,55\r\n10,65\r\n37,69\r\n43,15\r\n17,39\r\n17,29\r\n23,61\r\n9,49\r\n3,61\r\n29,41\r\n36,37\r\n41,9\r\n41,41\r\n13,59\r\n47,37\r\n63,30\r\n39,20\r\n60,19\r\n69,43\r\n25,57\r\n28,61\r\n59,28\r\n19,50\r\n65,26\r\n47,11\r\n1,43\r\n35,21\r\n7,5\r\n44,41\r\n13,27\r\n37,65\r\n29,43\r\n59,15\r\n57,29\r\n41,49\r\n35,69\r\n22,39\r\n24,43\r\n2,55\r\n61,10\r\n43,17\r\n12,25\r\n41,31\r\n55,25\r\n14,31\r\n41,50\r\n25,62\r\n33,65\r\n5,60\r\n69,35\r\n11,11\r\n9,63\r\n69,23\r\n48,5\r\n42,49\r\n23,54\r\n17,64\r\n37,29\r\n33,46\r\n27,67\r\n17,57\r\n19,29\r\n61,6\r\n56,1\r\n43,18\r\n51,24\r\n49,2\r\n61,49\r\n64,31\r\n13,64\r\n63,12\r\n69,34\r\n1,53\r\n17,31\r\n30,35\r\n15,69\r\n33,47\r\n13,49\r\n23,38\r\n59,1\r\n64,29\r\n9,28\r\n17,15\r\n44,13\r\n33,59\r\n57,7\r\n67,37\r\n41,35\r\n43,70\r\n7,3\r\n57,14\r\n22,59\r\n57,1\r\n67,19\r\n25,66\r\n5,59\r\n29,35\r\n45,25\r\n61,3\r\n25,40\r\n53,28\r\n21,40\r\n35,52\r\n7,69\r\n1,52\r\n19,65\r\n67,14\r\n67,7\r\n58,13\r\n69,39\r\n45,66\r\n13,57\r\n11,17\r\n49,26\r\n25,63\r\n42,39\r\n69,13\r\n67,36\r\n46,13\r\n51,7\r\n1,55\r\n31,55\r\n53,3\r\n19,46\r\n16,55\r\n42,47\r\n62,27\r\n41,39\r\n17,7\r\n51,50\r\n49,41\r\n17,43\r\n1,69\r\n21,37\r\n29,69\r\n67,46\r\n9,35\r\n54,21\r\n46,39\r\n67,13\r\n43,25\r\n45,20\r\n21,36\r\n43,4\r\n23,64\r\n61,48\r\n38,29\r\n57,15\r\n65,29\r\n28,45\r\n11,29\r\n69,33\r\n43,27\r\n52,35\r\n69,41\r\n33,53\r\n19,69\r\n3,63\r\n40,41\r\n16,59\r\n11,65\r\n15,1\r\n59,12\r\n57,11\r\n35,42\r\n59,13\r\n49,65\r\n51,33\r\n30,59\r\n48,45\r\n58,35\r\n37,18\r\n67,35\r\n55,43\r\n65,17\r\n53,29\r\n67,9\r\n59,38\r\n17,35\r\n55,1\r\n23,68\r\n9,67\r\n63,39\r\n39,30\r\n7,68\r\n53,24\r\n17,69\r\n54,41\r\n43,41\r\n64,51\r\n48,27\r\n35,39\r\n39,59\r\n65,41\r\n31,42\r\n55,3\r\n31,65\r\n55,33\r\n36,27\r\n53,8\r\n54,47\r\n47,22\r\n26,61\r\n67,40\r\n37,48\r\n51,20\r\n25,45\r\n54,13\r\n35,64\r\n0,43\r\n47,64\r\n11,61\r\n28,67\r\n14,37\r\n17,41\r\n49,51\r\n51,35\r\n5,65\r\n17,67\r\n43,49\r\n59,35\r\n24,9\r\n12,37\r\n63,19\r\n50,21\r\n70,11\r\n46,45\r\n7,35\r\n42,1\r\n1,47\r\n17,51\r\n63,16\r\n13,67\r\n65,11\r\n33,33\r\n41,20\r\n9,59\r\n65,22\r\n69,5\r\n67,29\r\n33,31\r\n17,47\r\n63,22\r\n21,33\r\n50,31\r\n68,17\r\n56,21\r\n69,7\r\n60,23\r\n62,43\r\n33,43\r\n69,17\r\n1,67\r\n33,39\r\n15,61\r\n47,29\r\n11,10\r\n36,31\r\n22,49\r\n63,25\r\n65,12\r\n47,33\r\n65,23\r\n33,17\r\n43,31\r\n1,49\r\n36,59\r\n42,31\r\n28,57\r\n31,37\r\n17,55\r\n44,45\r\n62,25\r\n45,51\r\n55,21\r\n29,51\r\n19,64\r\n55,27\r\n61,41\r\n4,65\r\n55,26\r\n41,37\r\n31,38\r\n46,25\r\n20,57\r\n32,33\r\n51,63\r\n45,19\r\n52,39\r\n7,27\r\n49,9\r\n57,22\r\n24,55\r\n43,37\r\n21,44\r\n54,5\r\n69,31\r\n27,48\r\n61,5\r\n7,67\r\n40,47\r\n7,55\r\n30,67\r\n17,36\r\n27,36\r\n16,45\r\n21,32\r\n37,56\r\n37,3\r\n43,3\r\n17,23\r\n5,56\r\n55,42\r\n59,9\r\n49,37\r\n61,13\r\n53,18\r\n64,12\r\n14,68\r\n45,14\r\n66,22\r\n46,6\r\n20,32\r\n32,14\r\n34,28\r\n8,44\r\n16,0\r\n8,58\r\n20,12\r\n27,42\r\n26,51\r\n58,7\r\n18,68\r\n44,6\r\n50,17\r\n60,64\r\n50,2\r\n15,30\r\n36,58\r\n14,52\r\n32,5\r\n54,4\r\n52,8\r\n17,62\r\n34,11\r\n26,27\r\n10,63\r\n9,32\r\n2,57\r\n60,47\r\n22,29\r\n40,17\r\n24,66\r\n34,64\r\n6,68\r\n36,40\r\n14,27\r\n17,56\r\n26,50\r\n24,20\r\n10,26\r\n54,1\r\n61,40\r\n14,42\r\n47,66\r\n66,11\r\n13,52\r\n49,56\r\n25,18\r\n28,29\r\n35,44\r\n32,1\r\n60,30\r\n21,2\r\n40,4\r\n54,12\r\n46,60\r\n38,6\r\n24,6\r\n56,0\r\n30,52\r\n62,4\r\n4,31\r\n40,12\r\n10,3\r\n44,0\r\n56,38\r\n17,46\r\n8,53\r\n66,49\r\n69,22\r\n12,16\r\n30,47\r\n69,0\r\n48,64\r\n34,16\r\n38,25\r\n47,0\r\n52,65\r\n43,10\r\n66,23\r\n60,32\r\n4,46\r\n32,26\r\n21,56\r\n57,8\r\n54,8\r\n36,66\r\n46,22\r\n50,57\r\n59,42\r\n30,37\r\n21,64\r\n57,10\r\n2,4\r\n48,8\r\n48,18\r\n62,26\r\n44,67\r\n52,64\r\n28,20\r\n16,43\r\n42,40\r\n49,22\r\n16,29\r\n14,4\r\n47,68\r\n36,44\r\n62,32\r\n22,7\r\n66,31\r\n33,8\r\n40,60\r\n20,52\r\n65,34\r\n30,0\r\n64,0\r\n33,50\r\n29,2\r\n55,40\r\n25,70\r\n52,18\r\n25,22\r\n38,42\r\n36,53\r\n70,27\r\n66,13\r\n16,34\r\n58,8\r\n40,56\r\n11,28\r\n38,16\r\n70,45\r\n64,32\r\n56,27\r\n22,30\r\n34,32\r\n42,56\r\n33,6\r\n0,70\r\n17,8\r\n27,44\r\n18,58\r\n43,16\r\n14,38\r\n13,8\r\n52,32\r\n38,57\r\n48,52\r\n53,4\r\n10,2\r\n62,21\r\n38,36\r\n54,68\r\n18,47\r\n10,50\r\n51,2\r\n8,57\r\n50,13\r\n12,21\r\n60,35\r\n62,29\r\n51,36\r\n48,56\r\n9,36\r\n38,59\r\n60,7\r\n45,70\r\n14,65\r\n48,26\r\n38,56\r\n68,11\r\n6,28\r\n54,25\r\n42,10\r\n12,52\r\n0,21\r\n1,48\r\n40,0\r\n32,46\r\n61,46\r\n66,25\r\n9,68\r\n16,33\r\n26,18\r\n49,38\r\n19,0\r\n66,39\r\n40,20\r\n28,30\r\n44,27\r\n54,22\r\n44,2\r\n42,24\r\n38,63\r\n22,37\r\n50,46\r\n12,34\r\n24,40\r\n20,70\r\n12,20\r\n32,22\r\n50,8\r\n62,20\r\n59,54\r\n22,68\r\n60,65\r\n1,64\r\n51,42\r\n63,46\r\n10,28\r\n25,44\r\n13,66\r\n50,12\r\n40,14\r\n31,10\r\n46,18\r\n26,32\r\n35,16\r\n52,42\r\n56,33\r\n36,26\r\n54,64\r\n7,4\r\n44,17\r\n56,35\r\n33,16\r\n66,28\r\n64,17\r\n54,62\r\n50,70\r\n30,38\r\n12,11\r\n28,27\r\n30,23\r\n60,29\r\n60,8\r\n8,66\r\n17,16\r\n56,13\r\n28,52\r\n40,34\r\n28,10\r\n32,62\r\n61,34\r\n66,4\r\n40,26\r\n40,61\r\n4,47\r\n18,10\r\n26,48\r\n48,66\r\n40,10\r\n38,3\r\n68,41\r\n34,47\r\n56,24\r\n69,50\r\n54,57\r\n18,48\r\n44,4\r\n40,30\r\n4,34\r\n45,28\r\n63,54\r\n66,47\r\n35,58\r\n19,62\r\n41,18\r\n60,63\r\n54,28\r\n69,48\r\n22,50\r\n10,46\r\n30,10\r\n21,38\r\n27,10\r\n48,44\r\n40,24\r\n44,69\r\n48,34\r\n58,18\r\n48,12\r\n24,44\r\n25,58\r\n26,14\r\n38,19\r\n38,40\r\n70,22\r\n20,23\r\n14,16\r\n64,26\r\n44,40\r\n14,28\r\n18,23\r\n70,5\r\n8,45\r\n28,17\r\n24,30\r\n30,3\r\n65,52\r\n18,32\r\n18,28\r\n61,42\r\n44,7\r\n29,8\r\n10,66\r\n66,26\r\n0,41\r\n2,42\r\n42,18\r\n38,53\r\n40,1\r\n54,6\r\n62,5\r\n47,38\r\n46,42\r\n34,0\r\n7,14\r\n20,51\r\n48,62\r\n42,9\r\n42,33\r\n38,13\r\n41,42\r\n42,0\r\n19,48\r\n28,55\r\n30,55\r\n52,37\r\n22,36\r\n30,58\r\n50,1\r\n22,46\r\n52,22\r\n18,35\r\n22,51\r\n20,50\r\n59,36\r\n26,31\r\n24,53\r\n68,29\r\n10,15\r\n34,56\r\n32,50\r\n43,24\r\n48,10\r\n8,17\r\n29,30\r\n40,38\r\n48,1\r\n0,24\r\n22,41\r\n26,34\r\n36,19\r\n54,23\r\n60,10\r\n28,4\r\n36,57\r\n64,20\r\n46,58\r\n19,36\r\n8,36\r\n16,2\r\n2,48\r\n10,14\r\n20,7\r\n22,34\r\n38,44\r\n70,20\r\n4,58\r\n20,8\r\n44,64\r\n5,66\r\n53,20\r\n4,0\r\n46,46\r\n45,18\r\n62,24\r\n8,34\r\n46,62\r\n16,4\r\n18,2\r\n43,6\r\n24,12\r\n65,44\r\n60,56\r\n40,33\r\n64,38\r\n64,24\r\n68,5\r\n4,27\r\n66,10\r\n21,34\r\n25,2\r\n10,29\r\n14,18\r\n35,70\r\n45,50\r\n56,20\r\n18,62\r\n20,34\r\n58,42\r\n8,52\r\n24,35\r\n47,24\r\n12,70\r\n68,43\r\n4,49\r\n70,17\r\n59,52\r\n16,8\r\n32,29\r\n56,10\r\n26,20\r\n44,32\r\n17,18\r\n62,54\r\n18,31\r\n52,41\r\n64,18\r\n53,40\r\n68,7\r\n6,10\r\n19,16\r\n64,10\r\n16,47\r\n2,56\r\n18,18\r\n37,6\r\n33,48\r\n15,22\r\n37,28\r\n34,29\r\n70,34\r\n36,29\r\n52,23\r\n64,48\r\n21,70\r\n25,54\r\n26,59\r\n27,56\r\n42,57\r\n4,66\r\n26,39\r\n44,1\r\n10,33\r\n50,16\r\n66,12\r\n18,0\r\n24,8\r\n38,24\r\n18,70\r\n62,42\r\n36,20\r\n70,43\r\n39,36\r\n5,14\r\n0,23\r\n28,60\r\n30,14\r\n52,70\r\n36,43\r\n10,6\r\n60,36\r\n31,0\r\n30,30\r\n52,24\r\n16,19\r\n61,68\r\n60,4\r\n50,64\r\n66,30\r\n20,38\r\n26,8\r\n2,60\r\n14,26\r\n46,36\r\n22,32\r\n19,52\r\n67,52\r\n1,70\r\n51,8\r\n12,24\r\n60,5\r\n42,45\r\n54,32\r\n68,52\r\n12,28\r\n41,14\r\n60,11\r\n30,41\r\n16,5\r\n24,18\r\n33,22\r\n32,13\r\n14,34\r\n52,2\r\n6,12\r\n37,42\r\n15,12\r\n14,17\r\n58,12\r\n70,35\r\n33,52\r\n24,14\r\n59,26\r\n48,68\r\n35,0\r\n69,14\r\n64,49\r\n51,64\r\n10,52\r\n44,18\r\n25,8\r\n14,57\r\n52,0\r\n28,21\r\n68,47\r\n58,14\r\n28,1\r\n10,19\r\n2,50\r\n9,20\r\n0,13\r\n35,6\r\n2,1\r\n26,35\r\n15,64\r\n17,2\r\n30,51\r\n64,14\r\n39,40\r\n12,50\r\n28,41\r\n62,23\r\n34,70\r\n18,29\r\n13,34\r\n24,36\r\n20,10\r\n23,18\r\n9,30\r\n16,53\r\n62,11\r\n51,22\r\n18,43\r\n48,16\r\n46,69\r\n42,42\r\n49,24\r\n56,34\r\n46,64\r\n6,56\r\n3,70\r\n18,34\r\n58,44\r\n24,48\r\n60,60\r\n44,31\r\n56,14\r\n24,63\r\n34,48\r\n46,55\r\n19,56\r\n44,70\r\n33,14\r\n27,52\r\n54,43\r\n54,35\r\n24,22\r\n60,66\r\n26,26\r\n18,14\r\n63,66\r\n16,22\r\n9,18\r\n62,13\r\n44,21\r\n46,61\r\n48,38\r\n2,31\r\n64,5\r\n3,56\r\n22,12\r\n11,50\r\n19,6\r\n42,6\r\n52,51\r\n57,70\r\n61,56\r\n62,12\r\n9,40\r\n23,58\r\n34,24\r\n14,20\r\n32,20\r\n44,3\r\n54,14\r\n32,39\r\n18,36\r\n2,52\r\n44,66\r\n54,51\r\n70,15\r\n47,34\r\n56,2\r\n28,38\r\n28,28\r\n0,6\r\n0,35\r\n16,51\r\n27,0\r\n48,70\r\n22,20\r\n42,50\r\n18,46\r\n8,12\r\n32,16\r\n23,56\r\n3,46\r\n40,28\r\n10,22\r\n54,18\r\n34,33\r\n16,40\r\n28,32\r\n2,13\r\n62,36\r\n42,52\r\n12,14\r\n26,63\r\n57,58\r\n20,68\r\n59,10\r\n69,56\r\n5,16\r\n60,50\r\n15,0\r\n36,4\r\n24,3\r\n51,48\r\n70,53\r\n15,68\r\n40,65\r\n62,3\r\n58,68\r\n16,36\r\n48,60\r\n42,29\r\n52,6\r\n68,40\r\n22,5\r\n69,12\r\n5,44\r\n6,39\r\n70,8\r\n0,7\r\n54,65\r\n64,40\r\n50,48\r\n30,17\r\n6,26\r\n43,48\r\n37,38\r\n20,29\r\n66,18\r\n34,20\r\n66,59\r\n50,66\r\n67,68\r\n0,54\r\n39,66\r\n69,66\r\n15,20\r\n13,0\r\n33,66\r\n60,46\r\n56,31\r\n25,46\r\n67,20\r\n18,51\r\n0,52\r\n26,47\r\n17,40\r\n64,55\r\n20,26\r\n48,48\r\n55,12\r\n70,58\r\n35,62\r\n60,21\r\n4,1\r\n5,0\r\n7,38\r\n6,17\r\n70,32\r\n50,42\r\n38,68\r\n34,52\r\n40,31\r\n26,23\r\n56,44\r\n32,59\r\n18,12\r\n0,59\r\n42,12\r\n25,12\r\n70,9\r\n68,27\r\n12,59\r\n40,54\r\n10,64\r\n62,62\r\n4,17\r\n10,32\r\n70,38\r\n47,50\r\n59,60\r\n0,5\r\n46,32\r\n28,18\r\n36,16\r\n8,48\r\n8,24\r\n70,28\r\n56,58\r\n43,34\r\n3,68\r\n18,3\r\n50,53\r\n63,36\r\n60,67\r\n26,46\r\n66,60\r\n28,47\r\n54,17\r\n52,69\r\n64,39\r\n45,8\r\n33,2\r\n29,4\r\n5,70\r\n33,68\r\n8,16\r\n37,0\r\n44,44\r\n37,60\r\n42,19\r\n64,66\r\n7,70\r\n18,54\r\n58,15\r\n3,16\r\n26,22\r\n57,6\r\n4,59\r\n51,38\r\n20,42\r\n39,0\r\n36,10\r\n33,10\r\n12,66\r\n20,19\r\n24,52\r\n40,55\r\n40,58\r\n39,44\r\n5,26\r\n65,60\r\n50,39\r\n20,11\r\n16,48\r\n19,32\r\n5,58\r\n6,61\r\n56,8\r\n26,67\r\n44,68\r\n10,62\r\n36,49\r\n30,34\r\n62,50\r\n36,12\r\n68,18\r\n28,34\r\n20,46\r\n68,60\r\n23,0\r\n30,68\r\n30,4\r\n37,32\r\n54,49\r\n58,32\r\n10,48\r\n38,43\r\n30,43\r\n42,26\r\n5,52\r\n24,54\r\n35,60\r\n12,27\r\n52,1\r\n41,2\r\n57,44\r\n13,10\r\n30,18\r\n62,40\r\n30,44\r\n66,1\r\n26,0\r\n66,44\r\n47,6\r\n0,30\r\n45,56\r\n22,70\r\n52,60\r\n56,19\r\n47,8\r\n47,14\r\n58,38\r\n42,20\r\n2,37\r\n22,27\r\n22,60\r\n30,56\r\n40,70\r\n2,58\r\n66,62\r\n0,60\r\n58,37\r\n68,8\r\n26,28\r\n30,28\r\n63,38\r\n33,34\r\n6,5\r\n8,0\r\n22,0\r\n60,12\r\n2,53\r\n10,57\r\n1,44\r\n68,16\r\n39,4\r\n42,54\r\n10,58\r\n18,66\r\n22,11\r\n58,60\r\n21,0\r\n1,34\r\n2,43\r\n66,56\r\n66,36\r\n50,45\r\n22,10\r\n21,48\r\n40,21\r\n8,9\r\n13,46\r\n31,4\r\n54,42\r\n30,27\r\n10,44\r\n55,70\r\n0,38\r\n2,70\r\n46,66\r\n30,2\r\n70,16\r\n32,18\r\n62,2\r\n64,52\r\n57,12\r\n38,9\r\n50,30\r\n52,50\r\n28,66\r\n2,11\r\n21,24\r\n44,19\r\n70,48\r\n24,56\r\n54,48\r\n11,22\r\n56,6\r\n11,54\r\n56,55\r\n48,42\r\n16,66\r\n52,27\r\n59,70\r\n54,27\r\n26,38\r\n21,30\r\n53,12\r\n24,68\r\n24,61\r\n50,5\r\n50,36\r\n18,25\r\n20,6\r\n44,65\r\n58,34\r\n14,40\r\n51,54\r\n4,33\r\n10,36\r\n6,48\r\n58,61\r\n12,57\r\n48,50\r\n2,40\r\n62,16\r\n24,10\r\n44,20\r\n1,54\r\n50,28\r\n65,4\r\n68,24\r\n52,40\r\n50,68\r\n9,12\r\n6,42\r\n36,8\r\n52,48\r\n40,66\r\n8,27\r\n3,50\r\n18,4\r\n11,46\r\n61,62\r\n38,64\r\n24,16\r\n51,32\r\n17,26\r\n66,16\r\n68,22\r\n6,30\r\n9,2\r\n48,28\r\n46,41\r\n1,46\r\n58,49\r\n31,50\r\n34,25\r\n30,22\r\n34,68\r\n3,22\r\n34,13\r\n56,66\r\n6,66\r\n36,50\r\n55,0\r\n37,22\r\n36,60\r\n56,16\r\n0,53\r\n54,34\r\n42,68\r\n36,15\r\n70,65\r\n58,16\r\n49,34\r\n6,36\r\n48,14\r\n24,25\r\n34,40\r\n38,35\r\n70,63\r\n44,14\r\n56,22\r\n14,48\r\n63,8\r\n20,1\r\n34,27\r\n41,52\r\n19,68\r\n22,8\r\n16,38\r\n58,50\r\n42,64\r\n47,26\r\n70,4\r\n65,30\r\n36,34\r\n40,22\r\n26,30\r\n69,40\r\n34,30\r\n64,69\r\n2,67\r\n35,8\r\n14,56\r\n41,70";
            return (Parse(data), 71, 71, 1024);
        }
        public static (IList<Position> bytes, int width, int height, int nrofFallenBytes) GetTrainingData()
        {
            var data = "5,4\r\n4,2\r\n4,5\r\n3,0\r\n2,1\r\n6,3\r\n2,4\r\n1,5\r\n0,6\r\n3,3\r\n2,6\r\n5,1\r\n1,2\r\n5,5\r\n2,5\r\n6,5\r\n1,4\r\n0,4\r\n6,4\r\n1,1\r\n6,1\r\n1,0\r\n0,5\r\n1,6\r\n2,0";
            return (Parse(data), 7, 7, 12);
        }
    }
}
