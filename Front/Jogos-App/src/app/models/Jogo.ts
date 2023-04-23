import {Genero} from './Genero';

export interface Jogo {
 id : number;
 nome : string;
 dataLancamento : Date;
 descricao : string;
 genero : string;
 desenvolvedora : string;
 jogoGenero: Genero[];
}
