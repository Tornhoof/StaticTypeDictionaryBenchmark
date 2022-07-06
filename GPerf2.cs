using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticTypeDictionaryBenchmark
{
	// with switch table
	public class GPerf2
	{
		const int TOTAL_KEYWORDS = 1000;
		const int MIN_WORD_LENGTH = 29;
		const int MAX_WORD_LENGTH = 31;
		const int MIN_HASH_VALUE = 29;
		const int MAX_HASH_VALUE = 3391;

		private static readonly ushort[] assoc_Values =
		{
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 77, 52,
			27, 2, 856, 100, 75, 50, 25, 0, 3392, 3392,
			3392, 3392, 3392, 3392, 25, 1020, 1015, 1010, 375, 20,
			15, 10, 5, 0, 1484, 1254, 754, 629, 126, 880,
			730, 250, 125, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392, 3392,
			3392
		};

		public int Hash(string str)
		{
			int hval = str.Length;
			switch (hval)
			{
				default:
				{
					hval += assoc_Values[str[30] + 25];
					goto case 30;
				}

				case 30:
				{
					hval += assoc_Values[str[29]];
					goto case 29;
				}


				case 29:
				{
					hval += assoc_Values[str[28] + 16];
					break;
				}
			}

			return hval;
		}

		public string? InWordSet(string str)
		{
			var len = str.Length;
			if (len is <= MAX_WORD_LENGTH and >= MIN_WORD_LENGTH)
			{
				int key = Hash(str);

				if (key is <= MAX_HASH_VALUE and >= 0)
				{
					string resword;
					switch (key - 29)
					{
						case 0:
							resword = "MyLongNamespace.Type.Request9";
							break;
						case 1:
							resword = "MyLongNamespace.Type.Request99";
							break;
						case 2:
							resword = "MyLongNamespace.Type.Request990";
							break;
						case 3:
							resword = "MyLongNamespace.Type.Request93";
							break;
						case 4:
							resword = "MyLongNamespace.Type.Request930";
							break;
						case 5:
							resword = "MyLongNamespace.Type.Request8";
							break;
						case 6:
							resword = "MyLongNamespace.Type.Request89";
							break;
						case 7:
							resword = "MyLongNamespace.Type.Request890";
							break;
						case 8:
							resword = "MyLongNamespace.Type.Request83";
							break;
						case 9:
							resword = "MyLongNamespace.Type.Request830";
							break;
						case 10:
							resword = "MyLongNamespace.Type.Request7";
							break;
						case 11:
							resword = "MyLongNamespace.Type.Request79";
							break;
						case 12:
							resword = "MyLongNamespace.Type.Request790";
							break;
						case 13:
							resword = "MyLongNamespace.Type.Request73";
							break;
						case 14:
							resword = "MyLongNamespace.Type.Request730";
							break;
						case 15:
							resword = "MyLongNamespace.Type.Request6";
							break;
						case 16:
							resword = "MyLongNamespace.Type.Request69";
							break;
						case 17:
							resword = "MyLongNamespace.Type.Request690";
							break;
						case 18:
							resword = "MyLongNamespace.Type.Request63";
							break;
						case 19:
							resword = "MyLongNamespace.Type.Request630";
							break;
						case 20:
							resword = "MyLongNamespace.Type.Request5";
							break;
						case 21:
							resword = "MyLongNamespace.Type.Request59";
							break;
						case 22:
							resword = "MyLongNamespace.Type.Request590";
							break;
						case 23:
							resword = "MyLongNamespace.Type.Request53";
							break;
						case 24:
							resword = "MyLongNamespace.Type.Request530";
							break;
						case 25:
							resword = "MyLongNamespace.Type.Request0";
							break;
						case 26:
							resword = "MyLongNamespace.Type.Request98";
							break;
						case 27:
							resword = "MyLongNamespace.Type.Request980";
							break;
						case 28:
							resword = "MyLongNamespace.Type.Request92";
							break;
						case 29:
							resword = "MyLongNamespace.Type.Request920";
							break;
						case 31:
							resword = "MyLongNamespace.Type.Request88";
							break;
						case 32:
							resword = "MyLongNamespace.Type.Request880";
							break;
						case 33:
							resword = "MyLongNamespace.Type.Request82";
							break;
						case 34:
							resword = "MyLongNamespace.Type.Request820";
							break;
						case 36:
							resword = "MyLongNamespace.Type.Request78";
							break;
						case 37:
							resword = "MyLongNamespace.Type.Request780";
							break;
						case 38:
							resword = "MyLongNamespace.Type.Request72";
							break;
						case 39:
							resword = "MyLongNamespace.Type.Request720";
							break;
						case 41:
							resword = "MyLongNamespace.Type.Request68";
							break;
						case 42:
							resword = "MyLongNamespace.Type.Request680";
							break;
						case 43:
							resword = "MyLongNamespace.Type.Request62";
							break;
						case 44:
							resword = "MyLongNamespace.Type.Request620";
							break;
						case 46:
							resword = "MyLongNamespace.Type.Request58";
							break;
						case 47:
							resword = "MyLongNamespace.Type.Request580";
							break;
						case 48:
							resword = "MyLongNamespace.Type.Request52";
							break;
						case 49:
							resword = "MyLongNamespace.Type.Request520";
							break;
						case 51:
							resword = "MyLongNamespace.Type.Request97";
							break;
						case 52:
							resword = "MyLongNamespace.Type.Request970";
							break;
						case 53:
							resword = "MyLongNamespace.Type.Request91";
							break;
						case 54:
							resword = "MyLongNamespace.Type.Request910";
							break;
						case 56:
							resword = "MyLongNamespace.Type.Request87";
							break;
						case 57:
							resword = "MyLongNamespace.Type.Request870";
							break;
						case 58:
							resword = "MyLongNamespace.Type.Request81";
							break;
						case 59:
							resword = "MyLongNamespace.Type.Request810";
							break;
						case 61:
							resword = "MyLongNamespace.Type.Request77";
							break;
						case 62:
							resword = "MyLongNamespace.Type.Request770";
							break;
						case 63:
							resword = "MyLongNamespace.Type.Request71";
							break;
						case 64:
							resword = "MyLongNamespace.Type.Request710";
							break;
						case 66:
							resword = "MyLongNamespace.Type.Request67";
							break;
						case 67:
							resword = "MyLongNamespace.Type.Request670";
							break;
						case 68:
							resword = "MyLongNamespace.Type.Request61";
							break;
						case 69:
							resword = "MyLongNamespace.Type.Request610";
							break;
						case 71:
							resword = "MyLongNamespace.Type.Request57";
							break;
						case 72:
							resword = "MyLongNamespace.Type.Request570";
							break;
						case 73:
							resword = "MyLongNamespace.Type.Request51";
							break;
						case 74:
							resword = "MyLongNamespace.Type.Request510";
							break;
						case 76:
							resword = "MyLongNamespace.Type.Request96";
							break;
						case 77:
							resword = "MyLongNamespace.Type.Request960";
							break;
						case 78:
							resword = "MyLongNamespace.Type.Request90";
							break;
						case 79:
							resword = "MyLongNamespace.Type.Request900";
							break;
						case 81:
							resword = "MyLongNamespace.Type.Request86";
							break;
						case 82:
							resword = "MyLongNamespace.Type.Request860";
							break;
						case 83:
							resword = "MyLongNamespace.Type.Request80";
							break;
						case 84:
							resword = "MyLongNamespace.Type.Request800";
							break;
						case 86:
							resword = "MyLongNamespace.Type.Request76";
							break;
						case 87:
							resword = "MyLongNamespace.Type.Request760";
							break;
						case 88:
							resword = "MyLongNamespace.Type.Request70";
							break;
						case 89:
							resword = "MyLongNamespace.Type.Request700";
							break;
						case 91:
							resword = "MyLongNamespace.Type.Request66";
							break;
						case 92:
							resword = "MyLongNamespace.Type.Request660";
							break;
						case 93:
							resword = "MyLongNamespace.Type.Request60";
							break;
						case 94:
							resword = "MyLongNamespace.Type.Request600";
							break;
						case 96:
							resword = "MyLongNamespace.Type.Request56";
							break;
						case 97:
							resword = "MyLongNamespace.Type.Request560";
							break;
						case 98:
							resword = "MyLongNamespace.Type.Request50";
							break;
						case 99:
							resword = "MyLongNamespace.Type.Request500";
							break;
						case 101:
							resword = "MyLongNamespace.Type.Request95";
							break;
						case 102:
							resword = "MyLongNamespace.Type.Request950";
							break;
						case 106:
							resword = "MyLongNamespace.Type.Request85";
							break;
						case 107:
							resword = "MyLongNamespace.Type.Request850";
							break;
						case 111:
							resword = "MyLongNamespace.Type.Request75";
							break;
						case 112:
							resword = "MyLongNamespace.Type.Request750";
							break;
						case 116:
							resword = "MyLongNamespace.Type.Request65";
							break;
						case 117:
							resword = "MyLongNamespace.Type.Request650";
							break;
						case 121:
							resword = "MyLongNamespace.Type.Request55";
							break;
						case 122:
							resword = "MyLongNamespace.Type.Request550";
							break;
						case 127:
							resword = "MyLongNamespace.Type.Request999";
							break;
						case 128:
							resword = "MyLongNamespace.Type.Request995";
							break;
						case 129:
							resword = "MyLongNamespace.Type.Request939";
							break;
						case 130:
							resword = "MyLongNamespace.Type.Request935";
							break;
						case 132:
							resword = "MyLongNamespace.Type.Request899";
							break;
						case 133:
							resword = "MyLongNamespace.Type.Request895";
							break;
						case 134:
							resword = "MyLongNamespace.Type.Request839";
							break;
						case 135:
							resword = "MyLongNamespace.Type.Request835";
							break;
						case 137:
							resword = "MyLongNamespace.Type.Request799";
							break;
						case 138:
							resword = "MyLongNamespace.Type.Request795";
							break;
						case 139:
							resword = "MyLongNamespace.Type.Request739";
							break;
						case 140:
							resword = "MyLongNamespace.Type.Request735";
							break;
						case 142:
							resword = "MyLongNamespace.Type.Request699";
							break;
						case 143:
							resword = "MyLongNamespace.Type.Request695";
							break;
						case 144:
							resword = "MyLongNamespace.Type.Request639";
							break;
						case 145:
							resword = "MyLongNamespace.Type.Request635";
							break;
						case 147:
							resword = "MyLongNamespace.Type.Request599";
							break;
						case 148:
							resword = "MyLongNamespace.Type.Request595";
							break;
						case 149:
							resword = "MyLongNamespace.Type.Request539";
							break;
						case 150:
							resword = "MyLongNamespace.Type.Request535";
							break;
						case 152:
							resword = "MyLongNamespace.Type.Request989";
							break;
						case 153:
							resword = "MyLongNamespace.Type.Request985";
							break;
						case 154:
							resword = "MyLongNamespace.Type.Request929";
							break;
						case 155:
							resword = "MyLongNamespace.Type.Request925";
							break;
						case 157:
							resword = "MyLongNamespace.Type.Request889";
							break;
						case 158:
							resword = "MyLongNamespace.Type.Request885";
							break;
						case 159:
							resword = "MyLongNamespace.Type.Request829";
							break;
						case 160:
							resword = "MyLongNamespace.Type.Request825";
							break;
						case 162:
							resword = "MyLongNamespace.Type.Request789";
							break;
						case 163:
							resword = "MyLongNamespace.Type.Request785";
							break;
						case 164:
							resword = "MyLongNamespace.Type.Request729";
							break;
						case 165:
							resword = "MyLongNamespace.Type.Request725";
							break;
						case 167:
							resword = "MyLongNamespace.Type.Request689";
							break;
						case 168:
							resword = "MyLongNamespace.Type.Request685";
							break;
						case 169:
							resword = "MyLongNamespace.Type.Request629";
							break;
						case 170:
							resword = "MyLongNamespace.Type.Request625";
							break;
						case 172:
							resword = "MyLongNamespace.Type.Request589";
							break;
						case 173:
							resword = "MyLongNamespace.Type.Request585";
							break;
						case 174:
							resword = "MyLongNamespace.Type.Request529";
							break;
						case 175:
							resword = "MyLongNamespace.Type.Request525";
							break;
						case 177:
							resword = "MyLongNamespace.Type.Request979";
							break;
						case 178:
							resword = "MyLongNamespace.Type.Request975";
							break;
						case 179:
							resword = "MyLongNamespace.Type.Request919";
							break;
						case 180:
							resword = "MyLongNamespace.Type.Request915";
							break;
						case 182:
							resword = "MyLongNamespace.Type.Request879";
							break;
						case 183:
							resword = "MyLongNamespace.Type.Request875";
							break;
						case 184:
							resword = "MyLongNamespace.Type.Request819";
							break;
						case 185:
							resword = "MyLongNamespace.Type.Request815";
							break;
						case 187:
							resword = "MyLongNamespace.Type.Request779";
							break;
						case 188:
							resword = "MyLongNamespace.Type.Request775";
							break;
						case 189:
							resword = "MyLongNamespace.Type.Request719";
							break;
						case 190:
							resword = "MyLongNamespace.Type.Request715";
							break;
						case 192:
							resword = "MyLongNamespace.Type.Request679";
							break;
						case 193:
							resword = "MyLongNamespace.Type.Request675";
							break;
						case 194:
							resword = "MyLongNamespace.Type.Request619";
							break;
						case 195:
							resword = "MyLongNamespace.Type.Request615";
							break;
						case 197:
							resword = "MyLongNamespace.Type.Request579";
							break;
						case 198:
							resword = "MyLongNamespace.Type.Request575";
							break;
						case 199:
							resword = "MyLongNamespace.Type.Request519";
							break;
						case 200:
							resword = "MyLongNamespace.Type.Request515";
							break;
						case 202:
							resword = "MyLongNamespace.Type.Request969";
							break;
						case 203:
							resword = "MyLongNamespace.Type.Request965";
							break;
						case 204:
							resword = "MyLongNamespace.Type.Request909";
							break;
						case 205:
							resword = "MyLongNamespace.Type.Request905";
							break;
						case 207:
							resword = "MyLongNamespace.Type.Request869";
							break;
						case 208:
							resword = "MyLongNamespace.Type.Request865";
							break;
						case 209:
							resword = "MyLongNamespace.Type.Request809";
							break;
						case 210:
							resword = "MyLongNamespace.Type.Request805";
							break;
						case 212:
							resword = "MyLongNamespace.Type.Request769";
							break;
						case 213:
							resword = "MyLongNamespace.Type.Request765";
							break;
						case 214:
							resword = "MyLongNamespace.Type.Request709";
							break;
						case 215:
							resword = "MyLongNamespace.Type.Request705";
							break;
						case 217:
							resword = "MyLongNamespace.Type.Request669";
							break;
						case 218:
							resword = "MyLongNamespace.Type.Request665";
							break;
						case 219:
							resword = "MyLongNamespace.Type.Request609";
							break;
						case 220:
							resword = "MyLongNamespace.Type.Request605";
							break;
						case 222:
							resword = "MyLongNamespace.Type.Request569";
							break;
						case 223:
							resword = "MyLongNamespace.Type.Request565";
							break;
						case 224:
							resword = "MyLongNamespace.Type.Request509";
							break;
						case 225:
							resword = "MyLongNamespace.Type.Request505";
							break;
						case 227:
							resword = "MyLongNamespace.Type.Request959";
							break;
						case 228:
							resword = "MyLongNamespace.Type.Request955";
							break;
						case 232:
							resword = "MyLongNamespace.Type.Request859";
							break;
						case 233:
							resword = "MyLongNamespace.Type.Request855";
							break;
						case 237:
							resword = "MyLongNamespace.Type.Request759";
							break;
						case 238:
							resword = "MyLongNamespace.Type.Request755";
							break;
						case 242:
							resword = "MyLongNamespace.Type.Request659";
							break;
						case 243:
							resword = "MyLongNamespace.Type.Request655";
							break;
						case 247:
							resword = "MyLongNamespace.Type.Request559";
							break;
						case 248:
							resword = "MyLongNamespace.Type.Request555";
							break;
						case 252:
							resword = "MyLongNamespace.Type.Request998";
							break;
						case 254:
							resword = "MyLongNamespace.Type.Request938";
							break;
						case 257:
							resword = "MyLongNamespace.Type.Request898";
							break;
						case 259:
							resword = "MyLongNamespace.Type.Request838";
							break;
						case 262:
							resword = "MyLongNamespace.Type.Request798";
							break;
						case 264:
							resword = "MyLongNamespace.Type.Request738";
							break;
						case 267:
							resword = "MyLongNamespace.Type.Request698";
							break;
						case 269:
							resword = "MyLongNamespace.Type.Request638";
							break;
						case 272:
							resword = "MyLongNamespace.Type.Request598";
							break;
						case 274:
							resword = "MyLongNamespace.Type.Request538";
							break;
						case 277:
							resword = "MyLongNamespace.Type.Request988";
							break;
						case 279:
							resword = "MyLongNamespace.Type.Request928";
							break;
						case 282:
							resword = "MyLongNamespace.Type.Request888";
							break;
						case 284:
							resword = "MyLongNamespace.Type.Request828";
							break;
						case 287:
							resword = "MyLongNamespace.Type.Request788";
							break;
						case 289:
							resword = "MyLongNamespace.Type.Request728";
							break;
						case 292:
							resword = "MyLongNamespace.Type.Request688";
							break;
						case 294:
							resword = "MyLongNamespace.Type.Request628";
							break;
						case 297:
							resword = "MyLongNamespace.Type.Request588";
							break;
						case 299:
							resword = "MyLongNamespace.Type.Request528";
							break;
						case 302:
							resword = "MyLongNamespace.Type.Request978";
							break;
						case 304:
							resword = "MyLongNamespace.Type.Request918";
							break;
						case 307:
							resword = "MyLongNamespace.Type.Request878";
							break;
						case 309:
							resword = "MyLongNamespace.Type.Request818";
							break;
						case 312:
							resword = "MyLongNamespace.Type.Request778";
							break;
						case 314:
							resword = "MyLongNamespace.Type.Request718";
							break;
						case 317:
							resword = "MyLongNamespace.Type.Request678";
							break;
						case 319:
							resword = "MyLongNamespace.Type.Request618";
							break;
						case 322:
							resword = "MyLongNamespace.Type.Request578";
							break;
						case 324:
							resword = "MyLongNamespace.Type.Request518";
							break;
						case 327:
							resword = "MyLongNamespace.Type.Request968";
							break;
						case 329:
							resword = "MyLongNamespace.Type.Request908";
							break;
						case 332:
							resword = "MyLongNamespace.Type.Request868";
							break;
						case 334:
							resword = "MyLongNamespace.Type.Request808";
							break;
						case 337:
							resword = "MyLongNamespace.Type.Request768";
							break;
						case 339:
							resword = "MyLongNamespace.Type.Request708";
							break;
						case 342:
							resword = "MyLongNamespace.Type.Request668";
							break;
						case 344:
							resword = "MyLongNamespace.Type.Request608";
							break;
						case 347:
							resword = "MyLongNamespace.Type.Request568";
							break;
						case 349:
							resword = "MyLongNamespace.Type.Request508";
							break;
						case 352:
							resword = "MyLongNamespace.Type.Request958";
							break;
						case 357:
							resword = "MyLongNamespace.Type.Request858";
							break;
						case 362:
							resword = "MyLongNamespace.Type.Request758";
							break;
						case 367:
							resword = "MyLongNamespace.Type.Request658";
							break;
						case 372:
							resword = "MyLongNamespace.Type.Request558";
							break;
						case 375:
							resword = "MyLongNamespace.Type.Request4";
							break;
						case 376:
							resword = "MyLongNamespace.Type.Request49";
							break;
						case 377:
							resword = "MyLongNamespace.Type.Request490";
							break;
						case 378:
							resword = "MyLongNamespace.Type.Request43";
							break;
						case 379:
							resword = "MyLongNamespace.Type.Request430";
							break;
						case 401:
							resword = "MyLongNamespace.Type.Request48";
							break;
						case 402:
							resword = "MyLongNamespace.Type.Request480";
							break;
						case 403:
							resword = "MyLongNamespace.Type.Request42";
							break;
						case 404:
							resword = "MyLongNamespace.Type.Request420";
							break;
						case 426:
							resword = "MyLongNamespace.Type.Request47";
							break;
						case 427:
							resword = "MyLongNamespace.Type.Request470";
							break;
						case 428:
							resword = "MyLongNamespace.Type.Request41";
							break;
						case 429:
							resword = "MyLongNamespace.Type.Request410";
							break;
						case 451:
							resword = "MyLongNamespace.Type.Request46";
							break;
						case 452:
							resword = "MyLongNamespace.Type.Request460";
							break;
						case 453:
							resword = "MyLongNamespace.Type.Request40";
							break;
						case 454:
							resword = "MyLongNamespace.Type.Request400";
							break;
						case 476:
							resword = "MyLongNamespace.Type.Request45";
							break;
						case 477:
							resword = "MyLongNamespace.Type.Request450";
							break;
						case 502:
							resword = "MyLongNamespace.Type.Request499";
							break;
						case 503:
							resword = "MyLongNamespace.Type.Request495";
							break;
						case 504:
							resword = "MyLongNamespace.Type.Request439";
							break;
						case 505:
							resword = "MyLongNamespace.Type.Request435";
							break;
						case 527:
							resword = "MyLongNamespace.Type.Request489";
							break;
						case 528:
							resword = "MyLongNamespace.Type.Request485";
							break;
						case 529:
							resword = "MyLongNamespace.Type.Request429";
							break;
						case 530:
							resword = "MyLongNamespace.Type.Request425";
							break;
						case 552:
							resword = "MyLongNamespace.Type.Request479";
							break;
						case 553:
							resword = "MyLongNamespace.Type.Request475";
							break;
						case 554:
							resword = "MyLongNamespace.Type.Request419";
							break;
						case 555:
							resword = "MyLongNamespace.Type.Request415";
							break;
						case 577:
							resword = "MyLongNamespace.Type.Request469";
							break;
						case 578:
							resword = "MyLongNamespace.Type.Request465";
							break;
						case 579:
							resword = "MyLongNamespace.Type.Request409";
							break;
						case 580:
							resword = "MyLongNamespace.Type.Request405";
							break;
						case 602:
							resword = "MyLongNamespace.Type.Request459";
							break;
						case 603:
							resword = "MyLongNamespace.Type.Request455";
							break;
						case 627:
							resword = "MyLongNamespace.Type.Request498";
							break;
						case 629:
							resword = "MyLongNamespace.Type.Request438";
							break;
						case 631:
							resword = "MyLongNamespace.Type.Request994";
							break;
						case 633:
							resword = "MyLongNamespace.Type.Request934";
							break;
						case 636:
							resword = "MyLongNamespace.Type.Request894";
							break;
						case 638:
							resword = "MyLongNamespace.Type.Request834";
							break;
						case 641:
							resword = "MyLongNamespace.Type.Request794";
							break;
						case 643:
							resword = "MyLongNamespace.Type.Request734";
							break;
						case 646:
							resword = "MyLongNamespace.Type.Request694";
							break;
						case 648:
							resword = "MyLongNamespace.Type.Request634";
							break;
						case 651:
							resword = "MyLongNamespace.Type.Request594";
							break;
						case 652:
							resword = "MyLongNamespace.Type.Request488";
							break;
						case 653:
							resword = "MyLongNamespace.Type.Request534";
							break;
						case 654:
							resword = "MyLongNamespace.Type.Request428";
							break;
						case 656:
							resword = "MyLongNamespace.Type.Request984";
							break;
						case 658:
							resword = "MyLongNamespace.Type.Request924";
							break;
						case 661:
							resword = "MyLongNamespace.Type.Request884";
							break;
						case 663:
							resword = "MyLongNamespace.Type.Request824";
							break;
						case 666:
							resword = "MyLongNamespace.Type.Request784";
							break;
						case 668:
							resword = "MyLongNamespace.Type.Request724";
							break;
						case 671:
							resword = "MyLongNamespace.Type.Request684";
							break;
						case 673:
							resword = "MyLongNamespace.Type.Request624";
							break;
						case 676:
							resword = "MyLongNamespace.Type.Request584";
							break;
						case 677:
							resword = "MyLongNamespace.Type.Request478";
							break;
						case 678:
							resword = "MyLongNamespace.Type.Request524";
							break;
						case 679:
							resword = "MyLongNamespace.Type.Request418";
							break;
						case 681:
							resword = "MyLongNamespace.Type.Request974";
							break;
						case 683:
							resword = "MyLongNamespace.Type.Request914";
							break;
						case 686:
							resword = "MyLongNamespace.Type.Request874";
							break;
						case 688:
							resword = "MyLongNamespace.Type.Request814";
							break;
						case 691:
							resword = "MyLongNamespace.Type.Request774";
							break;
						case 693:
							resword = "MyLongNamespace.Type.Request714";
							break;
						case 696:
							resword = "MyLongNamespace.Type.Request674";
							break;
						case 698:
							resword = "MyLongNamespace.Type.Request614";
							break;
						case 701:
							resword = "MyLongNamespace.Type.Request574";
							break;
						case 702:
							resword = "MyLongNamespace.Type.Request468";
							break;
						case 703:
							resword = "MyLongNamespace.Type.Request514";
							break;
						case 704:
							resword = "MyLongNamespace.Type.Request408";
							break;
						case 706:
							resword = "MyLongNamespace.Type.Request964";
							break;
						case 708:
							resword = "MyLongNamespace.Type.Request904";
							break;
						case 711:
							resword = "MyLongNamespace.Type.Request864";
							break;
						case 713:
							resword = "MyLongNamespace.Type.Request804";
							break;
						case 716:
							resword = "MyLongNamespace.Type.Request764";
							break;
						case 718:
							resword = "MyLongNamespace.Type.Request704";
							break;
						case 721:
							resword = "MyLongNamespace.Type.Request664";
							break;
						case 723:
							resword = "MyLongNamespace.Type.Request604";
							break;
						case 726:
							resword = "MyLongNamespace.Type.Request564";
							break;
						case 727:
							resword = "MyLongNamespace.Type.Request458";
							break;
						case 728:
							resword = "MyLongNamespace.Type.Request504";
							break;
						case 731:
							resword = "MyLongNamespace.Type.Request954";
							break;
						case 732:
							resword = "MyLongNamespace.Type.Request997";
							break;
						case 734:
							resword = "MyLongNamespace.Type.Request937";
							break;
						case 736:
							resword = "MyLongNamespace.Type.Request854";
							break;
						case 737:
							resword = "MyLongNamespace.Type.Request897";
							break;
						case 739:
							resword = "MyLongNamespace.Type.Request837";
							break;
						case 741:
							resword = "MyLongNamespace.Type.Request754";
							break;
						case 742:
							resword = "MyLongNamespace.Type.Request797";
							break;
						case 744:
							resword = "MyLongNamespace.Type.Request737";
							break;
						case 746:
							resword = "MyLongNamespace.Type.Request654";
							break;
						case 747:
							resword = "MyLongNamespace.Type.Request697";
							break;
						case 749:
							resword = "MyLongNamespace.Type.Request637";
							break;
						case 751:
							resword = "MyLongNamespace.Type.Request554";
							break;
						case 752:
							resword = "MyLongNamespace.Type.Request597";
							break;
						case 754:
							resword = "MyLongNamespace.Type.Request537";
							break;
						case 756:
							resword = "MyLongNamespace.Type.Request993";
							break;
						case 757:
							resword = "MyLongNamespace.Type.Request987";
							break;
						case 758:
							resword = "MyLongNamespace.Type.Request933";
							break;
						case 759:
							resword = "MyLongNamespace.Type.Request927";
							break;
						case 761:
							resword = "MyLongNamespace.Type.Request893";
							break;
						case 762:
							resword = "MyLongNamespace.Type.Request887";
							break;
						case 763:
							resword = "MyLongNamespace.Type.Request833";
							break;
						case 764:
							resword = "MyLongNamespace.Type.Request827";
							break;
						case 766:
							resword = "MyLongNamespace.Type.Request793";
							break;
						case 767:
							resword = "MyLongNamespace.Type.Request787";
							break;
						case 768:
							resword = "MyLongNamespace.Type.Request733";
							break;
						case 769:
							resword = "MyLongNamespace.Type.Request727";
							break;
						case 771:
							resword = "MyLongNamespace.Type.Request693";
							break;
						case 772:
							resword = "MyLongNamespace.Type.Request687";
							break;
						case 773:
							resword = "MyLongNamespace.Type.Request633";
							break;
						case 774:
							resword = "MyLongNamespace.Type.Request627";
							break;
						case 776:
							resword = "MyLongNamespace.Type.Request593";
							break;
						case 777:
							resword = "MyLongNamespace.Type.Request587";
							break;
						case 778:
							resword = "MyLongNamespace.Type.Request533";
							break;
						case 779:
							resword = "MyLongNamespace.Type.Request527";
							break;
						case 781:
							resword = "MyLongNamespace.Type.Request983";
							break;
						case 782:
							resword = "MyLongNamespace.Type.Request977";
							break;
						case 783:
							resword = "MyLongNamespace.Type.Request923";
							break;
						case 784:
							resword = "MyLongNamespace.Type.Request917";
							break;
						case 786:
							resword = "MyLongNamespace.Type.Request883";
							break;
						case 787:
							resword = "MyLongNamespace.Type.Request877";
							break;
						case 788:
							resword = "MyLongNamespace.Type.Request823";
							break;
						case 789:
							resword = "MyLongNamespace.Type.Request817";
							break;
						case 791:
							resword = "MyLongNamespace.Type.Request783";
							break;
						case 792:
							resword = "MyLongNamespace.Type.Request777";
							break;
						case 793:
							resword = "MyLongNamespace.Type.Request723";
							break;
						case 794:
							resword = "MyLongNamespace.Type.Request717";
							break;
						case 796:
							resword = "MyLongNamespace.Type.Request683";
							break;
						case 797:
							resword = "MyLongNamespace.Type.Request677";
							break;
						case 798:
							resword = "MyLongNamespace.Type.Request623";
							break;
						case 799:
							resword = "MyLongNamespace.Type.Request617";
							break;
						case 801:
							resword = "MyLongNamespace.Type.Request583";
							break;
						case 802:
							resword = "MyLongNamespace.Type.Request577";
							break;
						case 803:
							resword = "MyLongNamespace.Type.Request523";
							break;
						case 804:
							resword = "MyLongNamespace.Type.Request517";
							break;
						case 806:
							resword = "MyLongNamespace.Type.Request973";
							break;
						case 807:
							resword = "MyLongNamespace.Type.Request967";
							break;
						case 808:
							resword = "MyLongNamespace.Type.Request913";
							break;
						case 809:
							resword = "MyLongNamespace.Type.Request907";
							break;
						case 811:
							resword = "MyLongNamespace.Type.Request873";
							break;
						case 812:
							resword = "MyLongNamespace.Type.Request867";
							break;
						case 813:
							resword = "MyLongNamespace.Type.Request813";
							break;
						case 814:
							resword = "MyLongNamespace.Type.Request807";
							break;
						case 816:
							resword = "MyLongNamespace.Type.Request773";
							break;
						case 817:
							resword = "MyLongNamespace.Type.Request767";
							break;
						case 818:
							resword = "MyLongNamespace.Type.Request713";
							break;
						case 819:
							resword = "MyLongNamespace.Type.Request707";
							break;
						case 821:
							resword = "MyLongNamespace.Type.Request673";
							break;
						case 822:
							resword = "MyLongNamespace.Type.Request667";
							break;
						case 823:
							resword = "MyLongNamespace.Type.Request613";
							break;
						case 824:
							resword = "MyLongNamespace.Type.Request607";
							break;
						case 826:
							resword = "MyLongNamespace.Type.Request573";
							break;
						case 827:
							resword = "MyLongNamespace.Type.Request567";
							break;
						case 828:
							resword = "MyLongNamespace.Type.Request513";
							break;
						case 829:
							resword = "MyLongNamespace.Type.Request507";
							break;
						case 831:
							resword = "MyLongNamespace.Type.Request963";
							break;
						case 832:
							resword = "MyLongNamespace.Type.Request957";
							break;
						case 833:
							resword = "MyLongNamespace.Type.Request903";
							break;
						case 836:
							resword = "MyLongNamespace.Type.Request863";
							break;
						case 837:
							resword = "MyLongNamespace.Type.Request857";
							break;
						case 838:
							resword = "MyLongNamespace.Type.Request803";
							break;
						case 841:
							resword = "MyLongNamespace.Type.Request763";
							break;
						case 842:
							resword = "MyLongNamespace.Type.Request757";
							break;
						case 843:
							resword = "MyLongNamespace.Type.Request703";
							break;
						case 846:
							resword = "MyLongNamespace.Type.Request663";
							break;
						case 847:
							resword = "MyLongNamespace.Type.Request657";
							break;
						case 848:
							resword = "MyLongNamespace.Type.Request603";
							break;
						case 851:
							resword = "MyLongNamespace.Type.Request563";
							break;
						case 852:
							resword = "MyLongNamespace.Type.Request557";
							break;
						case 853:
							resword = "MyLongNamespace.Type.Request503";
							break;
						case 856:
							resword = "MyLongNamespace.Type.Request953";
							break;
						case 857:
							resword = "MyLongNamespace.Type.Request94";
							break;
						case 858:
							resword = "MyLongNamespace.Type.Request940";
							break;
						case 861:
							resword = "MyLongNamespace.Type.Request853";
							break;
						case 862:
							resword = "MyLongNamespace.Type.Request84";
							break;
						case 863:
							resword = "MyLongNamespace.Type.Request840";
							break;
						case 866:
							resword = "MyLongNamespace.Type.Request753";
							break;
						case 867:
							resword = "MyLongNamespace.Type.Request74";
							break;
						case 868:
							resword = "MyLongNamespace.Type.Request740";
							break;
						case 871:
							resword = "MyLongNamespace.Type.Request653";
							break;
						case 872:
							resword = "MyLongNamespace.Type.Request64";
							break;
						case 873:
							resword = "MyLongNamespace.Type.Request640";
							break;
						case 876:
							resword = "MyLongNamespace.Type.Request553";
							break;
						case 877:
							resword = "MyLongNamespace.Type.Request54";
							break;
						case 878:
							resword = "MyLongNamespace.Type.Request540";
							break;
						case 882:
							resword = "MyLongNamespace.Type.Request996";
							break;
						case 884:
							resword = "MyLongNamespace.Type.Request936";
							break;
						case 887:
							resword = "MyLongNamespace.Type.Request896";
							break;
						case 889:
							resword = "MyLongNamespace.Type.Request836";
							break;
						case 892:
							resword = "MyLongNamespace.Type.Request796";
							break;
						case 894:
							resword = "MyLongNamespace.Type.Request736";
							break;
						case 897:
							resword = "MyLongNamespace.Type.Request696";
							break;
						case 899:
							resword = "MyLongNamespace.Type.Request636";
							break;
						case 902:
							resword = "MyLongNamespace.Type.Request596";
							break;
						case 904:
							resword = "MyLongNamespace.Type.Request536";
							break;
						case 907:
							resword = "MyLongNamespace.Type.Request986";
							break;
						case 909:
							resword = "MyLongNamespace.Type.Request926";
							break;
						case 912:
							resword = "MyLongNamespace.Type.Request886";
							break;
						case 914:
							resword = "MyLongNamespace.Type.Request826";
							break;
						case 917:
							resword = "MyLongNamespace.Type.Request786";
							break;
						case 919:
							resword = "MyLongNamespace.Type.Request726";
							break;
						case 922:
							resword = "MyLongNamespace.Type.Request686";
							break;
						case 924:
							resword = "MyLongNamespace.Type.Request626";
							break;
						case 927:
							resword = "MyLongNamespace.Type.Request586";
							break;
						case 929:
							resword = "MyLongNamespace.Type.Request526";
							break;
						case 932:
							resword = "MyLongNamespace.Type.Request976";
							break;
						case 934:
							resword = "MyLongNamespace.Type.Request916";
							break;
						case 937:
							resword = "MyLongNamespace.Type.Request876";
							break;
						case 939:
							resword = "MyLongNamespace.Type.Request816";
							break;
						case 942:
							resword = "MyLongNamespace.Type.Request776";
							break;
						case 944:
							resword = "MyLongNamespace.Type.Request716";
							break;
						case 947:
							resword = "MyLongNamespace.Type.Request676";
							break;
						case 949:
							resword = "MyLongNamespace.Type.Request616";
							break;
						case 952:
							resword = "MyLongNamespace.Type.Request576";
							break;
						case 954:
							resword = "MyLongNamespace.Type.Request516";
							break;
						case 957:
							resword = "MyLongNamespace.Type.Request966";
							break;
						case 959:
							resword = "MyLongNamespace.Type.Request906";
							break;
						case 962:
							resword = "MyLongNamespace.Type.Request866";
							break;
						case 964:
							resword = "MyLongNamespace.Type.Request806";
							break;
						case 967:
							resword = "MyLongNamespace.Type.Request766";
							break;
						case 969:
							resword = "MyLongNamespace.Type.Request706";
							break;
						case 972:
							resword = "MyLongNamespace.Type.Request666";
							break;
						case 974:
							resword = "MyLongNamespace.Type.Request606";
							break;
						case 977:
							resword = "MyLongNamespace.Type.Request566";
							break;
						case 979:
							resword = "MyLongNamespace.Type.Request506";
							break;
						case 982:
							resword = "MyLongNamespace.Type.Request956";
							break;
						case 983:
							resword = "MyLongNamespace.Type.Request949";
							break;
						case 984:
							resword = "MyLongNamespace.Type.Request945";
							break;
						case 987:
							resword = "MyLongNamespace.Type.Request856";
							break;
						case 988:
							resword = "MyLongNamespace.Type.Request849";
							break;
						case 989:
							resword = "MyLongNamespace.Type.Request845";
							break;
						case 992:
							resword = "MyLongNamespace.Type.Request756";
							break;
						case 993:
							resword = "MyLongNamespace.Type.Request749";
							break;
						case 994:
							resword = "MyLongNamespace.Type.Request745";
							break;
						case 997:
							resword = "MyLongNamespace.Type.Request656";
							break;
						case 998:
							resword = "MyLongNamespace.Type.Request649";
							break;
						case 999:
							resword = "MyLongNamespace.Type.Request645";
							break;
						case 1002:
							resword = "MyLongNamespace.Type.Request556";
							break;
						case 1003:
							resword = "MyLongNamespace.Type.Request549";
							break;
						case 1004:
							resword = "MyLongNamespace.Type.Request545";
							break;
						case 1006:
							resword = "MyLongNamespace.Type.Request494";
							break;
						case 1008:
							resword = "MyLongNamespace.Type.Request434";
							break;
						case 1010:
							resword = "MyLongNamespace.Type.Request3";
							break;
						case 1011:
							resword = "MyLongNamespace.Type.Request39";
							break;
						case 1012:
							resword = "MyLongNamespace.Type.Request390";
							break;
						case 1013:
							resword = "MyLongNamespace.Type.Request33";
							break;
						case 1014:
							resword = "MyLongNamespace.Type.Request330";
							break;
						case 1015:
							resword = "MyLongNamespace.Type.Request2";
							break;
						case 1016:
							resword = "MyLongNamespace.Type.Request29";
							break;
						case 1017:
							resword = "MyLongNamespace.Type.Request290";
							break;
						case 1018:
							resword = "MyLongNamespace.Type.Request23";
							break;
						case 1019:
							resword = "MyLongNamespace.Type.Request230";
							break;
						case 1020:
							resword = "MyLongNamespace.Type.Request1";
							break;
						case 1021:
							resword = "MyLongNamespace.Type.Request19";
							break;
						case 1022:
							resword = "MyLongNamespace.Type.Request190";
							break;
						case 1023:
							resword = "MyLongNamespace.Type.Request13";
							break;
						case 1024:
							resword = "MyLongNamespace.Type.Request130";
							break;
						case 1031:
							resword = "MyLongNamespace.Type.Request484";
							break;
						case 1033:
							resword = "MyLongNamespace.Type.Request424";
							break;
						case 1036:
							resword = "MyLongNamespace.Type.Request38";
							break;
						case 1037:
							resword = "MyLongNamespace.Type.Request380";
							break;
						case 1038:
							resword = "MyLongNamespace.Type.Request32";
							break;
						case 1039:
							resword = "MyLongNamespace.Type.Request320";
							break;
						case 1041:
							resword = "MyLongNamespace.Type.Request28";
							break;
						case 1042:
							resword = "MyLongNamespace.Type.Request280";
							break;
						case 1043:
							resword = "MyLongNamespace.Type.Request22";
							break;
						case 1044:
							resword = "MyLongNamespace.Type.Request220";
							break;
						case 1046:
							resword = "MyLongNamespace.Type.Request18";
							break;
						case 1047:
							resword = "MyLongNamespace.Type.Request180";
							break;
						case 1048:
							resword = "MyLongNamespace.Type.Request12";
							break;
						case 1049:
							resword = "MyLongNamespace.Type.Request120";
							break;
						case 1056:
							resword = "MyLongNamespace.Type.Request474";
							break;
						case 1058:
							resword = "MyLongNamespace.Type.Request414";
							break;
						case 1061:
							resword = "MyLongNamespace.Type.Request37";
							break;
						case 1062:
							resword = "MyLongNamespace.Type.Request370";
							break;
						case 1063:
							resword = "MyLongNamespace.Type.Request31";
							break;
						case 1064:
							resword = "MyLongNamespace.Type.Request310";
							break;
						case 1066:
							resword = "MyLongNamespace.Type.Request27";
							break;
						case 1067:
							resword = "MyLongNamespace.Type.Request270";
							break;
						case 1068:
							resword = "MyLongNamespace.Type.Request21";
							break;
						case 1069:
							resword = "MyLongNamespace.Type.Request210";
							break;
						case 1071:
							resword = "MyLongNamespace.Type.Request17";
							break;
						case 1072:
							resword = "MyLongNamespace.Type.Request170";
							break;
						case 1073:
							resword = "MyLongNamespace.Type.Request11";
							break;
						case 1074:
							resword = "MyLongNamespace.Type.Request110";
							break;
						case 1081:
							resword = "MyLongNamespace.Type.Request464";
							break;
						case 1083:
							resword = "MyLongNamespace.Type.Request404";
							break;
						case 1086:
							resword = "MyLongNamespace.Type.Request36";
							break;
						case 1087:
							resword = "MyLongNamespace.Type.Request360";
							break;
						case 1088:
							resword = "MyLongNamespace.Type.Request30";
							break;
						case 1089:
							resword = "MyLongNamespace.Type.Request300";
							break;
						case 1091:
							resword = "MyLongNamespace.Type.Request26";
							break;
						case 1092:
							resword = "MyLongNamespace.Type.Request260";
							break;
						case 1093:
							resword = "MyLongNamespace.Type.Request20";
							break;
						case 1094:
							resword = "MyLongNamespace.Type.Request200";
							break;
						case 1096:
							resword = "MyLongNamespace.Type.Request16";
							break;
						case 1097:
							resword = "MyLongNamespace.Type.Request160";
							break;
						case 1098:
							resword = "MyLongNamespace.Type.Request10";
							break;
						case 1099:
							resword = "MyLongNamespace.Type.Request100";
							break;
						case 1106:
							resword = "MyLongNamespace.Type.Request454";
							break;
						case 1107:
							resword = "MyLongNamespace.Type.Request497";
							break;
						case 1108:
							resword = "MyLongNamespace.Type.Request948";
							break;
						case 1109:
							resword = "MyLongNamespace.Type.Request437";
							break;
						case 1111:
							resword = "MyLongNamespace.Type.Request35";
							break;
						case 1112:
							resword = "MyLongNamespace.Type.Request350";
							break;
						case 1113:
							resword = "MyLongNamespace.Type.Request848";
							break;
						case 1116:
							resword = "MyLongNamespace.Type.Request25";
							break;
						case 1117:
							resword = "MyLongNamespace.Type.Request250";
							break;
						case 1118:
							resword = "MyLongNamespace.Type.Request748";
							break;
						case 1121:
							resword = "MyLongNamespace.Type.Request15";
							break;
						case 1122:
							resword = "MyLongNamespace.Type.Request150";
							break;
						case 1123:
							resword = "MyLongNamespace.Type.Request648";
							break;
						case 1128:
							resword = "MyLongNamespace.Type.Request548";
							break;
						case 1131:
							resword = "MyLongNamespace.Type.Request493";
							break;
						case 1132:
							resword = "MyLongNamespace.Type.Request487";
							break;
						case 1133:
							resword = "MyLongNamespace.Type.Request433";
							break;
						case 1134:
							resword = "MyLongNamespace.Type.Request427";
							break;
						case 1137:
							resword = "MyLongNamespace.Type.Request399";
							break;
						case 1138:
							resword = "MyLongNamespace.Type.Request395";
							break;
						case 1139:
							resword = "MyLongNamespace.Type.Request339";
							break;
						case 1140:
							resword = "MyLongNamespace.Type.Request335";
							break;
						case 1142:
							resword = "MyLongNamespace.Type.Request299";
							break;
						case 1143:
							resword = "MyLongNamespace.Type.Request295";
							break;
						case 1144:
							resword = "MyLongNamespace.Type.Request239";
							break;
						case 1145:
							resword = "MyLongNamespace.Type.Request235";
							break;
						case 1147:
							resword = "MyLongNamespace.Type.Request199";
							break;
						case 1148:
							resword = "MyLongNamespace.Type.Request195";
							break;
						case 1149:
							resword = "MyLongNamespace.Type.Request139";
							break;
						case 1150:
							resword = "MyLongNamespace.Type.Request135";
							break;
						case 1156:
							resword = "MyLongNamespace.Type.Request483";
							break;
						case 1157:
							resword = "MyLongNamespace.Type.Request477";
							break;
						case 1158:
							resword = "MyLongNamespace.Type.Request423";
							break;
						case 1159:
							resword = "MyLongNamespace.Type.Request417";
							break;
						case 1162:
							resword = "MyLongNamespace.Type.Request389";
							break;
						case 1163:
							resword = "MyLongNamespace.Type.Request385";
							break;
						case 1164:
							resword = "MyLongNamespace.Type.Request329";
							break;
						case 1165:
							resword = "MyLongNamespace.Type.Request325";
							break;
						case 1167:
							resword = "MyLongNamespace.Type.Request289";
							break;
						case 1168:
							resword = "MyLongNamespace.Type.Request285";
							break;
						case 1169:
							resword = "MyLongNamespace.Type.Request229";
							break;
						case 1170:
							resword = "MyLongNamespace.Type.Request225";
							break;
						case 1172:
							resword = "MyLongNamespace.Type.Request189";
							break;
						case 1173:
							resword = "MyLongNamespace.Type.Request185";
							break;
						case 1174:
							resword = "MyLongNamespace.Type.Request129";
							break;
						case 1175:
							resword = "MyLongNamespace.Type.Request125";
							break;
						case 1181:
							resword = "MyLongNamespace.Type.Request473";
							break;
						case 1182:
							resword = "MyLongNamespace.Type.Request467";
							break;
						case 1183:
							resword = "MyLongNamespace.Type.Request413";
							break;
						case 1184:
							resword = "MyLongNamespace.Type.Request407";
							break;
						case 1187:
							resword = "MyLongNamespace.Type.Request379";
							break;
						case 1188:
							resword = "MyLongNamespace.Type.Request375";
							break;
						case 1189:
							resword = "MyLongNamespace.Type.Request319";
							break;
						case 1190:
							resword = "MyLongNamespace.Type.Request315";
							break;
						case 1192:
							resword = "MyLongNamespace.Type.Request279";
							break;
						case 1193:
							resword = "MyLongNamespace.Type.Request275";
							break;
						case 1194:
							resword = "MyLongNamespace.Type.Request219";
							break;
						case 1195:
							resword = "MyLongNamespace.Type.Request215";
							break;
						case 1197:
							resword = "MyLongNamespace.Type.Request179";
							break;
						case 1198:
							resword = "MyLongNamespace.Type.Request175";
							break;
						case 1199:
							resword = "MyLongNamespace.Type.Request119";
							break;
						case 1200:
							resword = "MyLongNamespace.Type.Request115";
							break;
						case 1206:
							resword = "MyLongNamespace.Type.Request463";
							break;
						case 1207:
							resword = "MyLongNamespace.Type.Request457";
							break;
						case 1208:
							resword = "MyLongNamespace.Type.Request403";
							break;
						case 1212:
							resword = "MyLongNamespace.Type.Request369";
							break;
						case 1213:
							resword = "MyLongNamespace.Type.Request365";
							break;
						case 1214:
							resword = "MyLongNamespace.Type.Request309";
							break;
						case 1215:
							resword = "MyLongNamespace.Type.Request305";
							break;
						case 1217:
							resword = "MyLongNamespace.Type.Request269";
							break;
						case 1218:
							resword = "MyLongNamespace.Type.Request265";
							break;
						case 1219:
							resword = "MyLongNamespace.Type.Request209";
							break;
						case 1220:
							resword = "MyLongNamespace.Type.Request205";
							break;
						case 1222:
							resword = "MyLongNamespace.Type.Request169";
							break;
						case 1223:
							resword = "MyLongNamespace.Type.Request165";
							break;
						case 1224:
							resword = "MyLongNamespace.Type.Request109";
							break;
						case 1225:
							resword = "MyLongNamespace.Type.Request105";
							break;
						case 1231:
							resword = "MyLongNamespace.Type.Request453";
							break;
						case 1232:
							resword = "MyLongNamespace.Type.Request44";
							break;
						case 1233:
							resword = "MyLongNamespace.Type.Request440";
							break;
						case 1237:
							resword = "MyLongNamespace.Type.Request359";
							break;
						case 1238:
							resword = "MyLongNamespace.Type.Request355";
							break;
						case 1242:
							resword = "MyLongNamespace.Type.Request259";
							break;
						case 1243:
							resword = "MyLongNamespace.Type.Request255";
							break;
						case 1247:
							resword = "MyLongNamespace.Type.Request159";
							break;
						case 1248:
							resword = "MyLongNamespace.Type.Request155";
							break;
						case 1256:
							resword = "MyLongNamespace.Type.Request992";
							break;
						case 1257:
							resword = "MyLongNamespace.Type.Request496";
							break;
						case 1258:
							resword = "MyLongNamespace.Type.Request932";
							break;
						case 1259:
							resword = "MyLongNamespace.Type.Request436";
							break;
						case 1261:
							resword = "MyLongNamespace.Type.Request892";
							break;
						case 1262:
							resword = "MyLongNamespace.Type.Request398";
							break;
						case 1263:
							resword = "MyLongNamespace.Type.Request832";
							break;
						case 1264:
							resword = "MyLongNamespace.Type.Request338";
							break;
						case 1266:
							resword = "MyLongNamespace.Type.Request792";
							break;
						case 1267:
							resword = "MyLongNamespace.Type.Request298";
							break;
						case 1268:
							resword = "MyLongNamespace.Type.Request732";
							break;
						case 1269:
							resword = "MyLongNamespace.Type.Request238";
							break;
						case 1271:
							resword = "MyLongNamespace.Type.Request692";
							break;
						case 1272:
							resword = "MyLongNamespace.Type.Request198";
							break;
						case 1273:
							resword = "MyLongNamespace.Type.Request632";
							break;
						case 1274:
							resword = "MyLongNamespace.Type.Request138";
							break;
						case 1276:
							resword = "MyLongNamespace.Type.Request592";
							break;
						case 1278:
							resword = "MyLongNamespace.Type.Request532";
							break;
						case 1281:
							resword = "MyLongNamespace.Type.Request982";
							break;
						case 1282:
							resword = "MyLongNamespace.Type.Request486";
							break;
						case 1283:
							resword = "MyLongNamespace.Type.Request922";
							break;
						case 1284:
							resword = "MyLongNamespace.Type.Request426";
							break;
						case 1286:
							resword = "MyLongNamespace.Type.Request882";
							break;
						case 1287:
							resword = "MyLongNamespace.Type.Request388";
							break;
						case 1288:
							resword = "MyLongNamespace.Type.Request822";
							break;
						case 1289:
							resword = "MyLongNamespace.Type.Request328";
							break;
						case 1291:
							resword = "MyLongNamespace.Type.Request782";
							break;
						case 1292:
							resword = "MyLongNamespace.Type.Request288";
							break;
						case 1293:
							resword = "MyLongNamespace.Type.Request722";
							break;
						case 1294:
							resword = "MyLongNamespace.Type.Request228";
							break;
						case 1296:
							resword = "MyLongNamespace.Type.Request682";
							break;
						case 1297:
							resword = "MyLongNamespace.Type.Request188";
							break;
						case 1298:
							resword = "MyLongNamespace.Type.Request622";
							break;
						case 1299:
							resword = "MyLongNamespace.Type.Request128";
							break;
						case 1301:
							resword = "MyLongNamespace.Type.Request582";
							break;
						case 1303:
							resword = "MyLongNamespace.Type.Request522";
							break;
						case 1306:
							resword = "MyLongNamespace.Type.Request972";
							break;
						case 1307:
							resword = "MyLongNamespace.Type.Request476";
							break;
						case 1308:
							resword = "MyLongNamespace.Type.Request912";
							break;
						case 1309:
							resword = "MyLongNamespace.Type.Request416";
							break;
						case 1311:
							resword = "MyLongNamespace.Type.Request872";
							break;
						case 1312:
							resword = "MyLongNamespace.Type.Request378";
							break;
						case 1313:
							resword = "MyLongNamespace.Type.Request812";
							break;
						case 1314:
							resword = "MyLongNamespace.Type.Request318";
							break;
						case 1316:
							resword = "MyLongNamespace.Type.Request772";
							break;
						case 1317:
							resword = "MyLongNamespace.Type.Request278";
							break;
						case 1318:
							resword = "MyLongNamespace.Type.Request712";
							break;
						case 1319:
							resword = "MyLongNamespace.Type.Request218";
							break;
						case 1321:
							resword = "MyLongNamespace.Type.Request672";
							break;
						case 1322:
							resword = "MyLongNamespace.Type.Request178";
							break;
						case 1323:
							resword = "MyLongNamespace.Type.Request612";
							break;
						case 1324:
							resword = "MyLongNamespace.Type.Request118";
							break;
						case 1326:
							resword = "MyLongNamespace.Type.Request572";
							break;
						case 1328:
							resword = "MyLongNamespace.Type.Request512";
							break;
						case 1331:
							resword = "MyLongNamespace.Type.Request962";
							break;
						case 1332:
							resword = "MyLongNamespace.Type.Request466";
							break;
						case 1333:
							resword = "MyLongNamespace.Type.Request902";
							break;
						case 1334:
							resword = "MyLongNamespace.Type.Request406";
							break;
						case 1336:
							resword = "MyLongNamespace.Type.Request862";
							break;
						case 1337:
							resword = "MyLongNamespace.Type.Request368";
							break;
						case 1338:
							resword = "MyLongNamespace.Type.Request802";
							break;
						case 1339:
							resword = "MyLongNamespace.Type.Request308";
							break;
						case 1341:
							resword = "MyLongNamespace.Type.Request762";
							break;
						case 1342:
							resword = "MyLongNamespace.Type.Request268";
							break;
						case 1343:
							resword = "MyLongNamespace.Type.Request702";
							break;
						case 1344:
							resword = "MyLongNamespace.Type.Request208";
							break;
						case 1346:
							resword = "MyLongNamespace.Type.Request662";
							break;
						case 1347:
							resword = "MyLongNamespace.Type.Request168";
							break;
						case 1348:
							resword = "MyLongNamespace.Type.Request602";
							break;
						case 1349:
							resword = "MyLongNamespace.Type.Request108";
							break;
						case 1351:
							resword = "MyLongNamespace.Type.Request562";
							break;
						case 1353:
							resword = "MyLongNamespace.Type.Request502";
							break;
						case 1356:
							resword = "MyLongNamespace.Type.Request952";
							break;
						case 1357:
							resword = "MyLongNamespace.Type.Request456";
							break;
						case 1358:
							resword = "MyLongNamespace.Type.Request449";
							break;
						case 1359:
							resword = "MyLongNamespace.Type.Request445";
							break;
						case 1361:
							resword = "MyLongNamespace.Type.Request852";
							break;
						case 1362:
							resword = "MyLongNamespace.Type.Request358";
							break;
						case 1366:
							resword = "MyLongNamespace.Type.Request752";
							break;
						case 1367:
							resword = "MyLongNamespace.Type.Request258";
							break;
						case 1371:
							resword = "MyLongNamespace.Type.Request652";
							break;
						case 1372:
							resword = "MyLongNamespace.Type.Request158";
							break;
						case 1376:
							resword = "MyLongNamespace.Type.Request552";
							break;
						case 1483:
							resword = "MyLongNamespace.Type.Request448";
							break;
						case 1486:
							resword = "MyLongNamespace.Type.Request991";
							break;
						case 1487:
							resword = "MyLongNamespace.Type.Request944";
							break;
						case 1488:
							resword = "MyLongNamespace.Type.Request931";
							break;
						case 1491:
							resword = "MyLongNamespace.Type.Request891";
							break;
						case 1492:
							resword = "MyLongNamespace.Type.Request844";
							break;
						case 1493:
							resword = "MyLongNamespace.Type.Request831";
							break;
						case 1496:
							resword = "MyLongNamespace.Type.Request791";
							break;
						case 1497:
							resword = "MyLongNamespace.Type.Request744";
							break;
						case 1498:
							resword = "MyLongNamespace.Type.Request731";
							break;
						case 1501:
							resword = "MyLongNamespace.Type.Request691";
							break;
						case 1502:
							resword = "MyLongNamespace.Type.Request644";
							break;
						case 1503:
							resword = "MyLongNamespace.Type.Request631";
							break;
						case 1506:
							resword = "MyLongNamespace.Type.Request591";
							break;
						case 1507:
							resword = "MyLongNamespace.Type.Request544";
							break;
						case 1508:
							resword = "MyLongNamespace.Type.Request531";
							break;
						case 1511:
							resword = "MyLongNamespace.Type.Request981";
							break;
						case 1513:
							resword = "MyLongNamespace.Type.Request921";
							break;
						case 1516:
							resword = "MyLongNamespace.Type.Request881";
							break;
						case 1518:
							resword = "MyLongNamespace.Type.Request821";
							break;
						case 1521:
							resword = "MyLongNamespace.Type.Request781";
							break;
						case 1523:
							resword = "MyLongNamespace.Type.Request721";
							break;
						case 1526:
							resword = "MyLongNamespace.Type.Request681";
							break;
						case 1528:
							resword = "MyLongNamespace.Type.Request621";
							break;
						case 1531:
							resword = "MyLongNamespace.Type.Request581";
							break;
						case 1533:
							resword = "MyLongNamespace.Type.Request521";
							break;
						case 1536:
							resword = "MyLongNamespace.Type.Request971";
							break;
						case 1538:
							resword = "MyLongNamespace.Type.Request911";
							break;
						case 1541:
							resword = "MyLongNamespace.Type.Request871";
							break;
						case 1543:
							resword = "MyLongNamespace.Type.Request811";
							break;
						case 1546:
							resword = "MyLongNamespace.Type.Request771";
							break;
						case 1548:
							resword = "MyLongNamespace.Type.Request711";
							break;
						case 1551:
							resword = "MyLongNamespace.Type.Request671";
							break;
						case 1553:
							resword = "MyLongNamespace.Type.Request611";
							break;
						case 1556:
							resword = "MyLongNamespace.Type.Request571";
							break;
						case 1558:
							resword = "MyLongNamespace.Type.Request511";
							break;
						case 1561:
							resword = "MyLongNamespace.Type.Request961";
							break;
						case 1563:
							resword = "MyLongNamespace.Type.Request901";
							break;
						case 1566:
							resword = "MyLongNamespace.Type.Request861";
							break;
						case 1568:
							resword = "MyLongNamespace.Type.Request801";
							break;
						case 1571:
							resword = "MyLongNamespace.Type.Request761";
							break;
						case 1573:
							resword = "MyLongNamespace.Type.Request701";
							break;
						case 1576:
							resword = "MyLongNamespace.Type.Request661";
							break;
						case 1578:
							resword = "MyLongNamespace.Type.Request601";
							break;
						case 1581:
							resword = "MyLongNamespace.Type.Request561";
							break;
						case 1583:
							resword = "MyLongNamespace.Type.Request501";
							break;
						case 1586:
							resword = "MyLongNamespace.Type.Request951";
							break;
						case 1588:
							resword = "MyLongNamespace.Type.Request947";
							break;
						case 1591:
							resword = "MyLongNamespace.Type.Request851";
							break;
						case 1593:
							resword = "MyLongNamespace.Type.Request847";
							break;
						case 1596:
							resword = "MyLongNamespace.Type.Request751";
							break;
						case 1598:
							resword = "MyLongNamespace.Type.Request747";
							break;
						case 1601:
							resword = "MyLongNamespace.Type.Request651";
							break;
						case 1603:
							resword = "MyLongNamespace.Type.Request647";
							break;
						case 1606:
							resword = "MyLongNamespace.Type.Request551";
							break;
						case 1608:
							resword = "MyLongNamespace.Type.Request547";
							break;
						case 1612:
							resword = "MyLongNamespace.Type.Request943";
							break;
						case 1617:
							resword = "MyLongNamespace.Type.Request843";
							break;
						case 1622:
							resword = "MyLongNamespace.Type.Request743";
							break;
						case 1627:
							resword = "MyLongNamespace.Type.Request643";
							break;
						case 1631:
							resword = "MyLongNamespace.Type.Request492";
							break;
						case 1632:
							resword = "MyLongNamespace.Type.Request543";
							break;
						case 1633:
							resword = "MyLongNamespace.Type.Request432";
							break;
						case 1641:
							resword = "MyLongNamespace.Type.Request394";
							break;
						case 1643:
							resword = "MyLongNamespace.Type.Request334";
							break;
						case 1646:
							resword = "MyLongNamespace.Type.Request294";
							break;
						case 1648:
							resword = "MyLongNamespace.Type.Request234";
							break;
						case 1651:
							resword = "MyLongNamespace.Type.Request194";
							break;
						case 1653:
							resword = "MyLongNamespace.Type.Request134";
							break;
						case 1656:
							resword = "MyLongNamespace.Type.Request482";
							break;
						case 1658:
							resword = "MyLongNamespace.Type.Request422";
							break;
						case 1666:
							resword = "MyLongNamespace.Type.Request384";
							break;
						case 1668:
							resword = "MyLongNamespace.Type.Request324";
							break;
						case 1671:
							resword = "MyLongNamespace.Type.Request284";
							break;
						case 1673:
							resword = "MyLongNamespace.Type.Request224";
							break;
						case 1676:
							resword = "MyLongNamespace.Type.Request184";
							break;
						case 1678:
							resword = "MyLongNamespace.Type.Request124";
							break;
						case 1681:
							resword = "MyLongNamespace.Type.Request472";
							break;
						case 1683:
							resword = "MyLongNamespace.Type.Request412";
							break;
						case 1691:
							resword = "MyLongNamespace.Type.Request374";
							break;
						case 1693:
							resword = "MyLongNamespace.Type.Request314";
							break;
						case 1696:
							resword = "MyLongNamespace.Type.Request274";
							break;
						case 1698:
							resword = "MyLongNamespace.Type.Request214";
							break;
						case 1701:
							resword = "MyLongNamespace.Type.Request174";
							break;
						case 1703:
							resword = "MyLongNamespace.Type.Request114";
							break;
						case 1706:
							resword = "MyLongNamespace.Type.Request462";
							break;
						case 1708:
							resword = "MyLongNamespace.Type.Request402";
							break;
						case 1716:
							resword = "MyLongNamespace.Type.Request364";
							break;
						case 1718:
							resword = "MyLongNamespace.Type.Request304";
							break;
						case 1721:
							resword = "MyLongNamespace.Type.Request264";
							break;
						case 1723:
							resword = "MyLongNamespace.Type.Request204";
							break;
						case 1726:
							resword = "MyLongNamespace.Type.Request164";
							break;
						case 1728:
							resword = "MyLongNamespace.Type.Request104";
							break;
						case 1731:
							resword = "MyLongNamespace.Type.Request452";
							break;
						case 1738:
							resword = "MyLongNamespace.Type.Request946";
							break;
						case 1741:
							resword = "MyLongNamespace.Type.Request354";
							break;
						case 1742:
							resword = "MyLongNamespace.Type.Request397";
							break;
						case 1743:
							resword = "MyLongNamespace.Type.Request846";
							break;
						case 1744:
							resword = "MyLongNamespace.Type.Request337";
							break;
						case 1746:
							resword = "MyLongNamespace.Type.Request254";
							break;
						case 1747:
							resword = "MyLongNamespace.Type.Request297";
							break;
						case 1748:
							resword = "MyLongNamespace.Type.Request746";
							break;
						case 1749:
							resword = "MyLongNamespace.Type.Request237";
							break;
						case 1751:
							resword = "MyLongNamespace.Type.Request154";
							break;
						case 1752:
							resword = "MyLongNamespace.Type.Request197";
							break;
						case 1753:
							resword = "MyLongNamespace.Type.Request646";
							break;
						case 1754:
							resword = "MyLongNamespace.Type.Request137";
							break;
						case 1758:
							resword = "MyLongNamespace.Type.Request546";
							break;
						case 1766:
							resword = "MyLongNamespace.Type.Request393";
							break;
						case 1767:
							resword = "MyLongNamespace.Type.Request387";
							break;
						case 1768:
							resword = "MyLongNamespace.Type.Request333";
							break;
						case 1769:
							resword = "MyLongNamespace.Type.Request327";
							break;
						case 1771:
							resword = "MyLongNamespace.Type.Request293";
							break;
						case 1772:
							resword = "MyLongNamespace.Type.Request287";
							break;
						case 1773:
							resword = "MyLongNamespace.Type.Request233";
							break;
						case 1774:
							resword = "MyLongNamespace.Type.Request227";
							break;
						case 1776:
							resword = "MyLongNamespace.Type.Request193";
							break;
						case 1777:
							resword = "MyLongNamespace.Type.Request187";
							break;
						case 1778:
							resword = "MyLongNamespace.Type.Request133";
							break;
						case 1779:
							resword = "MyLongNamespace.Type.Request127";
							break;
						case 1791:
							resword = "MyLongNamespace.Type.Request383";
							break;
						case 1792:
							resword = "MyLongNamespace.Type.Request377";
							break;
						case 1793:
							resword = "MyLongNamespace.Type.Request323";
							break;
						case 1794:
							resword = "MyLongNamespace.Type.Request317";
							break;
						case 1796:
							resword = "MyLongNamespace.Type.Request283";
							break;
						case 1797:
							resword = "MyLongNamespace.Type.Request277";
							break;
						case 1798:
							resword = "MyLongNamespace.Type.Request223";
							break;
						case 1799:
							resword = "MyLongNamespace.Type.Request217";
							break;
						case 1801:
							resword = "MyLongNamespace.Type.Request183";
							break;
						case 1802:
							resword = "MyLongNamespace.Type.Request177";
							break;
						case 1803:
							resword = "MyLongNamespace.Type.Request123";
							break;
						case 1804:
							resword = "MyLongNamespace.Type.Request117";
							break;
						case 1816:
							resword = "MyLongNamespace.Type.Request373";
							break;
						case 1817:
							resword = "MyLongNamespace.Type.Request367";
							break;
						case 1818:
							resword = "MyLongNamespace.Type.Request313";
							break;
						case 1819:
							resword = "MyLongNamespace.Type.Request307";
							break;
						case 1821:
							resword = "MyLongNamespace.Type.Request273";
							break;
						case 1822:
							resword = "MyLongNamespace.Type.Request267";
							break;
						case 1823:
							resword = "MyLongNamespace.Type.Request213";
							break;
						case 1824:
							resword = "MyLongNamespace.Type.Request207";
							break;
						case 1826:
							resword = "MyLongNamespace.Type.Request173";
							break;
						case 1827:
							resword = "MyLongNamespace.Type.Request167";
							break;
						case 1828:
							resword = "MyLongNamespace.Type.Request113";
							break;
						case 1829:
							resword = "MyLongNamespace.Type.Request107";
							break;
						case 1841:
							resword = "MyLongNamespace.Type.Request363";
							break;
						case 1842:
							resword = "MyLongNamespace.Type.Request357";
							break;
						case 1843:
							resword = "MyLongNamespace.Type.Request303";
							break;
						case 1846:
							resword = "MyLongNamespace.Type.Request263";
							break;
						case 1847:
							resword = "MyLongNamespace.Type.Request257";
							break;
						case 1848:
							resword = "MyLongNamespace.Type.Request203";
							break;
						case 1851:
							resword = "MyLongNamespace.Type.Request163";
							break;
						case 1852:
							resword = "MyLongNamespace.Type.Request157";
							break;
						case 1853:
							resword = "MyLongNamespace.Type.Request103";
							break;
						case 1861:
							resword = "MyLongNamespace.Type.Request491";
							break;
						case 1862:
							resword = "MyLongNamespace.Type.Request444";
							break;
						case 1863:
							resword = "MyLongNamespace.Type.Request431";
							break;
						case 1866:
							resword = "MyLongNamespace.Type.Request353";
							break;
						case 1867:
							resword = "MyLongNamespace.Type.Request34";
							break;
						case 1868:
							resword = "MyLongNamespace.Type.Request340";
							break;
						case 1871:
							resword = "MyLongNamespace.Type.Request253";
							break;
						case 1872:
							resword = "MyLongNamespace.Type.Request24";
							break;
						case 1873:
							resword = "MyLongNamespace.Type.Request240";
							break;
						case 1876:
							resword = "MyLongNamespace.Type.Request153";
							break;
						case 1877:
							resword = "MyLongNamespace.Type.Request14";
							break;
						case 1878:
							resword = "MyLongNamespace.Type.Request140";
							break;
						case 1886:
							resword = "MyLongNamespace.Type.Request481";
							break;
						case 1888:
							resword = "MyLongNamespace.Type.Request421";
							break;
						case 1892:
							resword = "MyLongNamespace.Type.Request396";
							break;
						case 1894:
							resword = "MyLongNamespace.Type.Request336";
							break;
						case 1897:
							resword = "MyLongNamespace.Type.Request296";
							break;
						case 1899:
							resword = "MyLongNamespace.Type.Request236";
							break;
						case 1902:
							resword = "MyLongNamespace.Type.Request196";
							break;
						case 1904:
							resword = "MyLongNamespace.Type.Request136";
							break;
						case 1911:
							resword = "MyLongNamespace.Type.Request471";
							break;
						case 1913:
							resword = "MyLongNamespace.Type.Request411";
							break;
						case 1917:
							resword = "MyLongNamespace.Type.Request386";
							break;
						case 1919:
							resword = "MyLongNamespace.Type.Request326";
							break;
						case 1922:
							resword = "MyLongNamespace.Type.Request286";
							break;
						case 1924:
							resword = "MyLongNamespace.Type.Request226";
							break;
						case 1927:
							resword = "MyLongNamespace.Type.Request186";
							break;
						case 1929:
							resword = "MyLongNamespace.Type.Request126";
							break;
						case 1936:
							resword = "MyLongNamespace.Type.Request461";
							break;
						case 1938:
							resword = "MyLongNamespace.Type.Request401";
							break;
						case 1942:
							resword = "MyLongNamespace.Type.Request376";
							break;
						case 1944:
							resword = "MyLongNamespace.Type.Request316";
							break;
						case 1947:
							resword = "MyLongNamespace.Type.Request276";
							break;
						case 1949:
							resword = "MyLongNamespace.Type.Request216";
							break;
						case 1952:
							resword = "MyLongNamespace.Type.Request176";
							break;
						case 1954:
							resword = "MyLongNamespace.Type.Request116";
							break;
						case 1961:
							resword = "MyLongNamespace.Type.Request451";
							break;
						case 1963:
							resword = "MyLongNamespace.Type.Request447";
							break;
						case 1967:
							resword = "MyLongNamespace.Type.Request366";
							break;
						case 1969:
							resword = "MyLongNamespace.Type.Request306";
							break;
						case 1972:
							resword = "MyLongNamespace.Type.Request266";
							break;
						case 1974:
							resword = "MyLongNamespace.Type.Request206";
							break;
						case 1977:
							resword = "MyLongNamespace.Type.Request166";
							break;
						case 1979:
							resword = "MyLongNamespace.Type.Request106";
							break;
						case 1987:
							resword = "MyLongNamespace.Type.Request443";
							break;
						case 1992:
							resword = "MyLongNamespace.Type.Request356";
							break;
						case 1993:
							resword = "MyLongNamespace.Type.Request349";
							break;
						case 1994:
							resword = "MyLongNamespace.Type.Request345";
							break;
						case 1997:
							resword = "MyLongNamespace.Type.Request256";
							break;
						case 1998:
							resword = "MyLongNamespace.Type.Request249";
							break;
						case 1999:
							resword = "MyLongNamespace.Type.Request245";
							break;
						case 2002:
							resword = "MyLongNamespace.Type.Request156";
							break;
						case 2003:
							resword = "MyLongNamespace.Type.Request149";
							break;
						case 2004:
							resword = "MyLongNamespace.Type.Request145";
							break;
						case 2112:
							resword = "MyLongNamespace.Type.Request942";
							break;
						case 2113:
							resword = "MyLongNamespace.Type.Request446";
							break;
						case 2117:
							resword = "MyLongNamespace.Type.Request842";
							break;
						case 2118:
							resword = "MyLongNamespace.Type.Request348";
							break;
						case 2122:
							resword = "MyLongNamespace.Type.Request742";
							break;
						case 2123:
							resword = "MyLongNamespace.Type.Request248";
							break;
						case 2127:
							resword = "MyLongNamespace.Type.Request642";
							break;
						case 2128:
							resword = "MyLongNamespace.Type.Request148";
							break;
						case 2132:
							resword = "MyLongNamespace.Type.Request542";
							break;
						case 2266:
							resword = "MyLongNamespace.Type.Request392";
							break;
						case 2268:
							resword = "MyLongNamespace.Type.Request332";
							break;
						case 2271:
							resword = "MyLongNamespace.Type.Request292";
							break;
						case 2273:
							resword = "MyLongNamespace.Type.Request232";
							break;
						case 2276:
							resword = "MyLongNamespace.Type.Request192";
							break;
						case 2278:
							resword = "MyLongNamespace.Type.Request132";
							break;
						case 2291:
							resword = "MyLongNamespace.Type.Request382";
							break;
						case 2293:
							resword = "MyLongNamespace.Type.Request322";
							break;
						case 2296:
							resword = "MyLongNamespace.Type.Request282";
							break;
						case 2298:
							resword = "MyLongNamespace.Type.Request222";
							break;
						case 2301:
							resword = "MyLongNamespace.Type.Request182";
							break;
						case 2303:
							resword = "MyLongNamespace.Type.Request122";
							break;
						case 2316:
							resword = "MyLongNamespace.Type.Request372";
							break;
						case 2318:
							resword = "MyLongNamespace.Type.Request312";
							break;
						case 2321:
							resword = "MyLongNamespace.Type.Request272";
							break;
						case 2323:
							resword = "MyLongNamespace.Type.Request212";
							break;
						case 2326:
							resword = "MyLongNamespace.Type.Request172";
							break;
						case 2328:
							resword = "MyLongNamespace.Type.Request112";
							break;
						case 2341:
							resword = "MyLongNamespace.Type.Request362";
							break;
						case 2342:
							resword = "MyLongNamespace.Type.Request941";
							break;
						case 2343:
							resword = "MyLongNamespace.Type.Request302";
							break;
						case 2346:
							resword = "MyLongNamespace.Type.Request262";
							break;
						case 2347:
							resword = "MyLongNamespace.Type.Request841";
							break;
						case 2348:
							resword = "MyLongNamespace.Type.Request202";
							break;
						case 2351:
							resword = "MyLongNamespace.Type.Request162";
							break;
						case 2352:
							resword = "MyLongNamespace.Type.Request741";
							break;
						case 2353:
							resword = "MyLongNamespace.Type.Request102";
							break;
						case 2357:
							resword = "MyLongNamespace.Type.Request641";
							break;
						case 2362:
							resword = "MyLongNamespace.Type.Request541";
							break;
						case 2366:
							resword = "MyLongNamespace.Type.Request352";
							break;
						case 2371:
							resword = "MyLongNamespace.Type.Request252";
							break;
						case 2376:
							resword = "MyLongNamespace.Type.Request152";
							break;
						case 2487:
							resword = "MyLongNamespace.Type.Request442";
							break;
						case 2496:
							resword = "MyLongNamespace.Type.Request391";
							break;
						case 2497:
							resword = "MyLongNamespace.Type.Request344";
							break;
						case 2498:
							resword = "MyLongNamespace.Type.Request331";
							break;
						case 2501:
							resword = "MyLongNamespace.Type.Request291";
							break;
						case 2502:
							resword = "MyLongNamespace.Type.Request244";
							break;
						case 2503:
							resword = "MyLongNamespace.Type.Request231";
							break;
						case 2506:
							resword = "MyLongNamespace.Type.Request191";
							break;
						case 2507:
							resword = "MyLongNamespace.Type.Request144";
							break;
						case 2508:
							resword = "MyLongNamespace.Type.Request131";
							break;
						case 2521:
							resword = "MyLongNamespace.Type.Request381";
							break;
						case 2523:
							resword = "MyLongNamespace.Type.Request321";
							break;
						case 2526:
							resword = "MyLongNamespace.Type.Request281";
							break;
						case 2528:
							resword = "MyLongNamespace.Type.Request221";
							break;
						case 2531:
							resword = "MyLongNamespace.Type.Request181";
							break;
						case 2533:
							resword = "MyLongNamespace.Type.Request121";
							break;
						case 2546:
							resword = "MyLongNamespace.Type.Request371";
							break;
						case 2548:
							resword = "MyLongNamespace.Type.Request311";
							break;
						case 2551:
							resword = "MyLongNamespace.Type.Request271";
							break;
						case 2553:
							resword = "MyLongNamespace.Type.Request211";
							break;
						case 2556:
							resword = "MyLongNamespace.Type.Request171";
							break;
						case 2558:
							resword = "MyLongNamespace.Type.Request111";
							break;
						case 2571:
							resword = "MyLongNamespace.Type.Request361";
							break;
						case 2573:
							resword = "MyLongNamespace.Type.Request301";
							break;
						case 2576:
							resword = "MyLongNamespace.Type.Request261";
							break;
						case 2578:
							resword = "MyLongNamespace.Type.Request201";
							break;
						case 2581:
							resword = "MyLongNamespace.Type.Request161";
							break;
						case 2583:
							resword = "MyLongNamespace.Type.Request101";
							break;
						case 2596:
							resword = "MyLongNamespace.Type.Request351";
							break;
						case 2598:
							resword = "MyLongNamespace.Type.Request347";
							break;
						case 2601:
							resword = "MyLongNamespace.Type.Request251";
							break;
						case 2603:
							resword = "MyLongNamespace.Type.Request247";
							break;
						case 2606:
							resword = "MyLongNamespace.Type.Request151";
							break;
						case 2608:
							resword = "MyLongNamespace.Type.Request147";
							break;
						case 2622:
							resword = "MyLongNamespace.Type.Request343";
							break;
						case 2627:
							resword = "MyLongNamespace.Type.Request243";
							break;
						case 2632:
							resword = "MyLongNamespace.Type.Request143";
							break;
						case 2717:
							resword = "MyLongNamespace.Type.Request441";
							break;
						case 2748:
							resword = "MyLongNamespace.Type.Request346";
							break;
						case 2753:
							resword = "MyLongNamespace.Type.Request246";
							break;
						case 2758:
							resword = "MyLongNamespace.Type.Request146";
							break;
						case 3122:
							resword = "MyLongNamespace.Type.Request342";
							break;
						case 3127:
							resword = "MyLongNamespace.Type.Request242";
							break;
						case 3132:
							resword = "MyLongNamespace.Type.Request142";
							break;
						case 3352:
							resword = "MyLongNamespace.Type.Request341";
							break;
						case 3357:
							resword = "MyLongNamespace.Type.Request241";
							break;
						case 3362:
							resword = "MyLongNamespace.Type.Request141";
							break;
						default:
						{
							return null;
						}
					}

					if (resword == str)
					{
						return resword;
					}
				}
			}

			return null;
		}
	}
}