﻿using AdventLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15___Warehouse_Woes
{
    internal class Input
    {
        public static (Matrix<char> matrix, char[] moves) GetData()
        {
            var data = "##################################################\r\n##.O...........#..O...O.O....OO......OO...O.O..#.#\r\n#OOO...OO.#O...#..OO.O.....O..##O...O....O....O..#\r\n##....O...O.........OO#...O.O#.#O.O.....#........#\r\n#OO.OO.O.OO.#.O..O.O#.O...OO..O..O#.OOO...O....O.#\r\n#O...O.O..O....O...OO..#...O.#O...OO......O..#.O.#\r\n#..O.......OO..##.#.O.O.O.....#...OO..O....O..O.O#\r\n#.O....OO.O#.#O.O........O.#......O..##O..O....O.#\r\n#O.....O..O.O.O...#......O.O.O...O#.....O#.#..O.##\r\n#.......O..#....#....O....O..##O.......#.....O...#\r\n#.....#...OO.O...O....O..O#.........O..O.O.O.....#\r\n#O.......O.......O..O.O....#.O..........O...#...O#\r\n#.OOOOOO#...O#...#....O...#.##...#..O.OO#OOOO#...#\r\n#..O....O.OOOO.O.#......O.##...#.#O...O....O.O.OO#\r\n##OOOO###..O..O.O.........#...O#.O..O.OO..##..OO.#\r\n#......OOO.....O....O...O.#..O...OO...OO.O...#O..#\r\n#......OO...#O#...OOO.........O........O.....OO..#\r\n#.#...O.O....#.......OOO...O...O#.OO..#.#.O..O...#\r\n#OO.O...O.O.#....OO..#.O.O.......##O..O.O..O.....#\r\n##.O#OOO.....O.....#.....O#..OO...O..O..O.....O..#\r\n#...O.O..O..O.O.....O.OO.....O...O...#..O.....O.O#\r\n#O..OO.O.#..O..O....OOO.O.O.............OO....O.O#\r\n#.OO#O.O.O.OOOO#O...O.#.O....#........O.O..#...#O#\r\n#O.O.#O..#...OOOO..........O...#OOO....#O..#O..O.#\r\n#..O.OO......#...OO..O.O@O#.#.....O.....#.#OO.#..#\r\n#O..O.....OOO....O...#..#....O..#OOOO........O...#\r\n#O..O#.#..O.....O.O.....OOO..O..O.#..#OO.....O.O##\r\n#..........O....O...O.#......O..O.......O........#\r\n#.OO#......O..OO...#O.O.#.O..O.O..........OO....##\r\n#..O#O.O....O#...O.O.O.O.O..O.O.##O.#..O.O.O.#O..#\r\n#..OOO.O.O...#.O.O.......O...#OO..OO.###..#O#..O##\r\n#.#OOO.....#..O....OO.O..#O.OO..#O#.O.#.OO.......#\r\n#.........OOO.OO.....#.....#O.O.OOO...#O...OO.#O##\r\n#...O...O......O...O#..O#O#..O.OO.O..O.O...O.O.O.#\r\n#.O.....OO...OOO.OO..O......OOO...O#.....O....O..#\r\n#O..O.......O........O...O.OOO.O..#..O...O.OO..O.#\r\n#...O..#O.O......#..O.......OO.#..#O..#O.O..#.OO.#\r\n#..OO....#.....OO.O#....O.O#.O...O...O..#..#.OO.O#\r\n#...OO.O........O...O.O......O.O.............#OO.#\r\n#.....#OO......O#..O#O....OO#O....O#...OO.#OOO...#\r\n#.....O.OO......OO#...#O......OO#...........O.#O##\r\n#.OO.O.O.OO....O........#..........O..........O..#\r\n#O.OO..O.O..OO...O...O.OO..O.....#..#.OO.OO.OO.OO#\r\n#..O..O..O.O.#.....O#..O...#.....#...O..O....O..##\r\n#O...#....O.#....O....OO.OO..O..O....#O..O.O.O.O##\r\n#..O.......O........OO#.....O.........#..........#\r\n#...O.#.O.OO#.......O.#...O.O......O.O...........#\r\n#.#.....O......O#.#.O...O#O.O.O...O.....O..O.OO.##\r\n#.....O.O..O.......O......O..O...O#O#.....OOO....#\r\n##################################################";
            var moves = "^^^v^^v><vvv>^v^><<^>>^^^<^vv^v>v^><v^v>v>v^<^^v^>v<^><^>^<>>><<<v^><>v^>^^^<<<>^<^<^v<^<><v<vv^^>^>v><^v><v><vv>^v<>v^v^^>>vv<^^^><^>>^^>v^^^v^>^v>>^<<v>v>>v<vv^^v<v>^<vv<><><^><<v<^<>^^<>>^>v^^<<^>v<>^<v<>vvv^v<>>vvv^^v^<v<v^^v^<>^^v><>v><^^<vv<>v<<><v><^^v><v<<>>>><^>^^>vv<><vv^>>>v^>>^^>><>^>>><vv<<v^^^^<<>v>>><>v<vv><v<>v>>v>^vvv><v^>v<^v^^<^^>^<^v<vv>>>^>>^<>^vv^v<^v<v><^>^<<v>>v>^^vv><v>^>vv<><^>><^^>><<^v><>>^><^<^^v><v<<^vvv^^><^^^^v^^v<>v<>>^>^<v>^^<^v>>>^v>>>><<<v<>><<<vvvv>><><><>vvv<>^^<vv^^<>^<vv>v<^^><>>^>^<v><>^v><>v>v<v<<<v<^vv<v>v^v<<^v<>^v<<<v>>vv^<vv<v^^<><^^^<<v^><v><><vvvv>^vv><^><v>^^v^^<v>^vv><<v^>v<<>^>^v>v<v>^^>v<<v>^^v^>^^^v^vv<<v^^^<<<<v>>^vvvv<^<^vv<<<<v>>v^v^<<^^<vvv>^<<v<v<^vvv<>^<>>>>v<^>v>>v>^>v<><vv>^><vvv>^^<^^^^^vv>^>v<<^^vv^>><<>v<vv>v>v^^v<>^^>vv<>vv<>><<^<<>>><v^^^>vv><^^<^<<>>vv<><><^><^>v>>^>v<^^<>vv<<v>>^<<^vv^<vvv<^^>v<^>>^^v><<<><><>><<>^>^>v^>^^<^vv><<vv>>>v<<^<^^v<v^><>^>v><^v<<^v^v<<v<v>>^^>^>v><v^vv<>>^v<<^v^v><<v><v><<^v><v>><>v^<^v^<>^v\r\n^^<vv><^^<>>^><<>><>v^<v>>^v<>>^>>^<>^^v>^<><^v>>^><>>v<v>^^^^vvv>^v<v^<v^v>v<v>^vv><v^<v<^<<><<<^vv^v<^v<>v^vv^^><>>v>vv>v>>^^>v<<>^>^^^^vvv>vv>^<>><<v<^>v<>v<<>^<v>><^><>^^^v<^v<^>>v>^v^><>^<>>v>>vv^>v>>>>v<<^<^v<^v><>^<v^>^>>><>^v<<<<^^<v<<v^v^vv^^<v^v>>v^v>v<^v<>v>^^^^v>^^<^^>v^^>>v^<><><>v<^vvv^<<<>^^^^^v>>v^v><vv<vvvv>>^><v^v<^^^><^v>^v<vv<<<v^^<>v>^<>v^>>>>v<v>>v<<vv>><>>v<^<>><<v>vvv>>^>>v><<<^^^>vv<><v<^>vvvv^v<vv^^<<>^vv><><>v^<><<v^^>>^>>v><>>>v>v><v^^v>v>vv^>^><vvv>vv<<<^^v<v<v^v^vv^>v^>>>>^<^<^<^>>vv>^>>v><<^>v>^>v<>><><v<>^<^>>v>v<<>^>^<>>vvv>>>^^><^^>^<v><^^>^<v<<<>>^^<>^<><><^<>^<>>^<><>^^<<vvv<<><<>>v<>v^^^^^vvv><<^^><>v^vv>vv>>^v<<>vv^>^<v>vv^>^v<><<^>^>>>v>^>>vv<^^^v>^^^^v<<<<<<^<^v>^vv><^>><^>>^^<v<>^^^<<v><><<^^^>v^^^v^>>>><<<><<<vv<>^^<><>>^^<v^vv><>v>>v>>>>vv<^>>v^^^<v<^><^vv>>>vv<<>>v^^v^^v>v><<^v^><vvvv>v^>>v><^^<<>v>v<^^^>vvvvv^>>>>vv^^v><v<^v>>v>^<<^v<<>>v<>^>vv>vv<<v>v<v<^^<^<<<^<^v<><><>><>v^<><^<<^v<v>v>^<<<<<v>v^>v<>^<>^v>vv>^^vv^^<<^<>^<<>v<v<^><<^<^vv^<\r\n>^^>v^>>vv^^v<<<vv>v<^>><v>^v>^^><^v^^^><v<>vv<>>^><^v><vv^v><<<vv>^><^<vv<<<^v>v<v<^<^^v^<>>>v>v<v>><<vv^^v<v^^>^v^>^v<^><<<>vv<>v<><<v><<^>>v^<^>^v<><^<^<<>v<vv^v^<vvv^>v^^^v<>^<<>>vvv<<<<^<<vv^<<<v><v><<vv^<>^vv>v>><^vv^<v<v^^vvv><>>^v^^^v>v<<<>v^^>>v^<<v>>>^<><>>^^^^^vvvvv>^vv<><><>vvv<^v>>vv<^vvv><^^^>>^>>^<>^>^^>>^^<>^^vvvv><<^><^><>v^><^^v^^<^v>vvv<v^>^>>><<<<v^>v^<^<>^v<<>v<><>v^^^v>^v^^^>v><v^>^^^v<><>^^>v<^^^^v>>v><^v>>^vv>^v<<<<v^>^^<<^<<<v<^<^^<v>>v>>vv<<><^v^^<><><^<<vv<v<^^<v>><^^^<v<v<^>^v^<<^<v<>>>><<v<^^vv>>^^<><vv^v<<<<<<vv><^>>v^<v<v>^>^vv^v^<>v>v<<>v<>v<vv^>^>>^>>^<^^<<^v^v^^^vv>v>^v><^>vv^<<^v>>^^v>^^v>^>>^>v^^>vv>^<v><<>v><vv>^<<>><<<<vv<<>>^^<^^v<vv^^^<>>^><>^>><>>^<><>^<^^<^>>v<^>><<<<<^<v>v>^<v>^>^vvvv^>>^^v^^^^^vvv<^^<<<^<^v<<^<<<<^>>^^>vv^>^^<vvv^^^v<<<><<>v><v<^^>><<>vv>^>v<^^^^<v<<v^v<<<><vv^v><^><>>><^vv<<^vv^>>><v^><v^>v^><vv<v>><^v^>vvvv><^<>><>><v<<v>v>><<<^^>>^^<^^>vv<vvvv><>v^v^v^<>>v^<<><><<<>^<v^^>v>v<><>v>>>^>>^<^^v>><><v^>v>^>^v^^^^>>v^^^v^^^v>>v>\r\n^>v>>^>>>^>^<>^v^^<^<><v^>^vv^<<>v>vvv>>v><>^>v><v<<>^>>>^<>><>>><<^<>^^<>><^<^<^<v<v><<^<v^>><<v^^>^><^>^<^>vv^><v>v>^vv>v<^>vv><^>v><vv>v><v<>^^>vvv<>^^^^><v^<vv<^v^v<>>v>>v>><>>v^<v>vvv<v<^^^>>^^vv>^><<<<v<<v<>^^^vvv>><^^v^v<v^<>^>><^v^^><v^^^>>v<v^^<>>>><<^^>v^vv>^^v>^<<vv<^<vvvv><vv^>^v^v<<^<v<^>vv>vv^<>^<<>^^^^v<^v><v^>v^<^^<<v>^<<^^^^vvv<>^^<>^><<^>>^^<^^^v>><^>>^v>^^<v^><v^^<>><>>^v>>^v>^>><^><>^^v>>^<<<v^v^vvv>>v>^v<^>>>^><^><>v>^v<<<>^>^v>v<^vv<v^<><><><^^^v<v<^><^<^<<<>^<v^v^v^>v><><v<>>>^vv>^<<^^^v<>^^v>><>^v>^^>^<><><<<>>>^<<<v>v>v^<><<><v>>>><vvvvv<>v^^<>v<>v^<<><<><><<>^vv^>v<<<^vvvv<<>><<<>v>>^v<^v<^<^>vv^<^^^<<<^v<v^<>v>>^vv^<<vv^<>v>^v<>^v^v^<<^>^^^^v<<^v>>>^^>^><<^<^>>>vvv<>><>v<>^<vv^^<^^>^<>^<v^<<><^<^<^^><><v^>v<><>^v<<>>v<^>v<v^v>^>v^<^>>>vv^^v<><>^^<><v^^<^vv<^vv^^<^>v^<<^><vvvvv<<<^>v<v^v>>^<<<<v>>v><<v^<v^<^^v<<><^v>>>>v<>v<^<vvvv>v><^v^v^<vv^^>v<v^>>v<>vv^<>^>v>v<><><>v<^vv>v^^^vvv<>><<v<<>^<>>>vvvv<>v<^^<^vv<^v^>^v^v^><>><vv^>>^<<v>>><>>>v^^<^<^<^<^<^><><^<>\r\n^><v>^>v>^<<vv^><^><^^<^>^<><v<>><<v<>>>^^<<<<v><v<vv<v><<<vvv^^<v>^^^>>vvv^^^<<>>^^<^^><vvvv^<>vv<v>>^>^^>v<vv>v^^>^<^<^<vv>>v<<>>v^>v<>^^>v^>^v^>v>>>^><^>^>v<<^<v^><>vv<v<v^<v^vv^<>^^^<v>^<vv><^^^^<v<>^<>^<<^>^>v<>^<^v^<><><>^<^<^^v>>^^><>v<^v<^>>>v>><><><v><<^>v<<^^<v>><^^<>v^>v^^>>>v>^<<v<><<^vvvv<>^^>v^v>^<>^>^v<<><>^<>^>>v^v><v<^>^v>^>vv<<<v>>v>^>^<v^^v^^<vvv<^<<<v^>>vv<<vv^<<<v<^^^>v<^<<^<><><^vv>>>v<<^<^<><<^v^^^v>v><^v<<>>>v^^vv^><<^><v^<v>>v^<v<>>v><vv<<^<<^v>v^<>>v^<^<^<^^vvv<^^v>v><^v<>^v>v>^<<<^vv^^vv^>vv^^>v><v<<<><<<vv><>v^<^<>>v^<<vv^^^^^>v^<v<v<><>>v^>v^>^v><^<^v<^<<^v^v^v<>^<>vv>^>v<^^^^v<<^<><<^^<>>v>^>^>>><v>^<^v>>^<^<><^^>v>>^>><><>>>v<^^v>v^>v<v><^v>>^<<><>^<><v<v<<vv<v<<^v<>><^^v<>^>v<<^>><^v^<<^>vv><>>^><<><>>^<<^<vv>v>^^>v>^><^<><vv>v^v^^v<<<<>vvv^<^<v^v<^^>v><^>^>^v>v<<<v^^v<^vv>vv^v>v^v><^^v<><v<<^<>><<>>>^>>^v^>>^<v<<><vv^><<<<v^^^<^^<^vv^v>>>>^^v^>>v<<^v^v>v^^v<>^^>v>><^<v<^v>^<<>^><v><v>vvv>v^v^^v>>^v<><<><v<^>v^<v<>^><<^<vv<<><vv>^><>^vv^v<v<^>>>>^v>><<><\r\n<v^^<><<>v><>>^^v<^^vvvvv<>v><v>^><>v>^v^v^v^>><><v>v^>v<^^<v^><^<>^<<>vv>v<<v^>v<<^<v<>^><>^^v<<vvv<v>v^<^>^<v>v<vv>>>v>>v<v^^>v^>v<^><^<v^>^^v>v>v<><vv<>^vv><<^v><<v^v>>v^v>^><^<^>v^^>^>^^v^^<>>vvv^^>^>><vv>v^<^v<<<v<><>^><<><vv<^^^^^v<>^v><^<<>v>^<>v>>^v<<^>^^^<><>^>><>>>v<v<<<v<v^v>v<^>>^><v^vv<v<>>>v><vvv<>>v<<<>v<>^v<<vv<><>><^v^vvv^>^<><><^v><^v<^^vvv>vv^<<^^<v^><^>v^^<^v<v>><<v>v>v<<vv<<>><<>v<^<<<>vv<v^<^<<^v<>v^^>^>v^^^^<v^^v^>><v^v^^^v^>v><^<<^>v^v<>^>>><>^^<>^^<^<v<>v^<^vv>^<>><>^<^^<<v<^>>v<vv<<v<v<>^>v><^v<v^vv<v>>^>^^<v>vv^^^<<^>><^<^>v><>>>v><^<vv<vvv^<><><>v<><<<v><^>^>^>><<<^^><>vv<^v<<vv><^^>^<v^^><v^<<v<<><><v^v>v^vvv^><>vv^<^<^<<<v^vv^><v<<>^<v>>v^v<^<>>^^^>>v>^v<<<^<v^<>><v^^v>>^v><<<<<v>^<>^v^>vv>v>v<v><^v><^vvv>v<^^^^><>>>><^^><<^^^<>>><<<<<<<<^>^>^^^^<>^<<vv<>><^^>>^v^^^>v><v>v<v<^<^<v>>^<^<>>^<^<<<v<<v^<>>>v>><>>^^vv<<^v>^vv^v^>><v>v<<v><^v<<<<^^<^^<<>>^^v<<<>>v<v^^vv^^><^vvvv^>^^v^^v^>^<>>vvv<vvvv>><^v>v^>^<vv^>v<<>>>^v<v^^<vv>v><>><>vv^vv>><^>^<>^^^><^^<<><^\r\n><<v^v>v>>^>vv^>^><^>^^^v<<^^^^<v>^v^v^^<^v<><<<v<>v^vvv<v^v^><v>>v>v^<<^^>>^^^v>v^>>^<<^^<<<^^<>>>>^v<>><>>>><v^>>>>^^>v<^<>vv>>vv>v<v^v><>vv>^^v<<<v>>^>vv<v<v>v^v<<^<^<vv<>>><^^>><v<v<v^v>v<v>v>>vv<v<v^^^v>^>>>v^v>^^<vvv<>>v>v<v<<><><><<^<<^>v^><>^v>><>>^v^v^>v>^<^^>>v^>v<^^^>v><<<v^vvv^<v<>v<>>^^v>vv>vv^^><>^<^^v<>>^^<v<^v^<^v>v>^v^<vvv>v>vvv<^v^><<^^v^v>>>^^^<^^^^<^^^<>vv^^^^^>><><>>v<>>vvvv<>>vv<v>v<^>^v<<<^>^>>>>>><<<>>^^>>v><vv<vv^><^>v<^vv>v^>^v><<>>v<vvv^^^><v^>vv<^<^>v>vv<>^>^<vv^>^><v<^^vv>>v<>>v<v^>^><<>^v><<>>vv>^v>v>^^<>>^<vvv><^^<<>v>^vvv<>^>>vv^>><v^v^<><><>^^<^^v<<v<^<^><>>^<^<^^<v<>>>>v<>v^>v<>^v^^<^^><^v^v<^><^^>v<v^>><<<^<<<<^<v>^v<><vv>v>v<<vv>>v<^<^v^>>v>^>>vv^<v^^><^vv<>v>v^^vvv><<vvv<^<>^^vv^<><^>^v^^<v<^>v><v<<>^<^v^v>^^v>>>^v<v^^<v^v<>v^v<v<<>^>^v><><vv>>v<^>vv^>^v<v<v^^>v<v>v<>v><v^v^^<vv>>^>v>>>><>^v>^^^<v^><>v><><>^><^v^v>>vv^>>v<^<^^v>^^v<^vv>v^vv<^>v<<^<^v<<^>^^<>v^<v^^>^><>^^^v^vv^<^>><<^^<^>^^v>>>v^<^<<v<v^^><>v<v<^>v<^v>>vv>^^v<>><>>^<v>>^^v^>v<>^vvv>^\r\n>v^<<v<>v>><^<v>^<>v>><v^>^v^><><<>^<^<^<^><vvvvvvv>v^<v^<>^>>>>><>><vv>^^vv<v^>>><v><<^<^>>^>>^^<><>^^<<<vv>><^vv>>v^^v^<<>^v>v^^v^>^v>vv><^v<v>vv<>v^v^^^v<<^>>><<<><vvv^<>>>v^v>>^>v^<<^^<^v^<>v^<>>v<<vvv>^^vv<<^vv<<v^vv^^^^v^v^^vv^>v^<^<<v>^v>v>><^>^<>>^v<v^v^^>^v<^>^^><><v<^v>^>>^<<^v^>v>^^<v><vvv^>v^>>>v^><v><>>v<^><^<v<>^<>v^v<>vv>><^<>v<><>>^>^^v^><v>^v^^vvvvvvvv<<^>v<vvvv><^<v^v<>><<<>v>v><><v^>>^>>^<<<<<>^v^<<<^^^v<<v<>>><<>^^>^>>v^^><><>vvv>>vv<><^^v^<>v<^v>v><><^^v^v<><^^^vv^>^v<<><<><v^^^<><v<<^^<<>^v>^<>>v>>v^>v<<>>>>><^><>^><v^<<<>^>v>>><^<v<^v>^v><v<^>^v>v>v^<<^><>v<<><^^^^vv^<<>^<<v^^^vv>v^^><v^^^><<<><<^vv<>v<<vvv<<v>v<vv<^^>><<^<v><>>>^^>vv<>v^<^^^><>>>v<^><<>^<><>v>>>><vvv^^>^>^^^><>><^><vv^vvv^<<<><v^^<v^^<^^^><>vvv>>v^v<vvv^<<><<v><<^<<<^^v^>v>^vvvv>^>v^<>>>^>v^>^<>>^>vv<<<^<^v^>><<^<><>v^<^<<^v<^vv>v><<v^><^^vv><^v^<<><<vv^<^^><^>>^<<^<vv<^>v<<>^><<><>>v<^>>^>>v>>^<v<>><<<^vv>>v^>^^<^v>^^^vv>><vv>^<><<^><><<>^^<v>v<vv<<>>^^<^>^<^v<^^^^>^v^<^>>v>vv><vv>^<^>vv>v>^>>^\r\nv<v>v>v<v<v^>^^v^<<>>>^v^vv>>^^v>^><^v><^vv^^^<>>vv<<<^^vv<^vv>>^v^>^^vv^^<^>^<^>v^^<<<<<vv>^<>>v><><^><>>v<v<^><v><>v><>^<^<<v<<>^^^v<<><><v>^<^<<vv^>>>><^^<^<><^<>v^<v^^>^^^^<v>^vvv>^v<v>v<>>>>^^><v<<<vv>>>>><<<v^>>^<^>^<>>><^><^^^vv<^>v<v<^v^v<>^v>^^vvv<>^><v^<^><<><vv^^^<^v>>v^v<>^<vv<v^<<<>^>v^>v^v<>>^v^<>v^v^v>vvv^>^<><v^vvv<<vv<>^>^>v^><>^<^^vvv>>v^^v^>><^vv>^v<<v>^>v><^v^<v>v<^<v<<>>^>vv^^vvv>vv^>v<vv>>^^<^^^v^><vvvv<<^vv>^^<vv>^^<<<^<v>^<vv<v>>^>>vv<<<>v^<v<^>^>^vv<^vvv<v>^vv>>^^v>v^<v>v>>><>^^>>>^^<v<><v>^>>><v><<vv<<>v^v^v>vvv>>v>>vv<^^<^^<<>>vvv^^^><>><v<<^<v>>^>^<>^v<^^v<<^>>vvv>>><v<^>^^><>v^<^<^>^v>><<<<^vvv<>^vvv>>^<v<^^v>>v<^><<^>><<vv^^^<^^^>^<vv>v>>^>>>^^>v^>v<v>vv><v^<<<vvv^<vvv<>>v<>>v><^^>^<v><v><^><>^^vv^<v^<>v^>vv<^>^<v^^>v<<<^^><<><<<^^^<^^>v>vvv^<>^^v^v<^>^><<><^<v<<^>^^>>v^>v>^<v>>^v><>v^v^^vv^<<<vv>vv>v<v><>>^<vv^<>^vv^v^v><>^^><>><>v><v^^>>>v^^<><<<<v<^^^<^><^>>^>^vvvv^<><<<^<^<^^>>^v<vv>><vv^<>>v<>^^<^v><v>>>vv<<^<<^vv^<vv<<v<>^>^>^vv<vv^<v<<>><^v>v><>>^<v\r\nv^>^^>>v^^^><>^<><<^><>v^v<>vv<v>^^<vvv>^^>v>><vv<>^>v><^<>>>vv<>^>^<>^<v^v<v^^^^><v<v^^<v^v^v<^>>>^><^^v>>^vv^<^<>v>v>v>^<>^>v<v<v^^<v<><<><><<^v^<^^v<<^<^v<^v<><vv<^><^^>^>>^v<<<^><>v^<<^><>>>>v>>>>^v>><>>v>><<v><^^^<^><>^^>^v<^>v^<>vv<^^^^<><v>><v<<<><vv<^^>v^><^v^^vv^<v>v^^^^v>>^vv>v<><v>>v^<vv<^v>^><v^<^^vv>^<<vvv>^>vv^v<><^vv^v^<v><v<v<>v^<^><v<<v>^<^>^>v^v>v>^v>>^><^>>vv^^vv<<^vv<^<v<v^<>><^>vv<<>v^^<^^<v<v^<><<<v>><v<><^^v^^v^v><<vv>^^<^v><v>>^^>v<v><v^<>>><^^v^<<^<>^<>v<v^<^<v>^<<^^^>>>^><vvv>>>v>vv^v^^<<^^<v>>>><><>vvv<<^vvv>>v<><>><v<>vv^^<^^vv<v<^>^^^v^^^v^v>><<>^><^v<<v>^<><<>vv^<<v<^>^vv<^<^v>>v>vv^<<v<v<<^v<v^>v<v><>^>^<v<><>>v<>v<vvv^^<v^><vv<><^>><v^<v<vv<<>><^^<><^v<><^^^vv<<>>>>v><<^<<>^^><v>^>vv<v>>>vv>^v^><>v>^>^>>v<vv^>^<<>>v<^^^vv^^^<>v<<>^>v^>vv^^>^v>v<^v>v>^>^vv^>>v>vv^^^<v^^^<^^<^v<>vvvvv^v<^^<v>^<<<v^>>><^vv>>v<v>>v^^^v^<^vv>>^>>>>^><^>>^^v^^^^>><^vv<>v^v^^><v^>^<<>>v<><^v>v>>>^<<^<<^<<vvv^v<^vv<vvv>v^^>>>>v>><^vv<<><^^v^<<>>v>^v^vvv^v^>>^v^^<>v^<><^>><v>>v>>\r\n>><<<v>><<^<v>^<v<>>^><<^<>>><^v<<^^<>^v>v<^^<vvvv^^^v<^<^<vv><^<^<>^vv><<v^><>^><v^>>>v<>^v>^<v><>>v<^>>><>^v>^<v<<^^vv>v^^>^v<v^vv<><v>^<^<>^v>^>^^<v^<^>v^<vvv^<vv^^^^v^<>v>^<v><v>v^<<<<<<>^^^^^^<vvvvv<>>v><<>^v><vv^>^>v>vv><^v<^>v^<<^^v^>^>>v<^^>^<v>v^vv>>><vvvv<^v^v^vv>^<^<^^^>^^<>^^>>>>v>>>v^>><v^v>^^^>^v<>v>>>><^v^>vv>^v<<<^<>v>^>vv>vv^^<><>v<vv<>v<^^^>^^>>v>><<<^v><^<vv>><>v<^<vv<^^>^<^<>>v^<^vv^>>>vvv^v>v^v>^<^<<<^^>>v^vvvvv<vvv^<>><^<v^<<<<>^^><v<^>^v^v>>^>><^^^<<^^<>v<v^^v^v^vv^>>v<>v<>^vv^>^^<^><>^^<vv^>>v^<<<>^>><<v>v>v<^^^<v<<>v^>>>^v^>>v>^^v>^v>^^>v^v^<<<^vv>v<>>v<v^<<^>^^^v>v^^<<^><<^^>v^^^><v>>^<<v<^<vv<vvvv>^<><^<^><v^<vv<^^<^>>^^^vv^>><v><<<^<<^^<<<><<>>^vv>><v^^v^<v^>>^^<^><<>^^v><<>^^vv^vvv<v^vvv^<v^<<v^>v^>><<v^>>v^v>^><vv><>vvv>^>^v<vv^^>^v^<^^v^<<>^<vv>^<^><^vv<vv^>>>>><v>v>^>^><vv^<v<^>>^<^v^^v^>^v<v><v^>><>v><><<^>v<>v>><<v>^vvv^v>v^>>^<<^>^^v><>^vv<>^^><<v>>v>^<<v^<<v>>v^<<<^^^<vv^v^v>^v><<>><>>>^^><<v^>^^v^v<><<vv^>^<^<v>vv^^v^^v<v>^>v><>vvv^vv>>><>^>^^<vv>^<\r\n><>^^>v<<>v><^<<v>^><v<v>>>^>>vvv>^><>>^v^^<^<>>v<v>>>>^>^v>>v<vv><^vvv<<<^v>><<<^>^v^vvv<^v<v^v^^>^>v><v>>^vv<>><>>>^^^>>>>>>v<>^vv><v>>^^<v>^<>^^^vvvv<v<^<^><<<>>><>v><>>^><<vvv^>v^<^^>v><vvv><>>v>v<^^<v^>>>^^>v<^<^^><><vv>^<>^<v>v>^v>v>>vv<vv^<vv<v>v<^v<^^^>^<<><^^v>v>v>>v^>>v>^v^<>^v><^v<^v^<v^<vvvv^>^>^>vv>vv<^>v<<v<<>>^v^v<v<^>>^<>v^>^^v>><v<vv>^^<<^v^<>>^<^<^<v^v><>><v><>v>v><^>^^>><vv<>><<^<^<v^^v<v^v<^><<vv>^><<vv^<^<><vv>v^^>><vv^<vvv<v>>vv^v><^^<^vvv^<<<^^<^v<><^<^<<><<v>^<v^<><^vv^^v^^^v<>^>><^vv<^<>^v><<vv^<^>^^v>^^<^>v<<<^><><<><^<^<><v<^^^^v<^<^^^^>vvvv><^vv>v^>v><vvv<><v^^<^^<^^<^<^<v<^^v>>^<<<^v^vv<>v^^>vv^^^<><>^<<^vvv>>^>v<vv>^<^vv>^>vv>>v<>v^^^<v^>vv^v^<>v^^<>v^v^>><^>v><<<>^^^><vvv>>^v<>><vv<<v<<^v>^^v<>>>vv^>>vv^^v>v><^v<vv^vvv>^^v^v^vv><<<>>^^<<<<><>vv>^^^^>^v^>^^><^vv>v>>^^<^^^v<<<^>^vv<<><v<v^^v^<vv<>><v^>><v<>>><v^<<vv^><^^<^^^>><^v^v>>>><^<><^><^<<^^v><^v>^<^<^>v<<v^^v<<^^v>vv><>>vv>^^<^><><^v^><vv<<^<<v<vv^<v^^<>vvv^<^vv>^<><<^<^^vv^>vv>>v^vv><<v^vv><<>^v^v<\r\n>>v^><^^>vv^^>v>>v<<vv^<<^>><^v<^<>v<vv>>>v<>^>v^vv^^<>^>^>^v<^<^^^^^>vvvv>vv><vv<<>>>^v><v>v<v>^^^^><<>><^<vv^^<>^<v<v<^<<v^<v><^^^><<^>^<^>>><vv^>>^^^><<>>vv^>><^^<<^><v<^v>^^^<>^>>>v<^^^v<<^>><><^>^>v<vv^v>^^vvv^<><>><<<<^^v<>^vv>v<>^><^<^v>^><<v<><^>>^<>v<^^<v>v><v>^>>v^^vvvv^>^>>v^<vv>>^<>v><<v>^<>v^^<<>><>><^<<<^><<<v^<v><v<<>v>v^v<<>^^><<^^<v<v>v>^<>^^^v^>><<v^^vv^>>><><vv>v^>>^v^<^v<v<<v^^<v^><>v<><^v>v<>v<><<v<>^v^<v<<<<><<vv<v^v<v>^<<v<<<^<v^>^<>v>v>v<<<^^<^^vvv<<<^>v<<^>><><>v<<<<>^^^>^>^<^v>^v<v^>v^>vv^<>>v>^v^vv><<>v^>>><><<vv^<<v>>^>^>v^>^^v>>^v<^>>v<^v^vv<v^^v^<^vv^^v>v>^^>>v><^v^><vv<><v<<>v><v^v>>v<^v>>v<^^^v>^vv>v><v<>^>>vv>>^^<<^^<v<v>>^><<^vv>^v>^^^<v>^<^>v^vv>v><<v<<^<<<^v^<>^<v>>v^<^^><>vv<><>v^v>>^<<>v<<v<<<<v^v^^^>v<<^><><<><>>v<vv<vv^^^v<>v<^vv^^>>vv<^^^v^vv^>vv>v<v^<>v<v^<<<v>^<^>^v^^<<v>v^>^<vv<<><>>^<>v>^>^>v>v><v<>vv<v^v^v<>^<<>vv>^^v^^v<^^vv<<^>>^>^<v<vv^<v<^vvv^^<>><>>><vv>>v<v^v^^v><<<<><><v<v>^<vv^>>vv>^^>>v>>><vv^v><v<>^>><<><vv^>v<^^v^v^^vv<vv>>v<<><>\r\n^^v^vv>>vv<^>^<<^v^<>v^<><><>^>v>^^<>v^v^^^v>^>vv^^>vv<^<>><v><><<>><v^><<v^^^>><v^<<>vvv<^>^^<^<><>^>^><>v>>>v>v<^>^>^vv<v<<>>>v^^<<v>>>^v<<>vv^^<<>^v<vvvv<^^>>><>^<^v<v><><^v>v^<v<^<><^^v<^v<^<<<><<^>^<v^<^><<>><v<v><>v<^^<>vv<v^<vv^v^><vvv^^^>>vv^<^>^<<<<v<<><><<v<>v<>>v>^<^>v<v<vv>^<^<>>vv><v^>>^vvv<^><^>><v^><v<v>^>v>><vv^<<v<^v<^>^><^>v<^^^<^^>^vvvvv<vv>^<>^^v>^^<^v<v>>^^<v><v>^>v<>>vv^v<><<^v<v<v<vvv<vv>vv^v<vv<>v>^<v<>v^<<v^><>^<^^^><><^<vvv^^<<v<<>^^v>^><v>>^>^v><v^<^^^<>v<<v<v<>>>^^><<<^v^v><^>vvv<>vv><^<>>v^>v^>><^>v^<>>v>>><^>^><v^>>^v>>vv<<v>^>><^^>><v^<^><<^><vv>>><vv^><>^>^vv^><^<^><>v<>>^vv>^^v>>><v><vv^>><^v^vv><^vv<>>v>>v<^^^v^v^v<v^<><^<v>>^^<<>^v<^v><vvvv^v<>vv>><vv>>v^v<<>v^v>^<vv<^<^><^^<<><>v<v^<<vv<vv<vvv<v<v^^^^^>><^vv<>vvv<<^vv^<^v^<v<<^v>>>vv^<>v><><<<^>^<<^^<>>v<^v><<^vv<^v>v^v<<v^<<v^v>^>v^>><>>^<v><><>^>><v^v>v^<^^<^v<vv^v>vvv>^^>^^<<<>v><<^v<^><<v<>>v<^>^^^<^><^<v>>vv<>v>>^^v>^^<^<><v>^<v<>^>vvv><<<<>^>^><v^>^v<^v<^<>v<^<>^>^^<^<>>^v^>v<^v^^>>^^>^v^^<>>^<\r\n<vv^>>^vv^^<^^>v^<<<<v^><v<><v^v<vvvv^vv^^^v<<^v>>v<>>><^><^^v><<<<^^vv<v^>v<^<vv>>>>>^^>^v>^^v<vv><<v^^^^^v<^^>>^v><^<v<^<<<v<>>>vv^^<<<v>><><^<^^<><>v>^v<^^v^^v>vv><<<>^^>^v^>>^^>^v>^^>^vv^>^>vv<v>><><v><^>^v><>>>v^>>>v>^v^^<<vv^^><<<^v>v><>^v>v^>^<>v^^vv<^v><><v^><v>>>v<>^v^^>>v^v<v^>^^^^<v>^v>^>v>vv<<v^vv<<v^v^v^^v^v^>^<v><^><<^v^v^>v><^v><<><v>>vv<^vvv^>^<^v<^^>>v<><v<<v^><<^<>>^v<^>><v^v>v>^<vv^<<v<<^^>>^^<^^^vv^vvv>vv<>^^v<v><><<>>>>v^vv<v>>v^<<<^<vv^v<^<>v>^<>v<<^^>><v^>>v<v<v>>^v^<^<>^^^^<>^v<>^>^^v^vv>^<^^>>>v^^<<<>v<vv<<v<^^<>^>>><v>>v<^^^v><v<><>vv>v>^>>>v^<>v>^<<^v^><vv>v>^vvv>>>v^<v^^>^<^>>><v>v<>^^>v>v^^v><<<<vvv<<^^>v^vv^>v<<^<vv^<>>>v<<<^<<<>v^>>>v<v>^^^^^v<>v<v><vv>>>v^><>v>>v>>v<vv^>^>>v>v^^^^vv<vv^v^>v^>^>^>^^^<^v<<^^v>v<^^^^<<<<><v>><><vv^^<v<>><v^v^<>v<<v<<>vv<<<vv>v>vv>><>^<>v<>>^<<v<>v>^><v^>^>^>^^>>^v>^<<<^<<>>^><vv^v><^<^^v<<v>>^<<<v>><>v><^^<vv><v><<^<v^^><v^^<><^>>>v>vv^v>vv>^<v<^vv<<^^^<v><v^v<>^<^<v>>^>>v^>v^<><<^>^v<>><^<<<v><v<<^<v^^^v<v<^^>v^>v<^<v>>v^v\r\n^^<>v^><v>^v<>^><>>><<^v><^><<<vv><v^<v^>>^<vvv<><><^<>v><v^v>^<vvv^v<^<^vvv<>>>^v>vv^>v<v>^^>vv^^v^<vv<<<<v^^><>>><<><vv>v^^v<>^^^v>>>^><^<v>^<<><v<^^>v^^>v>^^><>>v<>^vv<<v^><^<<vv^^v^<^vv>^>^^v<<vv<>>vv<<^v<v>^<^<>>>v<<>vv^^v^<<^^>^^^><v<<^>>>><<>^^vvvvv^><<vv><v^v>vv<>><vv^<vvv^^^<<^><<v^^><v^^<><v^<<v^^<^<v^<^v^<^>v<v>vv>^<<>^^><<v<v>^^^^v<>>>^^>v<<<^<><<<^v^<>>><vv<v^v><><>^v^vvvv>><v<vv^v<<v^v>vv^^>^>v<v>^^v<>v>^v<><<<^^v<^<^^v^vv<v^^v^<<<v<^<<<<>v>^vvv<>vvv<^>>^<v>>^><<v<><^>vv<><v<<^^<v^v<v<<^>vv^v>v^<><v<<>^v^^>><v>>>>^>>v>v>v>>^<vv>vv><>^><<^<v<<^v<><^^>^v<^v<<>>^<>vv><>^<v><>^<^<vv^v<<>><^<<>><^<vv<v>v>vvvvv^<<v<<<<>>v<<^<^^<>>>><>^^<v>v<v><<^vv<^v^<<<v>^vv^v<^<<<<<^v<vv>^>><<>vv>vv<^v<^^><<<vv<vv^>^>v><v^<>>>vv>><v<^><^>^^v^^^<>v<v<v^^>v<^<<>><vv<<^<v<<>>>^vvv^>^vv<><>^^<^^<<<>v<^><<>^><v^<<^^>v>><^>><v^<<vv^<^>>>^v^>>^<v<v<v^><v^<v>v<>>^v<v>^>v>v>v<v>v^>^v^>>vv>v<<^v>>><<^<^<><<v>>>v^>>^v<^^>^v<><v>^^<><vv^v<<^><>^^^<^^vv<^<>^^>><^<<><<^^v<v<vv^><^vvv><>>vv<^<<<<^<>^>^vv>>\r\n<>^<v<^<<v^^<vv>^v^<^vv<^<<^<<^^<^vvv>^vvv>v^<>v^v^>><<<<<^^^^<<^<^vv<><v<<^^^<v<>>v^>v^>^vv>>^>^vv>vv^<<>><<vv^<<<>^>v<<^<>>^<^><v<^^>^<v^^>v<v^<>^><v<^^^^^v^>>>>^>v^<>v^^<vv^^v^^^v>><<><<^v^>>v^<^^<v><^<>v>^<^>><<^v<^v><v^^^^^^<<<^>^>>v>><<vv<v^^^v>>vv<<<><v<>^v^>>v<<>>><>v<>^^^<v<v^v^^^^><>>v<^vv><>>^^v>v><<>>^^^v<>>v<^>v^v<v^^^^^<^>v>vv<<v^><>vvvv^vv><^>^v^v<v<<^v>v<vv^<v<<<^><vvv><>^>^vv<^v<>vv^v><<<>><^<<<>v<^>vvv<v<^^v^><>v<^v^>v^<vv^>^<<v^^<vvv^<<><v>v><>^>^^<<^<><><v<^^^>v^^>>>>>v<<>><<v<<^<v<>v<><v<>>v>v^^^v>>>^^>v<<v>vvv>>v<>>><<>^<>>>^<^^>^>^^^vv^<^><vv<<v>v><v^^><vv<>^v<^<^<v>v<>v^v>v<^<<>^>^>^>v^>^v^^^>^^><<<v>>>>^^>^<><^v^v^>^vv><>>>^><v^<>^vvvv<<vv^^<<^><v^vvv^<^<^v>><>><v<v>v^v>><<^^<^^>vvv><>^><<^vvvvv<<><v^>^v>v^v>vvv<v<<>v^^^^>^>vvv<v<>^>^^v>^v<<v>>>>v>><>^^>v<>>>vvv^^><^>>>^^>v>^>>>v^<<v>v^vvv><^vv>^^>>><<>>v<v>v^>v<><<>vv>v^<>>v<v^>v^v<>v>>v<^><vv>v^v<><v<^v<<<><^><vv>>>^^v<v^v^>^^^<v<<v^<^<>v>^<v^v^<^<^v<<v^^<>><<<^>>^v>^<>><^><vv^<^<^^^><^v<>v^v^<^v^<^<v^<v<^^^>\r\nv<vv^v>>^^v^v^vvvvvvv^^vv^<>^v^<vv>vvv>^><v>v<^>vv><^<>v>^>^v^^<v<^<><^^>^>vvv^^>><>v<^><v>>v^>v>v^><>>v^>^<>>><>^<vv<^v^v^vv><>>^^<^vv^<<vv^>^vv^^<v<v<vv<^^<^<<^>><<^<v^^^<<<>^^v>^<>v^^>vv<^v<^v<<>v^v^vv<v>>>v><v^v^<v<<>v^<v><v<vv<<^^^><v^^<<<<><>vvv^>^v<<<<^v^>vvv<<>>v^^vv>>v^<v<<>>v<^>><v^<<^>^>vv>>>^^v^^vv<^<^^^<^<v^v^v^v^>v><^<v<>><v>>^<<^<><>><<<^>>^v^v^v<^vvv^vv<>vvv^^^<<>^v<v^><^^>vv<><v><>^<<<>>v<>^vv>^^^v^>v>>^v>>^>vvv<<<^<^<<<v^>v>>^^v^>vvv^<<^>^v<<<><^^><v<^<>^><<v^^^^<><^<><^v>^^<>v><<v<<>^<vv>>><v>v<^^<>^<>><>><^<^>>>v>^^<>^v^<^^<^v^>^v<v<^><^>>^v^^<^^<>>>><<^v>v^^<>^^<<>^<>v>v^v<v^<^v<>>^>v^<v><<^>v>><<v>^v^><^><v^<<^^<>^>>^<>>^>>^v^v^<<v<<>v<^>v^v<<>^<vv>>v^v^<<<^v>^^>><<vv>>^v>^>^v><^>^<><>^<vv^<v^<<>^^v<>^<>^^v^><v>v^<vvv>^<^v>>>^><<<^v<v^<v>^<<<<vvv>v<^v><^vv^<>v><>^v>v><>>v<^^vv^>>^>><vv<v<v^>><>v><v<vv<><>^^v>v>>>vvv><vv^>>>>^^<^^<v>^^^v<>^^v><<v<vv<<<^>^><><vv><>v>^v^>^<^v>vvvv<^><>>>v^<>v<^^<>^>^^<<v><<^>vv^vv<^v^><vvv<vv^>v>v^>v^v>v^<v^><<^^^>><<^^<>^>v>^>^<^><>\r\n>^>^^>v<^<^^<>>>^<<vvvvv^><v>^<><<<v>>^<^v^<v<v>>vv>><v<v^^<v<<^><v<v<>>>><><><^<>^v^<v^>v<<<>v<<vv^^^<<<v<^vv^^<><v^><>^vv>>^<><^<>>^<>vv^<<<v^<v>><<>^^>>>>>^vv^v>^^<v^>>>v>vv<<^<^<>>^v^^^>^^<>v^^>^>v<^<>^<^v^>v<v><<<^<v<^<>>^><>><<v<<v<><>^>>v<<vv<v^^<v^><>><><v<><<^v<>^^^<^>vv>>^<^><<>v^^v>v>><<v><<v>^>v>vvv>v<^v^<v^<v<v><v<v><<^^<<><v^<>>v<v^<><v>v<^<vv>v>^<<><v^<^>v>v<v<>^^>><^v>>>>>^<<<^>v^v<^>v>v><<v^<>^<>^v>>^<>^^v^^<>v<vv^<^<>>v^vvvv<^><<>v><v<vvv^<v>^^^^^<<v>>>><<<>>vv<^v>^v^>^<v>^v><>v^>>><><>><>>>^v^<<v<^v<v>vv<<v>><<<<>>v^>>v>><<>>^<<v>>>>>v^>^^<<><^>vv<<v^<vv^^v><><v>>^>>^^^>>v^>>v>^^^>v^<<>v>^v^<^<^>v^v^>vvvv^^<<>^v>v>><>^^>v>>v^v<^>^<<^vv^<^<vv<><<^>^><<<v<^<>>^>>>^v^<v><^><><v>>^<^>><^^>^^vv>^><^v<>>vvv^><v^v^<v<^v>vv<<><>^>^^^<^^<^v^^^^vv<v<><^<<^>^<^>vv^^<^^>^v^<vv>v^<^<v<v>^v>>v><v^><v^v<><vv>^<><v^^<v^<^<>>>>^^<^<^v<^^v^v<^v^<><v>^^>v<^vvv><<>vvv^v<<v<><^<<<<v<vvv>^>>v>>v><^><v<>>v>v<<<v<^<>>>^<>>>vv<<v<<>><^v^v^<vv^^v<<^>^^<^^vv>^v<<>v>v<^v^v>><<>vv<<>^><v><v<^>^^\r\n<v>v>^>^<v^vv^v^v<v>>^>vv<>^^v>^>>vv<v>v^<^v<>>>vv><^vv<^^vv^><>>>v<<^<v^<^>>^vv<<>v^v>>>^^>v^>^<<^vv^<<^><^<v^>>vvv^^><>v^<v<v<v<^^>^v><<<^>v<<<<><^^<v<>^^<<v>v^v<vv^^><<^^v>^^^^v^vv^<v^^vv<v><<^<>v^^><v^^v<>^>>v<v^>>v>vv<<^^>^vvvv<<<v<><<>v>>><><>v<<<>vv><>v<^>v<v>v<<^><>^<^^^vvv><v^<>vv<><>vv<>^>^vv<><^v>^^<^<^vvv^<v<><>^<>^vv^<>^^v><>^>v^><>v<>^^>^^^v^>^<><>^^<>>>v^<>v<vv<<^>^>^v^<><^^><<^<^><<<^<>^<v<>vv>v<><vvv<v<><<>^^<<>vvv^v<<v<<^<v<v<<^v><vv><v^><^v>>^<^^^v^<v^>v^>^v<>><^vv>>>v><<>>vv^v<<<><<<<><>^><<<>>v^<<<^^<>>^<^<^><v<v^^<>vv>><><><<>^v<vv>v>v^<<>v<<^<v<<v>v>^v>>^v^<<<^v>v^<v<^v^v^v>><<^v^<>^v<><^><^>vv><^><>>v>^v^>>>v<>><>^vvvvv<>^<^<v>v<^v>><>v><^^v^vv>v^>^v^<<vv>^^^<^>>>v^<vv<^v>v<<v<<<^<<<^^<^<>^vv><>^v>>>v<<v<<^v><^<v<v<<<<<>vvv^<>vv<><^>v<>^vv^^><><v<<^>v^<v^v>>^><^>^<v>^vv<<v^<>^><^vv<^v>>v<v^<<<><<<^vv>>v^>v^v>vvv>v^^^^^<>vv>^<vv<<^^<v^^^v><vv<^<<><^>^^<>v>>^>vv<<><>><^vv<>^>vv<vv<^v>v>>>v>v>^<^v<>v>^^^^^v^^^v^>^^^<v^<<^^^v^vvv>^v<>v^>>^>v<v<v^><^^^>v>v>v>^>>^<<<^";
            return (new Matrix<char>(Parser.ToMatrix<char>(data)), moves.Replace("\r\n", "").ToCharArray());
        }
        public static (Matrix<char> matrix, char[] moves) GetTrainingData()
        {
            var data = "##########\r\n#..O..O.O#\r\n#......O.#\r\n#.OO..O.O#\r\n#..O@..O.#\r\n#O#..O...#\r\n#O..O..O.#\r\n#.OO.O.OO#\r\n#....O...#\r\n##########";
            var moves = "<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^\r\nvvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v\r\n><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<\r\n<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^\r\n^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><\r\n^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^\r\n>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^\r\n<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>\r\n^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>\r\nv^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";
            return (new Matrix<char>(Parser.ToMatrix<char>(data)), moves.Replace("\r\n", "").ToCharArray());
        }
        public static (Matrix<char> matrix, char[] moves) GetSimpleTrainingData()
        {
            var data = "#######\r\n#...#.#\r\n#.....#\r\n#..OO@#\r\n#..O..#\r\n#.....#\r\n#######";
            var moves = "<vv<<^^<<^^";
            return (new Matrix<char>(Parser.ToMatrix<char>(data)), moves.Replace("\r\n", "").ToCharArray());
        }
    }
}