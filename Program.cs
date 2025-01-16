using static NewSystem.NewConsole;

string[] CubeA = { "y", "y", "g", "r", "b", "y" };
string[] CubeC = { "r", "b", "b", "g", "g", "y" };
string[] CubeB = { "r", "y", "g", "r", "y", "b" };
string[] CubeD = { "r", "y", "b", "r", "g", "g" };
string[] TesteA = { };
string[] TesteB = { };
string[] TesteC = { };
string[] TesteD = { };

static string[] giraV(string[] cubo, int v)
{
    string[] cuboTemp = cubo;
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

static string[] giraH(string[] cubo, int h)
{
    string[] cuboTemp = cubo;
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

int hc = 0;
int vc = 0;

int hb = 0;
int vb = 0;

int ha = 0;
int va = 0;

int attempt = 0;

int victory = 0;


for (int a = 0; a < CubeA.Length * 4; a++)
{
    if (ha == 4)
        {
            va = va + 1;
            ha = 0;
        }

        CubeA = giraH(CubeA, ha);
        CubeA = giraV(CubeA, va);

        ha = ha + 1;

    for (int c = 0; c < CubeC.Length * 4; c++)
    {
        if (c == 0)
        {
            hc = 0;
            vc = 0;
            TesteC = CubeC;
        }

        if (hc == 4)
        {
            vc = vc + 1;
            hc = 0;
        }

        CubeC = giraH(CubeC, hc);
        CubeC = giraV(CubeC, vc);

        hc = hc + 1;

        for (int b = 0; b < CubeB.Length * 4; b++)
        {
            if (b == 0)
            {
                hb = 0;
                vb = 0;
                TesteB = CubeB;
            }

            if (hb == 4)
            {
                vb = vb + 1;
                hb = 0;
            }

            CubeB = giraH(CubeB, hb);
            CubeB = giraV(CubeB, vb);

            hb = hb + 1;

            for (int d = 0; d < CubeD.Length * 4; d++)
            {
                if (d == 0)
                {
                    hd = 0;
                    vd = 0;
                    TesteD = CubeD;
                }

                if (hd == 4)
                {
                    vd = vd + 1;
                    hd = 0;
                }

                CubeD = giraH(CubeD, hd);
                CubeD = giraV(CubeD, vd);

                bool result = verify(CubeA, CubeB, CubeC, CubeD);
                attempt = attempt + 1;
                if (result == true)
                {
                    victory = victory + 1;
                }
                hd = hd + 1;
            }
        }
    }
}

Print($"Tentativas: {attempt}");
Print($"Vitórias: {victory}");



