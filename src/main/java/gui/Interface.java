package gui;


import java.awt.Color;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.Action;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.UIDefaults;
import javax.swing.UIManager;
import javax.swing.UnsupportedLookAndFeelException;
import javax.swing.filechooser.FileNameExtensionFilter;
import javax.swing.plaf.ColorUIResource;
import javax.swing.text.DefaultCaret;
import javax.swing.text.DefaultEditorKit;
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author maria
 */

public class Interface extends javax.swing.JFrame {
  
  
     
    
    /**
     * Creates new form Interface
     */
    NumeroLinea numLinea;
    File archivo = null;
    
    PintarPalabras pintarPalabras;
    Color black;
    Color white;
    
    String nombreArchivo = "";
    private String textoCopiado;
    
    public Interface() {
        initComponents();
        numLinea = new NumeroLinea(jTxtCodigo);
        jScrollPane2.setRowHeaderView(numLinea);
        
        //permite cambiar el tema del editor
        pintarPalabras = new PintarPalabras();
        
        //permite que cambiar background del editor de texto
        black = new Color(66, 73, 73 );
        white = new Color(255, 255, 255 );
        UIDefaults defaults = new UIDefaults();
        defaults.put("TextPane.background", new ColorUIResource(black));
        defaults.put("TextPane[Enabled].backgroundPainter", black);
        defaults.put("TextPane.background", new ColorUIResource(white));
        defaults.put("TextPane[Enabled].backgroundPainter", white);
        jTxtCodigo.putClientProperty("Nimbus.Overrides", defaults);
        jTxtCodigo.putClientProperty("Nimbus.Overrides.InheritDefaults", true);
        
        jTxtCodigo.setStyledDocument(pintarPalabras.getDocClaro());
       
        
    }
        
    

    /**
     * This method is called from within the constructor to initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is always
     * regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jMenuBar2 = new javax.swing.JMenuBar();
        jMenu6 = new javax.swing.JMenu();
        jMenu7 = new javax.swing.JMenu();
        jMenuBar3 = new javax.swing.JMenuBar();
        jMenu8 = new javax.swing.JMenu();
        jMenu9 = new javax.swing.JMenu();
        jMenuBar4 = new javax.swing.JMenuBar();
        jMenu10 = new javax.swing.JMenu();
        jMenu11 = new javax.swing.JMenu();
        jPopupMenu1 = new javax.swing.JPopupMenu();
        jMenuBar5 = new javax.swing.JMenuBar();
        jMenu12 = new javax.swing.JMenu();
        jMenu13 = new javax.swing.JMenu();
        jMenuBar6 = new javax.swing.JMenuBar();
        jMenu14 = new javax.swing.JMenu();
        jMenu15 = new javax.swing.JMenu();
        jMenuItem1 = new javax.swing.JMenuItem();
        jMenu16 = new javax.swing.JMenu();
        jMenuItem2 = new javax.swing.JMenuItem();
        jMenuItem3 = new javax.swing.JMenuItem();
        jMenuItem4 = new javax.swing.JMenuItem();
        jLabel1 = new javax.swing.JLabel();
        jTabbedPane3 = new javax.swing.JTabbedPane();
        jToolBar6 = new javax.swing.JToolBar();
        jToolBar7 = new javax.swing.JToolBar();
        jScrollPane4 = new javax.swing.JScrollPane();
        jTextErrores = new javax.swing.JTextPane();
        jToolBar8 = new javax.swing.JToolBar();
        jPanel1 = new javax.swing.JPanel();
        jTabbedPane2 = new javax.swing.JTabbedPane();
        jToolBar2 = new javax.swing.JToolBar();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextLexico = new javax.swing.JTextPane();
        jToolBar3 = new javax.swing.JToolBar();
        jScrollPane3 = new javax.swing.JScrollPane();
        jTextSintactico = new javax.swing.JTextPane();
        jToolBar4 = new javax.swing.JToolBar();
        jScrollPane5 = new javax.swing.JScrollPane();
        jTextSemantico = new javax.swing.JTextPane();
        jToolBar5 = new javax.swing.JToolBar();
        lblCodigoIntermedio = new javax.swing.JLabel();
        jScrollPane6 = new javax.swing.JScrollPane();
        jTextCodigo = new javax.swing.JTextPane();
        jPanel2 = new javax.swing.JPanel();
        jScrollPane2 = new javax.swing.JScrollPane();
        jTxtCodigo = new javax.swing.JTextPane();
        jMenuBar1 = new javax.swing.JMenuBar();
        jMenu1 = new javax.swing.JMenu();
        jMINuevo = new javax.swing.JMenuItem();
        jMIAbrir = new javax.swing.JMenuItem();
        jMIGuardarC = new javax.swing.JMenuItem();
        jMIGuardar = new javax.swing.JMenuItem();
        jMEditar = new javax.swing.JMenu();
        jMenuItem5 = new javax.swing.JMenuItem();
        Copiar = new javax.swing.JMenuItem();
        Pegar = new javax.swing.JMenuItem();
        jMenu3 = new javax.swing.JMenu();
        setTemaClaro = new javax.swing.JMenuItem();
        setTemaOscuro = new javax.swing.JMenuItem();
        jMenu4 = new javax.swing.JMenu();
        compilar = new javax.swing.JMenuItem();
        jMenu5 = new javax.swing.JMenu();

        jMenu6.setText("File");
        jMenuBar2.add(jMenu6);

        jMenu7.setText("Edit");
        jMenuBar2.add(jMenu7);

        jMenu8.setText("File");
        jMenuBar3.add(jMenu8);

        jMenu9.setText("Edit");
        jMenuBar3.add(jMenu9);

        jMenu10.setText("File");
        jMenuBar4.add(jMenu10);

        jMenu11.setText("Edit");
        jMenuBar4.add(jMenu11);

        jMenu12.setText("File");
        jMenuBar5.add(jMenu12);

        jMenu13.setText("Edit");
        jMenuBar5.add(jMenu13);

        jMenu14.setText("File");
        jMenuBar6.add(jMenu14);

        jMenu15.setText("Edit");
        jMenuBar6.add(jMenu15);

        jMenuItem1.setText("jMenuItem1");

        jMenu16.setText("jMenu16");

        jMenuItem2.setText("jMenuItem2");

        jMenuItem3.setText("jMenuItem3");

        jMenuItem4.setText("jMenuItem4");

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setBackground(new java.awt.Color(255, 0, 0));

        jLabel1.setFont(new java.awt.Font("Tahoma", 1, 14)); // NOI18N
        jLabel1.setText("Código a compilar");

        jTabbedPane3.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jTabbedPane3.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N

        jToolBar6.setRollover(true);

        jToolBar7.setRollover(true);
        jToolBar6.add(jToolBar7);

        jScrollPane4.setViewportView(jTextErrores);

        jToolBar6.add(jScrollPane4);

        jTabbedPane3.addTab("Errores", jToolBar6);

        jToolBar8.setRollover(true);
        jTabbedPane3.addTab("Resultados", jToolBar8);

        jTabbedPane2.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jTabbedPane2.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N

        jToolBar2.setRollover(true);

        jTextLexico.setEditable(false);
        jScrollPane1.setViewportView(jTextLexico);

        jToolBar2.add(jScrollPane1);

        jTabbedPane2.addTab("Léxico", jToolBar2);

        jToolBar3.setRollover(true);

        jTextSintactico.setEditable(false);
        jTextSintactico.setAutoscrolls(false);
        jScrollPane3.setViewportView(jTextSintactico);

        jToolBar3.add(jScrollPane3);

        jTabbedPane2.addTab("Sintáctico", jToolBar3);

        jToolBar4.setRollover(true);

        jTextSemantico.setEditable(false);
        jScrollPane5.setViewportView(jTextSemantico);

        jToolBar4.add(jScrollPane5);

        jTabbedPane2.addTab("Semántico", jToolBar4);

        jToolBar5.setRollover(true);
        jToolBar5.add(lblCodigoIntermedio);

        jScrollPane6.setViewportView(jTextCodigo);

        jToolBar5.add(jScrollPane6);

        jTabbedPane2.addTab("Código intermedio", jToolBar5);

        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(jPanel1);
        jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, jPanel1Layout.createSequentialGroup()
                .addGap(0, 13, Short.MAX_VALUE)
                .addComponent(jTabbedPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 411, javax.swing.GroupLayout.PREFERRED_SIZE))
        );
        jPanel1Layout.setVerticalGroup(
            jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel1Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jTabbedPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 342, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jScrollPane2.setBorder(javax.swing.BorderFactory.createTitledBorder(""));
        jScrollPane2.setViewportView(jTxtCodigo);

        javax.swing.GroupLayout jPanel2Layout = new javax.swing.GroupLayout(jPanel2);
        jPanel2.setLayout(jPanel2Layout);
        jPanel2Layout.setHorizontalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 559, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );
        jPanel2Layout.setVerticalGroup(
            jPanel2Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(jPanel2Layout.createSequentialGroup()
                .addContainerGap()
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, 354, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        jMenu1.setText("Archivo");

        jMINuevo.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_N, java.awt.event.InputEvent.CTRL_MASK));
        jMINuevo.setText("Nuevo");
        jMINuevo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMINuevoActionPerformed(evt);
            }
        });
        jMenu1.add(jMINuevo);

        jMIAbrir.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_A, java.awt.event.InputEvent.ALT_MASK));
        jMIAbrir.setText("Abrir");
        jMIAbrir.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMIAbrirActionPerformed(evt);
            }
        });
        jMenu1.add(jMIAbrir);

        jMIGuardarC.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_S, java.awt.event.InputEvent.CTRL_MASK));
        jMIGuardarC.setText("Guardar como");
        jMIGuardarC.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMIGuardarCActionPerformed(evt);
            }
        });
        jMenu1.add(jMIGuardarC);

        jMIGuardar.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_G, java.awt.event.InputEvent.CTRL_MASK));
        jMIGuardar.setText("Guardar");
        jMIGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMIGuardarActionPerformed(evt);
            }
        });
        jMenu1.add(jMIGuardar);

        jMenuBar1.add(jMenu1);

        jMEditar.setText("Editar");
        jMEditar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMEditarActionPerformed(evt);
            }
        });

        jMenuItem5.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_X, java.awt.event.InputEvent.CTRL_MASK));
        jMenuItem5.setText("Cortar");
        jMenuItem5.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jMenuItem5ActionPerformed(evt);
            }
        });
        jMEditar.add(jMenuItem5);

        Copiar.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_C, java.awt.event.InputEvent.CTRL_MASK));
        Copiar.setText("Copiar");
        Copiar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                CopiarActionPerformed(evt);
            }
        });
        jMEditar.add(Copiar);

        Pegar.setAccelerator(javax.swing.KeyStroke.getKeyStroke(java.awt.event.KeyEvent.VK_V, java.awt.event.InputEvent.CTRL_MASK));
        Pegar.setText("Pegar");
        Pegar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                PegarActionPerformed(evt);
            }
        });
        jMEditar.add(Pegar);

        jMenuBar1.add(jMEditar);

        jMenu3.setText("Formato");

        setTemaClaro.setText("Tema Claro");
        setTemaClaro.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                setTemaClaroActionPerformed(evt);
            }
        });
        jMenu3.add(setTemaClaro);

        setTemaOscuro.setText("Tema Oscuro");
        setTemaOscuro.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                setTemaOscuroActionPerformed(evt);
            }
        });
        jMenu3.add(setTemaOscuro);

        jMenuBar1.add(jMenu3);

        jMenu4.setText("Compilar");

        compilar.setText("Compilar");
        compilar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                compilarActionPerformed(evt);
            }
        });
        jMenu4.add(compilar);

        jMenuBar1.add(jMenu4);

        jMenu5.setText("Ayuda");
        jMenuBar1.add(jMenu5);

        setJMenuBar(jMenuBar1);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(0, 0, Short.MAX_VALUE)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(jLabel1)
                            .addComponent(jPanel2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jTabbedPane3, javax.swing.GroupLayout.Alignment.TRAILING))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(20, 20, 20)
                .addComponent(jLabel1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                    .addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                    .addComponent(jPanel2, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jTabbedPane3, javax.swing.GroupLayout.PREFERRED_SIZE, 149, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void jMINuevoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMINuevoActionPerformed
        // TODO add your handling code here:
        jTxtCodigo.setText("");
        nombreArchivo = "";
        archivo = null;
    }//GEN-LAST:event_jMINuevoActionPerformed

    private void jMIAbrirActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMIAbrirActionPerformed
        // TODO add your handling code here:
     
      InputStreamReader fr = null;
      BufferedReader br = null;
      String cadena = "";
        try {
         // Apertura del fichero y creacion de BufferedReader para poder
         // hacer una lectura comoda (disponer del metodo readLine()).
         FileNameExtensionFilter filter = new FileNameExtensionFilter("Documento PDF", new String[]{"pdf"});
        final JFileChooser fc = new JFileChooser();
        fc.showOpenDialog(this);
         archivo = fc.getSelectedFile();
         nombreArchivo = archivo.getName(); 
         // fr = new FileReader (archivo);
         fr = new InputStreamReader(new FileInputStream(archivo), "UTF-8");
         br = new BufferedReader(fr);

         // Lectura del fichero
         String linea;
         while((linea=br.readLine())!=null)
             cadena += linea + "\n";
            jTxtCodigo.setText(cadena);
      }
      catch(Exception e){
         e.printStackTrace();
      }finally{
         // En el finally cerramos el fichero, para asegurarnos
         // que se cierra tanto si todo va bien como si salta 
         // una excepcion.
         try{                    
            if( null != fr ){   
               fr.close();     
            }                  
         }catch (Exception e2){ 
            e2.printStackTrace();
         }
      }
    }//GEN-LAST:event_jMIAbrirActionPerformed

    private void jMIGuardarCActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMIGuardarCActionPerformed
        // TODO add your handling code here:
        try
        {
            String nombreArchivo="";
            JFileChooser file=new JFileChooser();
            file.showSaveDialog(this);
            File guarda = file.getSelectedFile();

            if(guarda !=null)
            {
                /*guardamos el archivo y le damos el formato directamente,
                * si queremos que se guarde en formato doc lo definimos como .doc*/
                
                FileWriter  save = new FileWriter(guarda + ".txt");
                save.write(jTxtCodigo.getText());
                save.close();
                
                archivo = new File(guarda + ".txt");
                
                JOptionPane.showMessageDialog(null,
                    "El archivo se a guardado Exitosamente",
                    "Información",JOptionPane.INFORMATION_MESSAGE);
                nombreArchivo = guarda + ".txt";
            }
        }
        catch(IOException ex)
        {
            JOptionPane.showMessageDialog(null,
                "Su archivo no se ha guardado",
                "Advertencia",JOptionPane.WARNING_MESSAGE);
        }
        
    }//GEN-LAST:event_jMIGuardarCActionPerformed

    private void jMIGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMIGuardarActionPerformed
        // TODO add your handling code here:
        FileWriter fileOut;
        
        try {
            if (archivo == null){
                jMIGuardarCActionPerformed(evt);
            } else {
                fileOut = new FileWriter(archivo.getCanonicalPath());
                fileOut.write(jTxtCodigo.getText());
                fileOut.close();
                JOptionPane.showMessageDialog(null,
                    "Cambios guardados",
                    "Información",JOptionPane.INFORMATION_MESSAGE);
            }
        } catch (IOException ex) {
            Logger.getLogger(Interface.class.getName()).log(Level.SEVERE, null, ex);
        }
    }//GEN-LAST:event_jMIGuardarActionPerformed

    private void jMEditarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMEditarActionPerformed
       
        

    }//GEN-LAST:event_jMEditarActionPerformed

    private void setTemaClaroActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_setTemaClaroActionPerformed
        // TODO add your handling code here:
        jTxtCodigo.setBackground(white);
        String temp = jTxtCodigo.getText();
        jTxtCodigo.setStyledDocument(pintarPalabras.getDocClaro());
        jTxtCodigo.setText(temp);
    }//GEN-LAST:event_setTemaClaroActionPerformed

    private void setTemaOscuroActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_setTemaOscuroActionPerformed
        // TODO add your handling code here:
        jTxtCodigo.setBackground(black);
        // jTextPane1.setForeground(Color.BLACK);
        String temp = jTxtCodigo.getText();
        jTxtCodigo.setStyledDocument(pintarPalabras.getDocOscuro());
        jTxtCodigo.setText(temp);
    }//GEN-LAST:event_setTemaOscuroActionPerformed

    private void jMenuItem5ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jMenuItem5ActionPerformed
            Action cut = new DefaultEditorKit.CutAction();
             cut.actionPerformed(evt);
        
    }//GEN-LAST:event_jMenuItem5ActionPerformed

    private void CopiarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_CopiarActionPerformed
            Action copy= new DefaultEditorKit.CopyAction();
            copy.actionPerformed(evt);
    }//GEN-LAST:event_CopiarActionPerformed

    private void PegarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_PegarActionPerformed
         Action paste= new DefaultEditorKit.PasteAction();
         paste.actionPerformed(evt);
    }//GEN-LAST:event_PegarActionPerformed

    private void compilarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_compilarActionPerformed
        // TODO add your handling code here:
        try{
           /* directorio/ejecutable es el path del ejecutable y un nombre */            
           jMIGuardarActionPerformed(evt);
           
           /*Process p = Runtime.getRuntime().exec ("compilador", new String []{archivo.getAbsolutePath()});
           p.wait();
           p.getOutputStream();*/
           Runtime rt = Runtime.getRuntime();
            // String[] commands = {"D:\\documentos\\8vo\\compiladores\\c sharp\\compilador\\compilador\\bin\\Debug\\netcoreapp3.1\\compilador.exe", archivo.getAbsolutePath()};
            String[] commands = {"compilador\\compilador\\bin\\Debug\\netcoreapp3.1\\compilador.exe", archivo.getAbsolutePath()};
            Process proc = rt.exec(commands);

            BufferedReader stdInput = new BufferedReader(new 
                 InputStreamReader(proc.getInputStream()));

            BufferedReader stdError = new BufferedReader(new 
                 InputStreamReader(proc.getErrorStream()));

            // Read the output from the command
            System.out.println("Here is the standard output of the command:\n");
            String s = null;
            
            
            ArrayList<String> resultados = new ArrayList<>();
            String resultado = "";
            
            while ((s = stdInput.readLine()) != null) {
                System.out.println(s);
                resultados.add(s);
                // resultado = resultado + "\n" + s;
            }
            
            // Read any errors from the attempted command
            while ((s = stdError.readLine()) != null) {
                System.out.println(s);
                resultado = resultado + s + "\n";
            }
            
            jTextErrores.setText(resultado);
            
            DefaultCaret caret = (DefaultCaret)jTextLexico.getCaret();
            caret.setUpdatePolicy(DefaultCaret.NEVER_UPDATE);
            DefaultCaret caret2 = (DefaultCaret)jTextSintactico.getCaret();
            caret2.setUpdatePolicy(DefaultCaret.NEVER_UPDATE);
            DefaultCaret caret3 = (DefaultCaret)jTextSemantico.getCaret();
            caret3.setUpdatePolicy(DefaultCaret.NEVER_UPDATE);
            
            resultado = "";
            int i = 0;
            
            while (!resultados.get(i).equals("sintactico") && i < resultados.size()){
                resultado = resultado + "\n" + resultados.get(i);
                i++;
            }
            jTextLexico.setText(resultado);
            
            resultado = "";
            
            while (!resultados.get(i).equals("semantico") && i < resultados.size()){
                resultado = resultado + "\n" + resultados.get(i);
                i++;
            }
            jTextSintactico.setText(resultado);
            
            resultado = "";
            
            while (!resultados.get(i).equals("codigoIntermedio") && i < resultados.size()){
                resultado = resultado + "\n" + resultados.get(i);
                i++;
            }
            jTextSemantico.setText(resultado);
            
            resultado = "";
            
            while ( i < resultados.size()){
                resultado = resultado + "\n" + resultados.get(i);
                i++;
            }
            jTextCodigo.setText(resultado);
            
           
        } catch (Exception e) {
           /* Se lanza una excepción si no se encuentra en ejecutable o el fichero no es ejecutable. */
            System.out.println("Un errorsin " + e);
        }
    }//GEN-LAST:event_compilarActionPerformed

    /**
     * @param args the command line arguments
     */
    
    
    
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(Interface.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(Interface.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(Interface.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(Interface.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(() -> {
            try {
                UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
            } catch (ClassNotFoundException | InstantiationException | IllegalAccessException | UnsupportedLookAndFeelException ex) {
                Logger.getLogger(Interface.class.getName()).log(Level.SEVERE, null, ex);
            }
            
            new Interface().setVisible(true);
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JMenuItem Copiar;
    private javax.swing.JMenuItem Pegar;
    private javax.swing.JMenuItem compilar;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JMenu jMEditar;
    private javax.swing.JMenuItem jMIAbrir;
    private javax.swing.JMenuItem jMIGuardar;
    private javax.swing.JMenuItem jMIGuardarC;
    private javax.swing.JMenuItem jMINuevo;
    private javax.swing.JMenu jMenu1;
    private javax.swing.JMenu jMenu10;
    private javax.swing.JMenu jMenu11;
    private javax.swing.JMenu jMenu12;
    private javax.swing.JMenu jMenu13;
    private javax.swing.JMenu jMenu14;
    private javax.swing.JMenu jMenu15;
    private javax.swing.JMenu jMenu16;
    private javax.swing.JMenu jMenu3;
    private javax.swing.JMenu jMenu4;
    private javax.swing.JMenu jMenu5;
    private javax.swing.JMenu jMenu6;
    private javax.swing.JMenu jMenu7;
    private javax.swing.JMenu jMenu8;
    private javax.swing.JMenu jMenu9;
    private javax.swing.JMenuBar jMenuBar1;
    private javax.swing.JMenuBar jMenuBar2;
    private javax.swing.JMenuBar jMenuBar3;
    private javax.swing.JMenuBar jMenuBar4;
    private javax.swing.JMenuBar jMenuBar5;
    private javax.swing.JMenuBar jMenuBar6;
    private javax.swing.JMenuItem jMenuItem1;
    private javax.swing.JMenuItem jMenuItem2;
    private javax.swing.JMenuItem jMenuItem3;
    private javax.swing.JMenuItem jMenuItem4;
    private javax.swing.JMenuItem jMenuItem5;
    private javax.swing.JPanel jPanel1;
    private javax.swing.JPanel jPanel2;
    private javax.swing.JPopupMenu jPopupMenu1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JScrollPane jScrollPane4;
    private javax.swing.JScrollPane jScrollPane5;
    private javax.swing.JScrollPane jScrollPane6;
    private javax.swing.JTabbedPane jTabbedPane2;
    private javax.swing.JTabbedPane jTabbedPane3;
    private javax.swing.JTextPane jTextCodigo;
    private javax.swing.JTextPane jTextErrores;
    private javax.swing.JTextPane jTextLexico;
    private javax.swing.JTextPane jTextSemantico;
    private javax.swing.JTextPane jTextSintactico;
    private javax.swing.JToolBar jToolBar2;
    private javax.swing.JToolBar jToolBar3;
    private javax.swing.JToolBar jToolBar4;
    private javax.swing.JToolBar jToolBar5;
    private javax.swing.JToolBar jToolBar6;
    private javax.swing.JToolBar jToolBar7;
    private javax.swing.JToolBar jToolBar8;
    private javax.swing.JTextPane jTxtCodigo;
    private javax.swing.JLabel lblCodigoIntermedio;
    private javax.swing.JMenuItem setTemaClaro;
    private javax.swing.JMenuItem setTemaOscuro;
    // End of variables declaration//GEN-END:variables
}
