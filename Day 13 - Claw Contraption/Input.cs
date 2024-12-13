﻿using System.Numerics;

namespace Day_13___Claw_Contraption
{
    internal class Input
    {
        const int LINES_PER_ENTRY = 3;
        public record Position(long x, long y);
        public record StepSize(long x, long y);
        public record Entry(Position goal, StepSize a, StepSize b);
        static Func<string, long> GetIntParser(int offset)
        {
            return (string value) =>
            {
                return long.Parse(value[offset..]);
            };
        }
        static long[] ToIntegerArray(string value, int offset)
        {
            return value.Split(", ").Select(GetIntParser(offset)).ToArray();
        }
        static IEnumerable<Entry> Parse(string data)
        {
            var list = new List<Entry>();

            var machines = data.Replace("\r\n\r\n", "\r\n")
                               .Split("\r\n")
                               .Select((value, index) => (value, index))
                               .GroupBy(x => x.index / LINES_PER_ENTRY)
                               .Select(x =>
                                 x.Select(y => y.value)
                                  .ToArray()
                               );

            foreach (string[] lines in machines)
            {
                var movmentA = ToIntegerArray(lines[0][10..], 1);
                var movementB = ToIntegerArray(lines[1][10..], 1);
                var goal = ToIntegerArray(lines[2][7..], 2);

                list.Add(new Entry(new Position(goal[0], goal[1]),
                                   new StepSize(movmentA[0], movmentA[1]),
                                   new StepSize(movementB[0], movementB[1])));
            }

            return list;
        }
        public static IEnumerable<Entry> GetData()
        {
            var data = "Button A: X+23, Y+33\r\nButton B: X+62, Y+25\r\nPrize: X=6801, Y=3810\r\n\r\nButton A: X+31, Y+56\r\nButton B: X+27, Y+16\r\nPrize: X=18354, Y=8640\r\n\r\nButton A: X+45, Y+86\r\nButton B: X+30, Y+11\r\nPrize: X=5640, Y=8462\r\n\r\nButton A: X+39, Y+66\r\nButton B: X+97, Y+46\r\nPrize: X=9362, Y=7100\r\n\r\nButton A: X+66, Y+11\r\nButton B: X+11, Y+34\r\nPrize: X=4577, Y=8227\r\n\r\nButton A: X+73, Y+14\r\nButton B: X+94, Y+95\r\nPrize: X=10129, Y=9101\r\n\r\nButton A: X+65, Y+25\r\nButton B: X+59, Y+93\r\nPrize: X=2109, Y=1233\r\n\r\nButton A: X+19, Y+90\r\nButton B: X+67, Y+71\r\nPrize: X=3091, Y=8236\r\n\r\nButton A: X+74, Y+38\r\nButton B: X+17, Y+81\r\nPrize: X=3375, Y=7587\r\n\r\nButton A: X+47, Y+13\r\nButton B: X+12, Y+50\r\nPrize: X=19038, Y=924\r\n\r\nButton A: X+45, Y+21\r\nButton B: X+22, Y+37\r\nPrize: X=6821, Y=8669\r\n\r\nButton A: X+71, Y+29\r\nButton B: X+36, Y+96\r\nPrize: X=4434, Y=7014\r\n\r\nButton A: X+15, Y+55\r\nButton B: X+60, Y+17\r\nPrize: X=15440, Y=4357\r\n\r\nButton A: X+80, Y+49\r\nButton B: X+48, Y+90\r\nPrize: X=5328, Y=7566\r\n\r\nButton A: X+22, Y+48\r\nButton B: X+69, Y+35\r\nPrize: X=18409, Y=11853\r\n\r\nButton A: X+76, Y+39\r\nButton B: X+39, Y+72\r\nPrize: X=7655, Y=4812\r\n\r\nButton A: X+25, Y+30\r\nButton B: X+98, Y+21\r\nPrize: X=7277, Y=3999\r\n\r\nButton A: X+59, Y+42\r\nButton B: X+12, Y+31\r\nPrize: X=4477, Y=5051\r\n\r\nButton A: X+16, Y+35\r\nButton B: X+32, Y+21\r\nPrize: X=3696, Y=16097\r\n\r\nButton A: X+61, Y+27\r\nButton B: X+14, Y+49\r\nPrize: X=8585, Y=19166\r\n\r\nButton A: X+15, Y+49\r\nButton B: X+54, Y+27\r\nPrize: X=5009, Y=4005\r\n\r\nButton A: X+56, Y+77\r\nButton B: X+67, Y+28\r\nPrize: X=6554, Y=6062\r\n\r\nButton A: X+18, Y+64\r\nButton B: X+76, Y+72\r\nPrize: X=4220, Y=5688\r\n\r\nButton A: X+34, Y+16\r\nButton B: X+19, Y+36\r\nPrize: X=1612, Y=2328\r\n\r\nButton A: X+28, Y+11\r\nButton B: X+20, Y+45\r\nPrize: X=3100, Y=1755\r\n\r\nButton A: X+11, Y+36\r\nButton B: X+40, Y+21\r\nPrize: X=2630, Y=7616\r\n\r\nButton A: X+46, Y+12\r\nButton B: X+36, Y+59\r\nPrize: X=11292, Y=8388\r\n\r\nButton A: X+69, Y+19\r\nButton B: X+14, Y+49\r\nPrize: X=18362, Y=2812\r\n\r\nButton A: X+15, Y+95\r\nButton B: X+77, Y+47\r\nPrize: X=5794, Y=9374\r\n\r\nButton A: X+27, Y+87\r\nButton B: X+64, Y+18\r\nPrize: X=6444, Y=2130\r\n\r\nButton A: X+20, Y+67\r\nButton B: X+75, Y+56\r\nPrize: X=6795, Y=6167\r\n\r\nButton A: X+86, Y+61\r\nButton B: X+29, Y+82\r\nPrize: X=5464, Y=7070\r\n\r\nButton A: X+13, Y+79\r\nButton B: X+84, Y+13\r\nPrize: X=4021, Y=7957\r\n\r\nButton A: X+73, Y+13\r\nButton B: X+14, Y+77\r\nPrize: X=15266, Y=4754\r\n\r\nButton A: X+23, Y+98\r\nButton B: X+53, Y+23\r\nPrize: X=4336, Y=3466\r\n\r\nButton A: X+35, Y+13\r\nButton B: X+14, Y+63\r\nPrize: X=1925, Y=2738\r\n\r\nButton A: X+47, Y+14\r\nButton B: X+35, Y+72\r\nPrize: X=4048, Y=1320\r\n\r\nButton A: X+18, Y+61\r\nButton B: X+62, Y+28\r\nPrize: X=15782, Y=14681\r\n\r\nButton A: X+38, Y+13\r\nButton B: X+48, Y+79\r\nPrize: X=4736, Y=466\r\n\r\nButton A: X+23, Y+54\r\nButton B: X+71, Y+17\r\nPrize: X=7751, Y=4426\r\n\r\nButton A: X+90, Y+69\r\nButton B: X+39, Y+96\r\nPrize: X=8697, Y=9510\r\n\r\nButton A: X+63, Y+14\r\nButton B: X+22, Y+79\r\nPrize: X=10219, Y=6504\r\n\r\nButton A: X+45, Y+23\r\nButton B: X+12, Y+46\r\nPrize: X=2003, Y=1135\r\n\r\nButton A: X+54, Y+15\r\nButton B: X+27, Y+78\r\nPrize: X=17567, Y=14516\r\n\r\nButton A: X+34, Y+21\r\nButton B: X+11, Y+23\r\nPrize: X=12471, Y=5696\r\n\r\nButton A: X+67, Y+42\r\nButton B: X+37, Y+96\r\nPrize: X=7696, Y=10212\r\n\r\nButton A: X+28, Y+74\r\nButton B: X+36, Y+12\r\nPrize: X=396, Y=13702\r\n\r\nButton A: X+86, Y+48\r\nButton B: X+27, Y+49\r\nPrize: X=1407, Y=1905\r\n\r\nButton A: X+17, Y+36\r\nButton B: X+61, Y+37\r\nPrize: X=12574, Y=14609\r\n\r\nButton A: X+16, Y+28\r\nButton B: X+47, Y+27\r\nPrize: X=4372, Y=16648\r\n\r\nButton A: X+14, Y+40\r\nButton B: X+49, Y+41\r\nPrize: X=1771, Y=2981\r\n\r\nButton A: X+69, Y+17\r\nButton B: X+34, Y+73\r\nPrize: X=4756, Y=6277\r\n\r\nButton A: X+75, Y+93\r\nButton B: X+56, Y+13\r\nPrize: X=2786, Y=1705\r\n\r\nButton A: X+69, Y+30\r\nButton B: X+17, Y+70\r\nPrize: X=5156, Y=2680\r\n\r\nButton A: X+91, Y+92\r\nButton B: X+13, Y+64\r\nPrize: X=6734, Y=10012\r\n\r\nButton A: X+11, Y+37\r\nButton B: X+21, Y+11\r\nPrize: X=18964, Y=12956\r\n\r\nButton A: X+14, Y+35\r\nButton B: X+31, Y+23\r\nPrize: X=5314, Y=5119\r\n\r\nButton A: X+32, Y+13\r\nButton B: X+63, Y+83\r\nPrize: X=19490, Y=10380\r\n\r\nButton A: X+32, Y+62\r\nButton B: X+47, Y+20\r\nPrize: X=1260, Y=14382\r\n\r\nButton A: X+82, Y+22\r\nButton B: X+42, Y+65\r\nPrize: X=8018, Y=3387\r\n\r\nButton A: X+69, Y+42\r\nButton B: X+28, Y+55\r\nPrize: X=17829, Y=12213\r\n\r\nButton A: X+93, Y+48\r\nButton B: X+16, Y+57\r\nPrize: X=1715, Y=1860\r\n\r\nButton A: X+95, Y+24\r\nButton B: X+26, Y+97\r\nPrize: X=5246, Y=5033\r\n\r\nButton A: X+26, Y+71\r\nButton B: X+90, Y+31\r\nPrize: X=5182, Y=4701\r\n\r\nButton A: X+32, Y+23\r\nButton B: X+37, Y+91\r\nPrize: X=3504, Y=3549\r\n\r\nButton A: X+95, Y+46\r\nButton B: X+18, Y+48\r\nPrize: X=10177, Y=7442\r\n\r\nButton A: X+12, Y+62\r\nButton B: X+63, Y+20\r\nPrize: X=13535, Y=17316\r\n\r\nButton A: X+54, Y+18\r\nButton B: X+26, Y+57\r\nPrize: X=10796, Y=3707\r\n\r\nButton A: X+12, Y+48\r\nButton B: X+60, Y+31\r\nPrize: X=19664, Y=13962\r\n\r\nButton A: X+19, Y+38\r\nButton B: X+57, Y+16\r\nPrize: X=7340, Y=522\r\n\r\nButton A: X+47, Y+17\r\nButton B: X+34, Y+54\r\nPrize: X=13547, Y=1197\r\n\r\nButton A: X+21, Y+52\r\nButton B: X+34, Y+12\r\nPrize: X=18100, Y=9276\r\n\r\nButton A: X+91, Y+34\r\nButton B: X+30, Y+63\r\nPrize: X=5106, Y=5067\r\n\r\nButton A: X+64, Y+33\r\nButton B: X+11, Y+22\r\nPrize: X=11857, Y=17799\r\n\r\nButton A: X+13, Y+74\r\nButton B: X+28, Y+28\r\nPrize: X=3295, Y=8114\r\n\r\nButton A: X+67, Y+18\r\nButton B: X+30, Y+68\r\nPrize: X=7715, Y=4770\r\n\r\nButton A: X+85, Y+50\r\nButton B: X+22, Y+88\r\nPrize: X=9023, Y=10862\r\n\r\nButton A: X+18, Y+43\r\nButton B: X+70, Y+39\r\nPrize: X=18570, Y=7377\r\n\r\nButton A: X+17, Y+33\r\nButton B: X+30, Y+17\r\nPrize: X=4714, Y=3421\r\n\r\nButton A: X+14, Y+67\r\nButton B: X+72, Y+12\r\nPrize: X=808, Y=2628\r\n\r\nButton A: X+78, Y+15\r\nButton B: X+39, Y+65\r\nPrize: X=7020, Y=4685\r\n\r\nButton A: X+17, Y+46\r\nButton B: X+95, Y+57\r\nPrize: X=2389, Y=1863\r\n\r\nButton A: X+28, Y+97\r\nButton B: X+65, Y+47\r\nPrize: X=2192, Y=1892\r\n\r\nButton A: X+41, Y+71\r\nButton B: X+56, Y+17\r\nPrize: X=4078, Y=6742\r\n\r\nButton A: X+16, Y+40\r\nButton B: X+69, Y+25\r\nPrize: X=12681, Y=15365\r\n\r\nButton A: X+33, Y+55\r\nButton B: X+78, Y+38\r\nPrize: X=4260, Y=5812\r\n\r\nButton A: X+12, Y+45\r\nButton B: X+46, Y+14\r\nPrize: X=8392, Y=18642\r\n\r\nButton A: X+33, Y+14\r\nButton B: X+18, Y+27\r\nPrize: X=12749, Y=17332\r\n\r\nButton A: X+14, Y+65\r\nButton B: X+27, Y+24\r\nPrize: X=2596, Y=2728\r\n\r\nButton A: X+32, Y+62\r\nButton B: X+39, Y+14\r\nPrize: X=16653, Y=17268\r\n\r\nButton A: X+12, Y+40\r\nButton B: X+57, Y+37\r\nPrize: X=4217, Y=16825\r\n\r\nButton A: X+67, Y+44\r\nButton B: X+19, Y+46\r\nPrize: X=4645, Y=4748\r\n\r\nButton A: X+73, Y+89\r\nButton B: X+77, Y+21\r\nPrize: X=7505, Y=6745\r\n\r\nButton A: X+26, Y+13\r\nButton B: X+18, Y+44\r\nPrize: X=15034, Y=13357\r\n\r\nButton A: X+45, Y+61\r\nButton B: X+36, Y+12\r\nPrize: X=3492, Y=2084\r\n\r\nButton A: X+26, Y+52\r\nButton B: X+45, Y+14\r\nPrize: X=7208, Y=18704\r\n\r\nButton A: X+18, Y+41\r\nButton B: X+61, Y+15\r\nPrize: X=19617, Y=16443\r\n\r\nButton A: X+27, Y+55\r\nButton B: X+81, Y+15\r\nPrize: X=4455, Y=5475\r\n\r\nButton A: X+37, Y+60\r\nButton B: X+87, Y+13\r\nPrize: X=8407, Y=2618\r\n\r\nButton A: X+45, Y+12\r\nButton B: X+17, Y+71\r\nPrize: X=7194, Y=1125\r\n\r\nButton A: X+46, Y+17\r\nButton B: X+40, Y+70\r\nPrize: X=17324, Y=9138\r\n\r\nButton A: X+28, Y+50\r\nButton B: X+45, Y+25\r\nPrize: X=14211, Y=17625\r\n\r\nButton A: X+12, Y+70\r\nButton B: X+44, Y+33\r\nPrize: X=400, Y=1215\r\n\r\nButton A: X+86, Y+30\r\nButton B: X+78, Y+96\r\nPrize: X=5384, Y=2910\r\n\r\nButton A: X+21, Y+55\r\nButton B: X+48, Y+18\r\nPrize: X=2762, Y=6834\r\n\r\nButton A: X+20, Y+49\r\nButton B: X+68, Y+40\r\nPrize: X=16676, Y=13367\r\n\r\nButton A: X+43, Y+24\r\nButton B: X+21, Y+44\r\nPrize: X=18622, Y=3868\r\n\r\nButton A: X+64, Y+21\r\nButton B: X+26, Y+65\r\nPrize: X=1886, Y=7182\r\n\r\nButton A: X+92, Y+23\r\nButton B: X+17, Y+67\r\nPrize: X=6073, Y=5597\r\n\r\nButton A: X+14, Y+32\r\nButton B: X+23, Y+15\r\nPrize: X=14831, Y=9287\r\n\r\nButton A: X+86, Y+57\r\nButton B: X+14, Y+88\r\nPrize: X=7798, Y=8396\r\n\r\nButton A: X+71, Y+17\r\nButton B: X+22, Y+70\r\nPrize: X=5732, Y=6884\r\n\r\nButton A: X+11, Y+69\r\nButton B: X+87, Y+30\r\nPrize: X=9216, Y=13820\r\n\r\nButton A: X+25, Y+68\r\nButton B: X+71, Y+26\r\nPrize: X=8245, Y=18040\r\n\r\nButton A: X+52, Y+35\r\nButton B: X+15, Y+69\r\nPrize: X=2729, Y=2956\r\n\r\nButton A: X+81, Y+43\r\nButton B: X+16, Y+50\r\nPrize: X=4247, Y=7489\r\n\r\nButton A: X+15, Y+32\r\nButton B: X+43, Y+15\r\nPrize: X=18075, Y=2014\r\n\r\nButton A: X+45, Y+73\r\nButton B: X+53, Y+25\r\nPrize: X=5131, Y=7287\r\n\r\nButton A: X+95, Y+35\r\nButton B: X+14, Y+25\r\nPrize: X=6311, Y=3595\r\n\r\nButton A: X+24, Y+72\r\nButton B: X+65, Y+22\r\nPrize: X=2510, Y=14828\r\n\r\nButton A: X+12, Y+89\r\nButton B: X+80, Y+33\r\nPrize: X=6464, Y=7037\r\n\r\nButton A: X+11, Y+21\r\nButton B: X+53, Y+29\r\nPrize: X=14589, Y=11385\r\n\r\nButton A: X+51, Y+75\r\nButton B: X+37, Y+15\r\nPrize: X=17832, Y=3350\r\n\r\nButton A: X+58, Y+34\r\nButton B: X+13, Y+33\r\nPrize: X=15315, Y=7103\r\n\r\nButton A: X+58, Y+74\r\nButton B: X+79, Y+23\r\nPrize: X=8036, Y=6052\r\n\r\nButton A: X+91, Y+48\r\nButton B: X+11, Y+43\r\nPrize: X=2094, Y=3262\r\n\r\nButton A: X+35, Y+19\r\nButton B: X+16, Y+41\r\nPrize: X=10599, Y=14620\r\n\r\nButton A: X+30, Y+12\r\nButton B: X+41, Y+54\r\nPrize: X=13205, Y=13550\r\n\r\nButton A: X+18, Y+34\r\nButton B: X+46, Y+18\r\nPrize: X=478, Y=5554\r\n\r\nButton A: X+55, Y+19\r\nButton B: X+13, Y+50\r\nPrize: X=15778, Y=13621\r\n\r\nButton A: X+42, Y+14\r\nButton B: X+13, Y+35\r\nPrize: X=4802, Y=12646\r\n\r\nButton A: X+19, Y+95\r\nButton B: X+97, Y+56\r\nPrize: X=4759, Y=9638\r\n\r\nButton A: X+13, Y+68\r\nButton B: X+74, Y+73\r\nPrize: X=1371, Y=5601\r\n\r\nButton A: X+24, Y+65\r\nButton B: X+83, Y+12\r\nPrize: X=7732, Y=1364\r\n\r\nButton A: X+20, Y+34\r\nButton B: X+46, Y+14\r\nPrize: X=2532, Y=16552\r\n\r\nButton A: X+62, Y+20\r\nButton B: X+12, Y+60\r\nPrize: X=6086, Y=19340\r\n\r\nButton A: X+62, Y+98\r\nButton B: X+55, Y+20\r\nPrize: X=3900, Y=2550\r\n\r\nButton A: X+22, Y+45\r\nButton B: X+59, Y+33\r\nPrize: X=18781, Y=5858\r\n\r\nButton A: X+60, Y+29\r\nButton B: X+12, Y+45\r\nPrize: X=18440, Y=19558\r\n\r\nButton A: X+50, Y+19\r\nButton B: X+22, Y+39\r\nPrize: X=19748, Y=2366\r\n\r\nButton A: X+13, Y+74\r\nButton B: X+42, Y+50\r\nPrize: X=3997, Y=10084\r\n\r\nButton A: X+61, Y+17\r\nButton B: X+12, Y+62\r\nPrize: X=7708, Y=12832\r\n\r\nButton A: X+11, Y+31\r\nButton B: X+66, Y+14\r\nPrize: X=3048, Y=18244\r\n\r\nButton A: X+55, Y+16\r\nButton B: X+22, Y+49\r\nPrize: X=16336, Y=8296\r\n\r\nButton A: X+46, Y+12\r\nButton B: X+31, Y+64\r\nPrize: X=2535, Y=6632\r\n\r\nButton A: X+53, Y+25\r\nButton B: X+13, Y+21\r\nPrize: X=3569, Y=15621\r\n\r\nButton A: X+18, Y+59\r\nButton B: X+63, Y+17\r\nPrize: X=3770, Y=11192\r\n\r\nButton A: X+46, Y+12\r\nButton B: X+19, Y+37\r\nPrize: X=6196, Y=19736\r\n\r\nButton A: X+19, Y+73\r\nButton B: X+38, Y+25\r\nPrize: X=4199, Y=8026\r\n\r\nButton A: X+72, Y+60\r\nButton B: X+20, Y+87\r\nPrize: X=5724, Y=5403\r\n\r\nButton A: X+39, Y+11\r\nButton B: X+38, Y+72\r\nPrize: X=18434, Y=206\r\n\r\nButton A: X+20, Y+72\r\nButton B: X+70, Y+23\r\nPrize: X=7310, Y=7293\r\n\r\nButton A: X+41, Y+67\r\nButton B: X+50, Y+27\r\nPrize: X=422, Y=8325\r\n\r\nButton A: X+30, Y+80\r\nButton B: X+66, Y+14\r\nPrize: X=776, Y=5344\r\n\r\nButton A: X+11, Y+29\r\nButton B: X+63, Y+22\r\nPrize: X=15012, Y=17058\r\n\r\nButton A: X+13, Y+44\r\nButton B: X+85, Y+51\r\nPrize: X=17219, Y=6673\r\n\r\nButton A: X+25, Y+59\r\nButton B: X+39, Y+11\r\nPrize: X=17976, Y=15604\r\n\r\nButton A: X+59, Y+30\r\nButton B: X+22, Y+45\r\nPrize: X=8281, Y=6635\r\n\r\nButton A: X+38, Y+50\r\nButton B: X+85, Y+22\r\nPrize: X=4507, Y=1528\r\n\r\nButton A: X+13, Y+12\r\nButton B: X+16, Y+52\r\nPrize: X=2514, Y=5448\r\n\r\nButton A: X+52, Y+14\r\nButton B: X+15, Y+68\r\nPrize: X=5714, Y=7004\r\n\r\nButton A: X+41, Y+21\r\nButton B: X+26, Y+56\r\nPrize: X=17732, Y=13192\r\n\r\nButton A: X+72, Y+40\r\nButton B: X+22, Y+48\r\nPrize: X=18704, Y=8800\r\n\r\nButton A: X+80, Y+86\r\nButton B: X+81, Y+13\r\nPrize: X=11929, Y=6231\r\n\r\nButton A: X+72, Y+16\r\nButton B: X+21, Y+79\r\nPrize: X=14828, Y=5092\r\n\r\nButton A: X+62, Y+24\r\nButton B: X+28, Y+71\r\nPrize: X=9482, Y=4259\r\n\r\nButton A: X+31, Y+14\r\nButton B: X+14, Y+54\r\nPrize: X=914, Y=1338\r\n\r\nButton A: X+39, Y+17\r\nButton B: X+11, Y+50\r\nPrize: X=2698, Y=13446\r\n\r\nButton A: X+75, Y+39\r\nButton B: X+21, Y+74\r\nPrize: X=6363, Y=6652\r\n\r\nButton A: X+15, Y+81\r\nButton B: X+82, Y+51\r\nPrize: X=4348, Y=4281\r\n\r\nButton A: X+61, Y+24\r\nButton B: X+34, Y+75\r\nPrize: X=5283, Y=7563\r\n\r\nButton A: X+72, Y+33\r\nButton B: X+11, Y+39\r\nPrize: X=17203, Y=9617\r\n\r\nButton A: X+21, Y+52\r\nButton B: X+77, Y+44\r\nPrize: X=4540, Y=10560\r\n\r\nButton A: X+30, Y+14\r\nButton B: X+13, Y+41\r\nPrize: X=14049, Y=16261\r\n\r\nButton A: X+21, Y+41\r\nButton B: X+34, Y+17\r\nPrize: X=9712, Y=5542\r\n\r\nButton A: X+56, Y+87\r\nButton B: X+81, Y+15\r\nPrize: X=5004, Y=6444\r\n\r\nButton A: X+12, Y+66\r\nButton B: X+88, Y+13\r\nPrize: X=1260, Y=1278\r\n\r\nButton A: X+28, Y+62\r\nButton B: X+67, Y+28\r\nPrize: X=3746, Y=19504\r\n\r\nButton A: X+15, Y+61\r\nButton B: X+82, Y+29\r\nPrize: X=16461, Y=12602\r\n\r\nButton A: X+22, Y+59\r\nButton B: X+74, Y+33\r\nPrize: X=5892, Y=19334\r\n\r\nButton A: X+20, Y+47\r\nButton B: X+64, Y+41\r\nPrize: X=4156, Y=11048\r\n\r\nButton A: X+61, Y+37\r\nButton B: X+42, Y+84\r\nPrize: X=7381, Y=8047\r\n\r\nButton A: X+59, Y+11\r\nButton B: X+20, Y+42\r\nPrize: X=1850, Y=2756\r\n\r\nButton A: X+69, Y+25\r\nButton B: X+26, Y+73\r\nPrize: X=4751, Y=19072\r\n\r\nButton A: X+61, Y+21\r\nButton B: X+18, Y+58\r\nPrize: X=16458, Y=8618\r\n\r\nButton A: X+88, Y+39\r\nButton B: X+35, Y+66\r\nPrize: X=6246, Y=7716\r\n\r\nButton A: X+81, Y+20\r\nButton B: X+21, Y+67\r\nPrize: X=8802, Y=8293\r\n\r\nButton A: X+75, Y+89\r\nButton B: X+52, Y+12\r\nPrize: X=4336, Y=3008\r\n\r\nButton A: X+55, Y+18\r\nButton B: X+13, Y+36\r\nPrize: X=19484, Y=19592\r\n\r\nButton A: X+62, Y+35\r\nButton B: X+24, Y+45\r\nPrize: X=18008, Y=14615\r\n\r\nButton A: X+56, Y+30\r\nButton B: X+28, Y+48\r\nPrize: X=6720, Y=5580\r\n\r\nButton A: X+22, Y+53\r\nButton B: X+41, Y+15\r\nPrize: X=15194, Y=10016\r\n\r\nButton A: X+19, Y+52\r\nButton B: X+64, Y+25\r\nPrize: X=14612, Y=4460\r\n\r\nButton A: X+23, Y+11\r\nButton B: X+33, Y+57\r\nPrize: X=6641, Y=18797\r\n\r\nButton A: X+31, Y+68\r\nButton B: X+59, Y+15\r\nPrize: X=15183, Y=2170\r\n\r\nButton A: X+12, Y+32\r\nButton B: X+42, Y+29\r\nPrize: X=3366, Y=2917\r\n\r\nButton A: X+12, Y+34\r\nButton B: X+44, Y+14\r\nPrize: X=15992, Y=2860\r\n\r\nButton A: X+46, Y+93\r\nButton B: X+97, Y+23\r\nPrize: X=4212, Y=1245\r\n\r\nButton A: X+27, Y+17\r\nButton B: X+17, Y+45\r\nPrize: X=11411, Y=15891\r\n\r\nButton A: X+55, Y+20\r\nButton B: X+34, Y+71\r\nPrize: X=9870, Y=12505\r\n\r\nButton A: X+15, Y+39\r\nButton B: X+66, Y+41\r\nPrize: X=746, Y=7263\r\n\r\nButton A: X+95, Y+51\r\nButton B: X+21, Y+99\r\nPrize: X=8616, Y=10854\r\n\r\nButton A: X+95, Y+16\r\nButton B: X+70, Y+67\r\nPrize: X=2690, Y=1226\r\n\r\nButton A: X+14, Y+24\r\nButton B: X+94, Y+40\r\nPrize: X=9464, Y=4352\r\n\r\nButton A: X+33, Y+80\r\nButton B: X+58, Y+15\r\nPrize: X=19115, Y=18265\r\n\r\nButton A: X+72, Y+35\r\nButton B: X+11, Y+54\r\nPrize: X=12332, Y=6651\r\n\r\nButton A: X+25, Y+35\r\nButton B: X+39, Y+14\r\nPrize: X=3671, Y=1526\r\n\r\nButton A: X+12, Y+73\r\nButton B: X+98, Y+84\r\nPrize: X=8958, Y=13009\r\n\r\nButton A: X+95, Y+27\r\nButton B: X+38, Y+55\r\nPrize: X=4085, Y=4918\r\n\r\nButton A: X+33, Y+11\r\nButton B: X+14, Y+53\r\nPrize: X=9819, Y=2318\r\n\r\nButton A: X+88, Y+37\r\nButton B: X+53, Y+97\r\nPrize: X=3860, Y=3715\r\n\r\nButton A: X+72, Y+26\r\nButton B: X+48, Y+57\r\nPrize: X=2448, Y=1003\r\n\r\nButton A: X+46, Y+28\r\nButton B: X+18, Y+41\r\nPrize: X=11938, Y=17046\r\n\r\nButton A: X+12, Y+48\r\nButton B: X+74, Y+43\r\nPrize: X=19634, Y=15239\r\n\r\nButton A: X+95, Y+39\r\nButton B: X+46, Y+95\r\nPrize: X=10094, Y=10157\r\n\r\nButton A: X+82, Y+34\r\nButton B: X+31, Y+81\r\nPrize: X=8143, Y=7397\r\n\r\nButton A: X+46, Y+14\r\nButton B: X+31, Y+56\r\nPrize: X=15179, Y=3476\r\n\r\nButton A: X+92, Y+13\r\nButton B: X+34, Y+56\r\nPrize: X=9082, Y=2768\r\n\r\nButton A: X+41, Y+11\r\nButton B: X+62, Y+70\r\nPrize: X=804, Y=696\r\n\r\nButton A: X+90, Y+15\r\nButton B: X+59, Y+64\r\nPrize: X=4870, Y=1895\r\n\r\nButton A: X+43, Y+11\r\nButton B: X+27, Y+62\r\nPrize: X=11720, Y=8400\r\n\r\nButton A: X+64, Y+27\r\nButton B: X+24, Y+44\r\nPrize: X=5416, Y=2793\r\n\r\nButton A: X+53, Y+94\r\nButton B: X+51, Y+17\r\nPrize: X=6155, Y=5334\r\n\r\nButton A: X+30, Y+11\r\nButton B: X+23, Y+60\r\nPrize: X=2222, Y=1409\r\n\r\nButton A: X+11, Y+57\r\nButton B: X+49, Y+21\r\nPrize: X=5062, Y=13550\r\n\r\nButton A: X+33, Y+13\r\nButton B: X+57, Y+79\r\nPrize: X=4685, Y=14057\r\n\r\nButton A: X+13, Y+62\r\nButton B: X+72, Y+12\r\nPrize: X=2422, Y=4592\r\n\r\nButton A: X+21, Y+53\r\nButton B: X+59, Y+33\r\nPrize: X=4967, Y=10057\r\n\r\nButton A: X+69, Y+40\r\nButton B: X+28, Y+57\r\nPrize: X=17253, Y=11830\r\n\r\nButton A: X+25, Y+55\r\nButton B: X+71, Y+48\r\nPrize: X=7715, Y=7235\r\n\r\nButton A: X+45, Y+25\r\nButton B: X+14, Y+41\r\nPrize: X=1391, Y=4924\r\n\r\nButton A: X+51, Y+11\r\nButton B: X+14, Y+32\r\nPrize: X=14436, Y=9800\r\n\r\nButton A: X+65, Y+18\r\nButton B: X+21, Y+91\r\nPrize: X=3911, Y=2446\r\n\r\nButton A: X+53, Y+57\r\nButton B: X+79, Y+23\r\nPrize: X=2831, Y=2487\r\n\r\nButton A: X+38, Y+65\r\nButton B: X+55, Y+26\r\nPrize: X=17193, Y=7231\r\n\r\nButton A: X+36, Y+25\r\nButton B: X+14, Y+68\r\nPrize: X=2662, Y=7385\r\n\r\nButton A: X+51, Y+22\r\nButton B: X+19, Y+64\r\nPrize: X=11978, Y=2798\r\n\r\nButton A: X+31, Y+55\r\nButton B: X+40, Y+17\r\nPrize: X=12598, Y=2078\r\n\r\nButton A: X+16, Y+36\r\nButton B: X+50, Y+15\r\nPrize: X=2258, Y=1863\r\n\r\nButton A: X+22, Y+90\r\nButton B: X+81, Y+59\r\nPrize: X=6274, Y=10414\r\n\r\nButton A: X+58, Y+14\r\nButton B: X+35, Y+80\r\nPrize: X=4605, Y=19390\r\n\r\nButton A: X+24, Y+15\r\nButton B: X+20, Y+93\r\nPrize: X=2448, Y=6360\r\n\r\nButton A: X+44, Y+24\r\nButton B: X+18, Y+39\r\nPrize: X=7128, Y=5540\r\n\r\nButton A: X+81, Y+67\r\nButton B: X+90, Y+11\r\nPrize: X=7074, Y=1093\r\n\r\nButton A: X+51, Y+16\r\nButton B: X+12, Y+33\r\nPrize: X=12497, Y=10950\r\n\r\nButton A: X+89, Y+41\r\nButton B: X+47, Y+95\r\nPrize: X=4463, Y=3743\r\n\r\nButton A: X+20, Y+45\r\nButton B: X+26, Y+12\r\nPrize: X=4302, Y=8474\r\n\r\nButton A: X+22, Y+88\r\nButton B: X+89, Y+75\r\nPrize: X=6544, Y=11002\r\n\r\nButton A: X+30, Y+68\r\nButton B: X+57, Y+26\r\nPrize: X=5678, Y=18428\r\n\r\nButton A: X+24, Y+70\r\nButton B: X+75, Y+28\r\nPrize: X=18920, Y=19352\r\n\r\nButton A: X+69, Y+20\r\nButton B: X+14, Y+65\r\nPrize: X=19613, Y=12505\r\n\r\nButton A: X+50, Y+70\r\nButton B: X+58, Y+12\r\nPrize: X=8362, Y=7278\r\n\r\nButton A: X+87, Y+58\r\nButton B: X+11, Y+85\r\nPrize: X=2258, Y=5777\r\n\r\nButton A: X+71, Y+34\r\nButton B: X+11, Y+65\r\nPrize: X=1511, Y=3531\r\n\r\nButton A: X+63, Y+23\r\nButton B: X+31, Y+49\r\nPrize: X=4884, Y=4044\r\n\r\nButton A: X+49, Y+21\r\nButton B: X+22, Y+51\r\nPrize: X=4789, Y=2676\r\n\r\nButton A: X+21, Y+71\r\nButton B: X+49, Y+16\r\nPrize: X=17154, Y=7804\r\n\r\nButton A: X+37, Y+11\r\nButton B: X+49, Y+72\r\nPrize: X=13066, Y=14023\r\n\r\nButton A: X+90, Y+36\r\nButton B: X+53, Y+86\r\nPrize: X=6524, Y=4424\r\n\r\nButton A: X+71, Y+13\r\nButton B: X+17, Y+62\r\nPrize: X=5108, Y=12592\r\n\r\nButton A: X+16, Y+50\r\nButton B: X+50, Y+24\r\nPrize: X=10032, Y=7620\r\n\r\nButton A: X+55, Y+11\r\nButton B: X+13, Y+70\r\nPrize: X=6658, Y=10983\r\n\r\nButton A: X+14, Y+36\r\nButton B: X+55, Y+31\r\nPrize: X=15540, Y=1556\r\n\r\nButton A: X+34, Y+54\r\nButton B: X+27, Y+13\r\nPrize: X=12112, Y=8144\r\n\r\nButton A: X+68, Y+63\r\nButton B: X+77, Y+16\r\nPrize: X=9005, Y=6074\r\n\r\nButton A: X+52, Y+99\r\nButton B: X+59, Y+22\r\nPrize: X=4621, Y=4191\r\n\r\nButton A: X+57, Y+23\r\nButton B: X+27, Y+61\r\nPrize: X=13373, Y=1507\r\n\r\nButton A: X+39, Y+56\r\nButton B: X+40, Y+14\r\nPrize: X=15692, Y=11946\r\n\r\nButton A: X+50, Y+21\r\nButton B: X+17, Y+35\r\nPrize: X=4466, Y=13717\r\n\r\nButton A: X+12, Y+37\r\nButton B: X+54, Y+16\r\nPrize: X=8066, Y=12508\r\n\r\nButton A: X+54, Y+22\r\nButton B: X+14, Y+28\r\nPrize: X=1552, Y=7098\r\n\r\nButton A: X+24, Y+57\r\nButton B: X+66, Y+32\r\nPrize: X=4994, Y=12455\r\n\r\nButton A: X+39, Y+73\r\nButton B: X+49, Y+28\r\nPrize: X=4940, Y=5105\r\n\r\nButton A: X+63, Y+25\r\nButton B: X+26, Y+42\r\nPrize: X=2819, Y=2481\r\n\r\nButton A: X+87, Y+50\r\nButton B: X+34, Y+79\r\nPrize: X=9327, Y=6609\r\n\r\nButton A: X+88, Y+78\r\nButton B: X+12, Y+40\r\nPrize: X=4948, Y=4650\r\n\r\nButton A: X+78, Y+46\r\nButton B: X+14, Y+36\r\nPrize: X=16096, Y=12012\r\n\r\nButton A: X+75, Y+14\r\nButton B: X+22, Y+94\r\nPrize: X=6985, Y=6248\r\n\r\nButton A: X+29, Y+57\r\nButton B: X+33, Y+12\r\nPrize: X=434, Y=483\r\n\r\nButton A: X+60, Y+47\r\nButton B: X+13, Y+77\r\nPrize: X=3763, Y=5019\r\n\r\nButton A: X+42, Y+14\r\nButton B: X+51, Y+85\r\nPrize: X=5490, Y=7134\r\n\r\nButton A: X+74, Y+48\r\nButton B: X+16, Y+38\r\nPrize: X=10264, Y=2080\r\n\r\nButton A: X+42, Y+24\r\nButton B: X+13, Y+61\r\nPrize: X=1834, Y=4798\r\n\r\nButton A: X+47, Y+82\r\nButton B: X+50, Y+15\r\nPrize: X=14653, Y=17558\r\n\r\nButton A: X+74, Y+21\r\nButton B: X+17, Y+95\r\nPrize: X=7122, Y=7612\r\n\r\nButton A: X+18, Y+56\r\nButton B: X+89, Y+29\r\nPrize: X=7328, Y=5446\r\n\r\nButton A: X+36, Y+73\r\nButton B: X+57, Y+21\r\nPrize: X=1925, Y=3535\r\n\r\nButton A: X+53, Y+36\r\nButton B: X+13, Y+34\r\nPrize: X=9614, Y=6604\r\n\r\nButton A: X+30, Y+23\r\nButton B: X+22, Y+98\r\nPrize: X=3616, Y=6261\r\n\r\nButton A: X+37, Y+79\r\nButton B: X+87, Y+29\r\nPrize: X=1412, Y=1604\r\n\r\nButton A: X+37, Y+25\r\nButton B: X+14, Y+34\r\nPrize: X=728, Y=13612\r\n\r\nButton A: X+21, Y+51\r\nButton B: X+58, Y+25\r\nPrize: X=8630, Y=5411\r\n\r\nButton A: X+71, Y+80\r\nButton B: X+12, Y+85\r\nPrize: X=3871, Y=5005\r\n\r\nButton A: X+82, Y+37\r\nButton B: X+51, Y+84\r\nPrize: X=7154, Y=8351\r\n\r\nButton A: X+62, Y+42\r\nButton B: X+31, Y+66\r\nPrize: X=2976, Y=4626\r\n\r\nButton A: X+54, Y+22\r\nButton B: X+27, Y+62\r\nPrize: X=13463, Y=9180\r\n\r\nButton A: X+12, Y+50\r\nButton B: X+50, Y+12\r\nPrize: X=5058, Y=13152\r\n\r\nButton A: X+18, Y+52\r\nButton B: X+77, Y+29\r\nPrize: X=3147, Y=5029\r\n\r\nButton A: X+21, Y+86\r\nButton B: X+95, Y+66\r\nPrize: X=3578, Y=2700\r\n\r\nButton A: X+34, Y+78\r\nButton B: X+26, Y+14\r\nPrize: X=3866, Y=5902\r\n\r\nButton A: X+45, Y+28\r\nButton B: X+14, Y+42\r\nPrize: X=5409, Y=2902\r\n\r\nButton A: X+60, Y+29\r\nButton B: X+35, Y+66\r\nPrize: X=19625, Y=11658\r\n\r\nButton A: X+14, Y+49\r\nButton B: X+79, Y+38\r\nPrize: X=3957, Y=8128\r\n\r\nButton A: X+44, Y+12\r\nButton B: X+15, Y+77\r\nPrize: X=2978, Y=4166\r\n\r\nButton A: X+15, Y+36\r\nButton B: X+42, Y+13\r\nPrize: X=1040, Y=7437\r\n\r\nButton A: X+41, Y+30\r\nButton B: X+11, Y+65\r\nPrize: X=1311, Y=4775\r\n\r\nButton A: X+56, Y+19\r\nButton B: X+28, Y+62\r\nPrize: X=12940, Y=10005\r\n\r\nButton A: X+12, Y+38\r\nButton B: X+63, Y+41\r\nPrize: X=17435, Y=15109\r\n\r\nButton A: X+18, Y+86\r\nButton B: X+83, Y+25\r\nPrize: X=8962, Y=6406\r\n\r\nButton A: X+42, Y+18\r\nButton B: X+19, Y+52\r\nPrize: X=3636, Y=7386\r\n\r\nButton A: X+31, Y+22\r\nButton B: X+40, Y+97\r\nPrize: X=1803, Y=1554\r\n\r\nButton A: X+33, Y+43\r\nButton B: X+83, Y+28\r\nPrize: X=4286, Y=3581\r\n\r\nButton A: X+37, Y+50\r\nButton B: X+98, Y+19\r\nPrize: X=4671, Y=1548\r\n\r\nButton A: X+54, Y+27\r\nButton B: X+12, Y+95\r\nPrize: X=6096, Y=9812\r\n\r\nButton A: X+24, Y+80\r\nButton B: X+31, Y+16\r\nPrize: X=1359, Y=1648\r\n\r\nButton A: X+41, Y+11\r\nButton B: X+35, Y+73\r\nPrize: X=617, Y=13611\r\n\r\nButton A: X+22, Y+46\r\nButton B: X+72, Y+49\r\nPrize: X=10986, Y=636\r\n\r\nButton A: X+55, Y+14\r\nButton B: X+15, Y+41\r\nPrize: X=10895, Y=4037\r\n\r\nButton A: X+28, Y+28\r\nButton B: X+66, Y+13\r\nPrize: X=6920, Y=2892\r\n\r\nButton A: X+45, Y+13\r\nButton B: X+16, Y+51\r\nPrize: X=1883, Y=915";
            return Parse(data);
        }
        public static IEnumerable<Entry> GetTrainingData()
        {
            var data = "Button A: X+94, Y+34\r\nButton B: X+22, Y+67\r\nPrize: X=8400, Y=5400\r\nButton A: X+26, Y+66\r\nButton B: X+67, Y+21\r\nPrize: X=12748, Y=12176\r\nButton A: X+17, Y+86\r\nButton B: X+84, Y+37\r\nPrize: X=7870, Y=6450\r\nButton A: X+69, Y+23\r\nButton B: X+27, Y+71\r\nPrize: X=18641, Y=10279";
            return Parse(data);
        }
    }
}
