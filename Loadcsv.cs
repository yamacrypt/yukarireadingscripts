    using System.Collections.Generic;
    using System.IO;
        class Loadcsv
        {
             public List<string[]> loadcsv(string path,string target,ref int max)
            {
                var res=new List<string[]>();
                // 読み込みたいCSVファイルのパスを指定して開く
                StreamReader sr = new StreamReader(path);
                {
                    sr.ReadLine();
                    // 末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // CSVファイルの一行を読み込む
                        string line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        string[] values = line.Split(',');
                        int length=values.Length;
                        string[] key = new string[3];
                        // 配列からリストに格納する
                        for (int i=0;i<length-1;i++){
                            if (values[i].Contains(target)){
                                res.Add(values);
                                break;
                            }
                        }
                        if (res.Count>max+30){
                       break;
                        }
                        // コンソールに出力する
                    }          
                }
                max=res.Count;
                return res;
            }
        }
    