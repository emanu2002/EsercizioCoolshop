using System;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        int numero_colonna = 0; //int.Parse(args[0]);
        if(numero_colonna < 0 || numero_colonna > 3)
        {
            Console.WriteLine("Errore nella scelta della colonna");
            return;
        }
        string elemento_da_cercare = "2";
        List<Record> records = new List<Record>();
        List<Record> records_da_tornare = new List<Record>();
        string file = @"C:\Users\emanu\Desktop\EsercizioCoolshop/utenti.csv";
        StreamReader stream;
        string riga;
        Record record;
        try{
            stream = new StreamReader(file); // apro lo stream per leggere da file
            while (!stream.EndOfStream){
                riga = stream.ReadLine()!; // leggo riga per riga
                if(riga != null){
                    record = new Record(int.Parse(riga.Split(",")[0]), riga.Split(",")[1], riga.Split(",")[2], riga.Split(",")[3]);
                    records.Add(record);
                }
            }
            stream.Close();  // chiusura stream
        }
        catch(FileNotFoundException f){
            Console.WriteLine( f.Message );
        }

        for(int i = 0; i < records.Count; i++){
            if (records[i] != null) {
                switch (numero_colonna){
                    case 0:
                        if (records[i].getIndice() == int.Parse(elemento_da_cercare)){
                            records_da_tornare.Add(records[i]);
                        }
                        break;
                    case 1:
                        if (records[i].getCognome() == elemento_da_cercare){
                            records_da_tornare.Add(records[i]);
                        }
                        break;
                    case 2:
                        if (records[i].getNome() == elemento_da_cercare){
                            records_da_tornare.Add(records[i]);
                        }
                        break;
                    case 3:
                        if (records[i].getData() == elemento_da_cercare){
                            records_da_tornare.Add(records[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("Errore!!!");
                        break;
                }
            }
        }

        for (int i = 0; i < records_da_tornare.Count; i++){
            Console.WriteLine(records_da_tornare[i].toString());
        }
    }
}



class Record
{
    private int indice;
    private String cognome;
    private String nome;
    private String data;

    public Record(int indice, string cognome, string nome, string data)
    {
        this.indice = indice;
        this.cognome = cognome;
        this.nome = nome;
        this.data = data;
    }

    public int getIndice()
    {
        return this.indice;
    }

    public string getNome(){
        return this.nome;
    }
    public string getCognome()
    {
        return this.cognome;
    }

    public string getData()
    {
        return this.data;
    }

    public String toString(){
        return this.indice+","+this.cognome+","+this.nome+","+ this.data;
    }
}