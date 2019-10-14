using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.client
{
    public static class ContactData
    {
        public static string GetString()
        {
            return _content;
        }

        public static string[] GetLines()
        {
            return _content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        public static IEnumerable<Contact> GetContacts()
        {
            if (_contacts != null) return _contacts;
            var data = GetLines().Skip(1).ToList();
            _contacts = new List<Contact>(100);
            foreach (var row in data)
            {
                var values = row.Split(",".ToCharArray());
                _contacts.Add(new Contact()
                {
                    Code = values[0],
                    Name = values[1],
                    LastName = values[2],
                    Company = values[3],
                    Address = values[4],
                    City = values[5],
                    County = values[6],
                    State = values[7],
                    Zip = values[8],
                    Phone1 = values[9],
                    Phone2 = values[10],
                    Email = values[11]
                });
            }
            return _contacts;

        }

        private static List<Contact> _contacts;

        private static string _content = @"Code,Name,LastName,Company,Address,City,County,State,Zip,Phone1,Phone2,Email
LEP-33786,James,Butt,Benton John B Jr,6649 N Blue Gum St,New Orleans,Orleans,LA,70116,504-621-8927,504-845-1427,jbutt@gmail.com
CNT-51307,Josephine,Darakjy,Chanay Jeffrey A Esq,4 B Blue Ridge Blvd,Brighton,Livingston,MI,48116,810-292-9388,810-374-9840,josephine_darakjy@darakjy.org
LEP-12560,Art,Venere,Chemel James L Cpa,8 W Cerritos Ave #54,Bridgeport,Gloucester,NJ,8014,856-636-8749,856-264-4130,art@venere.org
PRF-96632,Lenna,Paprocki,Feltz Printing Service,639 Main St,Anchorage,Anchorage,AK,99501,907-385-4412,907-921-2010,lpaprocki@hotmail.com
PRF-75242,Donette,Foller,Printing Dimensions,34 Center St,Hamilton,Butler,OH,45011,513-570-1893,513-549-4561,donette.foller@cox.net
ACC-96080,Simona,Morasca,Chapman Ross E Esq,3 Mcauley Dr,Ashland,Ashland,OH,44805,419-503-2484,419-800-6759,simona@morasca.com
LEP-38492,Mitsue,Tollner,Morlong Associates,7 Eads St,Chicago,Cook,IL,60632,773-573-6914,773-924-8565,mitsue_tollner@yahoo.com
ACC-30373,Leota,Dilliard,Commercial Press,7 W Jackson Blvd,San Jose,Santa Clara,CA,95111,408-752-3500,408-813-1105,leota@hotmail.com
ACC-64790,Sage,Wieser,Truhlar And Truhlar Attys,5 Boston Ave #88,Sioux Falls,Minnehaha,SD,57105,605-414-2147,605-794-4895,sage_wieser@cox.net
ACC-13557,Kris,Marrier,King Christopher A Esq,228 Runamuck Pl #2808,Baltimore,Baltimore City,MD,21224,410-655-8723,410-804-4694,kris@gmail.com
LEP-87039,Minna,Amigon,Dorl James J Esq,2371 Jerrold Ave,Kulpsville,Montgomery,PA,19443,215-874-1229,215-422-8694,minna_amigon@yahoo.com
LEP-68395,Abel,Maclead,Rangoni Of Florence,37275 St  Rt 17m M,Middle Island,Suffolk,NY,11953,631-335-3414,631-677-3675,amaclead@gmail.com
PRF-24529,Kiley,Caldarera,Feiner Bros,25 E 75th St #69,Los Angeles,Los Angeles,CA,90034,310-498-5651,310-254-3084,kiley.caldarera@aol.com
ACC-96092,Graciela,Ruta,Buckley Miller & Wright,98 Connecticut Ave Nw,Chagrin Falls,Geauga,OH,44023,440-780-8425,440-579-7763,gruta@cox.net
CNT-66660,Cammy,Albares,Rousseaux Michael Esq,56 E Morehead St,Laredo,Webb,TX,78045,956-537-6195,956-841-7216,calbares@gmail.com
ACC-73534,Mattie,Poquette,Century Communications,73 State Road 434 E,Phoenix,Maricopa,AZ,85013,602-277-4385,602-953-6360,mattie@aol.com
PRF-30998,Meaghan,Garufi,Bolton Wilbur Esq,69734 E Carrillo St,Mc Minnville,Warren,TN,37110,931-313-9635,931-235-7959,meaghan@hotmail.com
CNT-80979,Gladys,Rim,T M Byxbee Company Pc,322 New Horizon Blvd,Milwaukee,Milwaukee,WI,53207,414-661-9598,414-377-2880,gladys.rim@rim.org
CNT-75884,Yuki,Whobrey,Farmers Insurance Group,1 State Route 27,Taylor,Wayne,MI,48180,313-288-7937,313-341-4470,yuki_whobrey@aol.com
CNT-74312,Fletcher,Flosi,Post Box Services Plus,394 Manchester Blvd,Rockford,Winnebago,IL,61109,815-828-2147,815-426-5657,fletcher.flosi@yahoo.com
CNT-94567,Bette,Nicka,Sport En Art,6 S 33rd St,Aston,Delaware,PA,19014,610-545-3615,610-492-4643,bette_nicka@cox.net
ACC-53573,Veronika,Inouye,C 4 Network Inc,6 Greenleaf Ave,San Jose,Santa Clara,CA,95111,408-540-1785,408-813-4592,vinouye@aol.com
LEP-15519,Willard,Kolmetz,Ingalls Donald R Esq,618 W Yakima Ave,Irving,Dallas,TX,75062,972-303-9197,972-896-4882,willard@hotmail.com
CNT-69629,Maryann,Royster,Franklin Peter L Esq,74 S Westgate St,Albany,Albany,NY,12204,518-966-7987,518-448-8982,mroyster@royster.com
PRF-56713,Alisha,Slusarski,Wtlz Power 107 Fm,3273 State St,Middlesex,Middlesex,NJ,8846,732-658-3154,732-635-3453,alisha@slusarski.com
ACC-72701,Allene,Iturbide,Ledecky David Esq,1 Central Ave,Stevens Point,Portage,WI,54481,715-662-6764,715-530-9863,allene_iturbide@cox.net
ACC-29995,Chanel,Caudy,Professional Image Inc,86 Nw 66th St #8673,Shawnee,Johnson,KS,66218,913-388-2079,913-899-1103,chanel.caudy@caudy.org
ACC-20205,Ezekiel,Chui,Sider Donald C Esq,2 Cedar Ave #84,Easton,Talbot,MD,21601,410-669-1642,410-235-8738,ezekiel@chui.com
ACC-34186,Willow,Kusko,U Pull It,90991 Thorburn Ave,New York,New York,NY,10011,212-582-4976,212-934-5167,wkusko@yahoo.com
CNT-63418,Bernardo,Figeroa,Clark Richard Cpa,386 9th Ave N,Conroe,Montgomery,TX,77301,936-336-3951,936-597-3614,bfigeroa@aol.com
CNT-79645,Ammie,Corrio,Moskowitz Barry S,74874 Atlantic Ave,Columbus,Franklin,OH,43215,614-801-9788,614-648-3265,ammie@corrio.com
ACC-36406,Francine,Vocelka,Cascade Realty Advisors Inc,366 South Dr,Las Cruces,Dona Ana,NM,88011,505-977-3911,505-335-5293,francine_vocelka@vocelka.com
CNT-74130,Ernie,Stenseth,Knwz Newsradio,45 E Liberty St,Ridgefield Park,Bergen,NJ,7660,201-709-6245,201-387-9093,ernie_stenseth@aol.com
CNT-61946,Albina,Glick,Giampetro Anthony D,4 Ralph Ct,Dunellen,Middlesex,NJ,8812,732-924-7882,732-782-6701,albina@glick.com
LEP-43442,Alishia,Sergi,Milford Enterprises Inc,2742 Distribution Way,New York,New York,NY,10025,212-860-1579,212-753-2740,asergi@gmail.com
LEP-50518,Solange,Shinko,Mosocco Ronald A,426 Wolf St,Metairie,Jefferson,LA,70002,504-979-9175,504-265-8174,solange@shinko.com
PRF-29722,Jose,Stockham,Tri State Refueler Co,128 Bransten Rd,New York,New York,NY,10011,212-675-8570,212-569-4233,jose@yahoo.com
CNT-93414,Rozella,Ostrosky,Parkway Company,17 Morena Blvd,Camarillo,Ventura,CA,93012,805-832-6163,805-609-1531,rozella.ostrosky@ostrosky.com
LEP-58929,Valentine,Gillian,Fbs Business Finance,775 W 17th St,San Antonio,Bexar,TX,78204,210-812-9597,210-300-6244,valentine_gillian@gmail.com
LEP-55575,Kati,Rulapaugh,Eder Assocs Consltng Engrs Pc,6980 Dorsett Rd,Abilene,Dickinson,KS,67410,785-463-7829,785-219-7724,kati.rulapaugh@hotmail.com
CNT-53298,Youlanda,Schemmer,Tri M Tool Inc,2881 Lewis Rd,Prineville,Crook,OR,97754,541-548-8197,541-993-2611,youlanda@aol.com
ACC-43266,Dyan,Oldroyd,International Eyelets Inc,7219 Woodfield Rd,Overland Park,Johnson,KS,66204,913-413-4604,913-645-8918,doldroyd@aol.com
ACC-36472,Roxane,Campain,Rapid Trading Intl,1048 Main St,Fairbanks,Fairbanks North Star,AK,99708,907-231-4722,907-335-6568,roxane@hotmail.com
LEP-79681,Lavera,Perin,Abc Enterprises Inc,678 3rd Ave,Miami,Miami-Dade,FL,33196,305-606-7291,305-995-2078,lperin@perin.org
PRF-87404,Erick,Ferencz,Cindy Turner Associates,20 S Babcock St,Fairbanks,Fairbanks North Star,AK,99712,907-741-1044,907-227-6777,erick.ferencz@aol.com
ACC-41018,Fatima,Saylors,Stanton James D Esq,2 Lighthouse Ave,Hopkins,Hennepin,MN,55343,952-768-2416,952-479-2375,fsaylors@saylors.org
ACC-91370,Jina,Briddick,Grace Pastries Inc,38938 Park Blvd,Boston,Suffolk,MA,2128,617-399-5124,617-997-5771,jina_briddick@briddick.com
PRF-68755,Kanisha,Waycott,Schroer Gene E Esq,5 Tomahawk Dr,Los Angeles,Los Angeles,CA,90006,323-453-2780,323-315-7314,kanisha_waycott@yahoo.com
PRF-45211,Emerson,Bowley,Knights Inn,762 S Main St,Madison,Dane,WI,53711,608-336-7444,608-658-7940,emerson.bowley@bowley.org
ACC-95492,Blair,Malet,Bollinger Mach Shp & Shipyard,209 Decker Dr,Philadelphia,Philadelphia,PA,19132,215-907-9111,215-794-4519,bmalet@yahoo.com
LEP-10775,Brock,Bolognia,Orinda News,4486 W O St #1,New York,New York,NY,10003,212-402-9216,212-617-5063,bbolognia@yahoo.com
ACC-58929,Lorrie,Nestle,Ballard Spahr Andrews,39 S 7th St,Tullahoma,Coffee,TN,37388,931-875-6644,931-303-6041,lnestle@hotmail.com
ACC-91645,Sabra,Uyetake,Lowy Limousine Service,98839 Hawthorne Blvd #6101,Columbia,Richland,SC,29201,803-925-5213,803-681-3678,sabra@uyetake.org
ACC-54633,Marjory,Mastella,Vicon Corporation,71 San Mateo Ave,Wayne,Delaware,PA,19087,610-814-5533,610-379-7125,mmastella@mastella.com
CNT-32755,Karl,Klonowski,Rossi Michael M,76 Brooks St #9,Flemington,Hunterdon,NJ,8822,908-877-6135,908-470-4661,karl_klonowski@yahoo.com
ACC-88955,Tonette,Wenner,Northwest Publishing,4545 Courthouse Rd,Westbury,Nassau,NY,11590,516-968-6051,516-333-4861,twenner@aol.com
PRF-55027,Amber,Monarrez,Branford Wire & Mfg Co,14288 Foster Ave #4121,Jenkintown,Montgomery,PA,19046,215-934-8655,215-329-6386,amber_monarrez@monarrez.org
ACC-10577,Shenika,Seewald,East Coast Marketing,4 Otis St,Van Nuys,Los Angeles,CA,91405,818-423-4007,818-749-8650,shenika@gmail.com
LEP-44111,Delmy,Ahle,Wye Technologies Inc,65895 S 16th St,Providence,Providence,RI,2909,401-458-2547,401-559-8961,delmy.ahle@hotmail.com
ACC-46345,Deeanna,Juhas,Healy George W Iv,14302 Pennsylvania Ave,Huntingdon Valley,Montgomery,PA,19006,215-211-9589,215-417-9563,deeanna_juhas@gmail.com
PRF-34087,Blondell,Pugh,Alpenlite Inc,201 Hawk Ct,Providence,Providence,RI,2904,401-960-8259,401-300-8122,bpugh@aol.com
PRF-13697,Jamal,Vanausdal,Hubbard Bruce Esq,53075 Sw 152nd Ter #615,Monroe Township,Middlesex,NJ,8831,732-234-1546,732-904-2931,jamal@vanausdal.org
PRF-70579,Cecily,Hollack,Arthur A Oliver & Son Inc,59 N Groesbeck Hwy,Austin,Travis,TX,78731,512-486-3817,512-861-3814,cecily@hollack.org
LEP-21228,Carmelina,Lindall,George Jessop Carter Jewelers,2664 Lewis Rd,Littleton,Douglas,CO,80126,303-724-7371,303-874-5160,carmelina_lindall@lindall.com
PRF-59211,Maurine,Yglesias,Schultz Thomas C Md,59 Shady Ln #53,Milwaukee,Milwaukee,WI,53214,414-748-1374,414-573-7719,maurine_yglesias@yglesias.com
ACC-27783,Tawna,Buvens,H H H Enterprises Inc,3305 Nabell Ave #679,New York,New York,NY,10009,212-674-9610,212-462-9157,tawna@gmail.com
CNT-93365,Penney,Weight,Hawaiian King Hotel,18 Fountain St,Anchorage,Anchorage,AK,99515,907-797-9628,907-873-2882,penney_weight@aol.com
ACC-61571,Elly,Morocco,Killion Industries,7 W 32nd St,Erie,Erie,PA,16502,814-393-5571,814-420-3553,elly_morocco@gmail.com
CNT-44766,Ilene,Eroman,Robinson William J Esq,2853 S Central Expy,Glen Burnie,Anne Arundel,MD,21061,410-914-9018,410-937-4543,ilene.eroman@hotmail.com
CNT-34112,Vallie,Mondella,Private Properties,74 W College St,Boise,Ada,ID,83707,208-862-5339,208-737-8439,vmondella@mondella.com
CNT-15472,Kallie,Blackwood,Rowley Schlimgen Inc,701 S Harrison Rd,San Francisco,San Francisco,CA,94104,415-315-2761,415-604-7609,kallie.blackwood@gmail.com
PRF-66352,Johnetta,Abdallah,Forging Specialties,1088 Pinehurst St,Chapel Hill,Orange,NC,27514,919-225-9345,919-715-3791,johnetta_abdallah@aol.com
LEP-13878,Bobbye,Rhym,Smits Patricia Garity,30 W 80th St #1995,San Carlos,San Mateo,CA,94070,650-528-5783,650-811-9032,brhym@rhym.com
LEP-56433,Micaela,Rhymes,H Lee Leonard Attorney At Law,20932 Hedley St,Concord,Contra Costa,CA,94520,925-647-3298,925-522-7798,micaela_rhymes@gmail.com
LEP-54130,Tamar,Hoogland,A K Construction Co,2737 Pistorio Rd #9230,London,Madison,OH,43140,740-343-8575,740-526-5410,tamar@hotmail.com
ACC-77978,Moon,Parlato,Ambelang Jessica M Md,74989 Brandon St,Wellsville,Allegany,NY,14895,585-866-8313,585-498-4278,moon@yahoo.com
LEP-32285,Laurel,Reitler,Q A Service,6 Kains Ave,Baltimore,Baltimore City,MD,21215,410-520-4832,410-957-6903,laurel_reitler@reitler.com
LEP-96377,Delisa,Crupi,Wood & Whitacre Contractors,47565 W Grand Ave,Newark,Essex,NJ,7105,973-354-2040,973-847-9611,delisa.crupi@crupi.com
ACC-25649,Viva,Toelkes,Mark Iv Press Ltd,4284 Dorigo Ln,Chicago,Cook,IL,60647,773-446-5569,773-352-3437,viva.toelkes@gmail.com
CNT-41246,Elza,Lipke,Museum Of Science & Industry,6794 Lake Dr E,Newark,Essex,NJ,7104,973-927-3447,973-796-3667,elza@yahoo.com
LEP-64052,Devorah,Chickering,Garrison Ind,31 Douglas Blvd #950,Clovis,Curry,NM,88101,505-975-8559,505-950-1763,devorah@hotmail.com
CNT-58075,Timothy,Mulqueen,Saronix Nymph Products,44 W 4th St,Staten Island,Richmond,NY,10309,718-332-6527,718-654-7063,timothy_mulqueen@mulqueen.org
CNT-11690,Arlette,Honeywell,Smc Inc,11279 Loytan St,Jacksonville,Duval,FL,32254,904-775-4480,904-514-9918,ahoneywell@honeywell.com
PRF-76038,Dominque,Dickerson,E A I Electronic Assocs Inc,69 Marquette Ave,Hayward,Alameda,CA,94545,510-993-3758,510-901-7640,dominque.dickerson@dickerson.org
PRF-99099,Lettie,Isenhower,Conte Christopher A Esq,70 W Main St,Beachwood,Cuyahoga,OH,44122,216-657-7668,216-733-8494,lettie_isenhower@yahoo.com
PRF-19846,Myra,Munns,Anker Law Office,461 Prospect Pl #316,Euless,Tarrant,TX,76040,817-914-7518,817-451-3518,mmunns@cox.net
LEP-23163,Stephaine,Barfield,Beutelschies & Company,47154 Whipple Ave Nw,Gardena,Los Angeles,CA,90247,310-774-7643,310-968-1219,stephaine@barfield.com
CNT-75704,Lai,Gato,Fligg Kenneth I Jr,37 Alabama Ave,Evanston,Cook,IL,60201,847-728-7286,847-957-4614,lai.gato@gato.org
ACC-41742,Stephen,Emigh,Sharp J Daniel Esq,3777 E Richmond St #900,Akron,Summit,OH,44302,330-537-5358,330-700-2312,stephen_emigh@hotmail.com
ACC-81983,Tyra,Shields,Assink Anne H Esq,3 Fort Worth Ave,Philadelphia,Philadelphia,PA,19106,215-255-1641,215-228-8264,tshields@gmail.com
CNT-93661,Tammara,Wardrip,Jewel My Shop Inc,4800 Black Horse Pike,Burlingame,San Mateo,CA,94010,650-803-1936,650-216-5075,twardrip@cox.net
LEP-29121,Cory,Gibes,Chinese Translation Resources,83649 W Belmont Ave,San Gabriel,Los Angeles,CA,91776,626-572-1096,626-696-2777,cory.gibes@gmail.com
ACC-25601,Danica,Bruschke,Stevens Charles T,840 15th Ave,Waco,McLennan,TX,76708,254-782-8569,254-205-1422,danica_bruschke@gmail.com
ACC-86076,Wilda,Giguere,Mclaughlin Luther W Cpa,1747 Calle Amanecer #2,Anchorage,Anchorage,AK,99501,907-870-5536,907-914-9482,wilda@cox.net
CNT-56012,Elvera,Benimadho,Tree Musketeers,99385 Charity St #840,San Jose,Santa Clara,CA,95110,408-703-8505,408-440-8447,elvera.benimadho@cox.net
LEP-45622,Carma,Vanheusen,Springfield Div Oh Edison Co,68556 Central Hwy,San Leandro,Alameda,CA,94577,510-503-7169,510-452-4835,carma@cox.net
ACC-19320,Malinda,Hochard,Logan Memorial Hospital,55 Riverside Ave,Indianapolis,Marion,IN,46202,317-722-5066,317-472-2412,malinda.hochard@yahoo.com
PRF-81261,Natalie,Fern,Kelly Charles G Esq,7140 University Ave,Rock Springs,Sweetwater,WY,82901,307-704-8713,307-279-3793,natalie.fern@hotmail.com
PRF-73254,Lisha,Centini,Industrial Paper Shredders Inc,64 5th Ave #1153,Mc Lean,Fairfax,VA,22102,703-235-3937,703-475-7568,lisha@centini.org";
    }
}
