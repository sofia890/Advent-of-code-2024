﻿using AdventLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14___Restroom_Redoubt
{
    public class Position(long x, long y)
    {
        public long X
        {
            get;
            set;
        } = x;
        public long Y
        {
            get;
            set;
        } = y;
    }
    public record Velocity(long x, long y);
    public class Robot(Position position, Velocity velocity)
    {
        public Position Position
        {
            get;
            set;
        } = position;
        public Robot Update(long steps, long width, long height)
        {
            Position.X = (Position.X + steps * (velocity.x + width)) % width;
            Position.Y = (Position.Y + steps * (velocity.y + height)) % height;

            return this;
        }
    }
    internal class Input
    {
        static IEnumerable<Robot> Parse(string data)
        {
            var lines = data.Split("\r\n");

            var robots = new List<Robot>();

            foreach (var line in lines)
            {
                var components = line.Split(' ');
                var position = Parser.ToIntegerArray<long>(components[0][2..], 0, ",");
                var velocity = Parser.ToIntegerArray<long>(components[1][2..], 0, ",");

                robots.Add(new Robot(new Position(position[0], position[1]),
                                     new Velocity(velocity[0], velocity[1])));
            }

            return robots;
        }
        public static (IEnumerable<Robot> robots, (int width, int height) areaSize, int steps) GetData()
        {
            var data = "p=50,78 v=89,45\r\np=65,96 v=88,-21\r\np=23,63 v=61,46\r\np=61,76 v=25,-67\r\np=23,90 v=6,91\r\np=1,47 v=-17,-9\r\np=84,56 v=-73,-24\r\np=78,66 v=-20,-76\r\np=49,59 v=-22,17\r\np=73,95 v=34,-64\r\np=99,76 v=67,-40\r\np=59,77 v=-49,-4\r\np=15,30 v=24,65\r\np=89,2 v=-19,-38\r\np=28,70 v=93,66\r\np=39,33 v=24,-42\r\np=14,42 v=-33,-49\r\np=68,85 v=-37,-47\r\np=91,0 v=-45,12\r\np=88,92 v=78,-24\r\np=19,63 v=-70,-10\r\np=69,4 v=-40,90\r\np=61,91 v=64,-11\r\np=47,95 v=-77,46\r\np=20,10 v=-23,-63\r\np=98,82 v=90,96\r\np=90,30 v=4,74\r\np=0,28 v=-73,8\r\np=88,102 v=51,-51\r\np=66,29 v=26,1\r\np=19,20 v=-61,-15\r\np=13,18 v=6,71\r\np=12,39 v=67,24\r\np=41,67 v=-24,-23\r\np=78,10 v=-59,-68\r\np=30,2 v=-35,85\r\np=86,47 v=-95,53\r\np=44,36 v=-69,-89\r\np=19,20 v=-87,-95\r\np=65,3 v=73,16\r\np=95,29 v=43,61\r\np=66,50 v=49,-69\r\np=28,92 v=-25,19\r\np=74,60 v=-6,-98\r\np=15,80 v=92,-27\r\np=80,12 v=18,-62\r\np=72,34 v=19,-65\r\np=46,75 v=33,-74\r\np=14,100 v=-79,99\r\np=94,97 v=74,49\r\np=46,13 v=-45,-61\r\np=93,39 v=-9,-64\r\np=100,45 v=45,-76\r\np=62,19 v=-76,85\r\np=18,85 v=30,-71\r\np=24,68 v=84,-73\r\np=31,20 v=-86,-35\r\np=76,46 v=-59,77\r\np=27,52 v=-95,77\r\np=52,81 v=1,59\r\np=43,60 v=-71,-38\r\np=59,38 v=-6,24\r\np=70,65 v=26,-23\r\np=11,40 v=60,-33\r\np=26,77 v=62,43\r\np=24,93 v=99,-51\r\np=46,84 v=24,76\r\np=48,30 v=58,-87\r\np=46,100 v=21,98\r\np=24,39 v=-23,84\r\np=25,6 v=47,-78\r\np=89,73 v=-73,23\r\np=4,49 v=-96,14\r\np=69,61 v=52,-10\r\np=96,68 v=-96,99\r\np=17,12 v=-30,75\r\np=91,47 v=-98,-87\r\np=50,38 v=71,67\r\np=68,58 v=-13,17\r\np=39,30 v=84,93\r\np=93,19 v=-66,98\r\np=31,7 v=-8,75\r\np=7,81 v=-95,-4\r\np=38,43 v=8,-89\r\np=24,21 v=-98,3\r\np=72,43 v=25,-13\r\np=4,98 v=-71,78\r\np=79,65 v=-91,-57\r\np=49,47 v=-97,23\r\np=37,7 v=-15,45\r\np=41,74 v=-15,36\r\np=58,30 v=-92,71\r\np=72,92 v=68,-7\r\np=1,79 v=-4,-75\r\np=82,99 v=42,6\r\np=62,51 v=57,63\r\np=10,43 v=48,-74\r\np=74,70 v=65,-40\r\np=25,35 v=-1,-39\r\np=50,71 v=37,68\r\np=51,84 v=67,55\r\np=71,25 v=-45,-98\r\np=47,14 v=-7,28\r\np=70,99 v=69,46\r\np=21,44 v=-94,-16\r\np=52,40 v=-83,-49\r\np=76,99 v=-71,63\r\np=21,92 v=-32,-34\r\np=78,27 v=-85,-55\r\np=42,92 v=-76,-61\r\np=50,29 v=95,77\r\np=72,10 v=65,58\r\np=92,48 v=20,-1\r\np=42,80 v=55,-98\r\np=69,96 v=41,62\r\np=68,35 v=-91,-45\r\np=18,56 v=-33,37\r\np=52,96 v=1,49\r\np=22,87 v=53,99\r\np=84,31 v=19,41\r\np=87,38 v=58,-13\r\np=9,13 v=-18,98\r\np=40,0 v=-94,-31\r\np=71,16 v=-62,76\r\np=41,88 v=-46,99\r\np=27,97 v=-15,-4\r\np=25,54 v=23,-36\r\np=61,0 v=-60,-21\r\np=28,75 v=41,-79\r\np=64,46 v=-8,34\r\np=97,26 v=37,74\r\np=32,67 v=-48,-93\r\np=18,81 v=53,-2\r\np=12,101 v=30,-1\r\np=80,40 v=-90,-16\r\np=48,16 v=-69,61\r\np=7,89 v=52,49\r\np=93,0 v=-35,-61\r\np=24,52 v=31,53\r\np=37,67 v=-98,36\r\np=92,77 v=28,46\r\np=76,59 v=-74,-21\r\np=96,63 v=58,57\r\np=62,2 v=-68,-68\r\np=39,20 v=-39,-25\r\np=5,12 v=60,88\r\np=75,35 v=-37,88\r\np=77,24 v=-52,-13\r\np=42,0 v=92,-72\r\np=33,61 v=-91,-6\r\np=10,74 v=23,-17\r\np=6,73 v=37,-54\r\np=76,99 v=2,-71\r\np=53,20 v=71,91\r\np=82,31 v=71,-82\r\np=20,87 v=-40,26\r\np=52,47 v=-45,-69\r\np=32,38 v=43,-55\r\np=8,85 v=-56,-77\r\np=11,0 v=68,2\r\np=40,30 v=-46,-72\r\np=26,53 v=27,-43\r\np=5,40 v=98,-90\r\np=46,4 v=39,-85\r\np=15,36 v=-95,87\r\np=0,4 v=-49,42\r\np=69,11 v=-86,-87\r\np=47,47 v=86,-17\r\np=95,88 v=-73,26\r\np=2,5 v=53,52\r\np=92,84 v=63,79\r\np=25,0 v=47,-35\r\np=83,55 v=-43,-46\r\np=95,43 v=-3,40\r\np=30,60 v=-79,-27\r\np=89,79 v=-39,-80\r\np=10,19 v=6,-95\r\np=70,64 v=87,10\r\np=51,93 v=79,-31\r\np=30,82 v=85,16\r\np=66,75 v=-51,40\r\np=79,70 v=-20,-20\r\np=59,60 v=25,63\r\np=86,17 v=75,-62\r\np=3,62 v=-18,-47\r\np=43,20 v=24,91\r\np=23,13 v=56,93\r\np=32,13 v=71,76\r\np=12,10 v=53,-28\r\np=20,86 v=-71,-74\r\np=91,90 v=-97,-75\r\np=76,66 v=-67,83\r\np=54,54 v=-84,64\r\np=66,70 v=-12,36\r\np=30,73 v=54,43\r\np=62,22 v=-21,31\r\np=11,92 v=-94,76\r\np=47,101 v=93,-25\r\np=37,21 v=96,19\r\np=93,51 v=20,97\r\np=46,31 v=-54,61\r\np=26,99 v=-64,-11\r\np=6,91 v=-55,-90\r\np=95,7 v=95,33\r\np=1,89 v=5,19\r\np=69,24 v=-83,81\r\np=82,37 v=-66,-92\r\np=20,66 v=-80,-77\r\np=45,87 v=-47,-11\r\np=19,77 v=8,1\r\np=61,12 v=-70,79\r\np=59,48 v=14,44\r\np=68,70 v=48,-37\r\np=77,94 v=42,-84\r\np=47,31 v=1,-32\r\np=22,1 v=-40,95\r\np=41,98 v=-53,16\r\np=38,49 v=48,77\r\np=21,98 v=-71,12\r\np=67,92 v=-13,69\r\np=99,99 v=-80,-84\r\np=50,18 v=-77,-45\r\np=71,35 v=-36,-22\r\np=61,65 v=-68,10\r\np=96,25 v=56,-21\r\np=77,65 v=-20,-40\r\np=56,81 v=56,29\r\np=81,19 v=-97,-15\r\np=31,12 v=-62,-38\r\np=92,83 v=51,-4\r\np=70,23 v=-44,45\r\np=55,61 v=-27,-33\r\np=9,48 v=99,40\r\np=20,36 v=-80,-52\r\np=83,46 v=-35,-59\r\np=52,43 v=58,-88\r\np=2,88 v=-49,-34\r\np=31,99 v=54,59\r\np=76,21 v=11,31\r\np=5,51 v=-27,35\r\np=57,88 v=2,19\r\np=86,41 v=-51,60\r\np=82,58 v=-98,-96\r\np=100,70 v=-38,-85\r\np=81,47 v=-10,-30\r\np=96,88 v=82,6\r\np=24,28 v=62,98\r\np=44,71 v=-69,-50\r\np=75,11 v=-99,-52\r\np=35,80 v=16,-37\r\np=2,21 v=-27,84\r\np=80,14 v=-43,98\r\np=49,76 v=80,21\r\np=84,96 v=-82,67\r\np=32,79 v=-95,74\r\np=35,81 v=-90,-68\r\np=47,45 v=-22,-6\r\np=69,45 v=41,-83\r\np=63,21 v=1,-92\r\np=57,1 v=-98,4\r\np=34,4 v=-93,-81\r\np=46,63 v=-99,47\r\np=8,99 v=5,29\r\np=32,27 v=54,-42\r\np=27,98 v=17,-98\r\np=63,22 v=81,98\r\np=75,36 v=-86,66\r\np=58,5 v=-67,-58\r\np=82,20 v=81,-57\r\np=82,67 v=81,83\r\np=58,58 v=17,-13\r\np=18,89 v=14,-21\r\np=76,63 v=24,65\r\np=38,48 v=-85,-99\r\np=17,34 v=45,21\r\np=77,70 v=3,-50\r\np=56,82 v=17,76\r\np=64,97 v=94,-71\r\np=16,40 v=37,84\r\np=29,96 v=-61,-7\r\np=12,79 v=-95,-34\r\np=1,72 v=63,38\r\np=0,20 v=60,68\r\np=43,60 v=-6,40\r\np=20,22 v=-17,58\r\np=47,49 v=-70,94\r\np=12,29 v=-25,-32\r\np=22,69 v=-44,-22\r\np=44,78 v=31,33\r\np=86,50 v=76,-19\r\np=0,92 v=35,16\r\np=42,8 v=-39,87\r\np=30,1 v=14,61\r\np=41,57 v=18,-84\r\np=83,82 v=-97,36\r\np=72,7 v=-78,62\r\np=17,4 v=-95,12\r\np=15,15 v=60,73\r\np=80,79 v=-59,56\r\np=49,76 v=-22,-47\r\np=58,82 v=26,62\r\np=59,101 v=-82,96\r\np=78,56 v=-97,-56\r\np=19,62 v=85,-44\r\np=21,4 v=61,-91\r\np=80,66 v=-12,-27\r\np=66,17 v=96,28\r\np=57,6 v=-45,-38\r\np=24,70 v=61,-90\r\np=4,12 v=68,-58\r\np=27,37 v=15,-59\r\np=10,66 v=-33,-50\r\np=22,64 v=95,-38\r\np=47,44 v=24,-39\r\np=96,28 v=75,71\r\np=95,20 v=32,30\r\np=38,52 v=-89,10\r\np=88,94 v=96,-6\r\np=93,31 v=-38,18\r\np=61,79 v=46,-3\r\np=22,27 v=-33,5\r\np=77,62 v=81,-60\r\np=63,13 v=-94,81\r\np=39,49 v=93,89\r\np=7,37 v=-2,-89\r\np=59,2 v=24,-58\r\np=82,32 v=-4,-45\r\np=28,55 v=-70,-13\r\np=36,49 v=-93,90\r\np=16,74 v=53,-20\r\np=56,69 v=-84,93\r\np=40,25 v=-93,-89\r\np=73,60 v=-75,90\r\np=28,82 v=-47,-27\r\np=35,67 v=-8,-73\r\np=76,17 v=68,63\r\np=33,43 v=1,37\r\np=5,7 v=-52,-34\r\np=79,49 v=89,60\r\np=78,59 v=20,57\r\np=96,31 v=-93,-50\r\np=24,88 v=78,-24\r\np=12,39 v=37,-16\r\np=60,15 v=-21,45\r\np=25,17 v=-40,-45\r\np=9,63 v=-42,13\r\np=46,48 v=8,1\r\np=16,85 v=18,48\r\np=36,45 v=-41,95\r\np=62,88 v=54,6\r\np=46,57 v=-99,23\r\np=57,67 v=79,-40\r\np=88,96 v=4,-51\r\np=82,19 v=66,-2\r\np=9,73 v=68,-54\r\np=66,38 v=9,74\r\np=40,68 v=-15,83\r\np=97,24 v=-64,-55\r\np=52,56 v=-61,7\r\np=55,15 v=-53,91\r\np=98,66 v=78,-47\r\np=27,46 v=-47,4\r\np=100,19 v=36,-78\r\np=5,9 v=6,82\r\np=63,35 v=49,21\r\np=40,101 v=8,-14\r\np=98,19 v=-74,-28\r\np=74,15 v=96,-65\r\np=53,47 v=-84,34\r\np=48,14 v=94,-98\r\np=69,2 v=3,-71\r\np=38,10 v=78,35\r\np=74,76 v=-90,-60\r\np=37,68 v=55,-70\r\np=52,78 v=-31,48\r\np=6,24 v=-73,24\r\np=77,51 v=38,94\r\np=73,45 v=-42,-72\r\np=52,57 v=67,-51\r\np=12,14 v=46,39\r\np=6,11 v=65,21\r\np=29,37 v=-54,-95\r\np=41,24 v=-85,68\r\np=78,102 v=96,-24\r\np=13,25 v=-16,66\r\np=8,53 v=6,90\r\np=77,6 v=26,-71\r\np=98,45 v=-95,84\r\np=56,15 v=-27,-83\r\np=82,98 v=-35,52\r\np=24,42 v=-8,-29\r\np=16,46 v=-78,-53\r\np=25,15 v=-34,-54\r\np=27,42 v=-11,-13\r\np=12,69 v=46,3\r\np=74,20 v=43,-9\r\np=25,85 v=9,-93\r\np=65,99 v=26,-1\r\np=90,78 v=74,36\r\np=41,6 v=77,-88\r\np=85,62 v=-43,93\r\np=34,61 v=33,2\r\np=0,65 v=75,53\r\np=40,30 v=48,-36\r\np=31,1 v=47,48\r\np=24,100 v=85,99\r\np=97,24 v=-76,-67\r\np=69,59 v=21,28\r\np=82,72 v=7,96\r\np=9,10 v=68,25\r\np=26,91 v=85,49\r\np=35,86 v=39,-24\r\np=38,35 v=48,-99\r\np=99,61 v=35,-61\r\np=79,86 v=-98,99\r\np=94,40 v=50,-22\r\np=47,101 v=16,72\r\np=53,61 v=41,-3\r\np=27,101 v=-48,89\r\np=28,82 v=15,29\r\np=83,58 v=58,-10\r\np=40,38 v=-14,-82\r\np=52,78 v=79,16\r\np=45,15 v=-47,78\r\np=72,0 v=81,64\r\np=72,51 v=-95,-32\r\np=88,67 v=34,70\r\np=89,72 v=12,-90\r\np=61,31 v=25,-92\r\np=68,53 v=48,70\r\np=47,53 v=94,10\r\np=15,53 v=-72,27\r\np=80,8 v=20,-37\r\np=28,66 v=-16,-17\r\np=77,17 v=99,-11\r\np=46,10 v=-9,-66\r\np=76,71 v=78,-78\r\np=26,62 v=-85,56\r\np=87,9 v=-80,-71\r\np=67,36 v=-67,18\r\np=99,32 v=-80,61\r\np=69,87 v=73,89\r\np=6,100 v=-72,-48\r\np=40,38 v=-93,-92\r\np=89,12 v=81,-92\r\np=85,97 v=-19,-88\r\np=22,100 v=37,-4\r\np=11,45 v=-33,34\r\np=43,32 v=6,79\r\np=47,102 v=-84,52\r\np=89,94 v=-84,65\r\np=75,14 v=-3,-11\r\np=11,65 v=2,46\r\np=76,59 v=65,35\r\np=65,60 v=-75,40\r\np=92,36 v=-32,-9\r\np=69,16 v=11,15\r\np=62,63 v=32,80\r\np=47,50 v=-30,60\r\np=13,98 v=-80,-98\r\np=32,82 v=23,-74\r\np=28,6 v=-92,35\r\np=72,89 v=4,3\r\np=72,57 v=-3,80\r\np=6,44 v=89,-1\r\np=33,19 v=31,-78\r\np=43,101 v=-39,78\r\np=46,51 v=-30,-63\r\np=24,37 v=-79,-82\r\np=51,46 v=64,44\r\np=0,36 v=13,-99\r\np=71,6 v=72,9\r\np=40,98 v=78,-81\r\np=36,33 v=96,-14\r\np=63,100 v=95,12\r\np=12,42 v=-41,87\r\np=66,48 v=-52,77\r\np=5,77 v=36,23\r\np=94,54 v=80,24\r\np=77,71 v=-50,1\r\np=81,20 v=89,-85\r\np=9,13 v=-95,42\r\np=13,78 v=71,20\r\np=36,43 v=-21,88\r\np=56,94 v=87,69\r\np=91,53 v=21,57\r\np=80,84 v=-74,-44\r\np=19,90 v=-87,96\r\np=13,83 v=-63,-51\r\np=14,91 v=5,56\r\np=23,1 v=-72,-15\r\np=50,44 v=71,-73\r\np=6,49 v=45,67\r\np=4,0 v=-9,-91\r\np=70,8 v=-98,45\r\np=30,42 v=-78,61\r\np=87,74 v=-97,26\r\np=35,89 v=92,-32\r\np=23,61 v=94,41\r\np=87,21 v=-82,28";
            return (Parse(data), (101, 103), 100);
        }
        public static (IEnumerable<Robot> robots, (int width, int height) areaSize, int steps) GetTrainingData()
        {
            var data = "p=0,4 v=3,-3\r\np=6,3 v=-1,-3\r\np=10,3 v=-1,2\r\np=2,0 v=2,-1\r\np=0,0 v=1,3\r\np=3,0 v=-2,-2\r\np=7,6 v=-1,-3\r\np=3,0 v=-1,-2\r\np=9,3 v=2,3\r\np=7,3 v=-1,2\r\np=2,4 v=2,-3\r\np=9,5 v=-3,-3";
            return (Parse(data), (11, 7), 100);
        }
    }
}
