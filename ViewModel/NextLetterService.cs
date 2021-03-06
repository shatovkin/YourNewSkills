﻿using System;
using NewSkills.Controller;
using System.IO;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace NewSkills.ViewModel
{
    public class NextLetterService
    {
       
        public static List<NextImage> LoadedImages { get; set; }
        StreamReaderController controller = new StreamReaderController("logs");

        public NextLetterService() {
            getPictureSource();
        }

        enum alphabet
        {
            Letter_А = 'А',
            Letter_a = 'а',
            Letter_B = 'Б',
            Letter_b = 'б',
            Letter_W = 'В',
            Letter_w = 'в',
            Letter_G = 'Г',
            Letter_g = 'г',
            Letter_D = 'Д',
            Letter_d = 'д',
            Letter_E = 'Е',
            Letter_e = 'е',
            Letter_JO = 'Ё',
            Letter_jo = 'ё',
            Letter_ZG = 'Ж',
            Letter_zg = 'ж',
            Letter_Z = 'З',
            Letter_z = 'з',
            Letter_I = 'И',
            Letter_i = 'и',
            Letter_II = 'Й',
            Letter_ii = 'й',
            Letter_K = 'К',
            Letter_k = 'к',
            Letter_L = 'Л',
            Letter_l = 'л',
            Letter_M = 'М',
            Letter_m = 'м',
            Letter_N = 'Н',
            Letter_n = 'н',
            Letter_O = 'О',
            Letter_o = 'о',
            Letter_P = 'П',
            Letter_p = 'п',
            Letter_R = 'Р',
            Letter_r = 'р',
            Letter_S = 'С',
            Letter_s = 'с',
            Letter_T = 'Т',
            Letter_t = 'т',
            Letter_Y = 'У',
            Letter_y = 'у',
            Letter_F = 'Ф',
            Letter_f = 'ф',
            Letter_X = 'Х',
            Letter_x = 'х',
            Letter_ZE = 'Ц',
            Letter_ze = 'ц',
            Letter_CH = 'Ч',
            Letter_ch = 'ч',
            Letter_Sh = 'Ш',
            Letter_sh = 'ш',
            Letter_SCHe = 'Щ',
            Letter_sche = 'щ',
            Letter_HARD = 'ъ',
            Letter_bl = 'ы',
            Letter_Soft = 'ь',
            Letter_EE = 'Э',
            Letter_ee = 'э',
            Letter_You = 'Ю',
            Letter_you = 'ю',
            Letter_JA = 'Я',
            Letter_ja = 'я',
            Letter_1 = '1',
            Letter_2 = '2',
            Letter_3 = '3',
            Letter_4 = '4',
            Letter_5 = '5',
            Letter_6 = '6',
            Letter_7 = '7',
            Letter_8 = '8',
            Letter_9 = '9',
            Letter_0 = '0',
            Letter_Comma = ',',
            Letter_Punkt = '.',
            Letter_ExclamationMark = '!',
            Letter_QuestionMark = '?',
            Letter_Quotes = '"',
            Letter_UnderScore = '_',
            Letter_Score = '-',
            Letter_Semicolon = ';',
            Letter_Colon = ':',
            Letter_BracketLeft = '(',
            Letter_BrackertRight = ')',
            Letter_Percent = '%',
            Letter_Number = '№',
            Letter_Stern = '*'
        }

        public NextLetterWrapper getLetter(char letter, int fontVariant)
        {
            NextLetterWrapper wrapper = new NextLetterWrapper();

            if (fontVariant == 0)
            {
                wrapper = getLetterVariantOne(letter);
                return wrapper;
            }
            else if (fontVariant == 1)
            {
                wrapper = getLetterVariantTwo(letter);
                return wrapper;
            }
            else 
            {
                wrapper = getLetterVariantThree(letter);
                return wrapper;
            }
        }


        private NextLetterWrapper getLetterVariantOne(char letter)
        {
            NextLetterWrapper wrapper = new NextLetterWrapper();
            switch (letter)
            {
                case (char)alphabet.Letter_А:
                    wrapper.letterDescription = "Заглавная буква 'А'[А], правой шифт, левой 1-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_A11_wav;
                    return wrapper;
                case (char)alphabet.Letter_a:
                    wrapper.letterDescription = "Буква 'а'[а], левой 1-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_a12_wav;
                    return wrapper;
                case (char)alphabet.Letter_B:
                    wrapper.letterDescription = "Заглавная буква 'Б'[Бэ], левой шифт, правой 2-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Be11_wav;
                    return wrapper;
                case (char)alphabet.Letter_b:
                    wrapper.letterDescription = "Буква 'б'[бэ], правой 2-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_be12_wav;
                    return wrapper;
                case (char)alphabet.Letter_W:
                    wrapper.letterDescription = "Заглавная буква 'В'[Вэ], правой шифт, левой 2-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ve11_wav;
                    return wrapper;
                case (char)alphabet.Letter_w:
                    wrapper.letterDescription = "Буква 'в'[вэ], левой 2-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ve12_wav;
                    return wrapper;
                case (char)alphabet.Letter_G:
                    wrapper.letterDescription = "Заглавная буква 'Г'[Гэ], левой шифт, правой 1-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ge11_wav;
                    return wrapper;
                case (char)alphabet.Letter_g:
                    wrapper.letterDescription = "Буква 'г'[гэ], правой 1-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ge12_wav;
                    return wrapper;
                case (char)alphabet.Letter_D:
                    wrapper.letterDescription = "Заглавная буква 'Д'[Дэ], левой шифт, правой 3-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_De11_wav;
                    return wrapper;
                case (char)alphabet.Letter_d:
                    wrapper.letterDescription = "Буква 'д'[дэ], правой 3-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_de12_wav;
                    return wrapper;
                case (char)alphabet.Letter_E:
                    wrapper.letterDescription = "Заглавная буква 'Е'[Йэ], правой шифт, левой 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ye11_wav;
                    return wrapper;
                case (char)alphabet.Letter_e:
                    wrapper.letterDescription = "Буква 'е'[йэ], левой 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ye12_wav;
                    return wrapper;
                case (char)alphabet.Letter_JO:
                    wrapper.letterDescription = "Заглавная буква 'Ё'[Йо], правой шифт, левой 4-м вершина в угол";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Yo11_wav;
                    return wrapper;
                case (char)alphabet.Letter_jo:
                    wrapper.letterDescription = "Буква 'ё'[йо], левой 4-м вершина в угол";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_yo12_wav;
                    return wrapper;
                case (char)alphabet.Letter_ZG:
                    wrapper.letterDescription = "Заглавная буква 'Ж'[Жэ], левой шифт, правой 4-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Zhe11_wav;
                    return wrapper;
                case (char)alphabet.Letter_zg:
                    wrapper.letterDescription = "Буква 'ж'[жэ], правой 4-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_zhe12_wav;
                    return wrapper;
                case (char)alphabet.Letter_Z:
                    wrapper.letterDescription = "Заглавная буква 'З'[Зэ], левой шифт, правой 4-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ze11_wav;
                    return wrapper;
                case (char)alphabet.Letter_z:
                    wrapper.letterDescription = "Буква 'з'[зэ], правой 4-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ze12_wav;
                    return wrapper;
                case (char)alphabet.Letter_I:
                    wrapper.letterDescription = "Заглавная буква 'И'[И], правой шифт, левой 1-м направо вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_I11_wav;
                    return wrapper;
                case (char)alphabet.Letter_i:
                    wrapper.letterDescription = "Буква 'и'[и], левой 1-м направо вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_i12_wav;
                    return wrapper;
                case (char)alphabet.Letter_II:
                    wrapper.letterDescription = "Заглавная буква 'Й'[Ий краткое], правой шифт, левой 4-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_I_kratkoe11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ii:
                    wrapper.letterDescription = "Буква 'й'[ий краткое], левой 4-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_i_kratkoe12_wav;
                    return wrapper;
                case (char)alphabet.Letter_K:
                    wrapper.letterDescription = "Заглавная буква 'К'[Ка], правой шифт, левой 1-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ka11_wav;
                    return wrapper;
                case (char)alphabet.Letter_k:
                    wrapper.letterDescription = "Буква 'к'[ка], левой 1-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ka12_wav;
                    return wrapper;
                case (char)alphabet.Letter_L:
                    wrapper.letterDescription = "Заглавная буква 'Л'[Эль], левой шифт, правой 2-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_El11_wav;
                    return wrapper;
                case (char)alphabet.Letter_l:
                    wrapper.letterDescription = "Буква 'л'[эль], правой 2-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_el12_wav;
                    return wrapper;
                case (char)alphabet.Letter_M:
                    wrapper.letterDescription = "Заглавная буква 'М'[Эм], правой шифт, левой 1-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Em11_wav;
                    return wrapper;
                case (char)alphabet.Letter_m:
                    wrapper.letterDescription = "Буква 'м'[эм], левой 1-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_em12_wav;
                    return wrapper;
                case (char)alphabet.Letter_N:
                    wrapper.letterDescription = "Заглавная буква 'Н'[Эн], левой шифт, правой 1-м налево вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_En11_wav;
                    return wrapper;
                case (char)alphabet.Letter_n:
                    wrapper.letterDescription = "Буква 'н'[эн], правой 1-м налево вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_en12_wav;
                    return wrapper;
                case (char)alphabet.Letter_O:
                    wrapper.letterDescription = "Заглавная буква 'О'[О], левой шифт, правой 1-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_О11_wav;
                    return wrapper;
                case (char)alphabet.Letter_o:
                    wrapper.letterDescription = "Буква 'о'[о], правой 1-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_o12_wav;
                    return wrapper;
                case (char)alphabet.Letter_P:
                    wrapper.letterDescription = "Заглавная буква 'П'[Пэ], правой шифт, левой 1-м направо на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Pe11_wav;
                    return wrapper;
                case (char)alphabet.Letter_p:
                    wrapper.letterDescription = "Буква 'п'[пэ], левой 1-м направо на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_pe12_wav;
                    return wrapper;
                case (char)alphabet.Letter_R:
                    wrapper.letterDescription = "Заглавная буква 'Р'[Эр], левой шифт, правой 1-м налево на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Er11_wav;
                    return wrapper;
                case (char)alphabet.Letter_r:
                    wrapper.letterDescription = "Буква 'р'[эр], правой 1-м налево на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_er12_wav;
                    return wrapper;
                case (char)alphabet.Letter_S:
                    wrapper.letterDescription = "Заглавная буква 'С'[Эс], правой шифт, левой 2-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Es11_wav;
                    return wrapper;
                case (char)alphabet.Letter_s:
                    wrapper.letterDescription = "Буква 'с'[эс], левой 2-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_es12_wav;
                    return wrapper;
                case (char)alphabet.Letter_T:
                    wrapper.letterDescription = "Заглавная буква 'Т'[Тэ], левой шифт, правой 1-м налево вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Te11_wav;
                    return wrapper;
                case (char)alphabet.Letter_t:
                    wrapper.letterDescription = "Буква 'т'[тэ], правой 1-м налево вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_te12_wav;
                    return wrapper;
                case (char)alphabet.Letter_Y:
                    wrapper.letterDescription = "Заглавная буква 'У'[У], правой шифт, левой 2-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_U11_wav;
                    return wrapper;
                case (char)alphabet.Letter_y:
                    wrapper.letterDescription = "Буква 'у'[у], левой 2-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_u12_wav;
                    return wrapper;
                case (char)alphabet.Letter_F:
                    wrapper.letterDescription = "Заглавная буква 'Ф'[Эф], правой шифт, левой 4-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ef11_wav;
                    return wrapper;
                case (char)alphabet.Letter_f:
                    wrapper.letterDescription = "Буква 'ф'[эф], левой 4-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ef12_wav;
                    return wrapper;
                case (char)alphabet.Letter_X:
                    wrapper.letterDescription = "Заглавная буква 'Х'[Ха], левой шифт, правой 4-м направо вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ha11_wav;
                    return wrapper;
                case (char)alphabet.Letter_x:
                    wrapper.letterDescription = "Буква 'х'[ха], правой 4-м направо вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ha12_wav;
                    return wrapper;
                case (char)alphabet.Letter_ZE:
                    wrapper.letterDescription = "Заглавная буква 'Ц'[Цэ], правой шифт, левой 3-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ce11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ze:
                    wrapper.letterDescription = "Буква 'ц'[цэ], левой 3-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ce12_wav;
                    return wrapper;
                case (char)alphabet.Letter_CH:
                    wrapper.letterDescription = "Заглавная буква 'Ч'[Че], правой шифт, левой 3-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Che11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ch:
                    wrapper.letterDescription = "Буква 'ч'[че], левой 3-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_che12_wav;
                    return wrapper;
                case (char)alphabet.Letter_Sh:
                    wrapper.letterDescription = "Заглавная буква 'Ш'[Ша], левой шифт, правой 2-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Sha11_wav;
                    return wrapper;
                case (char)alphabet.Letter_sh:
                    wrapper.letterDescription = "Буква 'ш'[ша], правой 2-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_sha12_wav;
                    return wrapper;
                case (char)alphabet.Letter_SCHe:
                    wrapper.letterDescription = "Заглавная буква 'Щ'[Ща], левой шифт, правой 3-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Shcha11_wav;
                    return wrapper;
                case (char)alphabet.Letter_sche:
                    wrapper.letterDescription = "Буква 'щ'[ща], правой 3-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_shcha12_wav;
                    return wrapper;
                case (char)alphabet.Letter_HARD:
                    wrapper.letterDescription = "Буква 'ъ'[твёрдый знак], правой 4-м направо в угол";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_tvyordyj_znak11_wav;
                    return wrapper;
                case (char)alphabet.Letter_bl:
                    wrapper.letterDescription = "Буква 'ы'[ы], левой 3-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_y12_wav;
                    return wrapper;
                case (char)alphabet.Letter_Soft:
                    wrapper.letterDescription = "Буква 'ь'[мягкий знак], правой 1-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_myagkij_znak11_wav;
                    return wrapper;
                case (char)alphabet.Letter_EE:
                    wrapper.letterDescription = "Заглавная буква 'Э'[Э], левой шифт, правой 4-м направо на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_E11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ee:
                    wrapper.letterDescription = "Буква 'э'[э], правой 4-м направо на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_e12_wav;
                    return wrapper;
                case (char)alphabet.Letter_You:
                    wrapper.letterDescription = "Заглавная буква 'Ю'[Йу], левой шифт, правой 3-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Yu11_wav;
                    return wrapper;
                case (char)alphabet.Letter_you:
                    wrapper.letterDescription = "Буква 'ю'[йу], правой 3-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_yu12_wav;
                    return wrapper;
                case (char)alphabet.Letter_JA:
                    wrapper.letterDescription = "Заглавная буква 'Я'[Йа], правой шифт, левой 4-м вниз";
                    wrapper.directionDescription = "RightSpace"; 
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ya11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ja:
                    wrapper.letterDescription = "Буква 'я'[йа], левой 4-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ya12_wav;
                    return wrapper;
                case (char)alphabet.Letter_1:
                    wrapper.letterDescription = "Цифра '1'[один], левой 4-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_odin11_wav;
                    return wrapper;
                case (char)alphabet.Letter_2:
                    wrapper.letterDescription = "Цифра '2'[два], левой 3-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_dva11_wav;
                    return wrapper;
                case (char)alphabet.Letter_3:
                    wrapper.letterDescription = "Цифра '3'[три], левой 2-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_tri11_wav;
                    return wrapper;
                case (char)alphabet.Letter_4:
                    wrapper.letterDescription = "Цифра '4'[четыре], левой 1-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_chetyre11_wav;
                    return wrapper;
                case (char)alphabet.Letter_5:
                    wrapper.letterDescription = "Цифра '5'[пять], левой 1-м направо вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_pyat11_wav;
                    return wrapper;
                case (char)alphabet.Letter_6:
                    wrapper.letterDescription = "Цифра '6'[шесть], правой 1-м налево вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_shest11_wav;
                    return wrapper;
                case (char)alphabet.Letter_7:
                    wrapper.letterDescription = "Цифра '7'[семь], правой 1-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_sem11_wav;
                    return wrapper;
                case (char)alphabet.Letter_8:
                    wrapper.letterDescription = "Цифра '8'[восемь], правой 2-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_vosem11_wav;
                    return wrapper;
                case (char)alphabet.Letter_9:
                    wrapper.letterDescription = "Цифра '9'[девять], правой 3-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_devyat11_wav;
                    return wrapper;
                case (char)alphabet.Letter_0:
                    wrapper.letterDescription = "Цифра '0'[ноль], правой 4-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_nol11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Comma:
                    wrapper.letterDescription = "',' [Запятая], левой шифт, правой 4-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zapyataya11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Punkt:
                    wrapper.letterDescription = "'.'[Точка], правой 4-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Tochka11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Score:
                    wrapper.letterDescription = "'-'[Дефис], правой 4-м направо вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Defis11_wav;
                    return wrapper;
                case (char)alphabet.Letter_UnderScore:
                    wrapper.letterDescription = "'_'[Нижнее подчёркивание], левой шифт, 4-м налево вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Nizhnee_podchyorkivanie11_wav;
                    return wrapper;
                case (char)alphabet.Letter_ExclamationMark:
                    wrapper.letterDescription = "'!'[Восклицательный знак], правой шифт, левой 4-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Vosklicatelnyj_znak11_wav;
                    return wrapper;
                case (char)alphabet.Letter_QuestionMark:
                    wrapper.letterDescription = "'?'[Вопросительный знак], левой шифт, правой 1-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Voprositelnyj_znak11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Semicolon:
                    wrapper.letterDescription = "';'[Точка с запятой], правой шифт, левой 1-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Tochka_s_zapyatoj11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Colon:
                    wrapper.letterDescription = "':'[Двоеточие], левой шифт, правой 1-м налево вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Dvoetochie11_wav;
                    return wrapper;
                case (char)alphabet.Letter_BracketLeft:
                    wrapper.letterDescription = "'('[Скобка открывается], левой шифт, правой 3-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Skobka_otkryvaetsya11_wav;
                    return wrapper;
                case (char)alphabet.Letter_BrackertRight:
                    wrapper.letterDescription = "')'[Скобка закрывается], левой шифт, правой 4-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Skobka_zakryvaetsya11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Percent:
                    wrapper.letterDescription = "'%'[Процент], правой шифт, левой 1-м направо вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Procent11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Stern:
                    wrapper.letterDescription = "'*'[Звездочка], левой шифт, правой 2-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zvezdochka11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Number:
                    wrapper.letterDescription = "'№'[Номер], правой шифт, левой 2-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Nomer11_wav;
                    return wrapper;
                case (char)alphabet.Letter_Quotes:
                    wrapper.letterDescription = "'»'[Кавычки], правой шифт, левой 3-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Kavychki11_wav;
                    return wrapper;
            }
            return new NextLetterWrapper();
        }


        public NextLetterWrapper getLetterVariantTwo(char letter) {

            NextLetterWrapper wrapper = new NextLetterWrapper();

            switch (letter)
            {
                case (char)alphabet.Letter_А:
                    wrapper.letterDescription = "Заглавная буква 'А'[А], правой шифт, левой указательным на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_A21_wav;
                    return wrapper;
                case (char)alphabet.Letter_a:
                    wrapper.letterDescription = "Буква 'а'[а], левой указательным на месте";
                    //wrapper.letterDescription =  "'a'  Левая - 1-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_a22_wav;
                    return wrapper;
                case (char)alphabet.Letter_B:
                    wrapper.letterDescription = "Заглавная буква 'Б'[Бэ], левой шифт, правой средним вниз";
                    //wrapper.letterDescription =  "'Б'  Shift + Правая - 2-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Be21_wav;
                    return wrapper;
                case (char)alphabet.Letter_b:
                    wrapper.letterDescription = "Буква 'б'[бэ], правой средним вниз";
                    //wrapper.letterDescription =  "'б'  Правая - 2-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_be22_wav;
                    return wrapper;
                case (char)alphabet.Letter_W:
                    wrapper.letterDescription = "Заглавная буква 'В'[Вэ], правой шифт, левой средним на месте";
                    //wrapper.letterDescription =  "'В'  Shift + Левая - 2-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ve21_wav;
                    return wrapper;
                case (char)alphabet.Letter_w:
                    wrapper.letterDescription = "Буква 'в'[вэ], левой средним на месте";
                    //wrapper.letterDescription =  "'в'  Левая - 2-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ve22_wav;
                    return wrapper;
                case (char)alphabet.Letter_G:
                    wrapper.letterDescription = "Заглавная буква 'Г'[Гэ], левой шифт, правой указательным вверх";
                    //wrapper.letterDescription =  "'Г'  Shift + Правая - 1-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ge21_wav;
                    return wrapper;
                case (char)alphabet.Letter_g:
                    wrapper.letterDescription = "Буква 'г'[гэ], правой указательным вверх";
                    //wrapper.letterDescription =  "'г'  Правая - 1-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ge22_wav;
                    return wrapper;
                case (char)alphabet.Letter_D:
                    wrapper.letterDescription = "Заглавная буква 'Д'[Дэ], левой шифт, правой безымянным на месте";
                    //wrapper.letterDescription = "'Д'  Shift + Правая - 3-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_De21_wav;
                    return wrapper;
                case (char)alphabet.Letter_d:
                    wrapper.letterDescription = "Буква 'д'[дэ], правой безымянным на месте";
                    //wrapper.letterDescription =  "'д'  Правая - 3-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_de22_wav;
                    return wrapper;
                case (char)alphabet.Letter_E:
                    wrapper.letterDescription = "Заглавная буква 'Е'[Йэ], правой шифт, левой указательным направо вверх";
                    //wrapper.letterDescription = "'Е'  Shift +  Левая - 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ye21_wav;
                    return wrapper;
                case (char)alphabet.Letter_e:
                    wrapper.letterDescription = "Буква 'е'[йэ], левой указательным направо вверх";
                    //wrapper.letterDescription = "'е' Левая - 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ye22_wav;
                    return wrapper;
                case (char)alphabet.Letter_JO:
                    wrapper.letterDescription = "Заглавная буква 'Ё'[Йо], правой шифт, левой мизинцем вершина в угол";
                    //wrapper.letterDescription = "'Ё'  Shift +  Левая - 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Yo21_wav;
                    return wrapper;
                case (char)alphabet.Letter_jo:
                    wrapper.letterDescription = "Буква 'ё'[йо], левой мизинцем вершина в угол";
                    //wrapper.letterDescription = "'ё' Левая - 1-м направо вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_yo22_wav;
                    return wrapper;
                case (char)alphabet.Letter_ZG:
                    wrapper.letterDescription = "Заглавная буква 'Ж'[Жэ], левой шифт, правой мизинцем на месте";
                    //wrapper.letterDescription = "'Ж' Шифт + Правая - 4-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Zhe21_wav;
                    return wrapper;
                case (char)alphabet.Letter_zg:
                    wrapper.letterDescription = "Буква 'ж'[жэ], правой мизинцем на месте";
                    //wrapper.letterDescription = "'ж'  Правая - 4-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_zhe22_wav;
                    return wrapper;
                case (char)alphabet.Letter_Z:
                    wrapper.letterDescription = "Заглавная буква 'З'[Зэ], левой шифт, правой мизинцем вверх";
                    //wrapper.letterDescription = "'З'  Шифт + Правая - 4-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ze21_wav;
                    return wrapper;
                case (char)alphabet.Letter_z:
                    wrapper.letterDescription = "Буква 'з'[зэ], правой мизинцем вверх";
                    //wrapper.letterDescription = "'з'  Правая - 4-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ze22_wav;
                    return wrapper;
                case (char)alphabet.Letter_I:
                    wrapper.letterDescription = "Заглавная буква 'И'[И], правой шифт, левой указательным направо вниз";
                    //wrapper.letterDescription = "'И'  Шифт + Левая - 1-м направо вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_I21_wav;
                    return wrapper;
                case (char)alphabet.Letter_i:
                    wrapper.letterDescription = "Буква 'и'[и], левой указательным направо вниз";
                    //wrapper.letterDescription = "'и'  Левая - 1-м направо вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_i22_wav;
                    return wrapper;
                case (char)alphabet.Letter_II:
                    wrapper.letterDescription = "Заглавная буква 'Й'[Ий краткое], правой шифт, левой мизинцем вверх";
                    //wrapper.letterDescription = "'Й'  Шифт + Левая - 4-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_I_kratkoe21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ii:
                    wrapper.letterDescription = "Буква 'й'[ий краткое], левой мизинцем вверх";
                    //wrapper.letterDescription = "'й'  Левая - 4-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_i_kratkoe22_wav;
                    return wrapper;
                case (char)alphabet.Letter_K:
                    wrapper.letterDescription = "Заглавная буква 'К'[Ка], правой шифт, левой указательным вверх";
                    //wrapper.letterDescription = "'К'  Шифт + Левая - 1-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ka21_wav;
                    return wrapper;
                case (char)alphabet.Letter_k:
                    wrapper.letterDescription = "Буква 'к'[ка], левой указательным вверх";
                    //wrapper.letterDescription = "'к'  Левая - 1-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ka22_wav;
                    return wrapper;
                case (char)alphabet.Letter_L:
                    wrapper.letterDescription = "Заглавная буква 'Л'[Эль], левой шифт, правой средним на месте";
                    //wrapper.letterDescription = "'Л'  Шифт + Правая - 2-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_El21_wav;
                    return wrapper;
                case (char)alphabet.Letter_l:
                    wrapper.letterDescription = "Буква 'л'[эль], правой средним на месте";
                    //wrapper.letterDescription = "'л'  Правая - 2-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_el22_wav;
                    return wrapper;
                case (char)alphabet.Letter_M:
                    wrapper.letterDescription = "Заглавная буква 'М'[Эм], правой шифт, левой указательным вниз";
                    //wrapper.letterDescription = "'М'  Шифт + Левая - 1-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Em21_wav;
                    return wrapper;
                case (char)alphabet.Letter_m:
                    wrapper.letterDescription = "Буква 'м'[эм], левой указательным вниз";
                    //wrapper.letterDescription = "'м'  Левая - 1-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_em22_wav;
                    return wrapper;
                case (char)alphabet.Letter_N:
                    wrapper.letterDescription = "Заглавная буква 'Н'[Эн], левой шифт, правой указательным налево вверх";
                    //wrapper.letterDescription = "'Н'  Шифт + Правая - 1-м налево вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_En21_wav;
                    return wrapper;
                case (char)alphabet.Letter_n:
                    wrapper.letterDescription = "Буква 'н'[эн], правой указательным налево вверх";
                    //wrapper.letterDescription = "'н'  Правая - 1-м налево вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_en22_wav;
                    return wrapper;
                case (char)alphabet.Letter_O:
                    wrapper.letterDescription = "Заглавная буква 'О'[О], левой шифт, правой указательным на месте";
                    //wrapper.letterDescription = "'О'  Шифт + Правая - 1-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_О21_wav;
                    return wrapper;
                case (char)alphabet.Letter_o:
                    wrapper.letterDescription = "Буква 'о'[о], правой указательным на месте";
                    //wrapper.letterDescription = "'о'  Правая - 1-м на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_o22_wav;
                    return wrapper;
                case (char)alphabet.Letter_P:
                    wrapper.letterDescription = "Заглавная буква 'П'[Пэ], правой шифт, левой указательным направо на месте ";
                    //wrapper.letterDescription = "'П'  Шифт + Левая - 1-м направо на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Pe21_wav;
                    return wrapper;
                case (char)alphabet.Letter_p:
                    wrapper.letterDescription = "Буква 'п'[пэ], левой указательным направо на месте";
                    //wrapper.letterDescription = "'п'  Левая - 1-м направо на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_pe22_wav;
                    return wrapper;
                case (char)alphabet.Letter_R:
                    wrapper.letterDescription = "Заглавная буква 'Р'[Эр], левой шифт, правой указательным налево на месте";
                    //wrapper.letterDescription = "'Р'  Шифт + Правая - 1-м налево на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Er21_wav;
                    return wrapper;
                case (char)alphabet.Letter_r:
                    wrapper.letterDescription = "Буква 'р'[эр], правой указательным налево на месте";
                    //wrapper.letterDescription = "'р'  Правая - 1-м налево на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_er22_wav;
                    return wrapper;
                case (char)alphabet.Letter_S:
                    wrapper.letterDescription = "Заглавная буква 'С'[Эс], правой шифт, левой средним вниз";
                    //wrapper.letterDescription = "'С'  Шифт + Левая - 2-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Es21_wav;
                    return wrapper;
                case (char)alphabet.Letter_s:
                    wrapper.letterDescription = "Буква 'с'[эс], левой средним вниз";
                    //wrapper.letterDescription = "'с'  Левая - 2-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_es22_wav;
                    return wrapper;
                case (char)alphabet.Letter_T:
                    wrapper.letterDescription = "Заглавная буква 'Т'[Тэ], левой шифт, правой указательным налево вниз";
                    //wrapper.letterDescription = "'Т'  Шифт + Правая - 1-м налево вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Te21_wav;
                    return wrapper;
                case (char)alphabet.Letter_t:
                    wrapper.letterDescription = "Буква 'т'[тэ], правой указательным налево вниз";
                    //wrapper.letterDescription = "'т'  Правая - 1-м налево вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_te22_wav;
                    return wrapper;
                case (char)alphabet.Letter_Y:
                    wrapper.letterDescription = "Заглавная буква 'У'[У], правой шифт, левой средним вверх";
                    //wrapper.letterDescription = "'У'  Шифт + Левая - 2-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_U21_wav;
                    return wrapper;
                case (char)alphabet.Letter_y:
                    wrapper.letterDescription = "Буква 'у'[у], левой средним вверх";
                    //wrapper.letterDescription = "'у'  Левая - 2-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_u22_wav;
                    return wrapper;
                case (char)alphabet.Letter_F:
                    wrapper.letterDescription = "Заглавная буква 'Ф'[Эф], правой шифт, левой мизинцем на месте ";
                    //wrapper.letterDescription = "'Ф'  Шифт + Левая - 4-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ef21_wav;
                    return wrapper;
                case (char)alphabet.Letter_f:
                    wrapper.letterDescription = "Буква 'ф'[эф], левой мизинцем на месте";
                    //wrapper.letterDescription = "'ф'  Левая - 4-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ef12_wav;
                    return wrapper;
                case (char)alphabet.Letter_X:
                    wrapper.letterDescription = "Заглавная буква 'Х'[Ха], левой шифт, правой мизинцем направо вверх";
                    //wrapper.letterDescription = "'Х'  Шифт + Правая - 4-м направо вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ha21_wav;
                    return wrapper;
                case (char)alphabet.Letter_x:
                    wrapper.letterDescription = "Буква 'х'[ха], правой мизинцем направо вверх";
                    //wrapper.letterDescription = "'х'  Правая - 4-м направо вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ha22_wav;
                    return wrapper;
                case (char)alphabet.Letter_ZE:
                    wrapper.letterDescription = "Заглавная буква 'Ц'[Цэ], правой шифт, левой безымянным вверх";
                    //wrapper.letterDescription = "'Ц'  Шифт + Левая - 3-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ce21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ze:
                    wrapper.letterDescription = "Буква 'ц'[цэ], левой безымянным вверх";
                    //wrapper.letterDescription = "'ц'  Левая - 3-м вверх";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ce22_wav;
                    return wrapper;
                case (char)alphabet.Letter_CH:
                    wrapper.letterDescription = "Заглавная буква 'Ч'[Че], правой шифт, левой безымянным вниз ";
                    //wrapper.letterDescription = "'Ч'  Шифт + Левая - 3-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Che21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ch:
                    wrapper.letterDescription = "Буква 'ч'[че], левой безымянным вниз";
                    //wrapper.letterDescription = "'ч'  Левая - 3-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_che22_wav;
                    return wrapper;
                case (char)alphabet.Letter_Sh:
                    wrapper.letterDescription = "Заглавная буква 'Ш'[Ша], левой шифт, правой средним вверх ";
                    //wrapper.letterDescription = "'Ш'  Шифт + Правая - 2-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Sha21_wav;
                    return wrapper;
                case (char)alphabet.Letter_sh:
                    wrapper.letterDescription = "Буква 'ш'[ша], правой средним вверх";
                    //wrapper.letterDescription = "'ш'  Правая - 2-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_sha22_wav;
                    return wrapper;
                case (char)alphabet.Letter_SCHe:
                    wrapper.letterDescription = "Заглавная буква 'Щ'[Ща], левой шифт, правой безымянным вверх ";
                    //wrapper.letterDescription = "'Щ'  Шифт + Правая - 3-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Shcha21_wav;
                    return wrapper;
                case (char)alphabet.Letter_sche:
                    wrapper.letterDescription = "Буква 'щ'[ща], правой безымянным вверх";
                    //wrapper.letterDescription = "'щ'  Правая - 3-м вверх";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_shcha22_wav;
                    return wrapper;
                case (char)alphabet.Letter_HARD:
                    wrapper.letterDescription = "Буква 'ъ'[твёрдый знак], правой мизинцем направо в угол";
                    //wrapper.letterDescription = "'ъ'  Правая - 4-м направо в угол";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_tvyordyj_znak22_wav;
                    return wrapper;
                case (char)alphabet.Letter_bl:
                    wrapper.letterDescription = "Буква 'ы'[ы], левой безымянным на месте";
                    //wrapper.letterDescription = "'ы'  Левая - 3-м на месте";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_y22_wav;
                    return wrapper;
                case (char)alphabet.Letter_Soft:
                    wrapper.letterDescription = "Буква 'ь'[мягкий знак], правой указательным вниз";
                    //wrapper.letterDescription = "'ь'  Правая - 1-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_myagkij_znak22_wav;
                    return wrapper;
                case (char)alphabet.Letter_EE:
                    wrapper.letterDescription = "Заглавная буква 'Э'[Э], левой шифт, правой мизинцем направо на месте";
                    //wrapper.letterDescription = "'Э'  Шифт + Правая - 4-м направо на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_E21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ee:
                    wrapper.letterDescription = "Буква 'э'[э], правой мизинцем направо на месте";
                    //wrapper.letterDescription = "'э'  Правая - 4-м направо на месте";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_e22_wav;
                    return wrapper;
                case (char)alphabet.Letter_You:
                    wrapper.letterDescription = "Заглавная буква 'Ю'[Йу], левой шифт, правой безымянным вниз";
                    //wrapper.letterDescription = "'Ю'  Шифт + Правая - 3-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Yu21_wav;
                    return wrapper;
                case (char)alphabet.Letter_you:
                    wrapper.letterDescription = "Буква 'ю'[йу], правой безымянным вниз";
                    //wrapper.letterDescription = "'ю'  Правая - 3-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_yu22_wav;
                    return wrapper;
                case (char)alphabet.Letter_JA:
                    wrapper.letterDescription = "Заглавная буква 'Я'[Йа], правой шифт, левой мизинцем вниз";
                    //wrapper.letterDescription = "'Я'  Шифт + Левая - 4-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zaglavnaya_Ya21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ja:
                    wrapper.letterDescription = "Буква 'я'[йа], левой мизинцем вниз";
                    //wrapper.letterDescription = "'я'  Левая - 4-м вниз";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Bukva_ya22_wav;
                    return wrapper;
                case (char)alphabet.Letter_1:
                    wrapper.letterDescription = "Цифра '1'[один], левой мизинцем вершина";
                    //wrapper.letterDescription = "'1'  Левая - 4-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_odin21;
                    return wrapper;
                case (char)alphabet.Letter_2:
                    wrapper.letterDescription = "Цифра '2'[два], левой безымянным вершина";
                    //wrapper.letterDescription = "'2'  Левая - 3-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_dva21_wav;
                    return wrapper;
                case (char)alphabet.Letter_3:
                    wrapper.letterDescription = "Цифра '3'[три], левой средним вершина";
                    //wrapper.letterDescription = "'3'  Левая - 2-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_tri21_wav;
                    return wrapper;
                case (char)alphabet.Letter_4:
                    wrapper.letterDescription = "Цифра '4'[четыре], левой указательным вершина";
                    //wrapper.letterDescription = "'4'  Левая - 1-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_chetyre21_wav;
                    return wrapper;
                case (char)alphabet.Letter_5:
                    wrapper.letterDescription = "Цифра '5'[пять], левой указательным направо вершина";
                    //wrapper.letterDescription = "'5'  Левая - 1-м направо вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_pyat21_wav;
                    return wrapper;
                case (char)alphabet.Letter_6:
                    wrapper.letterDescription = "Цифра '6'[шесть], правой указательным налево вершина";
                    //wrapper.letterDescription = "'6'  Правая - 1-м налево вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_shest21_wav;
                    return wrapper;
                case (char)alphabet.Letter_7:
                    wrapper.letterDescription = "Цифра '7'[семь], правой указательным вершина";
                    //wrapper.letterDescription = "'7'  Правая - 1-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_sem21_wav;
                    return wrapper;
                case (char)alphabet.Letter_8:
                    wrapper.letterDescription = "Цифра '8'[восемь], правой средним вершина";
                    //wrapper.letterDescription = "'8'  Правая - 2-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_vosem21_wav;
                    return wrapper;
                case (char)alphabet.Letter_9:
                    wrapper.letterDescription = "Цифра '9'[девять], правой безымянным вершина";
                    //wrapper.letterDescription = "'9'  Правая - 3-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_devyat21_wav;
                    return wrapper;
                case (char)alphabet.Letter_0:
                    wrapper.letterDescription = "Цифра '0'[ноль], правой мизинцем вершина";
                    //wrapper.letterDescription = "'0'  Правая - 4-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Cifra_nol21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Comma:
                    wrapper.letterDescription = "',' [Запятая], левой шифт, правой мизинцем вниз";
                    //wrapper.letterDescription = "'Запятая'  Шифт + Правая - 4-м вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zapyataya21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Punkt:
                    wrapper.letterDescription = "'.'[Точка], правой мизинцем вниз";
                    //wrapper.letterDescription = "'.'[Точка], правой мизинцем вниз";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Tochka21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Score:
                    wrapper.letterDescription = "'-'[Дефис], правой мизинцем направо вершина";
                    //wrapper.letterDescription = "' Тире '  Правая - 4-м направо вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Defis21_wav;
                    return wrapper;
                case (char)alphabet.Letter_UnderScore:
                    wrapper.letterDescription = "'_'[Нижнее подчёркивание], левой шифт, правой мизинцем направо вершина";
                    //wrapper.letterDescription = "'Подчеркивание'  Шифт + Правая - 4-м направо вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Nizhnee_podchyorkivanie21_wav;
                    return wrapper;
                case (char)alphabet.Letter_ExclamationMark:
                    wrapper.letterDescription = "'!'[Восклицательный знак], правой шифт, левой мизинцем вершина";
                    //wrapper.letterDescription = "'Восклицательный знак'  Шифт + Левая - 4-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Vosklicatelnyj_znak21_wav;
                    return wrapper;
                case (char)alphabet.Letter_QuestionMark:
                    wrapper.letterDescription = "'?'[Вопросительный знак], левой шифт, правой указательным вершина";
                    //wrapper.letterDescription = "'Вопросителный знак'  Шифт + Правая - 1-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Voprositelnyj_znak21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Semicolon:
                    wrapper.letterDescription = "';'[Точка с запятой], правой шифт, левой указательным вершина";
                    //wrapper.letterDescription = "';'  Шифт + Левая - 1-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Tochka_s_zapyatoj21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Colon:
                    wrapper.letterDescription = "':'[Двоеточие], левой шифт, правой указательным налево вершина";
                    //wrapper.letterDescription = "'Двоеточие'  Шифт + Правая - 1-м налево вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Dvoetochie21_wav;
                    return wrapper;
                case (char)alphabet.Letter_BracketLeft:
                    wrapper.letterDescription = "'('[Скобка открывается], левой шифт, правой безымянным вершина";
                    //wrapper.letterDescription = "'Левая скоба'  Шифт + Правая - 3-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Skobka_otkryvaetsya21_wav;
                    return wrapper;
                case (char)alphabet.Letter_BrackertRight:
                    wrapper.letterDescription = "')'[Скобка закрывается], левой шифт, правой мизинцем вершина";
                    //wrapper.letterDescription = "'Правая скоба'  Шифт + Правая - 4-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Skobka_zakryvaetsya21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Percent:
                    wrapper.letterDescription = "'%'[Процент], правой шифт, левой указательным направо вершина";
                    //wrapper.letterDescription = "'Знак процента'  Шифт + Левая - 1-м направо вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Procent21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Stern:
                    wrapper.letterDescription = "'*'[Звездочка], левой шифт, правой средним вершина";
                    //wrapper.letterDescription = "'Звёздочка'  Шифт + Правая - 2-м вершина";
                    wrapper.directionDescription = "LeftSpace";
                    wrapper.voicePath = Properties.Resources.audio_Zvezdochka21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Number:
                    wrapper.letterDescription = "'№'[Номер], правой шифт, левой средним вершина";
                    //wrapper.letterDescription = "'Номер'  Шифт + Левая - 3-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Nomer21_wav;
                    return wrapper;
                case (char)alphabet.Letter_Quotes:
                    wrapper.letterDescription = "'»'[Кавычки], правой шифт, левой безымянным вершина";
                    //wrapper.letterDescription = "'Номер'  Шифт + Левая - 3-м вершина";
                    wrapper.directionDescription = "RightSpace";
                    wrapper.voicePath = Properties.Resources.audio_Kavychki21_wav;
                    return wrapper;
            }
            return new NextLetterWrapper();
        }

        private NextLetterWrapper getLetterVariantThree(char letter)
        {
            throw new NotImplementedException();
        }

        public List<NextImage> getPictureSource() {

            LoadedImages = new List<NextImage>();
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_a1), letter: 'А'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_a2), letter: 'а'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_b1), letter: 'Б'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_b2), letter: 'б'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_v1), letter: 'В'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_v2), letter: 'в'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_g1), letter: 'Г'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_g2), letter: 'г'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_d1), letter: 'Д'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_d2), letter: 'д'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_e1), letter: 'Е'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_e2), letter: 'е'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_jo1), letter: 'Ё'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_jo2), letter: 'ё'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_zg1), letter: 'Ж'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_zg2), letter: 'ж'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_z1), letter: 'З'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_z2), letter: 'з'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_i1), letter: 'И'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_i2), letter: 'и'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_j1), letter: 'Й'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_j2), letter: 'й'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_k1), letter: 'К'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_k2), letter: 'к'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_l1), letter: 'Л'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_l2), letter: 'л'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_m1), letter: 'М'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_m2), letter: 'м'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_n1), letter: 'Н'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_n2), letter: 'н'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_o1), letter: 'О'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_o2), letter: 'о'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_p1), letter: 'П'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_p2), letter: 'п'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_r1), letter: 'Р'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_r2), letter: 'р'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_s1), letter: 'С'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_s2), letter: 'с'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_t1), letter: 'Т'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_t2), letter: 'т'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_u1), letter: 'У'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_u2), letter: 'у'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_f1), letter: 'Ф'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_f2), letter: 'ф'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_h1), letter: 'Х'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_h2), letter: 'х'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ze1), letter: 'Ц'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ze2), letter: 'ц'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ch1), letter: 'Ч'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ch2), letter: 'ч'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_sh1), letter: 'Ш'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_sh2), letter: 'ш'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_sche1), letter: 'Щ'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_sche2), letter: 'щ'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_hard), letter: 'ъ'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_bsign), letter: 'ь'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ee1), letter: 'Э'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ee2), letter: 'э'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_bl), letter: 'ы'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ju1), letter: 'Ю'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ju2), letter: 'ю'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ja1), letter: 'Я'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_ja2), letter: 'я'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_1), letter: '1'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_2), letter: '2'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_3), letter: '3'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_4), letter: '4'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_5), letter: '5'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_6), letter: '6'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_7), letter: '7'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_8), letter: '8'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_9), letter: '9'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_0), letter: '0'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_comma), letter: ','));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_point), letter: '.'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_1sign), letter: '!'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_7sign), letter: '?'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_2sign), letter: '"'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_score), letter: '_'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_underscore), letter: '-'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_4sign), letter: ';'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_6sign), letter: ':'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_9sign), letter: '('));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_0sign), letter: ')'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_5sign), letter: '%'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_3sign), letter: '№'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_8sign), letter: '*'));
            LoadedImages.Add(new NextImage(imageSource: getImagePathFromProperty(Properties.Resources.letter_space), letter: '|'));
            return LoadedImages; 
        }

        private BitmapSource getImagePathFromProperty(Bitmap resource)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(resource.GetHbitmap(),
                IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }

        public class NextLetterWrapper{
            public string letterDescription;
            public string directionDescription;
            public UnmanagedMemoryStream voicePath;
        }

        public class NextImage {
            public BitmapSource imageSource;
            public char letter;

            public NextImage(BitmapSource imageSource, char letter) {
                this.imageSource = imageSource;
                this.letter = letter;
            }
        }
   }
}
