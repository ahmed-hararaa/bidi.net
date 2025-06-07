namespace Harara.Bidi;
// ignore_for_file, constant_identifier_names

/// The different canonical classes of Unicode characters.
class CanonicalClass(int value) {
  
  public int Value => value;
  
  public static CanonicalClass FromValue(int value)
  {
    return new CanonicalClass(value);
  }
    
  public bool IsShaddaPair => value >= 28 && value <= 35;

  /// Not Reordered (NR).
  /// Spacing, split, enclosing, reordrant, and Tibetan subjoined.
  public static readonly CanonicalClass NotReordered = new(0);

  /// Overlays and interior (OV).
  public static readonly CanonicalClass OverlaysInterior = new(1);

  /// Nuktas (NK).
  public static readonly CanonicalClass Nuktas = new(7);

  /// Hiragana/Katakana voicing marks
  public static readonly CanonicalClass Kv = new(8);

  /// Viramas (VR).
  public static readonly CanonicalClass Viramas = new(9);

  /// General class level 10.
  public static readonly CanonicalClass Class10 = new(10);

  /// General class level 11.

  public static readonly CanonicalClass Class11 = new(11);

  /// General class level 12.

  public static readonly CanonicalClass Class12 = new(12);

  /// General class level 13.

  public static readonly CanonicalClass Class13 = new(13);

  /// General class level 14.

  public static readonly CanonicalClass Class14 = new(14);

  /// General class level 15.

  public static readonly CanonicalClass Class15 = new(15);

  /// General class level 16.

  public static readonly CanonicalClass Class16 = new(16);

  /// General class level 17.

  public static readonly CanonicalClass Class17 = new(17);

  /// General class level 18.

  public static readonly CanonicalClass Class18 = new(18);

  /// General class level 19.

  public static readonly CanonicalClass Class19 = new(19);

  /// General class level 20.

  public static readonly CanonicalClass Class20 = new(20);

  /// General class level 21.

  public static readonly CanonicalClass Class21 = new(21);

  /// General class level 22.

  public static readonly CanonicalClass Class22 = new(22);

  /// General class level 23.

  public static readonly CanonicalClass Class23 = new(23);

  /// General class level 24.

  public static readonly CanonicalClass Class24 = new(24);

  /// General class level 25.

  public static readonly CanonicalClass Class25 = new(25);

  /// General class level 26.

  public static readonly CanonicalClass Class26 = new(26);

  /// General class level 27.

  public static readonly CanonicalClass Class27 = new(27);

  /// General class level 28.

  public static readonly CanonicalClass Class28 = new(28);

  /// General class level 29.

  public static readonly CanonicalClass Class29 = new(29);

  /// General class level 30.

  public static readonly CanonicalClass Class30 = new(30);

  /// General class level 31.

  public static readonly CanonicalClass Class31 = new(31);

  /// General class level 32.

  public static readonly CanonicalClass Class32 = new(32);

  /// General class level 33.

  public static readonly CanonicalClass Class33 = new(33);

  /// General class level 34.

  public static readonly CanonicalClass Class34 = new(34);

  /// General class level 35.

  public static readonly CanonicalClass Class35 = new(35);

  /// General class level 36.

  public static readonly CanonicalClass Class36 = new(36);

  /// General class level 37.

  // public static _UnicodeCanonicalClass CLASS_37 = _Unicodenew CanonicalClass(37);

  /// General class level 38.

  // public static _UnicodeCanonicalClass CLASS_38 = _Unicodenew CanonicalClass(38);

  /// General class level 39.

  // public static _UnicodeCanonicalClass CLASS_39 = _Unicodenew CanonicalClass(39);

  /// General class level 40.

  // public static _UnicodeCanonicalClass CLASS_40 = _Unicodenew CanonicalClass(40);

  /// General class level 41.

  // public static _UnicodeCanonicalClass CLASS_41 = _Unicodenew CanonicalClass(41);

  /// General class level 42.

  // public static _UnicodeCanonicalClass CLASS_42 = _Unicodenew CanonicalClass(42);

  /// General class level 43.

  // public static _UnicodeCanonicalClass CLASS_43 = _Unicodenew CanonicalClass(43);

  /// General class level 44.

  // public static _UnicodeCanonicalClass CLASS_44 = _Unicodenew CanonicalClass(44);

  /// General class level 45.

  // public static _UnicodeCanonicalClass CLASS_45 = _Unicodenew CanonicalClass(45);

  /// General class level 46.

  // public static _UnicodeCanonicalClass CLASS_46 = _Unicodenew CanonicalClass(46);

  /// General class level 47.

  // public static _UnicodeCanonicalClass CLASS_47 = _Unicodenew CanonicalClass(47);

  /// General class level 48.

  // public static _UnicodeCanonicalClass CLASS_48 = _Unicodenew CanonicalClass(48);

  /// General class level 49.

  // public static _UnicodeCanonicalClass CLASS_49 = _Unicodenew CanonicalClass(49);

  /// General class level 50.

  // public static _UnicodeCanonicalClass CLASS_50 = _Unicodenew CanonicalClass(50);

  /// General class level 51.

  // public static _UnicodeCanonicalClass CLASS_51 = _Unicodenew CanonicalClass(51);

  /// General class level 52.

  // public static _UnicodeCanonicalClass CLASS_52 = _Unicodenew CanonicalClass(52);

  /// General class level 53.

  // public static _UnicodeCanonicalClass CLASS_53 = _Unicodenew CanonicalClass(53);

  /// General class level 54.

  // public static _UnicodeCanonicalClass CLASS_54 = _Unicodenew CanonicalClass(54);

  /// General class level 55.

  // public static _UnicodeCanonicalClass CLASS_55 = _Unicodenew CanonicalClass(55);

  /// General class level 56.

  // public static _UnicodeCanonicalClass CLASS_56 = _Unicodenew CanonicalClass(56);

  /// General class level 57.

  // public static _UnicodeCanonicalClass CLASS_57 = _Unicodenew CanonicalClass(57);

  /// General class level 58.

  // public static _UnicodeCanonicalClass CLASS_58 = _Unicodenew CanonicalClass(58);

  /// General class level 59.

  // public static _UnicodeCanonicalClass CLASS_59 = _Unicodenew CanonicalClass(59);

  /// General class level 60.

  // public static _UnicodeCanonicalClass CLASS_60 = _Unicodenew CanonicalClass(60);

  /// General class level 61.

  // public static _UnicodeCanonicalClass CLASS_61 = _Unicodenew CanonicalClass(61);

  /// General class level 62.

  // public static _UnicodeCanonicalClass CLASS_62 = _Unicodenew CanonicalClass(62);

  /// General class level 63.

  // public static _UnicodeCanonicalClass CLASS_63 = _Unicodenew CanonicalClass(63);

  /// General class level 64.

  // public static _UnicodeCanonicalClass CLASS_64 = _Unicodenew CanonicalClass(64);

  /// General class level 65.

  // public static _UnicodeCanonicalClass CLASS_65 = _Unicodenew CanonicalClass(65);

  /// General class level 66.

  // public static _UnicodeCanonicalClass CLASS_66 = _Unicodenew CanonicalClass(66);

  /// General class level 67.

  // public static _UnicodeCanonicalClass CLASS_67 = _Unicodenew CanonicalClass(67);

  /// General class level 68.

  // public static _UnicodeCanonicalClass CLASS_68 = _Unicodenew CanonicalClass(68);

  /// General class level 69.

  // public static _UnicodeCanonicalClass CLASS_69 = _Unicodenew CanonicalClass(69);

  /// General class level 70.

  // public static _UnicodeCanonicalClass CLASS_70 = _Unicodenew CanonicalClass(70);

  /// General class level 71.

  // public static _UnicodeCanonicalClass CLASS_71 = _Unicodenew CanonicalClass(71);

  /// General class level 72.

  // public static _UnicodeCanonicalClass CLASS_72 = _Unicodenew CanonicalClass(72);

  /// General class level 73.

  // public static _UnicodeCanonicalClass CLASS_73 = _Unicodenew CanonicalClass(73);

  /// General class level 74.

  // public static _UnicodeCanonicalClass CLASS_74 = _Unicodenew CanonicalClass(74);

  /// General class level 75.

  // public static _UnicodeCanonicalClass CLASS_75 = _Unicodenew CanonicalClass(75);

  /// General class level 76.

  // public static _UnicodeCanonicalClass CLASS_76 = _Unicodenew CanonicalClass(76);

  /// General class level 77.

  // public static _UnicodeCanonicalClass CLASS_77 = _Unicodenew CanonicalClass(77);

  /// General class level 78.

  // public static _UnicodeCanonicalClass CLASS_78 = _Unicodenew CanonicalClass(78);

  /// General class level 79.

  // public static _UnicodeCanonicalClass CLASS_79 = _Unicodenew CanonicalClass(79);

  /// General class level 80.

  // public static _UnicodeCanonicalClass CLASS_80 = _Unicodenew CanonicalClass(80);

  /// General class level 81.

  // public static _UnicodeCanonicalClass CLASS_81 = _Unicodenew CanonicalClass(81);

  /// General class level 82.

  // public static _UnicodeCanonicalClass CLASS_82 = _Unicodenew CanonicalClass(82);

  /// General class level 83.

  // public static _UnicodeCanonicalClass CLASS_83 = _Unicodenew CanonicalClass(83);

  /// General class level 84.

  public static readonly CanonicalClass Class84 = new(84);

  /// General class level 85.

  // public static _UnicodeCanonicalClass CLASS_85 = _Unicodenew CanonicalClass(85);

  /// General class level 86.

  // public static _UnicodeCanonicalClass CLASS_86 = _Unicodenew CanonicalClass(86);

  /// General class level 87.

  // public static _UnicodeCanonicalClass CLASS_87 = _Unicodenew CanonicalClass(87);

  /// General class level 88.

  // public static _UnicodeCanonicalClass CLASS_88 = _Unicodenew CanonicalClass(88);

  /// General class level 89.

  // public static _UnicodeCanonicalClass CLASS_89 = _Unicodenew CanonicalClass(89);

  /// General class level 90.

  // public static _UnicodeCanonicalClass CLASS_90 = _Unicodenew CanonicalClass(90);

  /// General class level 91.

  public static readonly CanonicalClass Class91 = new(91);

  /// General class level 92.

  // public static _UnicodeCanonicalClass CLASS_92 = _Unicodenew CanonicalClass(92);

  /// General class level 93.

  // public static _UnicodeCanonicalClass CLASS_93 = _Unicodenew CanonicalClass(93);

  /// General class level 94.

  // public static _UnicodeCanonicalClass CLASS_94 = _Unicodenew CanonicalClass(94);

  /// General class level 95.

  // public static _UnicodeCanonicalClass CLASS_95 = _Unicodenew CanonicalClass(95);

  /// General class level 96.

  // public static _UnicodeCanonicalClass CLASS_96 = _Unicodenew CanonicalClass(96);

  /// General class level 97.

  // public static _UnicodeCanonicalClass CLASS_97 = _Unicodenew CanonicalClass(97);

  /// General class level 98.

  // public static _UnicodeCanonicalClass CLASS_98 = _Unicodenew CanonicalClass(98);

  /// General class level 99.

  // public static _UnicodeCanonicalClass CLASS_99 = _Unicodenew CanonicalClass(99);

  /// General class level 100.

  // public static _UnicodeCanonicalClass CLASS_100 = _Unicodenew CanonicalClass(100);

  /// General class level 101.

  // public static _UnicodeCanonicalClass CLASS_101 = _Unicodenew CanonicalClass(101);

  /// General class level 102.

  // public static _UnicodeCanonicalClass CLASS_102 = _Unicodenew CanonicalClass(102);

  /// General class level 103.

  public static readonly CanonicalClass Class103 = new(103);

  /// General class level 104.

  // public static _UnicodeCanonicalClass CLASS_104 = _Unicodenew CanonicalClass(104);

  /// General class level 105.

  // public static _UnicodeCanonicalClass CLASS_105 = _Unicodenew CanonicalClass(105);

  /// General class level 106.

  // public static _UnicodeCanonicalClass CLASS_106 = _Unicodenew CanonicalClass(106);

  /// General class level 107.

  public static readonly CanonicalClass Class107 = new(107);

  /// General class level 108.

  // public static _UnicodeCanonicalClass CLASS_108 = _Unicodenew CanonicalClass(108);

  /// General class level 109.

  // public static _UnicodeCanonicalClass CLASS_109 = _Unicodenew CanonicalClass(109);

  /// General class level 110.

  // public static _UnicodeCanonicalClass CLASS_110 = _Unicodenew CanonicalClass(110);

  /// General class level 111.

  // public static _UnicodeCanonicalClass CLASS_111 = _Unicodenew CanonicalClass(111);

  /// General class level 112.

  // public static _UnicodeCanonicalClass CLASS_112 = _Unicodenew CanonicalClass(112);

  /// General class level 113.

  // public static _UnicodeCanonicalClass CLASS_113 = _Unicodenew CanonicalClass(113);

  /// General class level 114.

  // public static _UnicodeCanonicalClass CLASS_114 = _Unicodenew CanonicalClass(114);

  /// General class level 115.

  // public static _UnicodeCanonicalClass CLASS_115 = _Unicodenew CanonicalClass(115);

  /// General class level 116.

  // public static _UnicodeCanonicalClass CLASS_116 = _Unicodenew CanonicalClass(116);

  /// General class level 117.

  // public static _UnicodeCanonicalClass CLASS_117 = _Unicodenew CanonicalClass(117);

  /// General class level 118.

  public static readonly CanonicalClass Class118 = new(118);

  /// General class level 119.

  // public static _UnicodeCanonicalClass CLASS_119 = _Unicodenew CanonicalClass(119);

  /// General class level 120.

  // public static _UnicodeCanonicalClass CLASS_120 = _Unicodenew CanonicalClass(120);

  /// General class level 121.

  // public static _UnicodeCanonicalClass CLASS_121 = _Unicodenew CanonicalClass(121);

  /// General class level 122.

  // public static _UnicodeCanonicalClass CLASS_122 = _Unicodenew CanonicalClass(122);

  /// General class level 123.

  // public static _UnicodeCanonicalClass CLASS_123 = _Unicodenew CanonicalClass(123);

  /// General class level 124.

  // public static _UnicodeCanonicalClass CLASS_124 = _Unicodenew CanonicalClass(124);

  /// General class level 125.

  // public static _UnicodeCanonicalClass CLASS_125 = _Unicodenew CanonicalClass(125);

  /// General class level 126.

  // public static _UnicodeCanonicalClass CLASS_126 = _Unicodenew CanonicalClass(126);

  /// General class level 127.

  // public static _UnicodeCanonicalClass CLASS_127 = _Unicodenew CanonicalClass(127);

  /// General class level 128.

  // public static _UnicodeCanonicalClass CLASS_128 = _Unicodenew CanonicalClass(128);

  /// General class level 129.

  public static readonly CanonicalClass Class129 = new(129);

  /// General class level 130.

  public static readonly CanonicalClass Class130 = new(130);

  /// General class level 131.

  // public static _UnicodeCanonicalClass CLASS_131 = _Unicodenew CanonicalClass(131);

  /// General class level 132.

  public static readonly CanonicalClass Class132 = new(132);

  /// General class level 133.

  // public static _UnicodeCanonicalClass CLASS_133 = _Unicodenew CanonicalClass(133);

  /// General class level 134.

  // public static _UnicodeCanonicalClass CLASS_134 = _Unicodenew CanonicalClass(134);

  /// General class level 135.

  // public static _UnicodeCanonicalClass CLASS_135 = _Unicodenew CanonicalClass(135);

  /// General class level 136.

  // public static _UnicodeCanonicalClass CLASS_136 = _Unicodenew CanonicalClass(136);

  /// General class level 137.

  // public static _UnicodeCanonicalClass CLASS_137 = _Unicodenew CanonicalClass(137);

  /// General class level 138.

  // public static _UnicodeCanonicalClass CLASS_138 = _Unicodenew CanonicalClass(138);

  /// General class level 139.

  // public static _UnicodeCanonicalClass CLASS_139 = _Unicodenew CanonicalClass(139);

  /// General class level 140.

  // public static _UnicodeCanonicalClass CLASS_140 = _Unicodenew CanonicalClass(140);

  /// General class level 141.

  // public static _UnicodeCanonicalClass CLASS_141 = _Unicodenew CanonicalClass(141);

  /// General class level 142.

  // public static _UnicodeCanonicalClass CLASS_142 = _Unicodenew CanonicalClass(142);

  /// General class level 143.

  // public static _UnicodeCanonicalClass CLASS_143 = _Unicodenew CanonicalClass(143);

  /// General class level 144.

  // public static _UnicodeCanonicalClass CLASS_144 = _Unicodenew CanonicalClass(144);

  /// General class level 145.

  // public static _UnicodeCanonicalClass CLASS_145 = _Unicodenew CanonicalClass(145);

  /// General class level 146.

  // public static _UnicodeCanonicalClass CLASS_146 = _Unicodenew CanonicalClass(146);

  /// General class level 147.

  // public static _UnicodeCanonicalClass CLASS_147 = _Unicodenew CanonicalClass(147);

  /// General class level 148.

  // public static _UnicodeCanonicalClass CLASS_148 = _Unicodenew CanonicalClass(148);

  /// General class level 149.

  // public static _UnicodeCanonicalClass CLASS_149 = _Unicodenew CanonicalClass(149);

  /// General class level 150.

  // public static _UnicodeCanonicalClass CLASS_150 = _Unicodenew CanonicalClass(150);

  /// General class level 151.

  // public static _UnicodeCanonicalClass CLASS_151 = _Unicodenew CanonicalClass(151);

  /// General class level 152.

  // public static _UnicodeCanonicalClass CLASS_152 = _Unicodenew CanonicalClass(152);

  /// General class level 153.

  // public static _UnicodeCanonicalClass CLASS_153 = _Unicodenew CanonicalClass(153);

  /// General class level 154.

  // public static _UnicodeCanonicalClass CLASS_154 = _Unicodenew CanonicalClass(154);

  /// General class level 155.

  // public static _UnicodeCanonicalClass CLASS_155 = _Unicodenew CanonicalClass(155);

  /// General class level 156.

  // public static _UnicodeCanonicalClass CLASS_156 = _Unicodenew CanonicalClass(156);

  /// General class level 157.

  // public static _UnicodeCanonicalClass CLASS_157 = _Unicodenew CanonicalClass(157);

  /// General class level 158.

  // public static _UnicodeCanonicalClass CLASS_158 = _Unicodenew CanonicalClass(158);

  /// General class level 159.

  // public static _UnicodeCanonicalClass CLASS_159 = _Unicodenew CanonicalClass(159);

  /// General class level 160.

  // public static _UnicodeCanonicalClass CLASS_160 = _Unicodenew CanonicalClass(160);

  /// General class level 161.

  // public static _UnicodeCanonicalClass CLASS_161 = _Unicodenew CanonicalClass(161);

  /// General class level 162.

  public static readonly CanonicalClass Class162 = new(122);

  /// General class level 163.

  // public static _UnicodeCanonicalClass CLASS_163 = _Unicodenew CanonicalClass(166);

  /// General class level 164.

  // public static _UnicodeCanonicalClass CLASS_164 = _Unicodenew CanonicalClass(164);

  /// General class level 165.

  // public static _UnicodeCanonicalClass CLASS_165 = _Unicodenew CanonicalClass(165);

  /// General class level 166.

  // public static _UnicodeCanonicalClass CLASS_166 = _Unicodenew CanonicalClass(166);

  /// General class level 167.

  // public static _UnicodeCanonicalClass CLASS_167 = _Unicodenew CanonicalClass(167);

  /// General class level 168.

  // public static _UnicodeCanonicalClass CLASS_168 = _Unicodenew CanonicalClass(168);

  /// General class level 169.

  // public static _UnicodeCanonicalClass CLASS_169 = _Unicodenew CanonicalClass(169);

  /// General class level 170.

  // public static _UnicodeCanonicalClass CLASS_170 = _Unicodenew CanonicalClass(170);

  /// General class level 171.

  // public static _UnicodeCanonicalClass CLASS_171 = _Unicodenew CanonicalClass(171);

  /// General class level 172.

  // public static _UnicodeCanonicalClass CLASS_172 = _Unicodenew CanonicalClass(172);

  /// General class level 173.

  // public static _UnicodeCanonicalClass CLASS_173 = _Unicodenew CanonicalClass(173);

  /// General class level 174.

  // public static _UnicodeCanonicalClass CLASS_174 = _Unicodenew CanonicalClass(174);

  /// General class level 175.

  // public static _UnicodeCanonicalClass CLASS_175 = _Unicodenew CanonicalClass(175);

  /// General class level 176.

  // public static _UnicodeCanonicalClass CLASS_176 = _Unicodenew CanonicalClass(176);

  /// General class level 177.

  // public static _UnicodeCanonicalClass CLASS_177 = _Unicodenew CanonicalClass(177);

  /// General class level 178.

  // public static _UnicodeCanonicalClass CLASS_178 = _Unicodenew CanonicalClass(178);

  /// General class level 179.

  // public static _UnicodeCanonicalClass CLASS_179 = _Unicodenew CanonicalClass(179);

  /// General class level 180.

  // public static _UnicodeCanonicalClass CLASS_180 = _Unicodenew CanonicalClass(180);

  /// General class level 181.

  // public static _UnicodeCanonicalClass CLASS_181 = _Unicodenew CanonicalClass(181);

  /// General class level 182.

  // public static _UnicodeCanonicalClass CLASS_182 = _Unicodenew CanonicalClass(182);

  /// General class level 183.

  // public static _UnicodeCanonicalClass CLASS_183 = _Unicodenew CanonicalClass(183);

  /// General class level 184.

  // public static _UnicodeCanonicalClass CLASS_184 = _Unicodenew CanonicalClass(184);

  /// General class level 185.

  // public static _UnicodeCanonicalClass CLASS_185 = _Unicodenew CanonicalClass(185);

  /// General class level 186.

  // public static _UnicodeCanonicalClass CLASS_186 = _Unicodenew CanonicalClass(186);

  /// General class level 187.

  // public static _UnicodeCanonicalClass CLASS_187 = _Unicodenew CanonicalClass(187);

  /// General class level 188.

  // public static _UnicodeCanonicalClass CLASS_188 = _Unicodenew CanonicalClass(188);

  /// General class level 189.

  // public static _UnicodeCanonicalClass CLASS_189 = _Unicodenew CanonicalClass(189);

  /// General class level 190.

  // public static _UnicodeCanonicalClass CLASS_190 = _Unicodenew CanonicalClass(190);

  /// General class level 191.

  // public static _UnicodeCanonicalClass CLASS_191 = _Unicodenew CanonicalClass(191);

  /// General class level 192.

  // public static _UnicodeCanonicalClass CLASS_192 = _Unicodenew CanonicalClass(192);

  /// General class level 193.

  // public static _UnicodeCanonicalClass CLASS_193 = _Unicodenew CanonicalClass(193);

  /// General class level 194.

  // public static _UnicodeCanonicalClass CLASS_194 = _Unicodenew CanonicalClass(194);

  /// General class level 195.

  // public static _UnicodeCanonicalClass CLASS_195 = _Unicodenew CanonicalClass(195);

  /// General class level 196.

  // public static _UnicodeCanonicalClass CLASS_196 = _Unicodenew CanonicalClass(196);

  /// General class level 197.

  // public static _UnicodeCanonicalClass CLASS_197 = _Unicodenew CanonicalClass(197);

  /// General class level 198.

  // public static _UnicodeCanonicalClass CLASS_198 = _Unicodenew CanonicalClass(198);

  /// General class level 199.

  // public static _UnicodeCanonicalClass CLASS_199 = _Unicodenew CanonicalClass(199);

  ///Attached Below Left
  // public static _UnicodeCanonicalClass ATBL = _Unicodenew CanonicalClass(200);

  ///Attached Below
  public static readonly CanonicalClass Atb = new(202);

  ///Attached Below Right
  // public static _UnicodeCanonicalClass ATBR = _Unicodenew CanonicalClass(204);

  ///Attached Left
  ///Reordrant around single base character.
  // public static _UnicodeCanonicalClass ATL = _Unicodenew CanonicalClass(208);

  ///Attached Right
  // public static _UnicodeCanonicalClass ATR = _Unicodenew CanonicalClass(210);

  ///Attached Above Left
  // public static _UnicodeCanonicalClass ATAL = _Unicodenew CanonicalClass(212);

  ///Attached Above
  public static readonly CanonicalClass Ata = new(214);

  ///Attached Above Right
  public static readonly CanonicalClass Atar = new(216);

  ///Below Left
  public static readonly CanonicalClass Bl = new(218);

  /// Below (B).
  public static readonly CanonicalClass Below = new(220);

  ///Below Right
  public static readonly CanonicalClass Br = new(222);

  ///Left
  ///Reordrant around single base character.
  public static readonly CanonicalClass L = new(224);

  ///Right
  // public static _UnicodeCanonicalClass R = _Unicodenew CanonicalClass(226);

  ///Above Left
  public static readonly CanonicalClass Al = new(228);

  /// Above (A).
  public static readonly CanonicalClass Above = new(230);

  ///Above Right
  public static readonly CanonicalClass Ar = new(232);

  ///Double Below
  public static readonly CanonicalClass Db = new(233);

  ///Double Above
  public static readonly CanonicalClass Da = new(234);

  ///Iota Subscript
  public static readonly CanonicalClass Is = new(240);
  
  private static readonly Dictionary<int, CanonicalClass> CanonicalClassMap = new()
{
    {0x0300, Above},
    {0x0301, Above},
    {0x0302, Above},
    {0x0303, Above},
    {0x0304, Above},
    {0x0305, Above},
    {0x0306, Above},
    {0x0307, Above},
    {0x0308, Above},
    {0x0309, Above},
    {0x030A, Above},
    {0x030B, Above},
    {0x030C, Above},
    {0x030D, Above},
    {0x030E, Above},
    {0x030F, Above},
    {0x0310, Above},
    {0x0311, Above},
    {0x0312, Above},
    {0x0313, Above},
    {0x0314, Above},
    {0x0315, Ar},
    {0x0316, Below},
    {0x0317, Below},
    {0x0318, Below},
    {0x0319, Below},
    {0x031A, Ar},
    {0x031B, Atar},
    {0x031C, Below},
    {0x031D, Below},
    {0x031E, Below},
    {0x031F, Below},
    {0x0320, Below},
    {0x0321, Atb},
    {0x0322, Atb},
    {0x0323, Below},
    {0x0324, Below},
    {0x0325, Below},
    {0x0326, Below},
    {0x0327, Atb},
    {0x0328, Atb},
    {0x0329, Below},
    {0x032A, Below},
    {0x032B, Below},
    {0x032C, Below},
    {0x032D, Below},
    {0x032E, Below},
    {0x032F, Below},
    {0x0330, Below},
    {0x0331, Below},
    {0x0332, Below},
    {0x0333, Below},
    {0x0334, OverlaysInterior},
    {0x0335, OverlaysInterior},
    {0x0336, OverlaysInterior},
    {0x0337, OverlaysInterior},
    {0x0338, OverlaysInterior},
    {0x0339, Below},
    {0x033A, Below},
    {0x033B, Below},
    {0x033C, Below},
    {0x033D, Above},
    {0x033E, Above},
    {0x033F, Above},
    {0x0340, Above},
    {0x0341, Above},
    {0x0342, Above},
    {0x0343, Above},
    {0x0344, Above},
    {0x0345, Is},
    {0x0346, Above},
    {0x0347, Below},
    {0x0348, Below},
    {0x0349, Below},
    {0x034A, Above},
    {0x034B, Above},
    {0x034C, Above},
    {0x034D, Below},
    {0x034E, Below},
    {0x0350, Above},
    {0x0351, Above},
    {0x0352, Above},
    {0x0353, Below},
    {0x0354, Below},
    {0x0355, Below},
    {0x0356, Below},
    {0x0357, Above},
    {0x0358, Ar},
    {0x0359, Below},
    {0x035A, Below},
    {0x035B, Above},
    {0x035C, Db},
    {0x035D, Da},
    {0x035E, Da},
    {0x035F, Db},
    {0x0360, Da},
    {0x0361, Da},
    {0x0362, Db},
    {0x0363, Above},
    {0x0364, Above},
    {0x0365, Above},
    {0x0366, Above},
    {0x0367, Above},
    {0x0368, Above},
    {0x0369, Above},
    {0x036A, Above},
    {0x036B, Above},
    {0x036C, Above},
    {0x036D, Above},
    {0x036E, Above},
    {0x036F, Above},
    {0x0483, Above},
    {0x0484, Above},
    {0x0485, Above},
    {0x0486, Above},
    {0x0487, Above},
    {0x0591, Below},
    {0x0592, Above},
    {0x0593, Above},
    {0x0594, Above},
    {0x0595, Above},
    {0x0596, Below},
    {0x0597, Above},
    {0x0598, Above},
    {0x0599, Above},
    {0x059A, Br},
    {0x059B, Below},
    {0x059C, Above},
    {0x059D, Above},
    {0x059E, Above},
    {0x059F, Above},
    {0x05A0, Above},
    {0x05A1, Above},
    {0x05A2, Below},
    {0x05A3, Below},
    {0x05A4, Below},
    {0x05A5, Below},
    {0x05A6, Below},
    {0x05A7, Below},
    {0x05A8, Above},
    {0x05A9, Above},
    {0x05AA, Below},
    {0x05AB, Above},
    {0x05AC, Above},
    {0x05AD, Br},
    {0x05AE, Al},
    {0x05AF, Above},
    {0x05B0, Class10},
    {0x05B1, Class11},
    {0x05B2, Class12},
    {0x05B3, Class13},
    {0x05B4, Class14},
    {0x05B5, Class15},
    {0x05B6, Class16},
    {0x05B7, Class17},
    {0x05B8, Class18},
    {0x05B9, Class19},
    {0x05BA, Class19},
    {0x05BB, Class20},
    {0x05BC, Class21},
    {0x05BD, Class22},
    {0x05BF, Class23},
    {0x05C1, Class24},
    {0x05C2, Class25},
    {0x05C4, Above},
    {0x05C5, Below},
    {0x05C7, Class18},
    {0x0610, Above},
    {0x0611, Above},
    {0x0612, Above},
    {0x0613, Above},
    {0x0614, Above},
    {0x0615, Above},
    {0x0616, Above},
    {0x0617, Above},
    {0x0618, Class30},
    {0x0619, Class31},
    {0x061A, Class32},
    {0x064B, Class27},
    {0x064C, Class28},
    {0x064D, Class29},
    {0x064E, Class30},
    {0x064F, Class31},
    {0x0650, Class32},
    {0x0651, Class33},
    {0x0652, Class34},
    {0x0653, Above},
    {0x0654, Above},
    {0x0655, Below},
    {0x0656, Below},
    {0x0657, Above},
    {0x0658, Above},
    {0x0659, Above},
    {0x065A, Above},
    {0x065B, Above},
    {0x065C, Below},
    {0x065D, Above},
    {0x065E, Above},
    {0x065F, Below},
    {0x0670, Class35},
    {0x06D6, Above},
    {0x06D7, Above},
    {0x06D8, Above},
    {0x06D9, Above},
    {0x06DA, Above},
    {0x06DB, Above},
    {0x06DC, Above},
    {0x06DF, Above},
    {0x06E0, Above},
    {0x06E1, Above},
    {0x06E2, Above},
    {0x06E3, Below},
    {0x06E4, Above},
    {0x06E7, Above},
    {0x06E8, Above},
    {0x06EA, Below},
    {0x06EB, Above},
    {0x06EC, Above},
    {0x06ED, Below},
    {0x0711, Class36},
    {0x0730, Above},
    {0x0731, Below},
    {0x0732, Above},
    {0x0733, Above},
    {0x0734, Below},
    {0x0735, Above},
    {0x0736, Above},
    {0x0737, Below},
    {0x0738, Below},
    {0x0739, Below},
    {0x073A, Above},
    {0x073B, Below},
    {0x073C, Below},
    {0x073D, Above},
    {0x073E, Below},
    {0x073F, Above},
    {0x0740, Above},
    {0x0741, Above},
    {0x0742, Below},
    {0x0743, Above},
    {0x0744, Below},
    {0x0745, Above},
    {0x0746, Below},
    {0x0747, Above},
    {0x0748, Below},
    {0x0749, Above},
    {0x074A, Above},
    {0x07EB, Above},
    {0x07EC, Above},
    {0x07ED, Above},
    {0x07EE, Above},
    {0x07EF, Above},
    {0x07F0, Above},
    {0x07F1, Above},
    {0x07F2, Below},
    {0x07F3, Above},
    {0x0816, Above},
    {0x0817, Above},
    {0x0818, Above},
    {0x0819, Above},
    {0x081B, Above},
    {0x081C, Above},
    {0x081D, Above},
    {0x081E, Above},
    {0x081F, Above},
    {0x0820, Above},
    {0x0821, Above},
    {0x0822, Above},
    {0x0823, Above},
    {0x0825, Above},
    {0x0826, Above},
    {0x0827, Above},
    {0x0829, Above},
    {0x082A, Above},
    {0x082B, Above},
    {0x082C, Above},
    {0x082D, Above},
    {0x0859, Below},
    {0x085A, Below},
    {0x085B, Below},
    {0x08E4, Above},
    {0x08E5, Above},
    {0x08E6, Below},
    {0x08E7, Above},
    {0x08E8, Above},
    {0x08E9, Below},
    {0x08EA, Above},
    {0x08EB, Above},
    {0x08EC, Above},
    {0x08ED, Below},
    {0x08EE, Below},
    {0x08EF, Below},
    {0x08F0, Class27},
    {0x08F1, Class28},
    {0x08F2, Class29},
    {0x08F3, Above},
    {0x08F4, Above},
    {0x08F5, Above},
    {0x08F6, Below},
    {0x08F7, Above},
    {0x08F8, Above},
    {0x08F9, Below},
    {0x08FA, Below},
    {0x08FB, Above},
    {0x08FC, Above},
    {0x08FD, Above},
    {0x08FE, Above},
    {0x08FF, Above},
    {0x093C, Nuktas},
    {0x094D, Viramas},
    {0x0951, Above},
    {0x0952, Below},
    {0x0953, Above},
    {0x0954, Above},
    {0x09BC, Nuktas},
    {0x09CD, Viramas},
    {0x0A3C, Nuktas},
    {0x0A4D, Viramas},
    {0x0ABC, Nuktas},
    {0x0ACD, Viramas},
    {0x0B3C, Nuktas},
    {0x0B4D, Viramas},
    {0x0BCD, Viramas},
    {0x0C4D, Viramas},
    {0x0C55, Class84},
    {0x0C56, Class91},
    {0x0CBC, Nuktas},
    {0x0CCD, Viramas},
    {0x0D4D, Viramas},
    {0x0DCA, Viramas},
    {0x0E38, Class103},
    {0x0E39, Class103},
    {0x0E3A, Viramas},
    {0x0E48, Class107},
    {0x0E49, Class107},
    {0x0E4A, Class107},
    {0x0E4B, Class107},
    {0x0EB8, Class118},
    {0x0EB9, Class118},
    {0x0EC8, Class162},
    {0x0EC9, Class162},
    {0x0ECA, Class162},
    {0x0ECB, Class162},
    {0x0F18, Below},
    {0x0F19, Below},
    {0x0F35, Below},
    {0x0F37, Below},
    {0x0F39, Atar},
    {0x0F71, Class129},
    {0x0F72, Class130},
    {0x0F74, Class132},
    {0x0F7A, Class130},
    {0x0F7B, Class130},
    {0x0F7C, Class130},
    {0x0F7D, Class130},
    {0x0F80, Class130},
    {0x0F82, Above},
    {0x0F83, Above},
    {0x0F84, Viramas},
    {0x0F86, Above},
    {0x0F87, Above},
    {0x0FC6, Below},
    {0x1037, Nuktas},
    {0x1039, Viramas},
    {0x103A, Viramas},
    {0x108D, Below},
    {0x135D, Above},
    {0x135E, Above},
    {0x135F, Above},
    {0x1714, Viramas},
    {0x1734, Viramas},
    {0x17D2, Viramas},
    {0x17DD, Above},
    {0x18A9, Al},
    {0x1939, Br},
    {0x193A, Above},
    {0x193B, Below},
    {0x1A17, Above},
    {0x1A18, Below},
    {0x1A60, Viramas},
    {0x1A75, Above},
    {0x1A76, Above},
    {0x1A77, Above},
    {0x1A78, Above},
    {0x1A79, Above},
    {0x1A7A, Above},
    {0x1A7B, Above},
    {0x1A7C, Above},
    {0x1A7F, Below},
    {0x1AB0, Above},
    {0x1AB1, Above},
    {0x1AB2, Above},
    {0x1AB3, Above},
    {0x1AB4, Above},
    {0x1AB5, Below},
    {0x1AB6, Below},
    {0x1AB7, Below},
    {0x1AB8, Below},
    {0x1AB9, Below},
    {0x1ABA, Below},
    {0x1ABB, Above},
    {0x1ABC, Above},
    {0x1ABD, Below},
    {0x1B34, Nuktas},
    {0x1B44, Viramas},
    {0x1B6B, Above},
    {0x1B6C, Below},
    {0x1B6D, Above},
    {0x1B6E, Above},
    {0x1B6F, Above},
    {0x1B70, Above},
    {0x1B71, Above},
    {0x1B72, Above},
    {0x1B73, Above},
    {0x1BAA, Viramas},
    {0x1BAB, Viramas},
    {0x1BE6, Nuktas},
    {0x1BF2, Viramas},
    {0x1BF3, Viramas},
    {0x1C37, Nuktas},
    {0x1CD0, Above},
    {0x1CD1, Above},
    {0x1CD2, Above},
    {0x1CD4, OverlaysInterior},
    {0x1CD5, Below},
    {0x1CD6, Below},
    {0x1CD7, Below},
    {0x1CD8, Below},
    {0x1CD9, Below},
    {0x1CDA, Above},
    {0x1CDB, Above},
    {0x1CDC, Below},
    {0x1CDD, Below},
    {0x1CDE, Below},
    {0x1CDF, Below},
    {0x1CE0, Above},
    {0x1CE2, OverlaysInterior},
    {0x1CE3, OverlaysInterior},
    {0x1CE4, OverlaysInterior},
    {0x1CE5, OverlaysInterior},
    {0x1CE6, OverlaysInterior},
    {0x1CE7, OverlaysInterior},
    {0x1CE8, OverlaysInterior},
    {0x1CED, Below},
    {0x1CF4, Above},
    {0x1CF8, Above},
    {0x1CF9, Above},
    {0x1DC0, Above},
    {0x1DC1, Above},
    {0x1DC2, Below},
    {0x1DC3, Above},
    {0x1DC4, Above},
    {0x1DC5, Above},
    {0x1DC6, Above},
    {0x1DC7, Above},
    {0x1DC8, Above},
    {0x1DC9, Above},
    {0x1DCA, Below},
    {0x1DCB, Above},
    {0x1DCC, Above},
    {0x1DCD, Da},
    {0x1DCE, Ata},
    {0x1DCF, Below},
    {0x1DD0, Atb},
    {0x1DD1, Above},
    {0x1DD2, Above},
    {0x1DD3, Above},
    {0x1DD4, Above},
    {0x1DD5, Above},
    {0x1DD6, Above},
    {0x1DD7, Above},
    {0x1DD8, Above},
    {0x1DD9, Above},
    {0x1DDA, Above},
    {0x1DDB, Above},
    {0x1DDC, Above},
    {0x1DDD, Above},
    {0x1DDE, Above},
    {0x1DDF, Above},
    {0x1DE0, Above},
    {0x1DE1, Above},
    {0x1DE2, Above},
    {0x1DE3, Above},
    {0x1DE4, Above},
    {0x1DE5, Above},
    {0x1DE6, Above},
    {0x1DE7, Above},
    {0x1DE8, Above},
    {0x1DE9, Above},
    {0x1DEA, Above},
    {0x1DEB, Above},
    {0x1DEC, Above},
    {0x1DED, Above},
    {0x1DEE, Above},
    {0x1DEF, Above},
    {0x1DF0, Above},
    {0x1DF1, Above},
    {0x1DF2, Above},
    {0x1DF3, Above},
    {0x1DF4, Above},
    {0x1DF5, Above},
    {0x1DFC, Db},
    {0x1DFD, Below},
    {0x1DFE, Above},
    {0x1DFF, Below},
    {0x20D0, Above},
    {0x20D1, Above},
    {0x20D2, OverlaysInterior},
    {0x20D3, OverlaysInterior},
    {0x20D4, Above},
    {0x20D5, Above},
    {0x20D6, Above},
    {0x20D7, Above},
    {0x20D8, OverlaysInterior},
    {0x20D9, OverlaysInterior},
    {0x20DA, OverlaysInterior},
    {0x20DB, Above},
    {0x20DC, Above},
    {0x20E1, Above},
    {0x20E5, OverlaysInterior},
    {0x20E6, OverlaysInterior},
    {0x20E7, Above},
    {0x20E8, Below},
    {0x20E9, Above},
    {0x20EA, OverlaysInterior},
    {0x20EB, OverlaysInterior},
    {0x20EC, Below},
    {0x20ED, Below},
    {0x20EE, Below},
    {0x20EF, Below},
    {0x20F0, Above},
    {0x2CEF, Above},
    {0x2CF0, Above},
    {0x2CF1, Above},
    {0x2D7F, Viramas},
    {0x2DE0, Above},
    {0x2DE1, Above},
    {0x2DE2, Above},
    {0x2DE3, Above},
    {0x2DE4, Above},
    {0x2DE5, Above},
    {0x2DE6, Above},
    {0x2DE7, Above},
    {0x2DE8, Above},
    {0x2DE9, Above},
    {0x2DEA, Above},
    {0x2DEB, Above},
    {0x2DEC, Above},
    {0x2DED, Above},
    {0x2DEE, Above},
    {0x2DEF, Above},
    {0x2DF0, Above},
    {0x2DF1, Above},
    {0x2DF2, Above},
    {0x2DF3, Above},
    {0x2DF4, Above},
    {0x2DF5, Above},
    {0x2DF6, Above},
    {0x2DF7, Above},
    {0x2DF8, Above},
    {0x2DF9, Above},
    {0x2DFA, Above},
    {0x2DFB, Above},
    {0x2DFC, Above},
    {0x2DFD, Above},
    {0x2DFE, Above},
    {0x2DFF, Above},
    {0x302A, Bl},
    {0x302B, Al},
    {0x302C, Ar},
    {0x302D, Br},
    {0x302E, L},
    {0x302F, L},
    {0x3099, Kv},
    {0x309A, Kv},
    {0xA66F, Above},
    {0xA674, Above},
    {0xA675, Above},
    {0xA676, Above},
    {0xA677, Above},
    {0xA678, Above},
    {0xA679, Above},
    {0xA67A, Above},
    {0xA67B, Above},
    {0xA67C, Above},
    {0xA67D, Above},
    {0xA69F, Above},
    {0xA6F0, Above},
    {0xA6F1, Above},
    {0xA806, Viramas},
    {0xA8C4, Viramas},
    {0xA8E0, Above},
    { 0xA8E1, Above },
    { 0xA8E2, Above },
    { 0xA8E3, Above },
    { 0xA8E4, Above },
    { 0xA8E5, Above },
    { 0xA8E6, Above },
    { 0xA8E7, Above },
    { 0xA8E8, Above },
    { 0xA8E9, Above },
    { 0xA8EA, Above },
    { 0xA8EB, Above },
    { 0xA8EC, Above },
    { 0xA8ED, Above },
    { 0xA8EE, Above },
    { 0xA8EF, Above },
    { 0xA8F0, Above },
    { 0xA8F1, Above },
    { 0xA92B, Below },
    { 0xA92C, Below },
    { 0xA92D, Below },
    { 0xA953, Viramas },
    { 0xA9B3, Nuktas },
    { 0xA9C0, Viramas },
    { 0xAAB0, Above },
    { 0xAAB2, Above },
    { 0xAAB3, Above },
    { 0xAAB4, Below },
    { 0xAAB7, Above },
    { 0xAAB8, Above },
    { 0xAABE, Above },
    { 0xAABF, Above },
    { 0xAAC1, Above },
    { 0xAAF6, Viramas },
    { 0xABED, Viramas },
    { 0xFB1E, Class26 },
    { 0xFE20, Above },
    { 0xFE21, Above },
    { 0xFE22, Above },
    { 0xFE23, Above },
    { 0xFE24, Above },
    { 0xFE25, Above },
    { 0xFE26, Above },
    { 0xFE27, Below },
    { 0xFE28, Below },
    { 0xFE29, Below },
    { 0xFE2A, Below },
    { 0xFE2B, Below },
    { 0xFE2C, Below },
    { 0xFE2D, Below }
};
  
  /// Returns the Unicode canonical class for a given character.
  ///
  /// [character] A Unicode character for which to get the Unicode canonical class.
  ///
  /// Returns the character Unicode canonical class.
  internal static CanonicalClass GetCanonicalClass(int character) {
      if (CanonicalClassMap.TryGetValue(character, out var canonicalClass))
      {
          return canonicalClass;
      }
      return CanonicalClass.NotReordered;
  }
}



