import styles from "./styles.module.css"
import { Link } from 'react-router-dom';
import { useState } from "react"

function Navbar() {

  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => {
    setIsOpen(!isOpen);
  };

  const closeMenu = () =>{
    setIsOpen(false);
  }

  return (
    <div className={styles.navbar}>
      <div className={styles.brand} onClick={closeMenu}></div>

      <div className={`${styles.hamburger} ${isOpen && styles.open}`} onClick={toggleMenu}>
        {/* Hamburger icon */}
        <span className={styles.bar}></span>
        <span className={styles.bar}></span>
        <span className={styles.bar}></span>
      </div>

      <ul className={`${styles.buttonGroup} ${isOpen ? styles.active : ''}`}>
      <li><Link to="/"><button className={styles.navButton} onClick={closeMenu}>Anasayfa</button></Link></li>
      <li><Link to="/practice-areas"><button className={styles.navButton} onClick={closeMenu}>Uzmanlık Alanları</button></Link></li>
      <li><Link to="/about-us"><button className={styles.navButton} onClick={closeMenu}>Hakkımızda</button></Link></li>
      <li><Link to="/contact"><button className={styles.navButton} onClick={closeMenu}>İletişim</button></Link></li>
    </ul>
    <div className={styles.space}></div>
  </div>
  )
}

export default Navbar