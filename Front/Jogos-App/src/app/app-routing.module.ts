import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JogosComponent } from './components/jogos/jogos.component';
import { CadastroGeneroComponent } from './components/cadastroGenero/cadastroGenero.component';
import { CadastroJogoComponent } from './components/cadastroJogo/cadastroJogo.component';
import { NavComponent } from './components/nav/nav.component';
import { TituloComponent } from './components/titulo/titulo.component';

const routes: Routes = [
  {path: 'jogos', component: JogosComponent},
  {path: 'jogos/cadastroGenero', component: CadastroGeneroComponent},
  {path: 'jogos/cadastroJogo', component: CadastroJogoComponent},
  {path: 'jogos/nav', component: NavComponent},
  {path: 'jogos/titulo', component: TituloComponent},
  {path: '', redirectTo: 'jogos', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
