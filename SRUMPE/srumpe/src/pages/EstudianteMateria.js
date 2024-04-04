import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import withReactContent from 'sweetalert2-react-content';
import Swal from 'sweetalert2';



export default function EstudianteMaterias() {

	const [isSubMenuOpen, setIsSubMenuOpen] = useState(false);

  const toggleSubMenu = () => {
    setIsSubMenuOpen(!isSubMenuOpen);
  };
  const url = 'https://localhost:7284/api/notas'
  const [notas, setNotas] = useState([]);
  const [notaId, setNotaId] = useState('');
  const [estudiante, setEstudiante] = useState('');
  const [curso, setCurso] = useState('');
  const [periodoAcademico, setPeriodoAcademico] = useState('');
  const [fechaCreacion, setFechaCreacion] = useState('');
  const [materia, setMateria] = useState('');
  const [valorNota, setValorNota] = useState('');
  const [tipoNota, setTipoNota] = useState('');
  const [descripcionNota, setDescripcionNota] = useState('')
  const [searchTerm, setSearchTerm] = useState('');

  const [showModal, setShowModal] = useState(false);
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');

  const [notasSeleccionadas, setNotasSeleccionadas] = useState([]);
  const [promedio, setPromedio] = useState(null);

  const getnotas = async () => {
    try {
        const respuesta = await axios.get(url);
        setNotas(respuesta.data);
    } catch (error) {
        console.error('Error al obtener estudiante:', error);
    }
  };
  useEffect(() =>{
    getnotas();
  }, []);
  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
};

useEffect(() => {
  if (showModal) {
    const inputElement = document.getElementById('cursos');
    if (inputElement) {
      inputElement.focus();
    }
  }
}, [showModal]);






const filterednotas = notas.filter((nota) => {
  const fullName = `${nota.estudiante} ${nota.periodoAcademico}`.toLowerCase();
  return fullName.includes(searchTerm.toLowerCase()); 
});

const handleCheckboxChange = (e, nota) => {
  if (e.target.checked) {
    // Agregar la nota seleccionada al estado de notas seleccionadas
    setNotasSeleccionadas([...notasSeleccionadas, nota]);
  } else {
    // Eliminar la nota de las notas seleccionadas si se desmarca la casilla de verificación
    setNotasSeleccionadas(notasSeleccionadas.filter(item => item !== nota));
  }
};

// Función para calcular el promedio de las notas seleccionadas
const calcularPromedio = () => {
  // Verificar si hay notas seleccionadas
  if (notasSeleccionadas.length === 0) {
    show_alert('Selecciona al menos una nota para calcular el promedio', 'error');
    return;
  }

  // Calcular el promedio sumando los valores de las notas y dividiendo entre el número de notas
  const totalNotas = notasSeleccionadas.reduce((acc, nota) => acc + nota.valorNota, 0);
  const promedio = totalNotas / notasSeleccionadas.length;

  // Actualizar el estado del promedio
  setPromedio(promedio.toFixed(2)); // Redondear el promedio a dos decimales
};

    return(
        <React.Fragment>
	<main className="full-box main-container">
		<section className="full-box nav-lateral">
			<div className="full-box nav-lateral-bg show-nav-lateral"></div>
			<div className="full-box nav-lateral-content">
				<figure className="full-box nav-lateral-avatar">
					<i className="far fa-times-circle show-nav-lateral"></i>
					<figcaption className="SRMNPE text-center">
						SRUNPE <br/><small className="roboto-condensed-light"></small>
					</figcaption>
					<img src="../assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar"/>
					<figcaption className="roboto-medium text-center">
					¡Bienvenido! <br/><small className="roboto-condensed-light"><p><span className="badge badge-dark">Estudiante</span></p></small>
					</figcaption>
				</figure>
				<div className="full-box nav-lateral-bar"></div>
				<nav className="full-box nav-lateral-menu">
                <ul>
						<li >
							
								<a href='/Estudiante'><span style={{color: 'white'}}><i class="fab fa-dashcube fa-fw"  ></i> &nbsp;Inicio</span></a>
							
                        	
						</li>
						<li>
									
                                    <li>
                                        <a href='/EstudianteMateria'><i className="fas fa-clipboard-list fa-fw" ></i> &nbsp; Ver Materias</a>
                                    </li>
                                	
							<ul>	
									
                                    <li>
                                        <a href='/EstudianteMateria'><i className="fas fa-clipboard-list fa-fw" ></i> &nbsp; Ver Materias</a>
                                    </li>
                                	
							</ul>
						</li>	
						<li>
							<span style={{color: 'white'}}>
								<a  className="nav-btn-submenu" onClick={toggleSubMenu}><i className="fas fa-info fa-fw"></i> &nbsp; Información <i className="fas fa-chevron-down"></i></a>
							<ul style={{ display: isSubMenuOpen ? 'block' : 'none' }}>
                                
                                    <li>
                                        <a href='/Estudianteinfonotas'><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Notas</a>
                                    </li>		
                                
							</ul></span>
						</li>
					</ul>
				</nav>
			</div>
		</section>
		<section className="full-box page-content">
			<nav className="full-box navbar-info">
				<a className="float-left show-nav-lateral">
					<i className="fas fa-exchange-alt"></i>
				</a>
				<a href='/EstudianteuserUpdate'>
                    
                        <i class="fas fa-user-cog"></i>
                    
                </a>
				<a className="btn-exit-system">
					<i className="fas fa-power-off"></i>
				</a>
			</nav>
			<div className="full-box page-header">
				<h3 className="text-left">
					<i className="fas fa-vote-yea"></i> &nbsp; NOTAS DE CADA MATERIA
				</h3>
				<p className="text-justify">
					  {/* Resto del JSX del componente */}
					  <button onClick={calcularPromedio} className="btn btn-primary">
        Calcular Promedio
      </button>
      {/* Mostrar el resultado del promedio si está disponible */}
      {promedio !== null && (
        <p>Promedio de las notas seleccionadas: {promedio}</p>
      )}
				</p>
			</div>
			<div class="container-fluid">
				<form class="form-neon" onSubmit={(e) => e.preventDefault()}>
						<div class="row justify-content-md-center">
							<div class="col-12 col-md-6">
								<div class="form-group">
									<label for="inputSearch" class="frome bmd-label-floating">¿Qué estas buscando? Inserta el nombre del alumno</label>
									<input type="text" class="form-control" name="busqueda_reservation" id="inputSearch" maxlength="30" value={searchTerm} onChange={handleSearchChange} />
								</div>
							</div>
							
						</div>
            <div className="container-fluid">
            <div className="table-responsive" style={{ overflowY: 'auto', maxHeight: '70vh' }}>
              <table className="table table-dark table-sm">
                <thead>
                  <tr className="text-center roboto-medium">
                    <th>#</th>
                    <th>NOMBRE</th>
                    <th>CURSO</th>
                    <th>PERIODO ACADEMICO</th>
                    <th>FECHA DE CREACION</th>
                    <th>MATERIA</th>
                    <th>VALOR DE LA NOTA</th>
                    <th>TIPO DE NOTA</th>
                    <th>DESCRIPCION NOTA</th>
                    
                    <th>SELECCIONAR</th> 
                  </tr>
                </thead>
                <tbody className="table-group-divider">
                          {filterednotas.map((notas, i) => (
                      <tr className="text-center" key={notas.notaId}> 
                      <td><span className="table-index">{i + 1}</span></td>
                      <td><span className="table-estudiante">{notas.estudiante}</span></td>
                      <td><span className="table-curso">{notas.curso}</span></td>
                      <td><span className="table-periodo">{notas.periodoAcademico}</span></td>
                      <td><span className="table-fechac">{notas.fechaCreacion}</span></td>
                      <td><span className="table-materia">{notas.materia}</span></td>
                      <td><span className="table-valorn">{notas.valorNota}</span></td>
                      <td><span className="table-tipon">{notas.tipoNota}</span></td>
                      <td><span className="table-descripcion">{notas.descripcionNota}</span></td>
                      
                      <td><input type="checkbox" onChange={(e) => handleCheckboxChange(e, notas)} /></td>

                  </tr>
              ))}
          </tbody>
              </table>
            </div>
          </div>
				</form>
			</div>
</section>
    </main>
        </React.Fragment>
    )
}