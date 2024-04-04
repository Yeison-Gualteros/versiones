import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';
import { useNavigate } from 'react-router-dom';

export default function Home() {
	const API_URL = 'https://localhost:7284/api/usuario/registro';
	const API_URL2 = 'https://localhost:7284/api/usuario/login';

  const [usuario, setUsuario] = useState('');
  const [clave, setClave] = useState('');
  const [id, setId] = useState('');
  const [nombreUsuario, setNombreUsuario] = useState('');
  const [correoElectronico, setCorreoElectronico] = useState('');
  const [contrasena, setContrasena] = useState('');
  const [rol, setRol] = useState('');
  const [showModal, setShowModal] = useState(false);
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [selectedOption, setSelectedOption] = useState('');
  const [registrado, setRegistrado] = useState(false);

  
	const navigate = useNavigate();

  const navigateBasedOnRole = (rol) => {
    switch (rol) {
      case 'Estudiante':
        navigate('/Estudiante');
        break;
      case 'Docente':
        navigate('/Docente');
        break;
      case 'Secretaria':
        navigate('/Secretaria');
        break;
      default:
        show_alert('Rol no reconocido', 'Error');
        break;
    }
  };
  const cerrarModal = () => {
    setShowModal(false);
  };

  const handleLogin = async (event) => {
    event.preventDefault();
    try {
        const response = await axios.post(API_URL2, {
            NombreUsuario: usuario,
            Contrasena: clave
        });
        const { token } = response.data;
        localStorage.setItem('userToken', token);
        navigateBasedOnRole(rol);
    } catch (error) {
        if (error.response && error.response.status === 401) {
            show_alert('Error', 'Usuario o contraseña incorrectos');
        } else {
            show_alert('Error', 'Ocurrió un error al intentar iniciar sesión');
        }
    }
};

  const handleUsernameChange = (event) => {
    setUsername(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const handleSelectChange = (event) => {
    setSelectedOption(event.target.value);
  };

  const openModal = (op, usuario) => {
    setOperation(op);
    if (op === 1) {
      setTitle('Llenar información');
      setId('');
      setNombreUsuario('');
      setCorreoElectronico('');
      setContrasena('');
      setRol('');
      setShowModal(true);
    }
  };

  const validar = () => {
	if (!nombreUsuario || !correoElectronico || !contrasena || !rol) {
	  show_alert('Todos los campos son obligatorios', 'info');
	} else {
	  const parametros = {
		nombreUsuario,
		correoElectronico,
		contrasena,
		rol,
	  };
	  const metodo =  'post'; // Siempre usar POST
	  enviarSolicitud(metodo, parametros);
	}
	cerrarModal();
  };

  const enviarSolicitud = async (metodo, parametros) => {
	let respuesta;
	try {
	  if (metodo === "post") {
		respuesta = await axios.post(API_URL, parametros);
	  }
	  // Registro exitoso
	  show_alert("Registro exitoso", "success");
	  // Marca al usuario como registrado
	  setRegistrado(true);
	} catch (error) {
	  show_alert('Ya esta registrado ese nombre', 'error');
	  console.error(error);
	}
  };

  

  return (
    <React.Fragment>
      <div className="Fondo">
        <div className="login-content">
          <nav>
            <nav className="full-box navbar-info">
              <a href="/" className="float-left">
                <p className="fas fa-long-arrow-alt-left"><i > Volver </i></p>
              </a>
            </nav>
            <br />
            <ul>
              <li>
                <p className="text-center">
                  <i className="fas fa-user-circle fa-5x"></i>
                </p>
              </li>
              <ul>
                <li>
                  <p className="text-center">
                    Inicia sesión
                  </p>
                  <form onSubmit={handleLogin}>
                    <div className="form-group">
                      <label htmlFor="UserName" className="bmd-label-floating"><i className="fas fa-user-tie"></i> &nbsp; Usuario</label>
                      <input type="text" className="form-control" id="UserName" name="usuario" pattern="" maxLength="" value={usuario} onChange={(e) => setUsuario(e.target.value)}/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="exampleInputPassword1" className="bmd-label-floating"><i className="fas fa-key"></i> &nbsp; Contraseña</label>
                      <input type="password" className="form-control" id="UserPassword" name="clave" maxLength="200" value={clave} onChange={(e) => setClave(e.target.value)}/>
                    </div>
                    <div className="form-group">
                      <label htmlFor="UserPassword" className="bmd-label-floating"> &nbsp; </label>
                      <select className="form-select" aria-label="Default select example" value={rol} onChange={(e) => setRol(e.target.value)}>
                        <option value="">Seleccione el Usuario</option>
                        <option value="Estudiante">Estudiante</option>
                        <option value="Docente">Docente</option>
                        <option value="Secretaria">Administrativo</option>
                      </select>
                    </div>
                    
                  </form>
                </li>

                <div id="ModalUsuario" className={`modal fade ${showModal ? 'show' : ''}`} aria-hidden={!showModal ? 'true' : 'false'}>
                  <div className="modal-dialog">
                    <div className="modal-content">
                      <div className="modal-header">
                        <label className="h5">{title}</label>
                        
                      </div>
                      <div className="modal-body">
                        <input type="hidden" id="usuarioId" />
                        <div className="input-group mb-3">
                          <span className="input-group-text"><i className="fas fa-signature"></i></span>
                          <input
                            type="text"
                            id="NombreUsuario"
                            className="form-control"
                            placeholder="Nombre completo"
                            value={nombreUsuario}
                            onChange={(e) => setNombreUsuario(e.target.value)}
                          />
                        </div>
                        <div className="input-group mb-3">
                          <span className="input-group-text"><i className="far fa-envelope"></i></span>
                          <input
                            type="text"
                            id="CorreoElectronico"
                            className="form-control"
                            placeholder="Correo"
                            value={correoElectronico}
                            onChange={(e) => setCorreoElectronico(e.target.value)}
                          />
                        </div>

                        <div className="input-group mb-3">
                          <span className="input-group-text"><i className="fas fa-unlock-alt"></i></span>
                          <input
                            type="password"
                            id="Contrasena"
                            className="form-control"
                            placeholder="Contraseña"
                            value={contrasena}
                            onChange={(e) => setContrasena(e.target.value)}
                          />
                        </div>

                        <div className="input-group mb-3">
                          <select className="form-select" id='Rol' value={rol} onChange={(e) => setRol(e.target.value)}>
                            <option value="">Seleccione un rol:</option>
                            <option value="Estudiante">Estudiante</option>
                            <option value="Docente">Docente</option>
                            <option value="Administrador">Administrador</option>
                          </select>
                        </div>
                      </div>
                      <div className="modal-footer">
                        <button onClick={() => validar()} className="btn btn-outline-success">Guardar</button>
                        <button onClick={() => cerrarModal()} type='button' id="btnCerrar" className='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                      </div>
                    </div>
                  </div>
                </div>

                <div  className="text-center">
					<button type="submit" onClick={handleLogin} className='btn btn-secondary'>Iniciar Sesión</button>
					</div>
				<div className=" col-7 mx-auto text-center">
                      <button type="submit" className='btn btn-secondary text-center'  onClick={() => openModal(1)}
                      data-toggle="modal"
                      data-target="#ModalUsuario" ><i className=""></i> Registrar</button>
                    </div>
              </ul>
			  
			  
            </ul>
          </nav>
        </div>
      </div>
	
    
  </React.Fragment>
);
}