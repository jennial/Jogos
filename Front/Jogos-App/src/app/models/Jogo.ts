import {Genero} from './Genero';

export interface Jogo {
 Id : number;
 Nome : string;
 DataLancamento : Date;
 Descricao : string;
 Genero : string;
 Desenvolvedora : string;
 JogoGenero: Genero[];
}
