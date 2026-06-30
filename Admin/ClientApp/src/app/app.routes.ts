import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ControlRoomComponent } from './components/control-room/control-room.component';
import { ScoreBoardComponent } from './components/score-board/score-board.component';

export const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'control', component: ControlRoomComponent },
  { path: 'score-board', component: ScoreBoardComponent },
];
