import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { Contact } from './pages/contact/contact';
import { About } from './pages/about/about';
import { Navbar } from './shared/navbar/navbar';
import { Login } from './pages/auth/login/login';
import { Register } from './pages/auth/register/register';
import { Movies } from './pages/movies/movies';
import { TvShows } from './pages/tv-shows/tv-shows';

export const routes: Routes = [
  {
    path: '',
    component: Navbar,
    children: [
      { path: '', component: Home },
      { path: 'contact', component: Contact },
      { path: 'about', component: About },
      { path: 'movies', component: Movies },
      { path: 'shows', component: TvShows },
    ],
  },
  { path: 'login', component: Login },
  { path: 'register', component: Register }
];