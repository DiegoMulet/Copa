import { Selecao } from './Selecao';

export interface Chave {
    id: number;
    selecao1Id: number;
    selecao2Id: number;
    dataConfronto: Date;
    qtdGols1?: number;
    qtdGols2?: number;
}
