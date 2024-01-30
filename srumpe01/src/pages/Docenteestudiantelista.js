import React, {useState, useEffect}from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Docenteestudiantelista() {

    const url = 'https://localhost:5001/api/CandidatoEstudiante';
  const [candidatoEstudiante, setcandidatoEstudiante] = useState([]);
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  const [nombres, setNombres] = useState('');
  const [apellidos, setApellidos] = useState('');
  const [tipodepersona, settipodepersona] = useState('');
  const [fechaNacimiento, setFechaNacimiento] = useState('');
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');

  const [isSubMenuOpen, setIsSubMenuOpen] = useState(false);
  const [isSubMenuOpen1, setIsSubMenuOpen1] = useState(false);

  useEffect(() => {
    getCandidatoEstudiante();
  }, []);

  const getCandidatoEstudiante = async () => {
    try {
      const response = await axios.get(url);
      setcandidatoEstudiante(response.data);
    } catch (error) {
      console.error('Error al obtener al estudiante:', error);
    }
  };

    return(
            
            <React.Fragment>
            <div>
	
                <main className="full-box main-container">
                    
                    <section className="full-box nav-lateral">
                        <div className="full-box nav-lateral-bg show-nav-lateral"></div>
                        <div className="full-box nav-lateral-content">
                            <figure className="full-box nav-lateral-avatar">
                                <i className="far fa-times-circle show-nav-lateral"></i>
                                
                                <img src="/assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar"/>
                                <figcaption className="roboto-medium text-center">
                                Juan David Novoa Yanguma <br/><small className="roboto-condensed-light"><p><span className="badge badge-success">Docente</span></p></small>
                                </figcaption>
                            </figure>
                            <div className="full-box nav-lateral-bar"></div>
                            <nav className="full-box nav-lateral-menu">
                                <ul>
                                    <li>
                                    <Link to={'/Docente'}>
                                        <i class="fab fa-dashcube fa-fw"></i> &nbsp; Inicio
                                    </Link>
                                    </li>
                                    <li>
                                        <a href="#" className="nav-btn-submenu"><i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos <i className="fas fa-chevron-down"></i></a>
                                        <ul>	
                                        
                                            <li>
                                                <Link to={'/Docenteelegircurso'}>
                                                <a ><i class="fas fa-clipboard-list fa-fw"></i> &nbsp; Elegir Cursos</a>
                                                </Link>	
                                            </li>
                                        							
                                        </ul>
                                    </li>
                                    <li>
                                        <a href="#" className="nav-btn-submenu"><i className="fas fa-users fa-fw"></i> &nbsp;  Estudiantes <i className="fas fa-chevron-down"></i></a>
                                        <ul>  
                                        
                                        <li>
                                            <Link to={'/Docenteestudiantelista'}>
                                            <a ><i class="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante</a>
                                            </Link>
                                        </li>
                                        
                                        
                                        <li>
                                            <Link to={'/Docentebuscarestudiante'}>
                                            <a ><i class="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante</a>
                                            </Link>
                                        </li>
                                        
                                        </ul>
                                    </li>
                                    <li>
                                    <Link to={'/DocenteReclamos'}>
                                        <i class="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos
                                    </Link>
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
                            <Link to={'/Docenteuserupdate'}>
                            <a >
                                <i className="fas fa-user-cog"></i>
                            </a>
                            </Link>
                            <a className="btn-exit-system">
                                <i className="fas fa-power-off"></i>
                            </a>
                        </nav>

                        
                        
			<div class="full-box page-header">
				<h3 class="text-left">
					<i class="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES
				</h3>
				<p class="text-justify">
					
				</p>
			</div>

			<div class="container-fluid">
                <ul class="full-box list-unstyled page-nav-tabs">
                    <li>
                        <a class="active" href="Docente-estudiante-lista.html"><i class="fas fa-clipboard-list fa-fw"></i> &nbsp; lista de estudiantes</a>
                    </li>
                    <li>
                    <Link to={'/DocenteBuscarestudiante'}>
                    <i className="fas fa-search fa-fw"></i> &nbsp;buscar estudiante
                    </Link>
                    </li>
                </ul>
                    
                </div>
            </section>
			
			
			<div class="container-fluid">
				<div class="table-responsive">
                <table className="table table-dark table-sm">
                <thead>
                <tr className="text-center roboto-medium">
                  <th>#</th>
                  <th>ID</th>
                  <th>NOMBRE</th>
                  <th>APELLIDO</th>
                  <th>ASISTENCIA</th>
                  <th>NOTA</th>
                  
                </tr>
              </thead>
              <tbody>
              {candidatoEstudiante.map((CandidatoEstudiante, i) => (
                <tr key={CandidatoEstudiante.candidatoEstudianteId} className="text-center">
                  <td className="#">{i + 1}</td>
                  <td className="ID">{CandidatoEstudiante.candidatoEstudianteId}</td>
                  <td className="nombre" >{CandidatoEstudiante.nombre}</td>
                  <td className="apellido">{CandidatoEstudiante.apellido}</td>
                  <td className="asistencia">
                    <div className="col-12 col-md-6">
                      <div className="form-group">
                        <select className="form-control" name="item_estado" id="item_estado">
                          <option value="" selected="" disabled="">
                            Seleccione una opción
                          </option>
                          <option selected="" value="Habilitado">
                            ASISTENCIA
                          </option>
                          <option value="Deshabilitado">INASISTENCIA</option>
                          <option value="Deshabilitado">EVADIENDO CLASE</option>
                        </select>
                      </div>
                    </div>
                  </td>
                  <td className="nota">
                    <div className="col-12 col-md-6">
                      <div className="form-group">
                        <input
                          type="text"
                          pattern="[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{1,40}"
                          className="form-control"
                          name="cliente_nombre"
                          id="cliente_nombre"
                          maxLength="40"
                        />
                      </div>
                    </div>
                  </td>
                  
                </tr>
              ))}
              </tbody>
                </table>
				</div>
				<nav aria-label="Page navigation example">
					<ul class="pagination justify-content-center">
						<li class="page-item disabled">
							<a class="page-link" href="#" tabindex="-1">Anterior</a>
						</li>
						<li class="page-item"><a class="page-link" href="#">1</a></li>
						<li class="page-item"><a class="page-link" href="#">2</a></li>
						<li class="page-item"><a class="page-link" href="#">3</a></li>
						<li class="page-item">
							<a class="page-link" href="#">Siguiente</a>
						</li>
					</ul>
				</nav>
			</div>
                        
        </main>
        </div>      
            </React.Fragment>
            
        
    )
}