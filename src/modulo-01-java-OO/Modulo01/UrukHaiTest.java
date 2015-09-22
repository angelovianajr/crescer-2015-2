

import static org.junit.Assert.*;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

/**
 * A classe de teste UrukHaiTest.
 *
 * @author  (seu nome)
 * @version (um número de versão ou data)
 */
public class UrukHaiTest
{
    @Test
    public void criaUrukHai(){
        Orc orc = new UrukHai();
        
        int vidaEsperada = 150;
        Inventario inventarioEsperado = new Inventario();
        inventarioEsperado.adicionarItem(new Item(1, "Escudo Uruk-Hai"));
        inventarioEsperado.adicionarItem(new Item(1, "Espada"));
        
        assertEquals(vidaEsperada, orc.getVida());
        assertEquals(inventarioEsperado, orc.getInventario());
    }
    
    @Test
    public void orcUrukHaiRecebeAtaqueEPerde6DeVida(){
        Orc orc = new UrukHai();
        
        orc.levarAtaque();
        
        assertEquals(144, orc.getVida());
    }
    
    @Test
    public void orcUrukHaiRecebeAtaqueEPerde10DeVidaPorquePerdeuEscudo(){
        Orc orc = new UrukHai();
        
        orc.perderItem(new Item(1, "Escudo Uruk-Hai"));
        
        orc.levarAtaque();
        
        assertEquals(140, orc.getVida());
    }
    
    @Test
    public void orcUrukHaiPerdeEspadaEAtacaComArcoQueGanhouEUmaFlecha(){
        Orc orc = new UrukHai();
        Dwarf anao = new Dwarf();
        orc.perderItem(new Item(1, "Espada"));
        orc.adicionarItem(new Item(1, "Arco"));
        orc.adicionarItem(new Item(1, "Flecha"));
        Inventario inventarioEsperado = new Inventario();
        inventarioEsperado.adicionarItem(new Item(1, "Escudo Uruk-Hai"));
        inventarioEsperado.adicionarItem(new Item(1, "Arco"));
        
        orc.atacar(anao);
        
        assertEquals(102, anao.getVida());
        assertEquals(inventarioEsperado, orc.getInventario());
    }
    
    @Test
    public void orcUrukHaiFogePorqueNaoTemArmaParaAtacar(){
        Orc orc = new UrukHai();
        orc.perderItem(new Item(1, "Espada"));
        Elfo legolas = new Elfo("Legolas");
        int vidaEsperada = 80;
        
        orc.atacar(legolas);
        
        assertEquals(Status.FUGINDO, orc.getStatus());
        assertEquals(vidaEsperada, legolas.getVida());
    }
}
