using static NewSystem.NewConsole;
using System.IO;

string[] CubeA = { "red", "blue", "black", "blue", "green", "blue" };
string[] CubeC = { "blue", "black", "green", "red", "green", "red" };
string[] CubeB = { "black", "green", "blue", "black", "red", "green" };
string[] CubeD = { "green", "red", "red", "blue", "blue", "black" };
string[] TesteA = (string[])CubeA.Clone();
string[] TesteB = (string[])CubeB.Clone();
string[] TesteC = (string[])CubeC.Clone();
string[] TesteD = (string[])CubeD.Clone();

string[] RespA = (string[])TesteA.Clone();
string[] RespB = (string[])TesteB.Clone();
string[] RespC = (string[])TesteC.Clone();
string[] RespD = (string[])TesteD.Clone();



static string[] giraV(string[] cubo, int v)
{
    string[] cuboTemp = (string[])cubo.Clone();
    int top = 0;
    int front = 1;
    int bottom = 2;
    int rigth = 3;
    int left = 4;
    int back = 5;
    for (int i = 0; i < v; i++)
    {
        cubo[top] = cuboTemp[back];
        cubo[front] = cuboTemp[top];
        cubo[bottom] = cuboTemp[front];
        cubo[back] = cuboTemp[bottom];
    }

    return cubo;
}

static string[] giraVCima(string[] cubo, int v)
{
    string[] cuboTemp = (string[])cubo.Clone();
    int top = 0;
    int front = 1;
    int bottom = 2;
    int rigth = 3;
    int left = 4;
    int back = 5;
    for (int i = 0; i < v; i++)
    {
        cubo[top] = cuboTemp[front];
        cubo[front] = cuboTemp[bottom];
        cubo[bottom] = cuboTemp[back];
        cubo[back] = cuboTemp[top];
    }

    return cubo;
}

static string[] giraH(string[] cubo, int h)
{
    string[] cuboTemp = (string[])cubo.Clone();
    int top = 0;
    int front = 1;
    int bottom = 2;
    int rigth = 3;
    int left = 4;
    int back = 5;
    for (int i = 0; i < h; i++)
    {
        cubo[front] = cuboTemp[left];
        cubo[left] = cuboTemp[back];
        cubo[back] = cuboTemp[rigth];
        cubo[rigth] = cuboTemp[front];
    }

    return cubo;
}

static string[] giraHLeft(string[] cubo, int h)
{
    string[] cuboTemp = (string[])cubo.Clone();
    int top = 0;
    int front = 1;
    int bottom = 2;
    int rigth = 3;
    int left = 4;
    int back = 5;
    for (int i = 0; i < h; i++)
    {
        cubo[front] = cuboTemp[rigth];
        cubo[left] = cuboTemp[front];
        cubo[back] = cuboTemp[left];
        cubo[rigth] = cuboTemp[back];
    }

    return cubo;
}


static bool verify(string[] a, string[] b, string[] c, string[] d)
{
    int top = 0;
    int front = 0;
    int bottom = 0;
    int back = 0;

    if (a[0] != b[0] && a[0] != c[0] && a[0] != d[0] && b[0] != c[0] && b[0] != d[0] && c[0] != d[0])
    {
        top = 1;
    }
    if (a[1] != b[1] && a[1] != c[1] && a[1] != d[1] && b[1] != c[1] && b[1] != d[1] && c[1] != d[1])
    {
        front = 1;
    }
    if (a[2] != b[2] && a[2] != c[2] && a[2] != d[2] && b[2] != c[2] && b[2] != d[2] && c[2] != d[2])
    {
        bottom = 1;
    }
    if (a[5] != b[5] && a[5] != c[5] && a[5] != d[5] && b[5] != c[5] && b[5] != d[5] && c[5] != d[5])
    {
        back = 1;
    }
    if (top == 1 && front == 1 && bottom == 1 && back == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}


int hd = 0;
int vd = 0;
int ld = 0;
int rd = 0;

int hc = 0;
int vc = 0;
int lc = 0;
int rc = 0;

int hb = 0;
int vb = 0;
int lb = 0;
int rb = 0;

int ha = 0;
int va = 0;
int la = 0;
int ra = 0;

int attempt = 0;

int victory = 0;

int count = 0;


for (int a = 0; a < CubeA.Length * 4; a++)
{
    if (a == 0 || (la == 1 && ra == 1))
    {
        TesteA = (string[])CubeA.Clone();
    }
    if (a == 0)
    {
        ha = 0;
        va = 0;
    }

    if (la == 0 && ra == 0 && a == 0)
    {
        TesteA = giraVCima(TesteA, 1);
        TesteA = giraH(TesteA, 1);
        TesteA = giraVCima(TesteA, 1);
    }

    if (ha == 4 && la == 0 && ra == 0)
    {
        TesteA = giraVCima(TesteA, 1);
        TesteA = giraHLeft(TesteA, 1);
        TesteA = giraHLeft(TesteA, 1);
        TesteA = giraVCima(TesteA, 1);
        ha = 0;
        ra = 1;
    }

    if (ha == 4 && la == 0 && ra == 1)
    {
        TesteA = giraVCima(TesteA, 1);
        TesteA = giraVCima(TesteA, 1);
        TesteA = giraH(TesteA, 1);
        la = 1;
        ha = 0;
    }

    if (ha == 4 && la == 1 && ra == 1)
    {
        va = va + 1;
        ha = 0;
    }


    TesteA = giraH(CubeA, ha);
    TesteA = giraV(CubeA, va);

    ha = ha + 1;

    for (int c = 0; c < CubeC.Length * 4; c++)
    {
        if (c == 0 || (lc == 1 && rc == 1))
        {
            TesteC = (string[])CubeC.Clone();
        }
        if (c == 0)
        {
            hc = 0;
            vc = 0;
        }

        if (lc == 0 && rc == 0 && c == 0)
        {
            TesteC = giraVCima(TesteC, 1);
            TesteC = giraH(TesteC, 1);
            TesteC = giraVCima(TesteC, 1);
        }

        if (hc == 4 && lc == 0 && rc == 0)
        {
            TesteC = giraVCima(TesteC, 1);
            TesteC = giraHLeft(TesteC, 1);
            TesteC = giraHLeft(TesteC, 1);
            TesteC = giraVCima(TesteC, 1);
            hc = 0;
            rc = 1;
        }

        if (hc == 4 && lc == 0 && rc == 1)
        {
            TesteC = giraVCima(TesteC, 1);
            TesteC = giraVCima(TesteC, 1);
            TesteC = giraH(TesteC, 1);
            lc = 1;
            hc = 0;
        }

        if (hc == 4 && lc == 1 && rc == 1)
        {
            vc = vc + 1;
            hc = 0;
        }


        TesteC = giraH(CubeC, hc);
        TesteC = giraV(CubeC, vc);

        hc = hc + 1;

        for (int b = 0; b < CubeB.Length * 4; b++)
        {
            if (b == 0 || (lb == 1 && rb == 1))
            {
                TesteB = (string[])CubeB.Clone();
            }
            if (b == 0)
            {
                hb = 0;
                vb = 0;
            }

            if (lb == 0 && rb == 0 && b == 0)
            {
                TesteB = giraVCima(TesteB, 1);
                TesteB = giraH(TesteB, 1);
                TesteB = giraVCima(TesteB, 1);
            }

            if (hb == 4 && lb == 0 && rb == 0)
            {
                TesteB = giraVCima(TesteB, 1);
                TesteB = giraHLeft(TesteB, 1);
                TesteB = giraHLeft(TesteB, 1);
                TesteB = giraVCima(TesteB, 1);
                hb = 0;
                rb = 1;
            }

            if (hb == 4 && lb == 0 && rb == 1)
            {
                TesteB = giraVCima(TesteB, 1);
                TesteB = giraVCima(TesteB, 1);
                TesteB = giraH(TesteB, 1);
                lb = 1;
                hb = 0;
            }

            if (hb == 4 && lb == 1 && rb == 1)
            {
                vb = vb + 1;
                hb = 0;
            }


            TesteB = giraH(CubeB, hb);
            TesteB = giraV(CubeB, vb);

            hb = hb + 1;

            for (int d = 0; d < CubeD.Length * 4; d++)
            {
                if (d == 0 || (ld == 1 && rd == 1))
                {
                    TesteD = (string[])CubeD.Clone();
                }
                if (d == 0)
                {
                    hd = 0;
                    vd = 0;
                }

                if (ld == 0 && rd == 0 && d == 0)
                {
                    TesteD = giraVCima(TesteD, 1);
                    TesteD = giraH(TesteD, 1);
                    TesteD = giraVCima(TesteD, 1);
                }

                if (hd == 4 && ld == 0 && rd == 0)
                {
                    TesteD = giraVCima(TesteD, 1);
                    TesteD = giraHLeft(TesteD, 1);
                    TesteD = giraHLeft(TesteD, 1);
                    TesteD = giraVCima(TesteD, 1);
                    hd = 0;
                    rd = 1;
                }

                if (hd == 4 && ld == 0 && rd == 1)
                {
                    TesteD = giraVCima(TesteD, 1);
                    TesteD = giraVCima(TesteD, 1);
                    TesteD = giraH(TesteD, 1);
                    ld = 1;
                    hd = 0;
                }

                if (hd == 4 && ld == 1 && rd == 1)
                {
                    vd = vd + 1;
                    hd = 0;
                }


                TesteD = giraH(CubeD, hd);
                TesteD = giraV(CubeD, vd);


                bool result = verify(TesteA, TesteC, TesteB, TesteD);
                attempt = attempt + 1;
                if (result == true)
                {
                    count = count+1;
                    victory = victory + 1;
                    if (count == 1)
                    {
                        RespA = (string[])TesteA.Clone();
                        RespB = (string[])TesteB.Clone();
                        RespC = (string[])TesteC.Clone();
                        RespD = (string[])TesteD.Clone();
                    }
                    
                }
                hd = hd + 1;

            }
        }
    }
}

Print($"\nTentativas: {attempt}");
Print($"Vitórias: {victory}");

string filePath = "respostas.csv"; 
using (StreamWriter writer = new StreamWriter(filePath))
{
    for (int i = 0; i < RespA.Length; i++)
    {
        writer.Write($"{RespA[i]},");
    }
    writer.Write("\n");
    for (int i = 0; i < RespB.Length; i++)
    {
        writer.Write($"{RespB[i]},");
    }
    writer.Write("\n");
    for (int i = 0; i < RespC.Length; i++)
    {
        writer.Write($"{RespC[i]},");
    }
    writer.Write("\n");
    for (int i = 0; i < RespD.Length; i++)
    {
        writer.Write($"{RespD[i]},");
    }
}
