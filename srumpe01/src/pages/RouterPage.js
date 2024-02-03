import React from 'react'
import {BrowserRouter as Router,  Routes, Route} from 'react-router-dom'
import Home from './Home'
import Docente from './Docente'
import Docentebuscarestudiante from './DocenteBuscarestudiante'
import Docenteelegircurso from './Docenteelegircurso'
import Docenteestudiantelista from './Docenteestudiantelista'
import DocenteReclamos from './DocenteReclamos'
import Docenteuserupdate from './Docenteuserupdate'

import Estudiante from './Estudiante'
import Estudianteinfornotas from './EstudianteinfoNotas'
import EstudianteMaterias from './EstudianteMateria'
import EstudianteuserUpdate from './EstudianteuserUpdate'

export default function RouterPage() {
    return(
        <div>
            <Router>
                <Routes>
                    <Route path='/Home' exact Component={Home}/>
                    <Route path='/Docente' exact Component={Docente}/>
                    <Route path='/DocenteBuscarestudiante' exact Component={Docentebuscarestudiante}/>
                    <Route path='/Docenteelegircurso' exact Component={Docenteelegircurso}/>
                    <Route path='/Docenteestudiantelista' exact Component={Docenteestudiantelista}/>
                    <Route path='/DocenteReclamos' exact Component={DocenteReclamos}/>
                    <Route path='/Docenteuserupdate' exact Component={Docenteuserupdate}/>

                    <Route path='/Estudiante' exact Component={Estudiante}/>
                    <Route path='/EstudianteinfoNotas' exact Component={Estudianteinfornotas}/>
                    <Route path='/EstudianteMateria' exact Component={EstudianteMaterias}/>
                    <Route path='/EstudianteuserUpdate' exact Component={EstudianteuserUpdate}/>
                </Routes>
            </Router>
        </div>
        
    )
}