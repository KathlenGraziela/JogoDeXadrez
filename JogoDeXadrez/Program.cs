using JogoDeXadrez;
using tabuleiro;
using xadrez;

try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    while (!partida.terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
            partida.ValidarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
            partida.ValidarPosicaoDeDestino(origem, destino);

            partida.RealizaJogada(origem, destino);
        }
        catch(TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

Console.ReadLine();