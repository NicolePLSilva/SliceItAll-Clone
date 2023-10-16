# SliceItAll-Clone
Comecei pelo state machine da faca, a ideia é que ela tivesse os estados girando no ar, fincada na plataforma e knockback .
Depois tentei fazer a movimentação da faca, esta parte me demandou muito tempo pois testei várias abordagens diferentes para tentar chegar em um resultado parecido com o do jogo original; no final optei por usar AddForce para deslocar a faca nos eixos vertical e horizontal e AddRelativeTorque para adicionar torque de giro e usei uma corrotina para desabilitar a gravidade por um breve período de tempo.
Depois comecei a tentar implementar a feature de fincar a faca na plataforma, usei duas box colliders como triggers, ao entrar no estado KnifeStuckState, o atributo isKinematic do rigidbody é marcado com true parando a movimentação da faca até que seja detectado aperto de botão fazendo com que a faca volte ao estado em que ela gira no ar;
O próximo passo que tomei foi tentar implementar a funcionalidade de cortar os objetos, de início pensei em fazer um objeto "inteiro" que ao ser atingido pela faca seria destruido e substituído por um objeto já dividido, porém jogando o jogo original notei que os cortes nem sempre era no meio dos objetos, então comecei a estudar como fazer esse corte na malha do objeto o que me fez demorar muito nesta parte já que tem muitos processos, acabei desistindo da ideia e voltando para a abordagem inicial; 
-Adicionar: corte de mesh, IgnoreCollision com plataforma ao girar, sistema de pontos, ui, aceleração para baixo ao corta objetos...

Update: movimentação da faca ajustada, gerenciamento de level adicionado, object pool... 
