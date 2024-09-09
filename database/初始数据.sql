prompt PL/SQL Developer Export Tables for user SYSTEM@123.60.14.84:1521/ORCL
prompt Created by 廖秋实 on 2024年9月6日
set feedback off
set define off

prompt Loading ADMIN...
insert into ADMIN (admin_id, password, admin_name)
values (9, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'fy_a');
insert into ADMIN (admin_id, password, admin_name)
values (13, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'test1');
insert into ADMIN (admin_id, password, admin_name)
values (14, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'test3');
insert into ADMIN (admin_id, password, admin_name)
values (1, '12345678', 'default_admin');
insert into ADMIN (admin_id, password, admin_name)
values (6, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'ljc');
insert into ADMIN (admin_id, password, admin_name)
values (12, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'adminTest1111');
insert into ADMIN (admin_id, password, admin_name)
values (4, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'linchang');
insert into ADMIN (admin_id, password, admin_name)
values (5, 'fMF/BZZQlAJ6FDNr+MoxEFMQEwz/ErY4gShAPH29J1E=', 'string');
insert into ADMIN (admin_id, password, admin_name)
values (7, 'RYtzvR9VV/1wkCO08/aqa6swDp+zEvO2Iry65Syc7fc=', 'RW');
insert into ADMIN (admin_id, password, admin_name)
values (10, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'adminTest');
insert into ADMIN (admin_id, password, admin_name)
values (2, '123456', 'linchanggongren');
insert into ADMIN (admin_id, password, admin_name)
values (8, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'dzj');
insert into ADMIN (admin_id, password, admin_name)
values (11, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'TestAdmin');
commit;
prompt 13 records loaded
prompt Loading CITY...
insert into CITY (city_name, province, city_introduction)
values ('白山', '吉林', '白山市，别称“浑江”，吉林省辖地级市，地处长白山西侧，东与延边朝鲜族自治州相邻，西与通化市接壤，北与吉林市毗连，南与朝鲜民主主义人民共和国隔鸭绿江相望，地处长白山腹地，龙岗山脉和老岭山脉斜贯全境');
insert into CITY (city_name, province, city_introduction)
values ('长沙', '湖南', '长沙市，别称：潭州，湖南省省会，位于湖南省东部偏北，湘江下游和长浏盆地西缘。东邻江西省宜春、萍乡，西连娄底、益阳，南接株洲、湘潭，北靠岳阳');
insert into CITY (city_name, province, city_introduction)
values ('西安', '陕西', '西安市，是中国四大古都之一，拥有悠久的历史和丰富的文化遗产。作为华夏文明和中华文化关键发源地，西安自古以来就是说君王都，共有13个皇朝在此定都。境内有世界八大奇迹之一的兵马俑、古城墙、大雁塔等历史遗迹，被誉为天然历史博物馆和国际著名的旅游目的地城市。');
insert into CITY (city_name, province, city_introduction)
values ('成都', '四川', '成都市，简称“蓉”，别称蓉城、锦城，是四川省省会、副省级市、特大城市、成渝地区双城经济圈核心城市，国务院批复确定的中国西部地区重要的中心城市，国家重要的高新技术产业基地、商贸物流中心和综合交通枢纽。');
insert into CITY (city_name, province, city_introduction)
values ('上海', '上海', '上海市，简称“沪”或“申”，是中国共产党的诞生地。我国直辖市，国家中心城市，超大城市，中国的经济、交通、科技、工业、金融、贸易、会展和航运中心，首批沿海开放城市。');
insert into CITY (city_name, province, city_introduction)
values ('张家口', '河北', '张家口市，是河北省下辖地级市，又称“张垣”“武城”，位于河北省西北部，是冀西北地区的中心城市，连接京津、沟通晋蒙的交通枢纽。嘉靖八年（公元1529年）守备张珍在北城墙开一小门，曰“小北门”，因门小如口，又由张珍开筑，所以称“张家口”。');
insert into CITY (city_name, province, city_introduction)
values ('武汉', '湖北', '武汉市，简称“汉”，别称“江城”，是湖北省省会 ，中国中部地区最大都市及唯一的副省级城市，中国内陆地区最繁华都市、中华人民共和国区域中心城市。早在6000年前的新石器时代，已有先民在此繁衍生息。北郊的盘龙城遗址作为武汉建城开端，距今有3500年历史。');
insert into CITY (city_name, province, city_introduction)
values ('北京', '北京', '北京市，简称京，古称燕京、北平，中华人民共和国首都、直辖市、国家中心城市、超大城市，全国政治中心、文化中心、国际交往中心、科技创新中心，是中国共产党中央委员会、中华人民共和国中央人民政府和全国人民代表大会的办公所在地。');
insert into CITY (city_name, province, city_introduction)
values ('南京', '江苏', '南京市，简称“宁”，古称金陵、建康，地处中国东部、长江下游、濒江近海，是中国东部战区司令部驻地，长江国际航运物流中心，长三角辐射带动中西部地区发展的国家重要门户城市，也是东部沿海经济带与长江经济带战略交汇的重要节点城市。');
insert into CITY (city_name, province, city_introduction)
values ('张家界', '湖南', '张家界市，湖南省辖地级市，原名大庸市，辖2个市辖区（永定区、武陵源区）、2个县（慈利县、桑植县）。位于湖南西北部，澧水中上游，属武陵山区腹地。');
insert into CITY (city_name, province, city_introduction)
values ('苏州', '江苏', '苏州市，古称吴，简称为苏，又称姑苏、平江等，是国家历史文化名城和风景旅游城市，国家高新技术产业基地，长江三角洲重要的中心城市之一。');
insert into CITY (city_name, province, city_introduction)
values ('广州', '广东', '‌广州市，是广东省的省会，简称穗，别称羊城、花城，是广东省的政治、经济、科技、教育和文化中心。‌ 广州地处中国大陆南方，位于广东省中南部，珠江三角洲的北缘，濒临南海，邻近香港、澳门，是中国通往世界的南大门。');
commit;
prompt 12 records loaded
prompt Loading CLIMATE...
insert into CLIMATE (city_name, today_temperature, today_weather, tomorrow_temperature, tomorrow_weather)
values ('广州', null, null, null, null);
commit;
prompt 1 records loaded
prompt Loading FINANCIAL_SITUATION...
prompt Table is empty
prompt Loading GUIDE...
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (36, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'ljc', '男 ', null, '未设置大家好', null, null, null, null, 'C:\Avatars\guides\36.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (37, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'guideTest', '男 ', null, null, null, null, null, null, 'C:\Avatars\guides\37.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (2, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '罗军', '男 ', 1, '罗军是一名年轻的导游，热爱户外探险、冒险并充满激情。', 7000, '3', '+03-07', 350, 'C:\Avatars\guides\2.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (5, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '林浩然', '男 ', 1, '林浩然是一名资深导游，熟悉中国历史和文化。', 8300, '4', '+03-07', 420, 'C:\Avatars\guides\5.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (13, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '温雅婷', '女 ', 1, '温雅婷是一位热情洋溢的导游，尤其擅长家庭旅行和亲子游。', 7100, '3', '+02-01', 400, 'C:\Avatars\guides\13.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (33, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '萧安然', '女 ', 1, '萧安然是一位擅长策划高端定制旅行的导游，专注于豪华旅行体验。', 11000, '5', '+03-05', 520, 'C:\Avatars\guides\33.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (9, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '叶子琪', '女 ', 1, '叶子琪是一位活泼开朗的导游，热爱美食，精通各地的美食文化。', 6900, '3', '+02-01', 400, 'C:\Avatars\guides\9.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (10, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '何远航', '男 ', 1, '何远航是一位热爱摄影的导游，擅长带领游客发现最佳拍摄地点。', 7900, '4', '+02-01', 500, 'C:\Avatars\guides\10.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (1, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '高宇轩', '男 ', 1, '高宇轩是一名文化爱好者导游，专注于带领游客体验本地的传统艺术和手工艺。', 7600, '4', '+05-08', 450, 'C:\Avatars\guides\1.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (3, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '张晓琳', '女 ', 1, '张晓琳是一位年轻且充满活力的导游，精通英语，擅长为国际游客提供贴心服务。', 10500, '5', '+02-01', 600, 'C:\Avatars\guides\3.jpg');
insert into GUIDE (guide_id, password, guide_name, guide_gender, guide_free, guide_introduction, guide_salary, guide_performance_level, guide_seniority, guide_price, profile_picture)
values (4, 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', '陈曦', '男 ', 1, '陈曦是一位阳光开朗的导游，热爱自然风光，擅长带领游客探索美丽的自然景点。', 6300, '3', '+02-01', 300, 'C:\Avatars\guides\4.jpg');
commit;
prompt 11 records loaded
prompt Loading USERS...
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (194, 'Arcadia', to_date('05-09-2024 20:39:49', 'dd-mm-yyyy hh24:mi:ss'), '8ySJmr26XK5q+D0+rHN/QpOAVL3UUV5VPV5x8eFAPz0=', 'C:\Avatars\users\194.png', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (61, 'ljc', to_date('22-08-2024 22:42:38', 'dd-mm-yyyy hh24:mi:ss'), 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'C:\Avatars\users\61.jpg', '男 ');
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (122, 'dzj', to_date('29-08-2024 16:00:50', 'dd-mm-yyyy hh24:mi:ss'), 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'C:\Avatars\users\122.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (195, 'Dionysus', to_date('05-09-2024 21:48:53', 'dd-mm-yyyy hh24:mi:ss'), '8ySJmr26XK5q+D0+rHN/QpOAVL3UUV5VPV5x8eFAPz0=', 'C:\Avatars\users\195.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (196, 'dym', to_date('06-09-2024 00:58:28', 'dd-mm-yyyy hh24:mi:ss'), 'umnGkZl32JZzrQxbvp7/cUkRD+YIPC6G2AAhrvBfZzk=', 'C:\Avatars\users\196.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (101, 'linchang', to_date('27-08-2024 12:51:16', 'dd-mm-yyyy hh24:mi:ss'), 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'C:\Avatars\users\101.jpg', '男 ');
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (165, '测试修改', to_date('03-09-2024 08:24:55', 'dd-mm-yyyy hh24:mi:ss'), 'fMF/BZZQlAJ6FDNr+MoxEFMQEwz/ErY4gShAPH29J1E=', 'C:\Avatars\users\165.jpg', '男 ');
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (81, 'XJY', to_date('25-08-2024 17:11:50', 'dd-mm-yyyy hh24:mi:ss'), 'nr5FCyE61toA0S148aJfmB9RcEqoAXkhPjeRErjUUmg=', 'C:\Avatars\users\81.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (82, 'xjy', to_date('25-08-2024 22:37:50', 'dd-mm-yyyy hh24:mi:ss'), 'pP3fWCY744vI/PkhfoBH87iIsrldeMjGCfctVXhF5as=', 'C:\Avatars\users\82.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (121, 'fy_p', to_date('28-08-2024 22:39:50', 'dd-mm-yyyy hh24:mi:ss'), 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'C:\Avatars\users\121.jpg', null);
insert into USERS (user_id, user_name, registration_time, password, profile_picture, user_gender)
values (201, 'TestRegister', to_date('06-09-2024 21:18:24', 'dd-mm-yyyy hh24:mi:ss'), 'iHSHFlx7jOhO9avU5GcbdU4gh8og4CVfr4JlK8v66yY=', 'C:\Avatars\users\201.jpg', null);
commit;
prompt 11 records loaded
prompt Loading ORDER_DATA...
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 183, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Cancelled', 1644);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 185, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1524);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 191, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Cancelled', 700);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 214, to_date('05-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 300);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 142, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 155, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Completed', 2192);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 216, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 900);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 217, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 2191);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 141, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 189, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Completed', 598);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 107, to_date('27-08-2024', 'dd-mm-yyyy'), 61, 'Completed', 1479);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 108, to_date('27-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 479);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 109, to_date('27-08-2024', 'dd-mm-yyyy'), 61, 'Cancelled', 79);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 110, to_date('28-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 1479);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 111, to_date('28-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 479);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('vehicle', 112, to_date('28-08-2024', 'dd-mm-yyyy'), 61, 'Completed', 479);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 147, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1096);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 119, to_date('30-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 399);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 149, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 2740);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 152, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1644);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 130, to_date('01-09-2024', 'dd-mm-yyyy'), 101, 'Cancelled', 399);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 137, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 139, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 170, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Completed', 420);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 171, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1000);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 187, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1200);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 197, to_date('04-09-2024', 'dd-mm-yyyy'), 101, 'Cancelled', null);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 204, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 313);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('scenic_spot', 210, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('scenic_spot', 211, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 219, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 12600);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 132, to_date('01-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1096);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 138, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 140, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 196, to_date('04-09-2024', 'dd-mm-yyyy'), 101, 'Cancelled', null);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 172, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Completed', 400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 212, to_date('05-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 900);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('scenic_spot', 213, to_date('05-09-2024', 'dd-mm-yyyy'), 101, 'Cancelled', 35);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 215, to_date('05-09-2024', 'dd-mm-yyyy'), 61, 'Cancelled', null);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 120, to_date('30-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 1156);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 121, to_date('30-08-2024', 'dd-mm-yyyy'), 61, 'Cancelled', 798);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 122, to_date('30-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 798);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 123, to_date('30-08-2024', 'dd-mm-yyyy'), 61, 'Pending', 1197);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 188, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 3600);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 190, to_date('04-09-2024', 'dd-mm-yyyy'), 61, 'Completed', 1196);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 169, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 600);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 184, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 1644);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 186, to_date('04-09-2024', 'dd-mm-yyyy'), 101, 'Cancelled', 2400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('scenic_spot', 221, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('tour_group', 218, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 998);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('scenic_spot', 220, to_date('06-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 400);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('guide', 168, to_date('02-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 180);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 175, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
insert into ORDER_DATA (order_type, order_id, order_date, user_id, status, price)
values ('hotel', 176, to_date('03-09-2024', 'dd-mm-yyyy'), 61, 'Pending', 548);
commit;
prompt 54 records loaded
prompt Loading GUIDE_ORDER...
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (170, 5, to_date('27-09-2024', 'dd-mm-yyyy'), '绍兴两日游', to_date('28-09-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (171, 10, to_date('28-10-2024', 'dd-mm-yyyy'), '哈尔滨三日游', to_date('30-10-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (215, 37, to_date('07-09-2024', 'dd-mm-yyyy'), '家庭出游', to_date('12-09-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (191, 2, to_date('21-10-2024', 'dd-mm-yyyy'), '厦门两日游', to_date('22-10-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (196, 36, to_date('06-09-2024', 'dd-mm-yyyy'), 'dabaojian', to_date('07-10-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (172, 13, to_date('19-09-2024', 'dd-mm-yyyy'), '上海两日游', to_date('20-09-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (197, 36, to_date('06-09-2024', 'dd-mm-yyyy'), '特殊服务', to_date('07-09-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (212, 4, to_date('20-10-2024', 'dd-mm-yyyy'), '武汉三日游', to_date('22-10-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
insert into GUIDE_ORDER (order_id, guide_id, service_begin_date, service, service_end_date)
values (219, 2, to_date('11-09-2024', 'dd-mm-yyyy'), '上海', to_date('16-10-2024 23:59:59', 'dd-mm-yyyy hh24:mi:ss'));
commit;
prompt 9 records loaded
prompt Loading GUIDE_PHONE_NUMBER...
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('123', 36);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('123456789', 33);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('13810001001', 1);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('13834565432', 3);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('13967009089', 5);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('15268085702', 4);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('15366667777', 1);
insert into GUIDE_PHONE_NUMBER (phone_number, guide_id)
values ('15944975780', 2);
commit;
prompt 8 records loaded
prompt Loading GUIDE_REGION...
insert into GUIDE_REGION (guide_id, guided_region)
values (1, '上海');
insert into GUIDE_REGION (guide_id, guided_region)
values (1, '嘉兴');
insert into GUIDE_REGION (guide_id, guided_region)
values (3, '白山');
insert into GUIDE_REGION (guide_id, guided_region)
values (33, '上海');
insert into GUIDE_REGION (guide_id, guided_region)
values (36, '嘉定');
commit;
prompt 5 records loaded
prompt Loading GUIDE_SALARY_RECORD...
insert into GUIDE_SALARY_RECORD (guide_id, salary_paid_date, salary_amount, description)
values (1, to_date('01-08-2024', 'dd-mm-yyyy'), null, '底薪+绩效');
commit;
prompt 1 records loaded
prompt Loading HOTEL...
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (61, '秋果酒店（北京新国展首都机场店）', '北京', '四星级', '北京市顺义区天竺中街2号', '位于首都机场3公里处，毗邻空港工业区及北京国际展览中心新馆，交通便利、服务周到。');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (10, '上海如家酒店（沪太路店）', '上海', '五星级', '上海市静安区沪太路1049号', '如家酒店·neo(上海沪太路行知路地铁站店)毗邻沪太路，周围有大型的九百购物中心国美购物、大宁购物商业中心、大华社区、上海火车站、交通便捷到静安寺、人民广场、外滩、城隍庙、大宁灵石公园，酒店为您提供良好的环境；会议、用餐、住宿一站式服务，将是您商务、旅游、休闲的选择。');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (15, '南京山水大酒店', '南京', '四星级', '南京市玄武区龙蟠中路118号', '南京山水大酒店位于市区主干道珠江路与龙蟠中路交汇处，距离地铁2号线西安门站约475米，距离东部战区总医院（军区总院）约850米，酒店东临巍巍紫金山、中山陵风景区，北濒迷人玄武湖，西靠新街口繁华商业区往北经九华山隧道直通南京火车站，沪宁高速公路连接线近在咫尺，交通便利。');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (62, '汉庭酒店（武汉光谷广场店）', '武汉', '二星级', '武汉市洪山区珞瑜路560号', '酒店位于光谷广场核心商圈，洪山区珞瑜路地铁2号线光谷广场站旁，酒店正对东湖湖畔，可步行到达东湖绿道、樱花园。');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (5, '7天优品酒店（上海国际汽车城同济大学店）', '上海', '二星级', '上海市嘉定区曹安公路绿苑路576号', '酒店紧邻上海同济大学嘉定校区南门。分店周边吃喝玩乐应有尽有，环境幽雅；全新设备网速极快。交通十分便利：距离虹桥机场和高铁等枢纽，国家会展中心开车仅需20分钟！');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (6, '长白山天沐戴斯温泉酒店 ', '白山', '四星级', '白山市抚松县长白山保护开发区池南区政府前200米', '酒店坐落在风景秀美的长白山保护开发区池南区，交通极为便利。331国道穿越而过。酒店由珠海天沐温泉投资管理有限公司经营管理。一期建筑面积2万平方米，酒店拥有2个200平米各具特色的自助餐厅，以及5个大、中、小雅致包房。酒店还配套修建了东南亚风情的温泉馆，为您呈现度假新感觉。');
insert into HOTEL (hotel_id, hotel_name, city_name, hotel_grade, hotel_location, hotel_introduction)
values (12, '成都香格里拉大酒店', '成都', '五星级', '成都市锦江区滨江东路9号', '成都香格里拉拥有593间设计典雅、空间宽敞的豪华客房和套房，以及26套服务式公寓以满足长期住客的需要。 酒店位于成都市中心地带，所有房间均可饱览美轮美奂的城市高空景观。以豪华的装潢、时尚现代的布置以及色彩明快的设计缔造不同凡响的住宿体验。');
commit;
prompt 7 records loaded
prompt Loading HOTEL_ROOM_TYPE...
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (10, '大床房', 270, 8);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (10, '双床房', 300, 15);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (15, '商务大床房', 328, 3);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (15, '商务双床房', 348, 3);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (15, '家庭套房', 698, 2);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (61, '雅致大床房', 228, 6);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (61, '雅致双床房', 279, 6);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (61, '榻榻米大床房', 313, 3);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (62, '双床房', 240, 16);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (62, '高级双床房', 329, 4);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (5, '大床房', 270, 8);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (5, '双床房', 300, 16);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (6, '特色休闲房', 548, 0);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (6, '精致标准间', 508, 5);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (12, '双床房', 689, 16);
insert into HOTEL_ROOM_TYPE (hotel_id, room_type, room_price, room_left)
values (12, '特大床房', 689, 2);
commit;
prompt 16 records loaded
prompt Loading HOTEL_ROOM...
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2001', 10, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2002', 10, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2003', 10, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3001', 10, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3002', 10, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3003', 10, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2001', 15, '商务大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2002', 15, '商务大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2003', 15, '商务大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3001', 15, '商务双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3002', 15, '商务双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3003', 15, '商务双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('4001', 15, '家庭套房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('4002', 15, '家庭套房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1001', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1002', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1003', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1004', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1005', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1006', 61, '雅致大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2001', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2002', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2003', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2004', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2005', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2006', 61, '雅致双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3001', 61, '榻榻米大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3002', 61, '榻榻米大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3003', 61, '榻榻米大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('3004', 61, '榻榻米大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1001', 62, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1002', 62, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1003', 62, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('1004', 62, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2001', 62, '高级双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2002', 62, '高级双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2003', 62, '高级双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('2004', 62, '高级双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('701', 5, '大床房', 0);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('702', 5, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('703', 5, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('704', 5, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('705', 5, '大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('801', 5, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('802', 5, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('803', 5, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('804', 5, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('805', 5, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('201', 6, '特色休闲房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('202', 6, '特色休闲房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('101', 6, '精致标准间', 0);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('102', 6, '精致标准间', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('103', 6, '精致标准间', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('104', 6, '精致标准间', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('105', 6, '精致标准间', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8101', 12, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8102', 12, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8103', 12, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8105', 12, '特大床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8106', 12, '双床房', 1);
insert into HOTEL_ROOM (room_number, hotel_id, room_type, room_clear)
values ('8104', 12, '特大床房', 0);
commit;
prompt 61 records loaded
prompt Loading HOTEL_ORDER...
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (204, 61, to_date('04-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('05-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), '3001');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (217, 61, to_date('06-09-2024', 'dd-mm-yyyy'), to_date('13-09-2024', 'dd-mm-yyyy'), '3001');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (183, 6, to_date('07-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), '201');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (185, 6, to_date('09-09-2024', 'dd-mm-yyyy'), to_date('12-09-2024', 'dd-mm-yyyy'), '101');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (216, 10, to_date('03-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), '3001');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (184, 6, to_date('07-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), '202');
insert into HOTEL_ORDER (order_id, hotel_id, check_in_date, check_out_date, room_number)
values (214, 5, to_date('06-09-2024', 'dd-mm-yyyy'), to_date('07-09-2024', 'dd-mm-yyyy'), '801');
commit;
prompt 7 records loaded
prompt Loading SCENIC_SPOT...
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('中山陵', 53, '南京', '5', '中山陵是孙中山先生的陵墓，位于紫金山南麓，融合中西建筑元素，是重要的历史文化遗址和爱国主义教育基地。', '南京市玄武区紫金山南麓', 8.5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('上海迪士尼', 6, '上海', '5', '充满童真的梦幻乐园。', '上海市浦东新区川沙新镇上海迪士尼度假区', 20.8);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('东方明珠', 7, '上海', '5', '东方明珠矗立于上海浦东陆家嘴，与外滩隔江相望，是上海的标志性建筑。若在267米高的空中旋转餐厅一边品尝美食一边欣赏申城夜景，更是超凡的体验。', '上海市浦东新区世纪大道', 2.7);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('夫子庙', 54, '南京', '5', '夫子庙位于南京市秦淮区，是历史文化地标，夜晚灯火辉煌，展示了南京传统文化的深厚底蕴。', '南京市秦淮区夫子庙街道', 5.2);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('玄武湖', 55, '南京', '5', '玄武湖是中国著名的城市湖泊，位于南京市中心，是市民日常休闲和文化活动的理想场所。', '南京市玄武区玄武湖公园', 4.5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('总统府', 56, '南京', '4', '总统府是中国近代史的重要遗址，曾为中华民国政府的办公场所，现为中国近代史博物馆。', '南京市玄武区长江路292号', 3.8);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('南京长江大桥', 57, '南京', '4', '南京长江大桥是中国首座自行设计建造的双层铁路、公路两用桥梁，是南京的重要交通枢纽。', '南京市鼓楼区长江大桥', 8);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('莫愁湖', 58, '南京', '4', '莫愁湖因美丽传说而得名，景色秀丽，融合江南园林特色，是市民休闲娱乐的好去处。', '南京市建邺区水西门大街132号', 6.3);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('黄鹤楼', 38, '武汉', '5', '黄鹤楼是中国历史文化名楼之一，位于武汉市武昌区蛇山，是古今文人墨客吟咏的重要主题。', '武汉市武昌区蛇山西端', 2);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('宽窄巷子', 60, '成都', '5', '宽窄巷子是成都保存完好的历史街区，融合了古老的成都文化和现代城市生活的元素，具有浓厚的市井氛围。', '成都市青羊区金河路口', 2.5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('青城山', 61, '成都', '5', '青城山是中国道教发源地之一，以其秀丽的自然风光和丰富的文化遗产而闻名，是世界文化遗产之一。', '成都市都江堰市青城山镇', 20);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('锦里古街', 62, '成都', '4', '锦里古街是成都最具代表性的传统街区之一，展示了丰富的巴蜀文化和成都的民俗风情。', '成都市武侯区武侯祠大街', 3);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('杜甫草堂', 63, '成都', '5', '杜甫草堂是唐代大诗人杜甫的故居和纪念馆，展示了杜甫的诗歌文化和中国古代文学的魅力。', '成都市青羊区浣花溪公园内', 4);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('武侯祠', 64, '成都', '5', '武侯祠是纪念三国时期蜀汉丞相诸葛亮的祠堂，具有深厚的历史和文化价值，是成都的重要历史文化遗址。', '成都市武侯区武侯祠大街', 3.5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('都江堰', 65, '成都', '5', '都江堰是中国古代水利工程的杰出代表，至今仍在发挥作用，是世界文化遗产之一。', '成都市都江堰市南桥外', 15);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('故宫', 78, '北京', '5', '故宫是中国明清两代的皇家宫殿，也是世界上现存最大、保存最完整的木质结构古建筑群，具有极高的历史和文化价值。', '北京市东城区景山前街4号', 1);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('天坛', 79, '北京', '5', '天坛是明清两代皇帝祭天、祈祷五谷丰登的场所，以其独特的建筑风格和文化背景闻名于世，是世界文化遗产之一。', '北京市东城区天坛路东', 3);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('颐和园', 80, '北京', '5', '颐和园是中国现存规模最大、保存最完整的皇家园林，以其秀丽的自然风光和精致的古建筑闻名于世。', '北京市海淀区新建宫门路19号', 10);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('长城', 81, '北京', '5', '长城是中国古代伟大的防御工程，延绵数千公里，以其壮丽的景观和重要的历史地位，成为世界文化遗产之一。', '北京市延庆区八达岭镇', 60);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('天安门广场', 82, '北京', '5', '天安门广场是世界上最大的城市广场之一，见证了中国许多重要的历史事件，是国家的象征。', '北京市东城区东长安街', .5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('北海公园', 83, '北京', '4', '北海公园是中国现存最悠久、保存最完整的古典皇家园林之一，以其湖光山色和古建筑闻名，是北京市民休闲的好去处。', '北京市西城区文津街1号', 2);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('东湖', 85, '武汉', '5', '东湖是中国最大的城中湖之一，湖光山色，景色宜人，是武汉市民休闲娱乐的好去处。', '武汉市武昌区沿湖大道16号', 5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('武汉大学', 86, '武汉', '5', '武汉大学是中国著名的高等学府，以其优美的校园环境和悠久的学术传统而著称。每年春季樱花盛开时，吸引了大量游客。', '武汉市武昌区珞珈山路16号', 3);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('汉口江滩', 87, '武汉', '4', '汉口江滩是武汉市民日常休闲娱乐的好去处，滨江景色优美，每年夏季还会举办各种文化活动。', '武汉市江岸区沿江大道', 2);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('归元寺', 88, '武汉', '4', '归元寺是武汉市著名的佛教寺庙，以其千手观音和五百罗汉而闻名，吸引了大量信徒和游客。', '武汉市汉阳区翠微路20号', 3.5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('武汉长江大桥', 89, '武汉', '5', '武汉长江大桥是中国第一座公铁两用桥梁，横跨长江连接武昌和汉阳，是武汉的重要交通枢纽和地标性建筑。', '武汉市武昌区和平大道', .5);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('同济大学', 13, '上海', '5', '同济大学是位于中海市的一所综合性大学，是中华人民共和国教育部直属的全国重点大学，行政级别为正厅级（党委书记、校长高配副部级），是“双一流A类”和原“985工程”、原“211工程”重点建设大学。', '上海市嘉定区曹安公路4800号', 100);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('豫园', 8, '上海', '4', '上海豫园位于上海豫园旅游商业区的东北部，与上海城隍庙、上海豫园旅游商城毗邻，是知名的江南古典园林，闻名中外的名胜古迹。1982年被国 务院批准成为“全国重点文物保护单位”。', '上海市黄浦区安仁街137号 ', 1.8);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('海昌海洋公园', 10, '上海', '4', '上海海昌海洋公园被评定为国家4A级旅游景区，以海洋文化为主题，缔造五大区域和一个度假酒店，拥有《虎鲸科普秀》《海狮特快》《海豚奇缘》等十六大明星剧目；设有南极企鹅馆、海兽探秘馆等六大动物展示场馆，提供火山漂流、海豚过山车等十余项游乐设施，汇聚三万余只海洋生物 。', '上海市浦东新区南汇新城镇银飞路166号', 54);
insert into SCENIC_SPOT (scenic_spot_name, scenic_spot_id, city_name, scenic_spot_grade, scenic_spot_introduction, scenic_spot_location, scenic_spot_remoteness)
values ('东滩湿地公园', 12, '上海', '4', '东滩湿地公园位于崇明岛的东端，处于长江入海口，这里空气清新，又有一望无际的芦苇布满滩涂，走在木栈道上是一种亲近自然的享受。东滩是观日出的胜地，而每当秋冬候鸟迁徙的季节，可站在园内的观鸟台上观远处群鸟或飞翔或栖息，又有另一番生动自然的乐趣。', '上海市崇明区东滩大道风车路151号', 55.4);
commit;
prompt 30 records loaded
prompt Loading SCENIC_SPOT_TICKET...
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '儿童票', 0, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '成人票', 0, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '儿童票', 0, 300, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '成人票', 0, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '儿童票', 0, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '成人票', 50, 1000, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '儿童票', 25, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '成人票', 50, 1000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '儿童票', 25, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '成人票', 0, 800, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '儿童票', 0, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '成人票', 0, 800, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '儿童票', 0, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '成人票', 30, 600, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '儿童票', 15, 400, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '成人票', 30, 600, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '儿童票', 15, 400, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '成人票', 25, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '儿童票', 12, 300, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '成人票', 25, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '儿童票', 12, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '成人票', 40, 1000, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '儿童票', 20, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '成人票', 40, 1000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '儿童票', 20, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '成人票', 400, 4973, to_date('19-08-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '儿童票', 300, 1993, to_date('19-08-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '成人票', 30, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '儿童票', 15, 250, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '成人票', 0, 1000, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '儿童票', 0, 1000, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '成人票', 20, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '儿童票', 10, 150, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '成人票', 25, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '儿童票', 12, 200, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '成人票', 35, 600, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '儿童票', 18, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '成人票', 10, 700, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (60, '儿童票', 5, 350, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '成人票', 45, 800, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (61, '儿童票', 22, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '成人票', 20, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (62, '儿童票', 10, 250, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '成人票', 30, 700, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (63, '儿童票', 15, 350, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '成人票', 35, 800, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (64, '儿童票', 17, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '成人票', 50, 900, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (65, '儿童票', 25, 450, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (78, '成人票', 40, 900, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (78, '儿童票', 20, 450, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (79, '成人票', 35, 799, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (79, '儿童票', 17, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '成人票', 30, 700, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '儿童票', 15, 350, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '成人票', 45, 1000, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '儿童票', 22, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '成人票', 20, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '儿童票', 10, 250, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '成人票', 25, 600, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '儿童票', 12, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '成人票', 80, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '儿童票', 40, 250, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '成人票', 30, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '儿童票', 15, 350, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '成人票', 30, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (80, '儿童票', 15, 350, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '成人票', 45, 1000, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '儿童票', 22, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '成人票', 45, 1000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (81, '儿童票', 22, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '成人票', 20, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '儿童票', 10, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '成人票', 20, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (82, '儿童票', 10, 250, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '成人票', 25, 600, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '儿童票', 12, 300, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '成人票', 25, 600, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (83, '儿童票', 12, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '成人票', 40, 800, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '儿童票', 20, 400, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '成人票', 40, 800, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (38, '儿童票', 20, 400, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '成人票', 0, 1200, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '儿童票', 0, 600, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '成人票', 0, 1200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (85, '儿童票', 0, 600, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '成人票', 0, 1000, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '儿童票', 0, 500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '成人票', 0, 1000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (86, '儿童票', 0, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '成人票', 0, 1500, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '儿童票', 0, 700, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '成人票', 0, 1500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (87, '儿童票', 0, 700, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '成人票', 30, 600, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '儿童票', 15, 300, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '成人票', 30, 600, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (88, '儿童票', 15, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '成人票', 0, 2000, to_date('09-09-2024', 'dd-mm-yyyy'));
commit;
prompt 100 records committed...
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '儿童票', 0, 1000, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '成人票', 0, 2000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (89, '儿童票', 0, 1000, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '成人票', 80, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '儿童票', 40, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '成人票', 80, 450, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '儿童票', 40, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '成人票', 80, 400, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (10, '儿童票', 40, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '成人票', 20, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '儿童票', 10, 150, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '成人票', 20, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '儿童票', 10, 120, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '成人票', 20, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (12, '儿童票', 10, 100, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '成人票', 400, 998, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '儿童票', 300, 800, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '成人票', 400, 949, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '儿童票', 300, 700, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '成人票', 400, 899, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (6, '儿童票', 300, 650, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '成人票', 180, 600, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '儿童票', 90, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '成人票', 180, 550, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '儿童票', 90, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '成人票', 180, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (7, '儿童票', 90, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '成人票', 0, 1000, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '儿童票', 0, 1000, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '成人票', 0, 900, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '儿童票', 0, 900, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '成人票', 0, 850, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (13, '儿童票', 0, 850, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '成人票', 50, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '儿童票', 25, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '成人票', 50, 450, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '儿童票', 25, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '成人票', 50, 400, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (8, '儿童票', 25, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '成人票', 0, 500, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '成人票', 0, 450, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '儿童票', 0, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '成人票', 0, 400, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (53, '儿童票', 0, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '成人票', 50, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '儿童票', 25, 200, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '成人票', 50, 350, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '儿童票', 25, 150, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '成人票', 50, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (54, '儿童票', 25, 100, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '成人票', 0, 600, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '儿童票', 0, 350, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '成人票', 0, 550, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '儿童票', 0, 300, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '成人票', 0, 500, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (55, '儿童票', 0, 250, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '成人票', 30, 300, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '儿童票', 15, 150, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '成人票', 30, 250, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '儿童票', 15, 100, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '成人票', 30, 200, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (56, '儿童票', 15, 80, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '成人票', 0, 400, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '儿童票', 0, 200, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '成人票', 0, 350, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '儿童票', 0, 150, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '成人票', 0, 300, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (57, '儿童票', 0, 100, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '成人票', 10, 200, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '儿童票', 5, 100, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '成人票', 10, 150, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '儿童票', 5, 80, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '成人票', 10, 100, to_date('10-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_TICKET (scenic_spot_id, ticket_type, ticket_price, ticket_remaining, ticket_date)
values (58, '儿童票', 5, 60, to_date('10-09-2024', 'dd-mm-yyyy'));
commit;
prompt 174 records loaded
prompt Loading SCENIC_SPOT_ORDER...
insert into SCENIC_SPOT_ORDER (order_id, scenic_spot_id, ticket_type, ticket_number, ticket_date)
values (210, 6, '成人票', 1, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_ORDER (order_id, scenic_spot_id, ticket_type, ticket_number, ticket_date)
values (211, 6, '成人票', 1, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_ORDER (order_id, scenic_spot_id, ticket_type, ticket_number, ticket_date)
values (213, 79, '成人票', 1, to_date('08-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_ORDER (order_id, scenic_spot_id, ticket_type, ticket_number, ticket_date)
values (220, 6, '成人票', 1, to_date('09-09-2024', 'dd-mm-yyyy'));
insert into SCENIC_SPOT_ORDER (order_id, scenic_spot_id, ticket_type, ticket_number, ticket_date)
values (221, 6, '成人票', 1, to_date('10-09-2024', 'dd-mm-yyyy'));
commit;
prompt 5 records loaded
prompt Loading VEHICLE_SCHEDULE...
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'MU5404', to_date('06-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 16:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客A330', '上海浦东机场', '成都双流机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', 'MU5403', to_date('05-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('05-09-2024 12:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '空客A330', '成都双流机场', '上海浦东机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', 'CA4535', to_date('05-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('05-09-2024 17:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '波音737', '成都双流机场', '上海虹桥机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'CA4536', to_date('06-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 21:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '波音737', '上海虹桥机场', '成都双流机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', '3U8952', to_date('05-09-2024 19:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('05-09-2024 22:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '空客A321', '成都天府机场', '上海虹桥机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', '3U8953', to_date('06-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 11:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客A321', '上海虹桥机场', '成都天府机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('武汉', 'CA8203', to_date('07-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('07-09-2024 11:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '波音737', '武汉天河国际机场', '北京首都国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CA8204', to_date('07-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('07-09-2024 20:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '武汉', '波音737', '北京首都国际机场', '武汉天河国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('武汉', 'CZ3187', to_date('08-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '空客A320', '武汉天河国际机场', '北京大兴国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CZ3188', to_date('08-09-2024 17:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 19:50:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '武汉', '空客A320', '北京大兴国际机场', '武汉天河国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('武汉', 'G1722', to_date('09-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('09-09-2024 12:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '上海', '复兴号', '武汉站', '上海虹桥站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'G1723', to_date('09-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('09-09-2024 18:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '武汉', '复兴号', '上海虹桥站', '武汉站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'MN11', to_date('18-08-2024 06:17:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 21:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '上海', '大巴', '北京汽车站', '上海汽车站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'D2165', to_date('21-08-2024 17:23:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('21-08-2024 21:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '武汉', '动车', '南京南站', '武汉站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', '3U8633', to_date('11-09-2024 12:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('11-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客A380', '上海虹桥国际机场', '成都天府国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'NJSH001', to_date('10-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 18:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '南京', '大巴', '上海长途汽车客运总站', '南京长途汽车客运总站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'D7', to_date('17-08-2024 19:22:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 07:25:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '北京', '动车', '上海', '北京南');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'MU5498', to_date('01-09-2024 17:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('01-09-2024 19:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客320', '上海虹桥机场T2', '成都双流机场T2');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CA8229', to_date('30-08-2024 07:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('30-08-2024 11:40:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '武汉', '空客320', '武汉天河机场T3', '北京首都机场T3');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'MU5272', to_date('03-09-2024 16:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('03-09-2024 18:05:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '长沙', '空客320', '上海虹桥机场T2', '长沙黄花机场T2');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('长沙', 'MU5271', to_date('03-09-2024 13:20:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('03-09-2024 15:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '空客320', '长沙黄花机场T2', '上海虹桥机场T2');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'MN12', to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 09:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '上海', '大巴', '北京汽车站', '上海汽车站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', '137', to_date('28-08-2024 11:03:33', 'dd-mm-yyyy hh24:mi:ss'), to_date('28-08-2024 11:03:35', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '123', '北京机场', '上海机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'G145', to_date('17-09-2024 14:14:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 20:12:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '北京', '高铁', '上海虹桥', '北京南');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'SHNJ001', to_date('10-09-2024 07:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 11:00:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '上海', '大巴', '南京长途汽车客运总站', '上海长途汽车客运总站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'SHNJ002', to_date('10-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 12:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '上海', '大巴', '南京长途汽车客运站', '上海南站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'NJSH002', to_date('10-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 19:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'car', '南京', '大巴', '上海南站', '南京长途汽车客运站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', 'CA4112', to_date('12-09-2024 08:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('12-09-2024 11:45:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '波音737-800', '成都双流国际机场', '北京首都国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CA4113', to_date('12-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('12-09-2024 17:15:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '波音737-800', '北京首都国际机场', '成都双流国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', 'CZ6183', to_date('13-09-2024 09:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('13-09-2024 12:40:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '空客A321', '成都天府国际机场', '北京大兴国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CZ6184', to_date('13-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('13-09-2024 18:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客A321', '北京大兴国际机场', '成都天府国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'MU2802', to_date('14-09-2024 10:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:55:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '空客A320', '南京禄口国际机场', '北京首都国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'MU2803', to_date('14-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '南京', '空客A320', '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'CA1857', to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 10:55:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '北京', '波音737-800', '南京禄口国际机场', '北京首都国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'CA1858', to_date('14-09-2024 12:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '南京', '波音737-800', '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('武汉', 'G1720', to_date('14-09-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '南京', '和谐号', '武汉站', '南京南站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'G1721', to_date('14-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 16:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '武汉', '和谐号', '南京南站', '武汉站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('武汉', 'D3064', to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '南京', '复兴号', '武汉站', '南京南站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'D3065', to_date('14-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 17:20:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '武汉', '复兴号', '南京南站', '武汉站');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('成都', 'CZ3411', to_date('14-09-2024 07:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 10:10:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '南京', '空客A320', '成都双流国际机场', '南京禄口国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'CZ3412', to_date('14-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 22:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '空客A320', '南京禄口国际机场', '成都双流国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('南京', 'MU2804', to_date('14-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 20:30:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '成都', '波音737', '南京禄口国际机场', '成都天府国际机场');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('上海', 'G139', to_date('17-08-2024 13:04:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-08-2024 19:06:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '北京', '高铁', '上海虹桥', '北京南');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'KN5978', to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 10:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '波音373(中)', '大兴国际机场', '浦东国际机场T1');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'MN0429', to_date('17-08-2024 21:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 04:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '波音373(中)', '大兴国际机场', '浦东国际机场T1');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'MN0001', to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 09:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'plane', '上海', '波音373(中)', '大兴国际机场', '浦东国际机场T1');
insert into VEHICLE_SCHEDULE (arrival_city, vehicle_id, departure_time, arrival_time, vehicle_type, departure_city, vehicle_model, arrival_station, departure_station)
values ('北京', 'hc1234', to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 09:35:00', 'dd-mm-yyyy hh24:mi:ss'), 'train', '上海', '动车', '北京火车站', '上海火车站');
commit;
prompt 47 records loaded
prompt Loading VEHICLE_TICKET...
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('KN5978', '经济舱', 1479, to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 10:35:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '北京', 6, 76, '浦东国际机场T1', '大兴国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5271', '经济舱', 520, to_date('03-09-2024 13:20:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('03-09-2024 15:10:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '长沙', 22, 500, '上海虹桥机场T2', '长沙黄花机场T2');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8203', '商务舱', 1800, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 115, 20, '北京首都国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5403', '经济舱', 1200, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '成都', 42, 50, '上海浦东机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '二等座', 482, to_date('17-09-2024 14:14:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 18:51:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 31, 100, '北京南', '南京南');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '一等座', 809, to_date('17-09-2024 14:14:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 18:51:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 32, 100, '北京南', '南京南');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '商务座', 1607, to_date('17-09-2024 14:14:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 18:51:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 34, 100, '北京南', '南京南');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '二等座', 146, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 35, 100, '南京南', '上海虹桥');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '一等座', 247, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 07:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 36, 100, '南京南', '上海虹桥');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '优选一等座', 339, to_date('17-09-2024 18:56:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 20:12:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 37, 100, '南京南', '上海虹桥');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '商务座', 490, to_date('17-09-2024 18:56:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('17-09-2024 20:12:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 38, 100, '南京南', '上海虹桥');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5403', '商务舱', 2500, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 07:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 43, 20, '上海浦东机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5403', '头等舱', 4000, to_date('18-08-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 10:35:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '成都', 44, 10, '上海浦东机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5404', '经济舱', 1200, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 45, 50, '成都双流机场', '上海浦东机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5404', '商务舱', 2500, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '武汉', 46, 20, '成都双流机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5404', '头等舱', 4000, to_date('06-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 16:20:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 47, 10, '成都双流机场', '上海浦东机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4535', '经济舱', 1100, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 08:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '武汉', 48, 60, '上海虹桥机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4535', '商务舱', 2300, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '成都', 49, 25, '上海虹桥机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4535', '头等舱', 3800, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '成都', 50, 12, '上海虹桥机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4536', '经济舱', 1100, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 51, 60, '成都双流机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4536', '商务舱', 2300, to_date('06-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 21:10:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 52, 25, '成都双流机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4536', '头等舱', 3800, to_date('06-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 21:10:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 53, 12, '成都双流机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8952', '经济舱', 1150, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '成都', 102, 55, '上海虹桥机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8952', '商务舱', 2400, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '北京', 103, 22, '上海虹桥机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8953', '经济舱', 1150, to_date('06-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 105, 55, '成都天府国际机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8953', '商务舱', 2400, to_date('06-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 106, 22, '成都天府国际机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8953', '头等舱', 3700, to_date('06-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('06-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '上海', 107, 8, '成都天府国际机场', '上海虹桥机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8203', '经济舱', 900, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 114, 60, '北京首都国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8203', '头等舱', 2800, to_date('07-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('07-09-2024 11:30:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 116, 10, '北京首都国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8204', '经济舱', 900, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 11:15:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '北京', 117, 60, '武汉天河国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8204', '商务舱', 1800, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('07-09-2024 20:30:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 118, 20, '北京首都国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA8204', '头等舱', 2800, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:00:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '北京', 119, 10, '武汉天河国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3187', '经济舱', 850, to_date('08-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 120, 70, '北京大兴国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3187', '商务舱', 2000, to_date('08-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 121, 15, '北京大兴国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3187', '头等舱', 3200, to_date('08-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '武汉', 122, 5, '北京大兴国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3188', '经济舱', 850, to_date('08-09-2024 17:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 19:50:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '北京', 123, 70, '武汉天河国际机场', '北京大兴国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3188', '商务舱', 2000, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:00:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '成都', 124, 15, '武汉天河国际机场', ' ');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3188', '头等舱', 3200, to_date('08-09-2024 17:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 19:50:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '北京', 125, 5, '武汉天河国际机场', '北京大兴国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1722', '二等座', 450, to_date('09-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('09-09-2024 12:30:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '武汉', 126, 300, '上海虹桥站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1722', '一等座', 750, to_date('09-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('09-09-2024 12:30:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '武汉', 127, 100, '上海虹桥站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1722', '商务座', 1500, to_date('09-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 08:30:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '武汉', 128, 50, '上海虹桥站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1723', '二等座', 450, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '上海', 129, 300, '武汉站', '上海虹桥站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1723', '一等座', 750, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '上海', 130, 100, '武汉站', '上海虹桥站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1723', '商务座', 1500, to_date('09-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('09-09-2024 18:30:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '上海', 131, 50, '武汉站', '上海虹桥站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3411', '经济舱', 800, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 10:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '成都', 164, 150, '南京禄口国际机场', '成都双流国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3411', '商务舱', 2000, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '南京', 165, 20, '成都双流国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3412', '经济舱', 800, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '南京', 166, 150, '成都双流国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ3412', '商务舱', 2000, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '武汉', 167, 20, '成都双流国际机场', '武汉天河国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2803', '经济舱', 850, to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '成都', 168, 160, '南京禄口国际机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2803', '公务舱', 2200, to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '成都', 169, 25, '南京禄口国际机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2804', '经济舱', 850, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '南京', 170, 160, '成都天府国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2804', '公务舱', 2200, to_date('14-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 20:30:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '南京', 171, 25, '成都天府国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4535', '头等舱', 3800, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '成都', 180, 12, '上海虹桥机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('3U8952', '商务舱', 2400, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '北京', 181, 22, '上海虹桥机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5403', '商务舱', 2500, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 182, 20, '上海浦东机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4535', '经济舱', 1100, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '武汉', 183, 60, '上海虹桥机场', '成都双流机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4112', '商务舱', 1800, to_date('12-09-2024 08:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('12-09-2024 11:45:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '成都', 141, 30, '北京首都国际机场', '成都双流国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('SHNJ001', '普通座', 120, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 132, 45, '上海长途汽车客运总站', '南京长途汽车客运总站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('SHNJ001', '豪华座', 200, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 133, 10, '上海长途汽车客运总站', '南京长途汽车客运总站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU5272', '经济舱', 515, to_date('03-09-2024 16:05:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('03-09-2024 17:50:00', 'dd-mm-yyyy hh24:mi:ss'), '长沙', '上海', 23, 500, '长沙黄花机场T2', '上海虹桥机场T2');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('NJSH001', '普通座', 120, to_date('10-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 18:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 134, 45, '南京长途汽车客运总站', '上海长途汽车客运总站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('NJSH001', '豪华座', 200, to_date('10-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 18:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 135, 10, '南京长途汽车客运总站', '上海长途汽车客运总站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('SHNJ002', '普通座', 120, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 136, 40, '上海南站', '南京长途汽车客运站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('SHNJ002', '豪华座', 200, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '南京', 137, 15, '上海南站', '南京长途汽车客运站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('NJSH002', '普通座', 120, to_date('10-09-2024 16:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 19:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 138, 40, '南京长途汽车客运站', '上海南站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('NJSH002', '豪华座', 200, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 08:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 139, 15, '南京长途汽车客运站', '上海南站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4112', '经济舱', 950, to_date('12-09-2024 08:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('12-09-2024 11:45:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '成都', 140, 150, '北京首都国际机场', '成都双流国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4113', '经济舱', 950, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '北京', 142, 150, '成都双流国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA4113', '商务舱', 1800, to_date('12-09-2024 14:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('12-09-2024 17:15:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '北京', 143, 30, '成都双流国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ6183', '经济舱', 900, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '成都', 144, 160, '北京大兴国际机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ6183', '公务舱', 1900, to_date('13-09-2024 09:30:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('13-09-2024 12:40:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '成都', 145, 20, '北京大兴国际机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ6184', '经济舱', 900, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:00:00', 'dd-mm-yyyy hh24:mi:ss'), '成都', '北京', 146, 160, '成都天府国际机场', '北京大兴国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CZ6184', '公务舱', 1900, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '成都', 147, 20, '北京大兴国际机场', '成都天府国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2802', '经济舱', 650, to_date('14-09-2024 10:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:55:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 148, 120, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2802', '公务舱', 1500, to_date('14-09-2024 10:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:55:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 149, 15, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2803', '经济舱', 650, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 150, 120, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('MU2803', '公务舱', 1500, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:00:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '北京', 151, 15, '南京禄口国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA1857', '经济舱', 680, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 152, 140, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA1857', '公务舱', 1600, to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 10:55:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 153, 15, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA1858', '经济舱', 680, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 10:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '北京', 154, 140, '南京禄口国际机场', '北京首都国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('CA1858', '公务舱', 1600, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:00:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '南京', 155, 15, '北京首都国际机场', '南京禄口国际机场');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1720', '二等座', 150, to_date('14-09-2024 08:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 10:30:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '武汉', 156, 300, '南京南站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1720', '一等座', 240, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 10:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '武汉', 157, 100, '南京南站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1721', '二等座', 150, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '武汉', 158, 300, '南京南站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G1721', '一等座', 240, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '南京', 159, 100, '武汉站', '南京南站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D3064', '二等座', 140, to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:20:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '武汉', 160, 320, '南京南站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D3064', '一等座', 230, to_date('14-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 11:20:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '武汉', 161, 120, '南京南站', '武汉站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D3065', '二等座', 140, to_date('14-09-2024 15:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('14-09-2024 17:20:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '南京', 162, 320, '武汉站', '南京南站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D3065', '一等座', 230, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '武汉', '成都', 163, 120, '武汉站', '成都南站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('G145', '优选一等座', 1111, to_date('10-09-2024 20:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('10-09-2024 23:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '上海', 178, 100, '北京南', '上海虹桥');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D7', '一等座', 1211.9, to_date('08-09-2024 06:00:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('08-09-2024 09:15:00', 'dd-mm-yyyy hh24:mi:ss'), '北京', '上海', 179, 28, '北京南', '上海');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('D7', '二等座', 132.8, to_date('23-08-2024 04:58:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('23-08-2024 07:25:00', 'dd-mm-yyyy hh24:mi:ss'), '南京', '上海', 13, 99, '南京站', '上海站');
insert into VEHICLE_TICKET (vehicle_id, ticket_type, ticket_price, ticket_departure_time, ticket_arrival_time, ticket_departure_city, ticket_arrival_city, ticket_id, ticket_remaining, ticket_departure_station, ticket_arrival_station)
values ('hc1234', '二等座', 79, to_date('18-08-2024 00:10:00', 'dd-mm-yyyy hh24:mi:ss'), to_date('18-08-2024 02:35:00', 'dd-mm-yyyy hh24:mi:ss'), '上海', '北京', 28, 97, '上海火车站', '北京火车站');
commit;
prompt 93 records loaded
prompt Loading TOUR_GROUP...
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (1, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '上海三日跟团游', 1200, 179, 181, '北京', '上海');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (124, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '上海三日跟团游', 1200, 45, 180, '成都', '上海');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (125, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '北京三日跟团游', 1500, 142, 144, '成都', '北京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (126, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '武汉三日跟团游', 998, 46, null, '成都', '武汉');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (127, 5, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '南京三日跟团游', 998, 170, 49, '成都', '南京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (83, 1, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '成都三日跟团游', 1689, 50, 51, '上海', '成都');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (82, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '北京三日跟团游', 1500, 103, 178, '上海', '北京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (101, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '武汉三日跟团游', 998, 48, 129, '上海', '武汉');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (152, 5, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '南京三日跟团游', 998, 150, 151, '北京', '南京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (153, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '武汉三日跟团游', 998, 118, 119, '北京', '武汉');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (154, 1, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '成都三日跟团游', 1689, 147, 146, '北京', '成都');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (155, 1, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '成都三日跟团游', 1689, 164, 165, '南京', '成都');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (156, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '北京三日跟团游', 1500, 154, 152, '南京', '北京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (157, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '武汉三日跟团游', 998, 157, 166, '南京', '武汉');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (158, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '上海三日跟团游', 1200, 36, 182, '南京', '上海');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (159, 5, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '南京三日跟团游', 998, 159, 158, '武汉', '南京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (160, 1, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '成都三日跟团游', 1689, 163, 167, '武汉', '成都');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (161, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '北京三日跟团游', 1500, 117, 115, '武汉', '北京');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (162, 2, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '上海三日跟团游', 1200, 130, 183, '武汉', '上海');
insert into TOUR_GROUP (group_id, guide_id, start_date, end_date, group_name, group_price, go_ticket_id, return_ticket_id, departure, destination)
values (23, 5, to_date('08-09-2024', 'dd-mm-yyyy'), to_date('10-09-2024', 'dd-mm-yyyy'), '南京三日跟团游', 998, 43, 35, '上海', '南京');
commit;
prompt 20 records loaded
prompt Loading TOUR_HOTEL...
insert into TOUR_HOTEL (group_id, hotel_id)
values (1, 10);
insert into TOUR_HOTEL (group_id, hotel_id)
values (23, 15);
insert into TOUR_HOTEL (group_id, hotel_id)
values (82, 61);
insert into TOUR_HOTEL (group_id, hotel_id)
values (83, 12);
insert into TOUR_HOTEL (group_id, hotel_id)
values (101, 62);
insert into TOUR_HOTEL (group_id, hotel_id)
values (124, 10);
insert into TOUR_HOTEL (group_id, hotel_id)
values (125, 61);
insert into TOUR_HOTEL (group_id, hotel_id)
values (126, 62);
insert into TOUR_HOTEL (group_id, hotel_id)
values (127, 15);
insert into TOUR_HOTEL (group_id, hotel_id)
values (152, 15);
insert into TOUR_HOTEL (group_id, hotel_id)
values (153, 62);
insert into TOUR_HOTEL (group_id, hotel_id)
values (154, 12);
insert into TOUR_HOTEL (group_id, hotel_id)
values (155, 12);
insert into TOUR_HOTEL (group_id, hotel_id)
values (156, 61);
insert into TOUR_HOTEL (group_id, hotel_id)
values (157, 62);
insert into TOUR_HOTEL (group_id, hotel_id)
values (158, 10);
insert into TOUR_HOTEL (group_id, hotel_id)
values (159, 15);
insert into TOUR_HOTEL (group_id, hotel_id)
values (160, 12);
insert into TOUR_HOTEL (group_id, hotel_id)
values (161, 61);
insert into TOUR_HOTEL (group_id, hotel_id)
values (162, 10);
commit;
prompt 20 records loaded
prompt Loading TOUR_ITINERARY...
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (1, 1, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 13, '第一站参观同济大学（嘉定校区）校园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (2, 1, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 10, '第二站游玩海昌海洋公园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (3, 1, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 8, '参观豫园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (4, 1, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 6, '下午在迪士尼乐园游玩');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (5, 1, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 7, '参观东方明珠');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (6, 1, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 12, '东滩湿地公园看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (7, 23, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 58, '夜游莫愁湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (8, 23, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 54, '参观夫子庙');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (9, 23, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 53, '参观中山陵');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (10, 23, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 55, '游玩玄武湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (11, 23, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 56, '早上前往总统府');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (12, 23, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 57, '南京长江大桥看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (13, 162, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 10, '第二站游玩海昌海洋公园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (14, 162, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 8, '参观豫园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (15, 162, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 6, '下午在迪士尼乐园游玩');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (16, 162, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 7, '参观东方明珠');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (17, 162, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 12, '东滩湿地公园看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (18, 158, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 13, '第一站参观同济大学（嘉定校区）校园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (19, 158, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 10, '第二站游玩海昌海洋公园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (20, 158, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 8, '参观豫园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (21, 82, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 79, '游玩天坛');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (22, 158, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 6, '下午在迪士尼乐园游玩');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (23, 158, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 7, '参观东方明珠');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (24, 158, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 12, '东滩湿地公园看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (25, 82, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 80, '参观北海公园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (26, 82, to_date('09-09-2024 07:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 05:00:00.000000', 82, '早起去天安门看升国旗，并在游玩周边景点');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (27, 82, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 78, '下午逛故宫');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (28, 82, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 81, '早起爬长城');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (29, 82, to_date('10-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 80, '参观颐和园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (30, 101, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 89, '傍晚在长江大桥看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (31, 101, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 85, '游玩东湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (32, 101, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 86, '参观武汉大学');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (33, 101, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 38, '游玩黄鹤楼');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (34, 101, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 88, '参观归元寺');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (35, 101, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 87, '傍晚游玩汉口江滩');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (36, 83, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 60, '游玩宽窄巷子');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (37, 83, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 62, '游玩锦里古街');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (38, 83, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 64, '参观武侯祠');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (39, 83, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 65, '游玩都江堰');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (40, 83, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 63, '参观杜甫草堂');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (41, 83, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 61, '夜游青城山');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (42, 162, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 13, '第一站参观同济大学（嘉定校区）校园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (43, 124, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 13, '第一站参观同济大学（嘉定校区）校园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (44, 124, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 10, '第二站游玩海昌海洋公园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (45, 124, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 8, '参观豫园');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (46, 124, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 6, '下午在迪士尼乐园游玩');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (47, 124, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 7, '参观东方明珠');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (48, 124, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 12, '东滩湿地公园看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (49, 159, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 58, '夜游莫愁湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (50, 159, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 54, '参观夫子庙');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (51, 159, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 53, '参观中山陵');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (52, 159, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 55, '游玩玄武湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (53, 159, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 56, '早上前往总统府');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (54, 159, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 57, '南京长江大桥看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (55, 127, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 58, '夜游莫愁湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (56, 127, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 54, '参观夫子庙');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (57, 127, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 53, '参观中山陵');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (58, 127, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 55, '游玩玄武湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (59, 127, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 56, '早上前往总统府');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (60, 127, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 57, '南京长江大桥看日落');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (61, 152, to_date('08-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 58, '夜游莫愁湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (62, 152, to_date('08-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 02:00:00.000000', 54, '参观夫子庙');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (63, 152, to_date('09-09-2024 09:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 53, '参观中山陵');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (64, 152, to_date('09-09-2024 13:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 55, '游玩玄武湖');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (65, 152, to_date('10-09-2024 08:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 56, '早上前往总统府');
insert into TOUR_ITINERARY (itinerary_id, group_id, itinerary_time, itinerary_duration, scenic_spot_id, activities)
values (66, 152, to_date('10-09-2024 18:00:00', 'dd-mm-yyyy hh24:mi:ss'), '+00 03:00:00.000000', 57, '南京长江大桥看日落');
commit;
prompt 66 records loaded
prompt Loading TOUR_MEMBER...
prompt Table is empty
prompt Loading TOUR_ORDER...
insert into TOUR_ORDER (order_id, group_id, order_number)
values (186, 1, 2);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (189, 23, 1);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (121, 1, 2);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (122, 1, 2);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (123, 1, 3);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (130, 1, 1);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (187, 1, 1);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (218, 126, 1);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (119, 1, 1);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (188, 1, 3);
insert into TOUR_ORDER (order_id, group_id, order_number)
values (190, 23, 2);
commit;
prompt 11 records loaded
prompt Loading TRANSACTION_RECORD...
insert into TRANSACTION_RECORD (transaction_id, user_id, transaction_time, amount, transaction_object, transaction_status, transaction_method, transaction_category, description)
values (1, 22, to_date('29-08-2024', 'dd-mm-yyyy'), 100, 'object_test', 'test', 'alipay', 'hotel', 'test');
commit;
prompt 1 records loaded
prompt Loading USER_PHONE_NUMBER...
insert into USER_PHONE_NUMBER (user_id, phone_number)
values (61, '1121556778');
insert into USER_PHONE_NUMBER (user_id, phone_number)
values (61, '13456789011');
commit;
prompt 2 records loaded
prompt Loading VEHICLE_ORDER...
insert into VEHICLE_ORDER (order_id, ticket_id)
values (107, 6);
insert into VEHICLE_ORDER (order_id, ticket_id)
values (109, 28);
insert into VEHICLE_ORDER (order_id, ticket_id)
values (110, 6);
commit;
prompt 3 records loaded
prompt Loading VEHICLE_PASSENGER...
insert into VEHICLE_PASSENGER (order_id, passenger_id, passenger_name)
values (107, '1                 ', '1');
insert into VEHICLE_PASSENGER (order_id, passenger_id, passenger_name)
values (109, '1                 ', '1');
insert into VEHICLE_PASSENGER (order_id, passenger_id, passenger_name)
values (110, '1                 ', '1');
commit;
prompt 3 records loaded

set feedback on
set define on
prompt Done
