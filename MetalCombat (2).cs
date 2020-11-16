public class SnesRom
{
	public void L008C3B()
	{
		I = 1;
		C = 0;
		temp = C; C = E; E = temp;
		return this.L808C42();
	}

	public void L7D00BC()
	{
		Cpu.Break();
	}

	public void L808202()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x30;
		A = 0x01;
		[0x014B] = A;
	}

	public void L80820D()
	{
		A = [0x014B];
		
		if (Z == 0)
			return this.L80820D();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808215()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A |= 0x80;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808229()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0x7F;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80823D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A |= 0x80;
		[0x0100] = A;
		this.L808202();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808252()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A &= 0x7F;
		[0x0100] = A;
		this.L808202();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80827B()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0xEF;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8082A3()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x013C];
		A &= 0xDF;
		[0x4200] = A;
		[0x013C] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808306()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0154];
		
		if (Z == 1)
			return this.L808345();

		[0x0154] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		P &= ~0x30;
		[0x0152] = 0;
		Y = 0x0000;
		temp = Y - 0x0100;
		
		if (C == 0)
			return this.L808329();

	}

	public void L808327()
	{
		return this.L808327();
	}

	public void L808329()
	{
		A = [0x0155 + Y];
		A &= 0x00FF;
		temp = A - 0x0005;
		
		if (C == 0)
			return this.L808336();

	}

	public void L808334()
	{
		return this.L808334();
	}

	public void L808336()
	{
		A <<= 1;
		X = A;
		return [(0x833B + X)]();
	}

	public void L808345()
	{
		P |= 0x20;
		[0x0155] = 0;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80850F()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
	}

	public void L808515()
	{
		[0x7E0000 + X] = A;
		X++;
		X++;
		Y--;
		Y--;
		
		if (Z == 0)
			return this.L808515();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8085A5()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		Stack.Push(X);
		Stack.Push(Y);
		Stack.Push(A);
		Stack.Push(P);
		P &= ~0x20;
		P |= 0x10;
		X = [0x26];
		[0x4202] = X;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		Cpu.NOP();
		A = [0x4216];
		[0x2A] = A;
		X = [0x27];
		[0x4202] = X;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		Cpu.NOP();
		X = [0x4216];
		[0x2C] = X;
		Y = [0x4217];
		X = [0x27];
		[0x4202] = X;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		A = [0x2B];
		C = 0;
		A += [0x4216] + C;
		[0x2B] = A;
		
		if (C == 0)
			return this.L8085EE();

		Y++;
	}

	public void L8085EE()
	{
		X = [0x26];
		[0x4202] = X;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		Cpu.NOP();
		A = [0x2B];
		C = 0;
		A += [0x4216] + C;
		[0x2B] = A;
		
		if (C == 0)
			return this.L808605();

		Y++;
	}

	public void L808605()
	{
		[0x2D] = Y;
		P = Stack.Pop();
		A = Stack.Pop();
		Y = Stack.Pop();
		X = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L80860D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x2E] = 0;
		[0x30] = 0;
		[0x32] = 0;
		[0x34] = 0;
		P |= 0x10;
		X = [0x2A];
		this.L80863D();
		this.L80869C();
		X = [0x2B];
		this.L80863D();
		this.L80869C();
		X = [0x2C];
		this.L80863D();
		this.L80869C();
		X = [0x2D];
		this.L80863D();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80863D()
	{
		[0x4202] = X;
		C = 0;
		X = [0x26];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x31];
		A += [0x4216] + C;
		[0x31] = A;
		A = [0x33];
		A += 0x0000 + C;
		[0x33] = A;
		P |= 0x20;
		A = [0x35];
		A += 0x00 + C;
		[0x35] = A;
		P &= ~0x20;
		X = [0x27];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x32];
		A += [0x4216] + C;
		[0x32] = A;
		A = [0x34];
		A += 0x0000 + C;
		[0x34] = A;
		X = [0x28];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x33];
		A += [0x4216] + C;
		[0x33] = A;
		P |= 0x20;
		A = [0x35];
		A += 0x00 + C;
		[0x35] = A;
		P &= ~0x20;
		X = [0x29];
		[0x4203] = X;
		Cpu.NOP();
		C = 0;
		A = [0x34];
		A += [0x4216] + C;
		[0x34] = A;
		return;
	}

	public void L80869C()
	{
		A = [0x2F];
		[0x2E] = A;
		A = [0x31];
		[0x30] = A;
		A = [0x33];
		[0x32] = A;
		X = [0x35];
		[0x34] = X;
		X = 0x00;
		[0x35] = X;
		return;
	}

	public void L8086B1()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x26] = 0;
		A = [0x2E];
		
		if (Z == 0)
			return this.L8086C1();

		[0x2C] = 0;
		return this.L8086D9();
	}

	public void L8086C1()
	{
		X = 0x0011;
		C = 0;
	}

	public void L8086C5()
	{
		Cpu.ROL(0x2C);
		X--;
		
		if (Z == 1)
			return this.L8086D9();

		Cpu.ROL(0x26);
		A = [0x26];
		
		if (Z == 1)
			return this.L8086C5();

		C = 1;
		A -= [0x2E] - !C;
		
		if (C == 0)
			return this.L8086C5();

		[0x26] = A;
		return this.L8086C5();
	}

	public void L8086D9()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8086DC()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x28] = 0;
		[0x26] = 0;
		A = [0x30];
		A |= [0x2E];
		
		if (Z == 0)
			return this.L8086F2();

		[0x2C] = 0;
		[0x2A] = 0;
		return this.L808719();
	}

	public void L8086F2()
	{
		X = 0x0021;
		C = 0;
		return this.L808712();
	}

	public void L8086F8()
	{
		Cpu.ROL(0x26);
		Cpu.ROL(0x28);
		
		if (Z == 0)
			return this.L808702();

		A = [0x26];
		
		if (Z == 1)
			return this.L808712();

	}

	public void L808702()
	{
		C = 1;
		A = [0x26];
		A -= [0x2E] - !C;
		Y = A;
		A = [0x28];
		A -= [0x30] - !C;
		
		if (C == 0)
			return this.L808712();

		[0x28] = A;
		[0x26] = Y;
	}

	public void L808712()
	{
		Cpu.ROL(0x2A);
		Cpu.ROL(0x2C);
		X--;
		
		if (Z == 0)
			return this.L8086F8();

	}

	public void L808719()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808744()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x875B;
		[0x00] = A;
		this.L8087A4();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808764()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x877B;
		[0x00] = A;
		this.L8087A4();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808784()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0x879B;
		[0x00] = A;
		this.L8087A4();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8087A4()
	{
		Stack.Push(P);
		P &= ~0x30;
		X = [0x0152];
		Y = 0x0000;
		P |= 0x20;
		A = [[0x00] + Y];
		Y++;
		[0x0155 + X] = A;
		A--;
		
		if (Z == 0)
			return this.L8087BB();

		return this.L808822();
	}

	public void L8087BB()
	{
		A--;
		
		if (Z == 0)
			return this.L8087C1();

		return this.L8087CD();
	}

	public void L8087C1()
	{
		A--;
		
		if (Z == 0)
			return this.L8087C7();

		return this.L8087CD();
	}

	public void L8087C7()
	{
		A--;
		
		if (Z == 0)
			return this.L8087CD();

		return this.L8087F3();
	}

	public void L8087CD()
	{
		[0x015E + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		A = X;
		C = 0;
		A += 0x0009 + C;
		return this.L80883F();
	}

	public void L8087F3()
	{
		[0x0160 + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015C + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015E + X] = A;
		Y++;
		Y++;
		A = X;
		C = 0;
		A += 0x000B + C;
		return this.L80883F();
	}

	public void L808822()
	{
		[0x015C + X] = 0;
		P &= ~0x20;
		A = [[0x00] + Y];
		[0x0156 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x0158 + X] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		[0x015A + X] = A;
		A = X;
		C = 0;
		A += 0x0007 + C;
	}

	public void L80883F()
	{
		[0x0152] = A;
		P |= 0x30;
		A = 0x01;
		[0x0154] = A;
		A = [0x02D6];
		
		if (N == 0)
			return this.L808852();

		this.L808306();
	}

	public void L808852()
	{
		P = Stack.Pop();
		return;
	}

	public void L808888()
	{
		Stack.Push(P);
		Stack.Push(B);
		P |= 0x20;
		P &= ~0x10;
		A = [0x40];
		Stack.Push(A);
		B = Stack.Pop();
		[0x47] = 0;
		Y = 0x0000;
	}

	public void L808897()
	{
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L8088A3();

		this.L8089D5();
	}

	public void L8088A3()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x41] = A;
		temp = A - 0xFF;
		
		if (Z == 0)
			return this.L8088AF();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8088AF()
	{
		A &= 0xE0;
		temp = A - 0xE0;
		
		if (Z == 0)
			return this.L8088D3();

		A = [0x41];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A &= 0xE0;
		Stack.Push(A);
		A = [0x41];
		A &= 0x03;
		A = (A >> 4) | (A << 4);
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L8088CE();

		this.L8089D5();
	}

	public void L8088CE()
	{
		[0x3E] = X;
		X = Stack.Pop();
		return this.L8088DB();
	}

	public void L8088D3()
	{
		Stack.Push(A);
		A = 0x00;
		A = (A >> 4) | (A << 4);
		A = [0x41];
		A &= 0x1F;
	}

	public void L8088DB()
	{
		X = A;
		X++;
		A = Stack.Pop();
		temp = A - 0x00;
		
		if (N == 0)
			return this.L8088E5();

		return this.L80896E();
	}

	public void L8088E5()
	{
		temp = A - 0x20;
		
		if (Z == 1)
			return this.L808908();

		temp = A - 0x40;
		
		if (Z == 1)
			return this.L808920();

		temp = A - 0x60;
		
		if (Z == 1)
			return this.L808955();

	}

	public void L8088F1()
	{
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L8088FD();

		this.L8089D5();
	}

	public void L8088FD()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[[0x43] + Y] = A;
		Y++;
		X--;
		
		if (Z == 0)
			return this.L8088F1();

		
		if (Z == 1)
			return this.L808897();

	}

	public void L808908()
	{
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L808914();

		this.L8089D5();
	}

	public void L808914()
	{
		[0x3E] = X;
		X = Stack.Pop();
	}

	public void L808917()
	{
		[[0x43] + Y] = A;
		Y++;
		X--;
		
		if (Z == 0)
			return this.L808917();

		return this.L808897();
	}

	public void L808920()
	{
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L80892C();

		this.L8089D5();
	}

	public void L80892C()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x41] = A;
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L80893D();

		this.L8089D5();
	}

	public void L80893D()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x42] = A;
	}

	public void L808942()
	{
		A = [0x41];
		[[0x43] + Y] = A;
		Y++;
		X--;
		
		if (Z == 1)
			return this.L808952();

		A = [0x42];
		[[0x43] + Y] = A;
		Y++;
		X--;
		
		if (Z == 0)
			return this.L808942();

	}

	public void L808952()
	{
		return this.L808897();
	}

	public void L808955()
	{
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L808961();

		this.L8089D5();
	}

	public void L808961()
	{
		[0x3E] = X;
		X = Stack.Pop();
	}

	public void L808964()
	{
		[[0x43] + Y] = A;
		A++;
		Y++;
		X--;
		
		if (Z == 0)
			return this.L808964();

		return this.L808897();
	}

	public void L80896E()
	{
		temp = A - 0xC0;
		
		if (C == 1)
			return this.L8089B4();

		A &= 0x20;
		[0x46] = A;
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L808982();

		this.L8089D5();
	}

	public void L808982()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x41] = A;
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L808993();

		this.L8089D5();
	}

	public void L808993()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x42] = A;
	}

	public void L808998()
	{
		P |= 0x20;
	}

	public void L80899A()
	{
		Stack.Push(X);
		Stack.Push(Y);
		Y = [0x41];
		A = [[0x43] + Y];
		Y++;
		[0x41] = Y;
		Y = Stack.Pop();
		X = [0x46];
		
		if (Z == 1)
			return this.L8089AA();

		A ^= 0xFF;
	}

	public void L8089AA()
	{
		[[0x43] + Y] = A;
		Y++;
		X = Stack.Pop();
		X--;
		
		if (Z == 0)
			return this.L80899A();

		return this.L808897();
	}

	public void L8089B4()
	{
		A &= 0x20;
		[0x46] = A;
		Stack.Push(X);
		X = [0x3E];
		A = [0x0000 + X];
		X++;
		
		if (Z == 0)
			return this.L8089C4();

		this.L8089D5();
	}

	public void L8089C4()
	{
		[0x3E] = X;
		X = Stack.Pop();
		[0x41] = A;
		[0x42] = 0;
		P &= ~0x20;
		A = Y;
		C = 1;
		A -= [0x41] - !C;
		[0x41] = A;
		return this.L808998();
	}

	public void L8089D5()
	{
		X = 0x8000;
		Stack.Push(A);
		Stack.Push(B);
		A = Stack.Pop();
		A++;
		Stack.Push(A);
		B = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L808C42()
	{
		P |= 0x20;
		A = 0x80;
		[0x0100] = A;
		[0x2100] = A;
		A = 0x00;
		[0x7FF7] = A;
		P |= 0x30;
		[0x420B] = 0;
		[0x420C] = 0;
		[0x2140] = 0;
		[0x2141] = 0;
		[0x2142] = 0;
		[0x2143] = 0;
		P &= ~0x30;
		X = 0x1FFF;
		S = X;
		Y = 0x0000;
		Stack.Push(Y);
		D = Stack.Pop();
		Stack.Push(K);
		B = Stack.Pop();
		return this.L808EE3();
	}

	public void L808C76()
	{
		Stack.Push(P);
		P |= 0x30;
		A = 0x01;
		[0x4200] = A;
		[0x013C] = A;
		A = 0x80;
		[0x4201] = A;
		[0x4202] = 0;
		[0x4203] = 0;
		[0x4204] = 0;
		[0x4205] = 0;
		[0x4206] = 0;
		[0x4207] = 0;
		[0x013F] = 0;
		[0x4208] = 0;
		[0x0140] = 0;
		[0x4209] = 0;
		[0x013D] = 0;
		[0x420A] = 0;
		[0x013E] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		[0x0141] = 0;
		A = 0x01;
		[0x420D] = A;
		[0x0142] = A;
		P = Stack.Pop();
		return;
	}

	public void L808CC0()
	{
		Stack.Push(P);
		P |= 0x30;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		A = 0x01;
		[0x2101] = A;
		[0x0101] = A;
		[0x2102] = 0;
		[0x0102] = 0;
		A = 0x80;
		[0x2103] = A;
		[0x0103] = A;
		[0x2104] = 0;
		[0x2104] = 0;
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;
		[0x2106] = 0;
		[0x0105] = 0;
		A = 0x00;
		[0x2107] = A;
		[0x0106] = A;
		A = 0x08;
		[0x2108] = A;
		[0x0107] = A;
		A = 0x1C;
		[0x2109] = A;
		[0x0108] = A;
		A = 0x00;
		[0x210A] = 0;
		[0x0109] = 0;
		A = 0x06;
		[0x210B] = A;
		[0x010A] = A;
		A = 0x01;
		[0x210C] = A;
		[0x010B] = A;
		[0x210D] = 0;
		[0x210D] = 0;
		[0x210E] = 0;
		[0x210E] = 0;
		[0x210F] = 0;
		[0x210F] = 0;
		[0x2110] = 0;
		[0x2110] = 0;
		[0x2111] = 0;
		[0x2111] = 0;
		[0x2112] = 0;
		[0x2112] = 0;
		[0x2113] = 0;
		[0x2113] = 0;
		[0x2114] = 0;
		[0x2114] = 0;
		[0x2115] = 0;
		[0x211A] = 0;
		[0x010C] = 0;
		[0x211B] = 0;
		[0x211C] = 0;
		[0x211D] = 0;
		[0x211E] = 0;
		[0x211F] = 0;
		[0x2120] = 0;
		A = 0x00;
		[0x2123] = A;
		[0x010D] = A;
		A = 0x00;
		[0x2124] = A;
		[0x010E] = A;
		[0x2125] = 0;
		[0x011F] = 0;
		A = 0x00;
		[0x2126] = A;
		[0x0120] = A;
		A = 0xF8;
		[0x2127] = A;
		[0x0121] = A;
		[0x2128] = 0;
		[0x0122] = 0;
		[0x2129] = 0;
		[0x0123] = 0;
		[0x212A] = 0;
		[0x0124] = 0;
		[0x212B] = 0;
		[0x0125] = 0;
		A = 0x11;
		[0x212C] = A;
		[0x0126] = A;
		[0x212E] = A;
		[0x0128] = A;
		A = 0x02;
		[0x212D] = A;
		[0x0127] = A;
		[0x212F] = A;
		[0x0129] = A;
		A = 0x02;
		[0x2130] = A;
		[0x012A] = A;
		A = 0xA1;
		[0x2131] = A;
		[0x012B] = A;
		A = 0x20;
		[0x2132] = A;
		[0x012E] = A;
		A = 0x40;
		[0x2132] = A;
		[0x012D] = A;
		A = 0x80;
		[0x2132] = A;
		[0x012C] = A;
		A = 0x00;
		[0x2133] = A;
		[0x012F] = A;
		P = Stack.Pop();
		return;
	}

	public void L808E19()
	{
		P &= ~0x30;
		A = 0x1C2F;
		this.L808E3F();
		A = 0x1C2F;
		this.L808E52();
		A = 0x1C2F;
		this.L808E65();
		P |= 0x30;
		this.L808744();
		this.L808764();
		this.L808784();
		return;
	}

	public void L808E3F()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2000;
		Y = 0x0800;
		this.L80850F();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808E52()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2800;
		Y = 0x0800;
		this.L80850F();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808E65()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x3000;
		Y = 0x0800;
		this.L80850F();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L808E78()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.L808EA7();
		A = [0x0255];
		temp = A - 0x0005;
		
		if (C == 0)
			return this.L808E8E();

		A = 0x0001;
		[0x0257] = A;
		return this.L808E91();
	}

	public void L808E8E()
	{
		[0x0257] = 0;
	}

	public void L808E91()
	{
		A = [0x0259];
		C = 0;
		A += [0x025D] + C;
		[0x0261] = A;
		A = [0x025B];
		C = 0;
		A += [0x025F] + C;
		[0x0263] = A;
		P = Stack.Pop();
		return;
	}

	public void L808EA7()
	{
		Stack.Push(P);
		P |= 0x20;
		A = [0x213F];
		temp = A & 0x40;
		
		if (Z == 1)
			return this.L808ED9();

		A = [0x00213C];
		[0x0259] = A;
		A = [0x00213C];
		A &= 0x01;
		[0x025A] = A;
		A = [0x00213D];
		[0x025B] = A;
		A = [0x00213D];
		A &= 0x01;
		[0x025C] = A;
		[0x0255] = 0;
	}

	public void L808ED4()
	{
		[0x0256] = 0;
		P = Stack.Pop();
		return;
	}

	public void L808ED9()
	{
		[0x0255]++;
		
		if (Z == 0)
			return this.L808ED4();

		[0x0255]--;
		return this.L808ED4();
	}

	public void L808EE3()
	{
		P |= 0x30;
		A = 0xA1;
		[0x7FF5] = A;
		A = 0x0A;
		[0x7FF7] = A;
		P &= ~0x30;
		X = 0x01FE;
	}

	public void L808EF4()
	{
		[0x00 + X] = 0;
		[0x0200 + X] = 0;
		[0x0400 + X] = 0;
		[0x0600 + X] = 0;
		[0x0800 + X] = 0;
		[0x0A00 + X] = 0;
		[0x0C00 + X] = 0;
		[0x0E00 + X] = 0;
		[0x1000 + X] = 0;
		[0x1200 + X] = 0;
		[0x1400 + X] = 0;
		[0x1600 + X] = 0;
		[0x1800 + X] = 0;
		[0x1A00 + X] = 0;
		[0x1C00 + X] = 0;
		[0x1E00 + X] = 0;
		X--;
		X--;
		
		if (N == 0)
			return this.L808EF4();

		return this.L808F49();
	}

	public void L808F49()
	{
		P |= 0x30;
		[0x4200] = 0;
		[0x013C] = 0;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		this.L808C76();
		this.L808CC0();
		this.L808E19();
		this.L809D46();
		this.L809BAB();
		this.L808215();
		P |= 0x20;
		A = 0x54;
		[0x36] = A;
		[0x37] = 0;
		[0x38] = 0;
		A = 0x6B;
		[0x39] = A;
		A = 0x44;
		[0x3A] = A;
		[0x3B] = 0;
		[0x3C] = 0;
		A = 0x6B;
		[0x3D] = A;
		A = 0x01;
		[0x4B] = A;
		P &= ~0x30;
		this.L8CC0E8();
		this.L808252();
		P &= ~0x30;
		this.L80942D();
		P &= ~0x30;
		Y = 0x003C;
	}

	public void L808FA1()
	{
		this.L808202();
		Y--;
		
		if (Z == 0)
			return this.L808FA1();

		P |= 0x30;
		A = 0x7E;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FB6()
	{
		[0x2000 + X] = A;
		[0x3000 + X] = A;
		[0x4000 + X] = A;
		[0x5000 + X] = A;
		[0x6000 + X] = A;
		[0x7000 + X] = A;
		[0x8000 + X] = A;
		[0x9000 + X] = A;
		[0xA000 + X] = A;
		[0xB000 + X] = A;
		[0xC000 + X] = A;
		[0xD000 + X] = A;
		[0xE000 + X] = A;
		[0xF000 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L808FB6();

		P |= 0x30;
		A = 0x7F;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FF2()
	{
		[0x0000 + X] = A;
		[0x1000 + X] = A;
		[0x2000 + X] = A;
		[0x3000 + X] = A;
		[0x4000 + X] = A;
		[0x5000 + X] = A;
		[0x6000 + X] = A;
		[0x7000 + X] = A;
		[0x8000 + X] = A;
		[0x9000 + X] = A;
		[0xA000 + X] = A;
		[0xB000 + X] = A;
		[0xC000 + X] = A;
		[0xD000 + X] = A;
		[0xE000 + X] = A;
		[0xF000 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L808FF2();

		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x0F;
		[0x0100] = A;
	}

	public void L80902F()
	{
		this.L808202();
		[0x0100]--;
		
		if (Z == 0)
			return this.L80902F();

		P &= ~0x20;
		this.L80823D();
		A = 0x8000;
		[0x01] = A;
		A = 0x904E;
		[0x00] = A;
		this.L8087A4();
		return this.L809059();
	}

	public void L809059()
	{
		A = 0x8000;
		[0x01] = A;
		A = 0x9069;
		[0x00] = A;
		this.L8087A4();
		return this.L809074();
	}

	public void L809074()
	{
		return this.L809078();
	}

	public void L809078()
	{
		P &= ~0x30;
		[0x026D] = 0;
		[0x0265] = 0;
		[0x0267] = 0;
		this.L809559();
		this.L808202();
	}

	public void L80908B()
	{
		P &= ~0x30;
		this.L8090A1();
		this.L808E78();
		this.L8090CD();
		this.L8090B8();
		this.L808202();
		return this.L80908B();
	}

	public void L8090A1()
	{
		this.L809570();
		this.L809A94();
		this.L809B30();
		this.L809FDF();
		P &= ~0x30;
		this.L809D46();
		return;
	}

	public void L8090B8()
	{
		this.L809BAB();
		this.L80A005();
		P &= ~0x30;
		A = [0x5A];
		[0x0265] = A;
		A = [0x52];
		[0x0267] = A;
		return;
	}

	public void L8090CD()
	{
		P &= ~0x30;
		Stack.Push(B);
		A = [0x026D];
		A <<= 1;
		A += [0x026D] + C;
		X = A;
		P |= 0x20;
		A = [0x809107 + X];
		temp = A - 0x7D;
		
		if (Z == 1)
			return this.L8090F6();

		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0x809105 + X];
		[0x00] = A;
		this.L809102();
	}

	public void L8090F2()
	{
		P &= ~0x30;
		B = Stack.Pop();
		return;
	}

	public void L8090F6()
	{
		P &= ~0x20;
		A = [0x809105 + X];
		[0x026D] = A;
		return this.L8090F2();
	}

	public void L809102()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L80942D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x0001;
		[0x0322] = A;
		Stack.Push(X);
		Stack.Push(Y);
		A = [0x00];
		Stack.Push(A);
		A = [0x01];
		Stack.Push(A);
		A = 0xB900;
		[0x01] = A;
		Y = 0x8000;
		[0x00] = 0;
		this.L8098E6();
		P |= 0x30;
		A = 0xFE;
	}

	public void L809452()
	{
		[0x2142] = A;
		temp = A - [0x2142];
		
		if (Z == 0)
			return this.L809452();

		P &= ~0x30;
		X = 0x005E;
	}

	public void L80945F()
	{
		[0x02D7 + X] = 0;
		X--;
		X--;
		
		if (N == 1)
			return this.L809468();

		return this.L80945F();
	}

	public void L809468()
	{
		P &= ~0x30;
		A = Stack.Pop();
		[0x01] = A;
		A = Stack.Pop();
		[0x00] = A;
		Y = Stack.Pop();
		X = Stack.Pop();
		A = 0x0000;
		[0x0322] = A;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L809492()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A = [0x02F7];
		A &= 0x0001;
		
		if (Z == 0)
			return this.L8094B6();

		Stack.Push(X);
		X = 0x0000;
	}

	public void L8094A6()
	{
		A = [0x02D7 + X];
		
		if (Z == 1)
			return this.L8094B2();

		X++;
		X++;
		temp = X - 0x0006;
		
		if (Z == 0)
			return this.L8094A6();

	}

	public void L8094B2()
	{
		A = Stack.Pop();
		[0x02D7 + X] = A;
	}

	public void L8094B6()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8094BA()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A = [0x02F7];
		A &= 0x0001;
		
		if (Z == 0)
			return this.L8094DE();

		Stack.Push(X);
		X = 0x0000;
	}

	public void L8094CE()
	{
		A = [0x02DF + X];
		
		if (Z == 1)
			return this.L8094DA();

		X++;
		X++;
		temp = X - 0x0006;
		
		if (Z == 0)
			return this.L8094CE();

	}

	public void L8094DA()
	{
		A = Stack.Pop();
		[0x02DF + X] = A;
	}

	public void L8094DE()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8094E2()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		temp = A - 0x00F0;
		
		if (C == 1)
			return this.L809541();

		temp = A - 0x0000;
		
		if (Z == 1)
			return this.L809555();

		Stack.Push(Y);
		X = [0x00];
		Stack.Push(X);
		X = [0x01];
		Stack.Push(X);
		X = A;
		A = [0x030B];
		
		if (Z == 0)
			return this.L80950E();

		this.L808229();
		this.L8097B2();
		this.L808215();
		P &= ~0x30;
	}

	public void L80950E()
	{
		X = Stack.Pop();
		[0x01] = X;
		X = Stack.Pop();
		[0x00] = X;
		Y = Stack.Pop();
		return this.L809555();
	}

	public void L809517()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		A &= 0x00FF;
		temp = A - 0x00F0;
		
		if (C == 1)
			return this.L809555();

		temp = A - 0x00E0;
		
		if (C == 0)
			return this.L809555();

		temp = A - 0x00E5;
		
		if (C == 0)
			return this.L809534();

		[0x02F9] = X;
	}

	public void L809534()
	{
		A = [0x030B];
		
		if (Z == 0)
			return this.L809555();

		A = [0x02F7];
		A &= 0x0002;
		
		if (Z == 0)
			return this.L809555();

	}

	public void L809541()
	{
		Stack.Push(X);
		X = 0x0000;
	}

	public void L809545()
	{
		A = [0x02D7 + X];
		
		if (Z == 1)
			return this.L809551();

		X++;
		X++;
		temp = X - 0x0006;
		
		if (Z == 0)
			return this.L809545();

	}

	public void L809551()
	{
		A = Stack.Pop();
		[0x02D7 + X] = A;
	}

	public void L809555()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L809559()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x20;
		Stack.Push(A);
		A = 0xFFFF;
		[0x02EB] = A;
		[0x02EF] = A;
		[0x02F3] = A;
		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L809570()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(A);
		Stack.Push(X);
		Stack.Push(Y);
		A = 0xBA00;
		[0x01] = A;
		A = 0x80C0;
		[0x00] = A;
		X = 0x0000;
	}

	public void L809586()
	{
		A = [0x02EB + X];
		
		if (N == 0)
			return this.L8095A2();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L8095AA();

		Stack.Push(A);
		A = Stack.Pop();
		A &= 0x00FF;
		A <<= 1;
		Y = X;
		X = A;
		A = [0xBA80C0 + X];
		[0x02EB + Y] = A;
		X = Y;
		return this.L8095A7();
	}

	public void L8095A2()
	{
		[0x02ED + X]--;
		
		if (Z == 0)
			return this.L8095AA();

	}

	public void L8095A7()
	{
		this.L8095BB();
	}

	public void L8095AA()
	{
		temp = X - 0x0005;
		
		if (C == 1)
			return this.L8095B5();

		X++;
		X++;
		X++;
		X++;
		return this.L809586();
	}

	public void L8095B5()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8095BB()
	{
		Stack.Push(X);
		A = [0x02EB + X];
		Y = A;
	}

	public void L8095C0()
	{
		this.L80968B();
		X = A;
		
		if (Z == 0)
			return this.L8095CB();

		A--;
		Y = A;
		return this.L809682();
	}

	public void L8095CB()
	{
		this.L80968B();
		temp = X - 0x2000;
		
		if (C == 0)
			return this.L80962F();

		temp = X - 0x3000;
		
		if (C == 0)
			return this.L809635();

		temp = X - 0x4000;
		
		if (C == 0)
			return this.L80963B();

		temp = X - 0x5000;
		
		if (C == 0)
			return this.L809641();

		temp = X - 0x6000;
		
		if (C == 0)
			return this.L809647();

		temp = X - 0x7000;
		
		if (C == 0)
			return this.L809625();

		temp = X - 0x8000;
		
		if (C == 0)
			return this.L809666();

		temp = X - 0x9000;
		
		if (C == 0)
			return this.L80961A();

		temp = X - 0xA000;
		
		if (C == 0)
			return this.L80960F();

		temp = X - 0xB000;
		
		if (C == 0)
			return this.L80964A();

		temp = X - 0xC000;
		
		if (C == 0)
			return this.L80964F();

		temp = X - 0xD000;
		
		if (C == 0)
			return this.L80965A();

		temp = X - 0xE000;
		
		if (C == 0)
			return this.L809660();

	}

	public void L80960F()
	{
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L809620();

		A = 0x8000;
		temp = A & [0x031A]; [0x031A] |= A;
	}

	public void L80961A()
	{
		A = [0x0318];
		this.L8096FB();
	}

	public void L809620()
	{
		A |= [0x031A];
		return this.L809635();
	}

	public void L809625()
	{
		A = [0x02F9];
		this.L809517();
		return this.L809679();
	}

	public void L80962F()
	{
		this.L809492();
		return this.L809679();
	}

	public void L809635()
	{
		this.L8094BA();
		return this.L809679();
	}

	public void L80963B()
	{
		this.L809517();
		return this.L809679();
	}

	public void L809641()
	{
		this.L8094E2();
		return this.L809679();
	}

	public void L809647()
	{
		Y = A;
		return this.L809679();
	}

	public void L80964A()
	{
		this.L809690();
		return this.L809679();
	}

	public void L80964F()
	{
		this.L809690();
		A = [0x030B];
		
		if (Z == 0)
			return this.L809672();

		return this.L8095C0();
	}

	public void L80965A()
	{
		this.L809711();
		return this.L8095C0();
	}

	public void L809660()
	{
		this.L809715();
		return this.L8095C0();
	}

	public void L809666()
	{
		A = X;
		A &= 0x00FF;
		A &= [0x02FB];
		
		if (Z == 0)
			return this.L809672();

		return this.L8095C0();
	}

	public void L809672()
	{
		Y--;
		Y--;
		Y--;
		Y--;
		X = 0x0001;
	}

	public void L809679()
	{
		A = X;
		A &= 0x0FFF;
		
		if (Z == 0)
			return this.L809682();

		return this.L8095C0();
	}

	public void L809682()
	{
		X = Stack.Pop();
		[0x02ED + X] = A;
		A = Y;
		[0x02EB + X] = A;
		return;
	}

	public void L80968B()
	{
		A = [[0x00] + Y];
		Y++;
		Y++;
		return;
	}

	public void L809690()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		Stack.Push(X);
		X = A;
		Stack.Push(Y);
		X = [0x00];
		Stack.Push(X);
		X = [0x01];
		Stack.Push(X);
		X = A;
		A = [0x030B];
		
		if (Z == 0)
			return this.L8096AB();

		A = 0x0001;
		[0x030B] = A;
	}

	public void L8096AB()
	{
		this.L8097B2();
		A = [0x02E7];
		[0x2140] = A;
		A = [0x02D7];
		[0x02E7] = A;
		A = [0x02D9];
		[0x02D7] = A;
		A = [0x02DB];
		[0x02D9] = A;
		A = [0x02DD];
		[0x02DB] = A;
		[0x02DD] = 0;
		A = [0x02E9];
		[0x2142] = A;
		A = [0x02DF];
		[0x02E9] = A;
		A = [0x02E1];
		[0x02DF] = A;
		A = [0x02E3];
		[0x02E1] = A;
		A = [0x02E5];
		[0x02E3] = A;
		[0x02E5] = 0;
		X = Stack.Pop();
		[0x01] = X;
		X = Stack.Pop();
		[0x00] = X;
		Y = Stack.Pop();
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8096FB()
	{
		A &= 0x00FF;
		[0x031C] = A;
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A >>= 1;
		A >>= 1;
		C = 1;
		A -= [0x031C] - !C;
		C = 0;
		A += 0x0100 + C;
		A &= 0x1F00;
		return;
	}

	public void L809711()
	{
		[0x0402] = A;
		return;
	}

	public void L809715()
	{
		temp = A - 0xFFF1;
		
		if (Z == 0)
			return this.L80971F();

		this.L80973C();
		return this.L80973B();
	}

	public void L80971F()
	{
		Stack.Push(A);
		A &= 0xFF00;
		
		if (Z == 0)
			return this.L809731();

		A = Stack.Pop();
		A &= 0x00FF;
		A ^= 0xFFFF;
		A &= [0x02F7];
		return this.L809738();
	}

	public void L809731()
	{
		A = Stack.Pop();
		A &= 0x00FF;
		A |= [0x02F7];
	}

	public void L809738()
	{
		[0x02F7] = A;
	}

	public void L80973B()
	{
		return;
	}

	public void L80973C()
	{
		Stack.Push(X);
		A = [0x036D];
		A &= 0x0003;
		[0x031C] = A;
		A = [0x0381];
		A &= 0x0001;
		
		if (Z == 1)
			return this.L80975A();

		A = 0x0010;
	}

	public void L809751()
	{
		C = 0;
		A += [0x031C] + C;
		[0x031C] = A;
		return this.L80976D();
	}

	public void L80975A()
	{
		A = 0x000E;
		[0x0367] = A;
		this.L94EB88();
		A = [0x2C];
		
		if (Z == 1)
			return this.L80976D();

		A = 0x0008;
		return this.L809751();
	}

	public void L80976D()
	{
		A = [0x150C];
		A &= 0x0010;
		
		if (Z == 1)
			return this.L80977F();

		A = 0x0004;
		C = 0;
		A += [0x031C] + C;
		[0x031C] = A;
	}

	public void L80977F()
	{
		A = [0x031C];
		temp = A - 0x0018;
		
		if (C == 0)
			return this.L80978A();

		A = 0x0000;
	}

	public void L80978A()
	{
		X = A;
		A = [0x80979A + X];
		A &= 0x00FF;
		A |= 0x8000;
		[0x02F3] = A;
		X = Stack.Pop();
		return;
	}

	public void L8097B2()
	{
		P &= ~0x30;
		[0x0303] = 0;
		A = [0x030B];
		
		if (Z == 1)
			return this.L809801();

		[0x0322] = A;
		Y = 0x0040;
		[0x0303] = Y;
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L8097D2();

		[0x030B]++;
		A = 0x00FC;
		return this.L809804();
	}

	public void L8097D2()
	{
		A = [0x030D];
		Y = 0x1234;
	}

	public void L8097D8()
	{
		temp = Y - [0x2140];
		
		if (Z == 0)
			return this.L8097D8();

		[0x2140] = A;
		Y = 0x007F;
		[0x2142] = Y;
	}

	public void L8097E6()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L8097E6();

		A = [0x030F];
		[0x00] = A;
		A = [0x0310];
		[0x01] = A;
		A = 0x007F;
		X = [0x0307];
		Y = [0x0309];
		return this.L80988B();
	}

	public void L809801()
	{
		A = 0x00FE;
	}

	public void L809804()
	{
		[0x2140] = A;
		[0x2142] = 0;
		A = X;
		A--;
		A <<= 1;
		X = A;
		A = [0xBA8010 + X];
		[0x02FD] = A;
		X = 0x0000;
		return this.L809898();
	}

	public void L80981B()
	{
		[0x2142] = X;
		X = A;
		A = [0xBA8201 + X];
		C = 0;
		A += 0xB900 + C;
		[0x01] = A;
		[0x00] = 0;
		A = [0xBA8203 + X];
		A++;
		A >>= 1;
		[0x02FF] = A;
		A = [0xBA8205 + X];
		Y = 0x1234;
	}

	public void L80983B()
	{
		temp = Y - [0x2140];
		
		if (Z == 0)
			return this.L80983B();

		[0x2140] = A;
		[0x030D] = A;
		Y = 0x007F;
		[0x2142] = Y;
	}

	public void L80984C()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L80984C();

		A = [0xBA8200 + X];
		Y = A;
		[0x0301] = 0;
		A = [[0x00] + Y];
		X = A;
		A = 0x007F;
	}

	public void L80985F()
	{
		temp = A - [0x2142];
		
		if (Z == 0)
			return this.L80985F();

		[0x2140] = X;
		A = [0x0301];
		[0x2142] = A;
		Y++;
		Y++;
		Stack.Push(A);
		A = [[0x00] + Y];
		X = A;
		[0x0301]++;
		A = 0xFF80;
		temp = A & [0x0301]; [0x0301] &= ~A;
		A = Stack.Pop();
		[0x030D]++;
		[0x030D]++;
		[0x0303]--;
		
		if (Z == 0)
			return this.L80988B();

		return this.L8098D1();
	}

	public void L80988B()
	{
		[0x02FF]--;
		
		if (Z == 0)
			return this.L80985F();

		X = 0x7FFF;
	}

	public void L809893()
	{
		temp = A - [0x2142];
		
		if (Z == 0)
			return this.L809893();

	}

	public void L809898()
	{
		Y = [0x02FD];
		A = 0xBA00;
		[0x01] = A;
		[0x00] = 0;
		A = [[0x00] + Y];
		
		if (Z == 1)
			return this.L8098AE();

		Y++;
		Y++;
		[0x02FD] = Y;
		return this.L80981B();
	}

	public void L8098AE()
	{
		[0x030B] = 0;
		[0x0305] = 0;
		A = 0x00FF;
	}

	public void L8098B7()
	{
		[0x2142] = A;
	}

	public void L8098BA()
	{
		A = [0x2140];
		
		if (Z == 0)
			return this.L8098BA();

		A = [0x2142];
		
		if (Z == 0)
			return this.L8098BA();

		[0x2142] = A;
		[0x2140] = A;
		A = 0x0000;
		[0x0322] = A;
		return;
	}

	public void L8098D1()
	{
		[0x0307] = X;
		[0x0309] = Y;
		A = [0x00];
		[0x030F] = A;
		A = [0x01];
		[0x0310] = A;
		A = 0xFFFF;
		return this.L8098B7();
	}

	public void L8098E6()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = 0xBBAA;
		return this.L8098F4();
	}

	public void L8098EE()
	{
		X = 0x00FD;
		[0x2140] = X;
	}

	public void L8098F4()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L8098EE();

		P |= 0x20;
		A = 0xCC;
		return this.L809925();
	}

	public void L8098FF()
	{
		A = [[0x00] + Y];
		Y++;
		A = (A >> 4) | (A << 4);
		A = 0x00;
		return this.L809912();
	}

	public void L809907()
	{
		A = (A >> 4) | (A << 4);
		A = [[0x00] + Y];
		Y++;
		A = (A >> 4) | (A << 4);
	}

	public void L80990C()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L80990C();

		A++;
	}

	public void L809912()
	{
		P &= ~0x20;
		[0x2140] = A;
		P |= 0x20;
		X--;
		
		if (Z == 0)
			return this.L809907();

	}

	public void L80991C()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L80991C();

	}

	public void L809921()
	{
		A += 0x03 + C;
		
		if (Z == 1)
			return this.L809921();

	}

	public void L809925()
	{
		Stack.Push(A);
		P &= ~0x20;
		A = [[0x00] + Y];
		Y++;
		Y++;
		X = A;
		A = [[0x00] + Y];
		Y++;
		Y++;
		[0x2142] = A;
		P |= 0x20;
		temp = X - 0x0001;
		A = 0x00;
		Cpu.ROL();
		[0x2141] = A;
		A += 0x7F + C;
		A = Stack.Pop();
		[0x2140] = A;
	}

	public void L809945()
	{
		temp = A - [0x2140];
		
		if (Z == 0)
			return this.L809945();

		
		if (V == 1)
			return this.L8098FF();

		P = Stack.Pop();
		return;
	}

	public void L809977()
	{
		temp = A - 0x0000;
		
		if (N == 1)
			return this.L80998C();

		temp = A - 0x0100;
		
		if (N == 0)
			return this.L809990();

		Stack.Push(X);
		X = A;
		A = [0x809993 + X];
		A &= 0x1F00;
		X = Stack.Pop();
		return;
	}

	public void L80998C()
	{
		A = 0x0100;
		return;
	}

	public void L809990()
	{
		A = 0x1F00;
		return;
	}

	public void L809A94()
	{
		Stack.Push(P);
		P |= 0x20;
		A = [0x030B];
		
		if (Z == 0)
			return this.L809ADF();

		A = [0x0100];
		temp = A & 0x80;
		
		if (Z == 0)
			return this.L809ADF();

		A ^= 0xFF;
		temp = A & 0x0F;
		
		if (Z == 0)
			return this.L809ADF();

		A = [0x026B];
		
		if (Z == 1)
			return this.L809ADF();

		A = [0x0269];
		A++;
		
		if (Z == 1)
			return this.L809ADF();

		A--;
		
		if (Z == 0)
			return this.L809AE1();

		A = [0x53];
		temp = A & 0x40;
		
		if (Z == 1)
			return this.L809ADF();

		A = [0x0266];
		temp = A & 0x80;
		
		if (Z == 1)
			return this.L809ADF();

		A = 0x3C;
		[0x0269] = A;
		A = [0x0268];
		A &= 0x7F;
		[0x0268] = A;
		A = [0x0266];
		A &= 0x7F;
		[0x0266] = A;
		A = [0x63];
		A &= 0x7F;
		[0x63] = A;
	}

	public void L809ADF()
	{
		P = Stack.Pop();
		return;
	}

	public void L809AE1()
	{
		[0x0269]--;
		A = [0x53];
		temp = A & 0x40;
		
		if (Z == 1)
			return this.L809AF5();

		A = [0x0266];
		temp = A & 0x80;
		
		if (Z == 1)
			return this.L809ADF();

		this.L809B58();
	}

	public void L809AF5()
	{
		A = [0x0266];
		temp = A & 0x90;
		
		if (Z == 1)
			return this.L809ADF();

		[0x0269] = 0;
		return this.L809ADF();
	}

	public void L809B30()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x030B];
		
		if (Z == 0)
			return this.L809B56();

		A = [0x50];
		temp = A - 0x4080;
		
		if (Z == 0)
			return this.L809B56();

		A = [0x58];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L809B56();

		[0x0255] = 0;
		[0x0257] = 0;
		A = 0x00FF;
		temp = A & [0x52]; [0x52] |= A;
		A = 0x8000;
		temp = A & [0x5A]; [0x5A] |= A;
	}

	public void L809B56()
	{
		P = Stack.Pop();
		return;
	}

	public void L809B58()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.L80823D();
		P |= 0x20;
		A = 0x81;
		[0x4200] = A;
		[0x013C] = A;
		P &= ~0x20;
		this.L80827B();
		this.L8082A3();
		P |= 0x20;
		[0x49] = 0;
		[0x4A] = 0;
		[0x0141] = 0;
		[0x0154] = 0;
		P &= ~0x20;
		[0x0152] = 0;
		this.L808202();
		[0x026B] = 0;
		[0x14CE] = 0;
		[0x14CC] = 0;
		A = 0x0002;
		[0x026D] = A;
		P = Stack.Pop();
		return;
	}

	public void L809BAB()
	{
		Stack.Push(P);
		P &= ~0x20;
		A = [0xA6];
		A >>= 1;
		[0x00] = A;
		A >>= 1;
		C = 0;
		A += [0x00] + C;
		C = 0;
		A += 0x9BC4 + C;
		[0x00] = A;
		P |= 0x20;
		A = 0xEF;
		return [(0x0000)]();
	}

	public void L809D46()
	{
		Stack.Push(P);
		P &= ~0x30;
		[0x7A00] = 0;
		[0x7A02] = 0;
		[0x7A04] = 0;
		[0x7A06] = 0;
		[0x7A08] = 0;
		[0x7A0A] = 0;
		[0x7A0C] = 0;
		[0x7A0E] = 0;
		[0x7A10] = 0;
		[0x7A12] = 0;
		[0x7A14] = 0;
		[0x7A16] = 0;
		[0x7A18] = 0;
		[0x7A1A] = 0;
		[0x7A1C] = 0;
		[0x7A1E] = 0;
		[0xA6] = 0;
		P = Stack.Pop();
		return;
	}

	public void L809D7D()
	{
		A = [0x28];
		A ^= [0x2C];
		Stack.Push(P);
		A = [0x28];
		
		if (N == 0)
			return this.L809D9B();

		C = 0;
		A = [0x26];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x26] = A;
		A = [0x28];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x28] = A;
	}

	public void L809D9B()
	{
		A = [0x2C];
		
		if (N == 0)
			return this.L809DB4();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809DB4()
	{
		this.L80860D();
		P = Stack.Pop();
		
		if (N == 0)
			return this.L809DE4();

		C = 0;
		A = [0x2E];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2E] = A;
		A = [0x30];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x30] = A;
		A = [0x32];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x32] = A;
		A = [0x34];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x34] = A;
	}

	public void L809DE4()
	{
		return;
	}

	public void L809DE5()
	{
		A = [0x2C];
		A ^= [0x30];
		Stack.Push(P);
		A = [0x2C];
		
		if (N == 0)
			return this.L809E03();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809E03()
	{
		A = [0x30];
		
		if (N == 0)
			return this.L809E1C();

		C = 0;
		A = [0x2E];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2E] = A;
		A = [0x30];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x30] = A;
	}

	public void L809E1C()
	{
		P |= 0x20;
		A = [0x2C];
		[0x2D] = A;
		A = [0x2B];
		[0x2C] = A;
		A = [0x2A];
		[0x2B] = A;
		A = 0x00;
		[0x2A] = A;
		P &= ~0x20;
		this.L8086DC();
		P |= 0x20;
		A = [0x2C];
		[0x2D] = A;
		A = [0x2B];
		[0x2C] = A;
		A = [0x2A];
		[0x2B] = A;
		A = 0x00;
		[0x2A] = A;
		P &= ~0x20;
		P = Stack.Pop();
		
		if (N == 0)
			return this.L809E60();

		C = 0;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x2A] = A;
		A = [0x2C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2C] = A;
	}

	public void L809E60()
	{
		return;
	}

	public void L809F0C()
	{
		P &= ~0x30;
		this.L80823D();
		this.L80A1E2();
		P &= ~0x30;
		[0x026D]++;
		return;
	}

	public void L809F1C()
	{
		this.L839443();
		A = 0x0000;
		[0x1B0F] = A;
		[0x035D] = 0;
		[0x026D]++;
		return;
	}

	public void L809F2D()
	{
		P &= ~0x30;
		this.L80823D();
		[0x026F] = 0;
		this.L80A237();
		P &= ~0x30;
		[0x026D]++;
		return;
	}

	public void L809F40()
	{
		A = 0x0001;
	}

	public void L809F43()
	{
		A--;
		
		if (Z == 0)
			return this.L809F43();

		this.L81865D();
		A = 0x0001;
		[0x14CE] = A;
		P &= ~0x30;
		A = 0x3C00;
		temp = A & [0xB8]; [0xB8] &= ~A;
		this.L80A1B7();
		this.L968269();
		this.L90825D();
		A = 0x0000;
		[0x1510] = A;
		this.L968278();
		this.L8CC0E4();
		this.L809F7A();
		this.L90828C();
		return;
	}

	public void L809F7A()
	{
		this.L81EB18();
		this.L81E7A7();
		this.L80D927();
		this.L81ECAB();
		this.L80DC2A();
		this.L81E9F4();
		this.L838EE1();
		this.L81E870();
		this.L81EA54();
		this.L80B5E6();
		this.L80CC06();
		this.L839C9C();
		this.L83955A();
		this.L81E934();
		this.L8397F7();
		this.L839DDD();
		this.L80CDE4();
		this.L81E994();
		this.L8289A7();
		this.L80D7A7();
		this.L80D7F3();
		this.L81E807();
		this.L838000();
		this.L80D852();
		this.L8D8002();
		return;
	}

	public void L809FDF()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x14CE];
		
		if (Z == 1)
			return this.L80A003();

		A = [0x0265];
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80A003();

		A = [0x14CC];
		
		if (Z == 0)
			return this.L80A003();

		[0x0265] = 0;
		A = [0x026D];
		[0x14CA] = A;
		A = 0x001B;
		[0x026D] = A;
	}

	public void L80A003()
	{
		P = Stack.Pop();
		return;
	}

	public void L80A005()
	{
		A = [0x58];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80A00F();

		return this.L80A093();
	}

	public void L80A00F()
	{
		A = [0x026D];
		temp = A - 0x001A;
		
		if (Z == 0)
			return this.L80A020();

		A = [0x0371];
		A--;
		
		if (Z == 1)
			return this.L80A022();

		A--;
		
		if (Z == 1)
			return this.L80A022();

	}

	public void L80A020()
	{
		return this.L80A093();
	}

	public void L80A022()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.L808202();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
		A = [0x026D];
		temp = A - 0x001A;
		
		if (Z == 0)
			return this.L80A05C();

		this.L909993();
		this.L80A094();
		A = 0x8000;
		[0x01] = A;
		A = 0xA053;
		[0x00] = A;
		this.L8087A4();
		return this.L80A05C();
	}

	public void L80A05C()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.L808202();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
		A = [0x58];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80A07E();

		A = [0x5A];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80A07E();

		return this.L80A05C();
	}

	public void L80A07E()
	{
		this.L80A0C6();
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.L808202();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L80A093()
	{
		return;
	}

	public void L80A094()
	{
		A = 0x2199;
		[0x7E3318] = A;
		A = 0x2194;
		[0x7E331A] = A;
		A = 0x2195;
		[0x7E331C] = A;
		A = 0x2196;
		[0x7E331E] = A;
		A = 0x2197;
		[0x7E3320] = A;
		A = 0x2198;
		[0x7E3322] = A;
		A = 0x2199;
		[0x7E3324] = A;
		return;
	}

	public void L80A0C6()
	{
		A = 0x0080;
		[0x7E3318] = A;
		[0x7E331A] = A;
		[0x7E331C] = A;
		[0x7E331E] = A;
		[0x7E3320] = A;
		[0x7E3322] = A;
		[0x7E3324] = A;
		return;
	}

	public void L80A0E6()
	{
		[0x026D]++;
		return this.L81E739();
	}

	public void L80A0ED()
	{
		this.L908453();
		this.L80A10A();
		A = [0x150C];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L80A100();

		[0x026D]++;
	}

	public void L80A100()
	{
		return;
	}

	public void L80A10A()
	{
		this.L80A1B7();
		this.L81EB18();
		this.L81E7A7();
		this.L80D927();
		this.L81ECAB();
		this.L80DC2A();
		this.L81E9F4();
		this.L838EE1();
		this.L81E870();
		this.L81EA54();
		this.L80CC06();
		this.L839C9C();
		this.L83955A();
		this.L81E934();
		this.L8397F7();
		this.L839DDD();
		this.L80CDE4();
		this.L81E994();
		this.L8289A7();
		this.L80D7A7();
		this.L80D7F3();
		this.L838000();
		this.L80D852();
		A = 0x3C00;
		temp = A & [0xB8]; [0xB8] &= ~A;
		return;
	}

	public void L80A1B7()
	{
		A = [0x14D6];
		temp = A - 0x000F;
		
		if (Z == 0)
			return this.L80A1E1();

		A = [0x14D8];
		C = 0;
		A += [0x14FA] + C;
		[0xB0] = A;
		A = [0x14E6];
		C = 0;
		A += [0x14FC] + C;
		[0xB2] = A;
		this.L82898E();
		A = [0x010F];
		[0x0113] = A;
		A = [0x0111];
		[0x0115] = A;
	}

	public void L80A1E1()
	{
		return;
	}

	public void L80A1E2()
	{
		P &= ~0x30;
		A = 0x0000;
		[0x0B36] = A;
		A = 0x0000;
		[0x0B38] = A;
		A = 0x0000;
		[0x0B3A] = A;
		A = 0x0000;
		[0x14D6] = A;
		A = 0x0000;
		[0x0381] = A;
		A = 0x0001;
		[0x7E3983] = A;
		A = 0x0000;
		[0x7E3985] = A;
		A = 0x0000;
		[0x7E5BF3] = A;
		[0x1B0E] = A;
		A = 0xFFDD;
		[0x025D] = A;
		A = 0xFFE4;
		[0x025F] = A;
		A = 0x0000;
		[0x150C] = A;
		A = 0x0002;
		[0x4E] = A;
		A = 0x001B;
		[0x4C] = A;
		return;
	}

	public void L80A237()
	{
		P &= ~0x30;
		this.L80A2B5();
		this.L80A256();
		this.L839416();
		this.L8391CD();
		this.L819E82();
		this.L81EAB4();
		this.L80A27F();
		return;
	}

	public void L80A256()
	{
		X = 0x005C;
		A = 0xFFFF;
	}

	public void L80A25C()
	{
		[0x117C + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A25C();

		X = 0x001E;
	}

	public void L80A266()
	{
		A = 0x0000;
		[0x1A81 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A266();

		X = 0x001E;
	}

	public void L80A273()
	{
		A = 0x0000;
		[0x7E3963 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L80A273();

		return;
	}

	public void L80A27F()
	{
		P |= 0x20;
		P &= ~0x10;
		X = 0x8000;
		[0x3E] = X;
		A = 0x9D;
		[0x40] = A;
		X = 0x6B38;
		[0x43] = X;
		A = 0x7E;
		[0x45] = A;
		this.L808888();
		P &= ~0x30;
		A = 0x8000;
		[0x01] = A;
		A = 0xA2AB;
		[0x00] = A;
		this.L8087A4();
		return this.L80A2B4();
	}

	public void L80A2B4()
	{
		return;
	}

	public void L80A2B5()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x8F;
		[0x0100] = A;
		A = 0x01;
		[0x0101] = A;
		A = 0x09;
		[0x0104] = A;
		A = 0x00;
		[0x0105] = A;
		A = 0x01;
		[0x0106] = A;
		A = 0x09;
		[0x0107] = A;
		A = 0x10;
		[0x0108] = A;
		A = 0x00;
		[0x0109] = A;
		A = 0x44;
		[0x010A] = A;
		A = 0x01;
		[0x010B] = A;
		P = Stack.Pop();
		return;
	}

	public void L80B5E6()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		this.L80B6E7();
		this.L80B5F3();
		B = Stack.Pop();
		return;
	}

	public void L80B5F3()
	{
		A = [0x1968];
		A |= [0x1866];
		
		if (N == 1)
			return this.L80B615();

		A = [0x7E5BC3];
		C = 0;
		A += 0x0100 + C;
		temp = A - 0x0200;
		
		if (C == 1)
			return this.L80B633();

		A = [0x7E5BC5];
		C = 0;
		A += 0x00D8 + C;
		temp = A - 0x01B0;
		
		if (C == 1)
			return this.L80B633();

	}

	public void L80B615()
	{
		A = 0x0000;
		[0x7E5BEB] = A;
		A = [0x7E5BED];
		A++;
		[0x7E5BED] = A;
		temp = A - 0x0003;
		
		if (C == 0)
			return this.L80B631();

		A = 0x0003;
		[0x7E5BED] = A;
	}

	public void L80B631()
	{
		return this.L80B651();
	}

	public void L80B633()
	{
		A = [0x7E5BEB];
		A++;
		[0x7E5BEB] = A;
		temp = A - 0x0003;
		
		if (C == 0)
			return this.L80B648();

		A = 0x0003;
		[0x7E5BEB] = A;
	}

	public void L80B648()
	{
		A = 0x0000;
		[0x7E5BED] = A;
		return this.L80B651();
	}

	public void L80B651()
	{
		A = [0x7E5BEB];
		
		if (Z == 1)
			return this.L80B65C();

		A <<= 1;
		X = A;
		return [(0xB668 + X)]();
	}

	public void L80B65C()
	{
		A = [0x7E5BED];
		
		if (Z == 1)
			return this.L80B667();

		A <<= 1;
		X = A;
		return [(0xB670 + X)]();
	}

	public void L80B667()
	{
		return;
	}

	public void L80B6E7()
	{
		A = [0x7E5BC3];
		
		if (N == 0)
			return this.L80B6F1();

		A ^= 0xFFFF;
		A++;
	}

	public void L80B6F1()
	{
		temp = A - 0x00B0;
		
		if (C == 1)
			return this.L80B6F9();

		return this.L80B760();
	}

	public void L80B6F9()
	{
		temp = A - 0x01B0;
		
		if (C == 0)
			return this.L80B717();

		temp = A - 0x02B0;
		
		if (C == 0)
			return this.L80B712();

		temp = A - 0x03B0;
		
		if (C == 0)
			return this.L80B70D();

		A = 0x0020;
		return this.L80B71C();
	}

	public void L80B70D()
	{
		A = 0x0010;
		return this.L80B71C();
	}

	public void L80B712()
	{
		A = 0x0008;
		return this.L80B71C();
	}

	public void L80B717()
	{
		A = 0x0004;
		return this.L80B71C();
	}

	public void L80B71C()
	{
		temp = A & [0x014C];
		
		if (Z == 0)
			return this.L80B760();

		A--;
		A &= [0x014C];
		
		if (Z == 0)
			return this.L80B735();

		A = [0x14D8];
		this.L809977();
		A |= 0x0035;
		this.L8094BA();
	}

	public void L80B735()
	{
		A = 0x0060;
		[0xB2] = A;
		A = [0x7E5BC3];
		
		if (N == 0)
			return this.L80B750();

		A = 0x0010;
		[0xB0] = A;
		A = 0x00A1;
		[0xB4] = A;
		this.L828000();
		return this.L80B760();
	}

	public void L80B750()
	{
		A = 0x00F0;
		[0xB0] = A;
		A = 0x00A0;
		[0xB4] = A;
		this.L828000();
		return this.L80B760();
	}

	public void L80B760()
	{
		A = [0x7E5BC5];
		
		if (N == 0)
			return this.L80B76A();

		A ^= 0xFFFF;
		A++;
	}

	public void L80B76A()
	{
		temp = A - 0x0088;
		
		if (C == 1)
			return this.L80B772();

		return this.L80B7D9();
	}

	public void L80B772()
	{
		temp = A - 0x0188;
		
		if (C == 0)
			return this.L80B790();

		temp = A - 0x0288;
		
		if (C == 0)
			return this.L80B78B();

		temp = A - 0x0388;
		
		if (C == 0)
			return this.L80B786();

		A = 0x0020;
		return this.L80B795();
	}

	public void L80B786()
	{
		A = 0x0010;
		return this.L80B795();
	}

	public void L80B78B()
	{
		A = 0x0008;
		return this.L80B795();
	}

	public void L80B790()
	{
		A = 0x0004;
		return this.L80B795();
	}

	public void L80B795()
	{
		temp = A & [0x014C];
		
		if (Z == 0)
			return this.L80B7D9();

		A--;
		A &= [0x014C];
		
		if (Z == 0)
			return this.L80B7AE();

		A = [0x14D8];
		this.L809977();
		A |= 0x0035;
		this.L8094BA();
	}

	public void L80B7AE()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x7E5BC5];
		
		if (N == 0)
			return this.L80B7C9();

		A = 0x0030;
		[0xB2] = A;
		A = 0x00A2;
		[0xB4] = A;
		this.L828000();
		return this.L80B7D9();
	}

	public void L80B7C9()
	{
		A = 0x0098;
		[0xB2] = A;
		A = 0x00A3;
		[0xB4] = A;
		this.L828000();
		return this.L80B7D9();
	}

	public void L80B7D9()
	{
		return;
	}

	public void L80C90B()
	{
		A = [0x117C];
		
		if (N == 0)
			return this.L80C915();

		Y = 0x0000;
		C = 0;
		return;
	}

	public void L80C915()
	{
		A = [0x117E];
		
		if (N == 0)
			return this.L80C91F();

		Y = 0x0002;
		C = 0;
		return;
	}

	public void L80C91F()
	{
		A = [0x1180];
		
		if (N == 0)
			return this.L80C929();

		Y = 0x0004;
		C = 0;
		return;
	}

	public void L80C929()
	{
		C = 1;
		return;
	}

	public void L80C92B()
	{
		A = [0x1182];
		
		if (N == 0)
			return this.L80C935();

		Y = 0x0006;
		C = 0;
		return;
	}

	public void L80C935()
	{
		A = [0x1184];
		
		if (N == 0)
			return this.L80C93F();

		Y = 0x0008;
		C = 0;
		return;
	}

	public void L80C93F()
	{
		A = [0x1186];
		
		if (N == 0)
			return this.L80C949();

		Y = 0x000A;
		C = 0;
		return;
	}

	public void L80C949()
	{
		A = [0x1188];
		
		if (N == 0)
			return this.L80C953();

		Y = 0x000C;
		C = 0;
		return;
	}

	public void L80C953()
	{
		A = [0x118A];
		
		if (N == 0)
			return this.L80C95D();

		Y = 0x000E;
		C = 0;
		return;
	}

	public void L80C95D()
	{
		A = [0x118C];
		
		if (N == 0)
			return this.L80C967();

		Y = 0x0010;
		C = 0;
		return;
	}

	public void L80C967()
	{
		A = [0x118E];
		
		if (N == 0)
			return this.L80C971();

		Y = 0x0012;
		C = 0;
		return;
	}

	public void L80C971()
	{
		A = [0x1190];
		
		if (N == 0)
			return this.L80C97B();

		Y = 0x0014;
		C = 0;
		return;
	}

	public void L80C97B()
	{
		A = [0x1192];
		
		if (N == 0)
			return this.L80C985();

		Y = 0x0016;
		C = 0;
		return;
	}

	public void L80C985()
	{
		A = [0x1194];
		
		if (N == 0)
			return this.L80C98F();

		Y = 0x0018;
		C = 0;
		return;
	}

	public void L80C98F()
	{
		A = [0x1196];
		
		if (N == 0)
			return this.L80C999();

		Y = 0x001A;
		C = 0;
		return;
	}

	public void L80C999()
	{
		A = [0x1198];
		
		if (N == 0)
			return this.L80C9A3();

		Y = 0x001C;
		C = 0;
		return;
	}

	public void L80C9A3()
	{
		A = [0x119A];
		
		if (N == 0)
			return this.L80C9AD();

		Y = 0x001E;
		C = 0;
		return;
	}

	public void L80C9AD()
	{
		A = [0x119C];
		
		if (N == 0)
			return this.L80C9B7();

		Y = 0x0020;
		C = 0;
		return;
	}

	public void L80C9B7()
	{
		A = [0x119E];
		
		if (N == 0)
			return this.L80C9C1();

		Y = 0x0022;
		C = 0;
		return;
	}

	public void L80C9C1()
	{
		A = [0x11A0];
		
		if (N == 0)
			return this.L80C9CB();

		Y = 0x0024;
		C = 0;
		return;
	}

	public void L80C9CB()
	{
		A = [0x11A2];
		
		if (N == 0)
			return this.L80C9D5();

		Y = 0x0026;
		C = 0;
		return;
	}

	public void L80C9D5()
	{
		A = [0x11A4];
		
		if (N == 0)
			return this.L80C9DF();

		Y = 0x0028;
		C = 0;
		return;
	}

	public void L80C9DF()
	{
		A = [0x11A6];
		
		if (N == 0)
			return this.L80C9E9();

		Y = 0x002A;
		C = 0;
		return;
	}

	public void L80C9E9()
	{
		A = [0x11A8];
		
		if (N == 0)
			return this.L80C9F3();

		Y = 0x002C;
		C = 0;
		return;
	}

	public void L80C9F3()
	{
		A = [0x11AA];
		
		if (N == 0)
			return this.L80C9FD();

		Y = 0x002E;
		C = 0;
		return;
	}

	public void L80C9FD()
	{
		A = [0x11AC];
		
		if (N == 0)
			return this.L80CA07();

		Y = 0x0030;
		C = 0;
		return;
	}

	public void L80CA07()
	{
		A = [0x11AE];
		
		if (N == 0)
			return this.L80CA11();

		Y = 0x0032;
		C = 0;
		return;
	}

	public void L80CA11()
	{
		A = [0x11B0];
		
		if (N == 0)
			return this.L80CA1B();

		Y = 0x0034;
		C = 0;
		return;
	}

	public void L80CA1B()
	{
		C = 1;
		return;
	}

	public void L80CABF()
	{
		A = [0x11D2];
		
		if (N == 0)
			return this.L80CAC9();

		Y = 0x0056;
		C = 0;
		return;
	}

	public void L80CAC9()
	{
		A = [0x11D4];
		
		if (N == 0)
			return this.L80CAD3();

		Y = 0x0058;
		C = 0;
		return;
	}

	public void L80CAD3()
	{
		A = [0x11D6];
		
		if (N == 0)
			return this.L80CADD();

		Y = 0x005A;
		C = 0;
		return;
	}

	public void L80CADD()
	{
		A = [0x11D8];
		
		if (N == 0)
			return this.L80CAE7();

		Y = 0x005C;
		C = 0;
		return;
	}

	public void L80CAE7()
	{
		C = 1;
		return;
	}

	public void L80CAE9()
	{
		Stack.Push(A);
		Stack.Push(X);
		[0x117C + Y] = A;
		A <<= 1;
		X = A;
		A = [0x7E43C3 + X];
		[0x1238 + Y] = A;
		A = [0x7E49C3 + X];
		[0x10C0 + Y] = A;
		A = [0x7E4CC3 + X];
		[0x111E + Y] = A;
		A = 0x0000;
		[0x0B9C + Y] = A;
		[0x0C58 + Y] = A;
		[0x0CB6 + Y] = A;
		[0x0F48 + Y] = A;
		[0x0FA6 + Y] = A;
		[0x0E8C + Y] = A;
		[0x0EEA + Y] = A;
		[0x1352 + Y] = A;
		[0x11DA + Y] = A;
		[0x140E + Y] = A;
		[0x146C + Y] = A;
		A = 0xFFFF;
		[0x12F4 + Y] = A;
		[0x1296 + Y] = A;
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80CB48();

		A = [0x197C];
		[0x0D14 + Y] = A;
		A = [0x197E];
		[0x0D72 + Y] = A;
		return this.L80CB51();
	}

	public void L80CB48()
	{
		A = 0x0000;
		[0x0D14 + Y] = A;
		[0x0D72 + Y] = A;
	}

	public void L80CB51()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80CB67();

		A = [0x1988];
		[0x0DD0 + Y] = A;
		A = [0x198A];
		[0x0E2E + Y] = A;
		return this.L80CB70();
	}

	public void L80CB67()
	{
		A = 0x0000;
		[0x0DD0 + Y] = A;
		[0x0E2E + Y] = A;
	}

	public void L80CB70()
	{
		X = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L80CB73()
	{
		Stack.Push(A);
		Stack.Push(X);
		[0x117C + Y] = A;
		A <<= 1;
		X = A;
		A = [0x7E43C3 + X];
		[0x1238 + Y] = A;
		A = [0x7E49C3 + X];
		[0x10C0 + Y] = A;
		A = [0x7E4CC3 + X];
		[0x111E + Y] = A;
		A = 0x0000;
		[0x0B9C + Y] = A;
		[0x0C58 + Y] = A;
		[0x0F48 + Y] = A;
		[0x0FA6 + Y] = A;
		[0x0E8C + Y] = A;
		[0x0EEA + Y] = A;
		[0x11DA + Y] = A;
		[0x140E + Y] = A;
		[0x146C + Y] = A;
		A = 0xFFFF;
		[0x1296 + Y] = A;
		A = 0x0100;
		[0x0CB6 + Y] = A;
		A = 0xF1FF;
		[0x12F4 + Y] = A;
		A = 0x0400;
		[0x1352 + Y] = A;
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80CBDB();

		A = [0x14DE];
		[0x0D14 + Y] = A;
		A = [0x14E0];
		[0x0D72 + Y] = A;
		return this.L80CBE4();
	}

	public void L80CBDB()
	{
		A = 0x0000;
		[0x0D14 + Y] = A;
		[0x0D72 + Y] = A;
	}

	public void L80CBE4()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80CBFA();

		A = [0x14EC];
		[0x0DD0 + Y] = A;
		A = [0x14EE];
		[0x0E2E + Y] = A;
		return this.L80CC03();
	}

	public void L80CBFA()
	{
		A = 0x0000;
		[0x0DD0 + Y] = A;
		[0x0E2E + Y] = A;
	}

	public void L80CC03()
	{
		X = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L80CC06()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x117C];
		
		if (N == 1)
			return this.L80CC14();

		Y = 0x0000;
		this.L80CE15();
	}

	public void L80CC14()
	{
		A = [0x117E];
		
		if (N == 1)
			return this.L80CC1F();

		Y = 0x0002;
		this.L80CE15();
	}

	public void L80CC1F()
	{
		A = [0x1180];
		
		if (N == 1)
			return this.L80CC2A();

		Y = 0x0004;
		this.L80CE15();
	}

	public void L80CC2A()
	{
		A = [0x1182];
		
		if (N == 1)
			return this.L80CC35();

		Y = 0x0006;
		this.L80CE15();
	}

	public void L80CC35()
	{
		A = [0x1184];
		
		if (N == 1)
			return this.L80CC40();

		Y = 0x0008;
		this.L80CE15();
	}

	public void L80CC40()
	{
		A = [0x1186];
		
		if (N == 1)
			return this.L80CC4B();

		Y = 0x000A;
		this.L80CE15();
	}

	public void L80CC4B()
	{
		A = [0x1188];
		
		if (N == 1)
			return this.L80CC56();

		Y = 0x000C;
		this.L80CE15();
	}

	public void L80CC56()
	{
		A = [0x118A];
		
		if (N == 1)
			return this.L80CC61();

		Y = 0x000E;
		this.L80CE15();
	}

	public void L80CC61()
	{
		A = [0x118C];
		
		if (N == 1)
			return this.L80CC6C();

		Y = 0x0010;
		this.L80CE15();
	}

	public void L80CC6C()
	{
		A = [0x118E];
		
		if (N == 1)
			return this.L80CC77();

		Y = 0x0012;
		this.L80CE15();
	}

	public void L80CC77()
	{
		A = [0x1190];
		
		if (N == 1)
			return this.L80CC82();

		Y = 0x0014;
		this.L80CE15();
	}

	public void L80CC82()
	{
		A = [0x1192];
		
		if (N == 1)
			return this.L80CC8D();

		Y = 0x0016;
		this.L80CE15();
	}

	public void L80CC8D()
	{
		A = [0x1194];
		
		if (N == 1)
			return this.L80CC98();

		Y = 0x0018;
		this.L80CE15();
	}

	public void L80CC98()
	{
		A = [0x1196];
		
		if (N == 1)
			return this.L80CCA3();

		Y = 0x001A;
		this.L80CE15();
	}

	public void L80CCA3()
	{
		A = [0x1198];
		
		if (N == 1)
			return this.L80CCAE();

		Y = 0x001C;
		this.L80CE15();
	}

	public void L80CCAE()
	{
		A = [0x119A];
		
		if (N == 1)
			return this.L80CCB9();

		Y = 0x001E;
		this.L80CE15();
	}

	public void L80CCB9()
	{
		A = [0x119C];
		
		if (N == 1)
			return this.L80CCC4();

		Y = 0x0020;
		this.L80CE15();
	}

	public void L80CCC4()
	{
		A = [0x119E];
		
		if (N == 1)
			return this.L80CCCF();

		Y = 0x0022;
		this.L80CE15();
	}

	public void L80CCCF()
	{
		A = [0x11A0];
		
		if (N == 1)
			return this.L80CCDA();

		Y = 0x0024;
		this.L80CE15();
	}

	public void L80CCDA()
	{
		A = [0x11A2];
		
		if (N == 1)
			return this.L80CCE5();

		Y = 0x0026;
		this.L80CE15();
	}

	public void L80CCE5()
	{
		A = [0x11A4];
		
		if (N == 1)
			return this.L80CCF0();

		Y = 0x0028;
		this.L80CE15();
	}

	public void L80CCF0()
	{
		A = [0x11A6];
		
		if (N == 1)
			return this.L80CCFB();

		Y = 0x002A;
		this.L80CE15();
	}

	public void L80CCFB()
	{
		A = [0x11A8];
		
		if (N == 1)
			return this.L80CD06();

		Y = 0x002C;
		this.L80CE15();
	}

	public void L80CD06()
	{
		A = [0x11AA];
		
		if (N == 1)
			return this.L80CD11();

		Y = 0x002E;
		this.L80CE15();
	}

	public void L80CD11()
	{
		A = [0x11AC];
		
		if (N == 1)
			return this.L80CD1C();

		Y = 0x0030;
		this.L80CE15();
	}

	public void L80CD1C()
	{
		A = [0x11AE];
		
		if (N == 1)
			return this.L80CD27();

		Y = 0x0032;
		this.L80CE15();
	}

	public void L80CD27()
	{
		A = [0x11B0];
		
		if (N == 1)
			return this.L80CD32();

		Y = 0x0034;
		this.L80CE15();
	}

	public void L80CD32()
	{
		A = [0x11B2];
		
		if (N == 1)
			return this.L80CD3D();

		Y = 0x0036;
		this.L80CE15();
	}

	public void L80CD3D()
	{
		A = [0x11B4];
		
		if (N == 1)
			return this.L80CD48();

		Y = 0x0038;
		this.L80CE15();
	}

	public void L80CD48()
	{
		A = [0x11B6];
		
		if (N == 1)
			return this.L80CD53();

		Y = 0x003A;
		this.L80CE15();
	}

	public void L80CD53()
	{
		A = [0x11B8];
		
		if (N == 1)
			return this.L80CD5E();

		Y = 0x003C;
		this.L80CE15();
	}

	public void L80CD5E()
	{
		A = [0x11BA];
		
		if (N == 1)
			return this.L80CD69();

		Y = 0x003E;
		this.L80CE15();
	}

	public void L80CD69()
	{
		A = [0x11BC];
		
		if (N == 1)
			return this.L80CD74();

		Y = 0x0040;
		this.L80CE15();
	}

	public void L80CD74()
	{
		A = [0x11BE];
		
		if (N == 1)
			return this.L80CD7F();

		Y = 0x0042;
		this.L80CE15();
	}

	public void L80CD7F()
	{
		A = [0x11C0];
		
		if (N == 1)
			return this.L80CD8A();

		Y = 0x0044;
		this.L80CE15();
	}

	public void L80CD8A()
	{
		A = [0x11C2];
		
		if (N == 1)
			return this.L80CD95();

		Y = 0x0046;
		this.L80CE15();
	}

	public void L80CD95()
	{
		A = [0x11C4];
		
		if (N == 1)
			return this.L80CDA0();

		Y = 0x0048;
		this.L80CE15();
	}

	public void L80CDA0()
	{
		A = [0x11C6];
		
		if (N == 1)
			return this.L80CDAB();

		Y = 0x004A;
		this.L80CE15();
	}

	public void L80CDAB()
	{
		A = [0x11C8];
		
		if (N == 1)
			return this.L80CDB6();

		Y = 0x004C;
		this.L80CE15();
	}

	public void L80CDB6()
	{
		A = [0x11CA];
		
		if (N == 1)
			return this.L80CDC1();

		Y = 0x004E;
		this.L80CE15();
	}

	public void L80CDC1()
	{
		A = [0x11CC];
		
		if (N == 1)
			return this.L80CDCC();

		Y = 0x0050;
		this.L80CE15();
	}

	public void L80CDCC()
	{
		A = [0x11CE];
		
		if (N == 1)
			return this.L80CDD7();

		Y = 0x0052;
		this.L80CE15();
	}

	public void L80CDD7()
	{
		A = [0x11D0];
		
		if (N == 1)
			return this.L80CDE2();

		Y = 0x0054;
		this.L80CE15();
	}

	public void L80CDE2()
	{
		B = Stack.Pop();
		return;
	}

	public void L80CDE4()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x11D2];
		
		if (N == 1)
			return this.L80CDF2();

		Y = 0x0056;
		this.L80CE15();
	}

	public void L80CDF2()
	{
		A = [0x11D4];
		
		if (N == 1)
			return this.L80CDFD();

		Y = 0x0058;
		this.L80CE15();
	}

	public void L80CDFD()
	{
		A = [0x11D6];
		
		if (N == 1)
			return this.L80CE08();

		Y = 0x005A;
		this.L80CE15();
	}

	public void L80CE08()
	{
		A = [0x11D8];
		
		if (N == 1)
			return this.L80CE13();

		Y = 0x005C;
		this.L80CE15();
	}

	public void L80CE13()
	{
		B = Stack.Pop();
		return;
	}

	public void L80CE15()
	{
		Stack.Push(B);
		this.L80CE1C();
		B = Stack.Pop();
		return;
	}

	public void L80CE1C()
	{
		A = [0x117C + Y];
		A <<= 1;
		C = 0;
		A += [0x117C + Y] + C;
		X = A;
		A = [0xCE86 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xCE88 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();	//24-Bit Address
	}

	public byte[] FunctionPointerTable80CE86 = new byte[]
	{
		0x00, 0x80, 0x97,
		0x40, 0x80, 0x97,
		0x2B, 0x80, 0x97,
		0x40, 0x80, 0x97,
		0x55, 0x80, 0x97,
		0x6D, 0x80, 0x97,
		0x6D, 0x80, 0x97,
		0x6D, 0x80, 0x97,
		0x82, 0x80, 0x97,
		0xA0, 0x80, 0x97,
		0xAF, 0x80, 0x97,
		0xBE, 0x80, 0x97,
		0xCD, 0x80, 0x97,
		0x8E, 0x80, 0x97,
		0xF1, 0x80, 0x97,
		0x88, 0xDC, 0x96,
		0x8F, 0xDC, 0x96,
		0x96, 0xDC, 0x96,
		0x9D, 0xDC, 0x96,
		0xA4, 0xDC, 0x96,
		0xAB, 0xDC, 0x96,
		0xB2, 0xDC, 0x96,
		0xB9, 0xDC, 0x96,
		0xBD, 0xDC, 0x96,
		0xDC, 0x80, 0x97,
		0x96, 0xDC, 0x96,
		0x9D, 0xDC, 0x96,
		0xA4, 0xDC, 0x96,
		0xAB, 0xDC, 0x96,
		0xB2, 0xDC, 0x96,
		0xB9, 0xDC, 0x96,
		0xBD, 0xDC, 0x96,
		0x88, 0xDC, 0x96,
		0x8F, 0xDC, 0x96,
		0xC4, 0xDC, 0x96,
		0xCB, 0xDC, 0x96,
		0xD2, 0xDC, 0x96,
		0xD9, 0xDC, 0x96,
		0xE0, 0xDC, 0x96,
		0xE7, 0xDC, 0x96,
		0xEE, 0xDC, 0x96,
		0xEE, 0xDC, 0x96,
		0xF5, 0xDC, 0x96,
		0xF5, 0xDC, 0x96,
		0xF9, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0x06, 0xDD, 0x96,
		0xC4, 0xDC, 0x96,
		0xCB, 0xDC, 0x96,
		0xD2, 0xDC, 0x96,
		0xD9, 0xDC, 0x96,
		0xE0, 0xDC, 0x96,
		0xE7, 0xDC, 0x96,
		0xEE, 0xDC, 0x96,
		0xEE, 0xDC, 0x96,
		0xF5, 0xDC, 0x96,
		0xF5, 0xDC, 0x96,
		0xF9, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0xFD, 0xDC, 0x96,
		0x06, 0xDD, 0x96,
		0xEC, 0xEA, 0x96,
		0x03, 0xEB, 0x96,
		0x1A, 0xEB, 0x96,
		0x26, 0xEB, 0x96,
		0x32, 0xEB, 0x96,
		0x3E, 0xEB, 0x96,
		0x00, 0x81, 0x97,
		0x18, 0xAC, 0x97,
		0x02, 0xAE,	0x97,
		0x61, 0xAF, 0x97,
		0x90, 0xB0, 0x97,
		0x22, 0xB2, 0x97,
		0x79, 0xB3, 0x97,
		0xD0, 0xB4, 0x97,
		0xC1, 0xB5, 0x97,
		0x84, 0xB6, 0x97,
		0xD7, 0xFC, 0x96,
		0x4B, 0xEB, 0x96,
		0x62, 0xEB, 0x96,
		0x79, 0xEB, 0x96,
		0xE9, 0xEE, 0x96,
		0xF5, 0xEE, 0x96,
		0xA4, 0xEF, 0x96,
		0xA3, 0xEB, 0x96,
		0xBA, 0xEB, 0x96,
		0xD1, 0xEB, 0x96,
		0xD1, 0xEB, 0x96,
		0xE8, 0xEB, 0x96,
		0xFF, 0xEB, 0x96,
		0xFF, 0xEB, 0x96,
		0x16, 0xEC, 0x96,
		0xCF, 0xEC, 0x96,
		0x16, 0xEC, 0x96,
		0xCF, 0xEC, 0x96,
		0xAC, 0xED, 0x96,
		0x90, 0xEB, 0x96,
		0x6A, 0xF7, 0x96,
		0xB3, 0xF7, 0x96,
		0x2E, 0xF8, 0x96,
		0xF9, 0xF8, 0x96,
		0x1A, 0xB2, 0x9C,
		0xB5, 0xA8, 0x97,
		0xA9, 0xAE, 0x8E,
		0xD0, 0xAE, 0x8E,
		0xD5, 0xB6, 0x97,
		0xFF, 0xB7, 0x97
		0x13, 0xB9, 0x97,
		0xEB, 0xB9, 0x97,
		0xE2, 0xBA, 0x97,
		0x79, 0xBB, 0x97,
		0xD1, 0xB7, 0x97,
		0xAD, 0xB7, 0x97,
		0x27, 0xB1, 0x83,
		0x38, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x49, 0xB1, 0x83,
		0x02, 0xC3, 0x83,
		0x02, 0xC3, 0x83,
		0x02, 0xC3, 0x83,
		0x02, 0xC3, 0x83,
		0x02, 0xC3, 0x83,
		0x02, 0xC3, 0x83,
		0xE1, 0xC2, 0x83,
		0xE1, 0xC2, 0x83,
		0xE1, 0xC2, 0x83,
		0xE1, 0xC2, 0x83,
		0xC4, 0xC2, 0x83,
		0xC4, 0xC2, 0x83,
		0xC4, 0xC2, 0x83,
		0xC4, 0xC2, 0x83,
		0x1F, 0xC3, 0x83,
		0x38, 0xC3, 0x83,
		0x19, 0x95, 0x99,
		0x3A, 0x95, 0x99,
		0x5B, 0x95, 0x99,
		0x78, 0x95, 0x99,
		0x95, 0x95, 0x99,
		0xB2, 0x95, 0x99,
		0x33, 0x97, 0x99,
		0x50, 0x97, 0x99,
		0x6D, 0x97, 0x99,
		0x8A, 0x97, 0x99,
		0x47, 0x99, 0x99,
		0x47, 0x99, 0x99,
		0x47, 0x99, 0x99,
		0x47, 0x99, 0x99,
		0x47, 0x99, 0x99,
		0x47, 0x99, 0x99,
		0xC6, 0x99, 0x99,
		0xEB, 0xCC, 0x87,
		0x20, 0xCD, 0x87,
		0x11, 0xCE, 0x87,
		0x46, 0xCE, 0x87,
		0x95, 0xD2, 0x87,
		0xCA, 0xD2, 0x87,
		0x2F, 0xD2, 0x87,
		0x64, 0xD2, 0x87,
		0xCB, 0xD0, 0x87,
		0xE8, 0xD0, 0x87,
		0x05, 0xD1, 0x87,
		0x3A, 0xD1, 0x87,
		0xF7, 0xCF, 0x87,
		0x14, 0xD0, 0x87,
		0x31, 0xD0, 0x87,
		0x4E, 0xD0, 0x87,
		0xCE, 0xCC, 0x87,
		0x94, 0xCC, 0x87,
		0xB1, 0xCC, 0x87,
		0x77, 0xCC, 0x87,
		0x55, 0xCB, 0x87,
		0xE6, 0xCB, 0x87,
		0x5A, 0xD0, 0x86,
		0x93, 0xD1, 0x86,
		0x5A, 0xD0, 0x86,
		0x93, 0xD1, 0x86,
		0xD0, 0xD1, 0x86,
		0x0D, 0xD2, 0x86,
		0x1F, 0xD3, 0x86,
		0x46, 0xD2, 0x86,
		0x1F, 0xD3, 0x86,
		0x46, 0xD2, 0x86,
		0x89, 0xD3, 0x86,
		0x54, 0xD3, 0x86,
		0xC2, 0xD3, 0x86,
		0x9B, 0xD4, 0x86,
		0xC2, 0xD3, 0x86,
		0x9B, 0xD4, 0x86,
		0xD0, 0xD4, 0x86,
		0x01, 0xD5, 0x86,
		0xD0, 0xD4, 0x86,
		0x01, 0xD5, 0x86,
		0x36, 0xD5, 0x86,
		0x4F, 0xD5, 0x86,
		0x68, 0xD5, 0x86,
		0x89, 0xD5, 0x86,
		0xAA, 0xD5, 0x86,
		0x02, 0x97, 0x8C,
		0x3D, 0x97, 0x8C,
		0x7C, 0x99, 0x8C,
		0xBE, 0x99, 0x8C,
		0x6D, 0x98, 0x8C,
		0x6D, 0x98, 0x8C,
		0x9D, 0x99, 0x8C,
		0xA7, 0x97, 0x8C,
		0xDF, 0x99, 0x8C,
		0xDF, 0x99, 0x8C,
		0xC7, 0xA9, 0x9A,
		0xF8, 0xA9, 0x9A,
		0x95, 0x95, 0x99,
		0x5B, 0x95, 0x99,
		0x33, 0xAB, 0x9A,
		0x68, 0xAB, 0x9A,
		0x19, 0xAC, 0x9A,
		0x4E, 0xAC, 0x9A,
		0xFF, 0xAC, 0x9A,
		0xC2, 0xAE, 0x9A,
		0xFF, 0xAC, 0x9A,
		0xC2, 0xAE, 0x9A,
		0x1B, 0xB1, 0x9A,
		0x50, 0xB1, 0x9A,
		0x78, 0x95, 0x99,
		0xB2, 0x95, 0x99,
		0x43, 0xB2, 0x9A,
		0x78, 0xB2, 0x9A,
		0x43, 0xB2, 0x9A,
		0x78, 0xB2, 0x9A,
		0x20, 0xB5, 0x9A,
		0x29, 0xB3, 0x9A,
		0x20, 0xB5, 0x9A,
		0x29, 0xB3, 0x9A,
		0x1D, 0xB6, 0x9A,
		0xF9, 0xB7, 0x9A,
		0x6E, 0xB9, 0x9A,
		0x1D, 0xB6, 0x9A,
		0xF9, 0xB7, 0x9A,
		0x6E, 0xB9, 0x9A,
		0xE3, 0xBA, 0x9A,
		0x97, 0xBB, 0x9A,
		0xCC, 0xBC, 0x9A,
		0x05, 0xBD, 0x9A,
		0x3E, 0xBD, 0x9A,
		0x73, 0xBD, 0x9A,
		0x8C, 0xBD, 0x9A,
		0xAD, 0xBD, 0x9A,
		0xE6, 0xB7, 0x89,
		0x98, 0x95, 0x89,
		0xA3, 0xB6, 0x89,
		0xDE, 0xB6, 0x89,
		0xA6, 0xB8, 0x89,
		0x50, 0xBA, 0x89,
		0x71, 0xDA, 0x9B,
		0xAA, 0xDA, 0x9B,
		0x71, 0xDA, 0x9B,
		0xAA, 0xDA, 0x9B,
		0x07, 0xDC, 0x9B,
		0x30, 0xDC, 0x9B,
		0x59, 0xDC, 0x9B,
		0x59, 0xDC, 0x9B,
		0x2F, 0xDD, 0x9B,
		0x58, 0xDD, 0x9B,
		0x85, 0xDD, 0x9B,
		0xE4, 0xDD, 0x9B,
		0x00, 0x00, 0x00,
		0x8A, 0xAA, 0x9C,
		0xAB, 0xAA, 0x9C,
		0xCC, 0xAA, 0x9C,
		0xED, 0xAA, 0x9C,
		0xDE, 0xAB, 0x9C,
		0xB2, 0xAC, 0x9C,
		0xED, 0xAA, 0x9C,
		0xDE, 0xAB, 0x9C,
		0xB2, 0xAC, 0x9C,
		0x45, 0xAD, 0x9C,
		0xC4, 0xAD, 0x9C,
		0xA7, 0xB4, 0x9C,
		0x5C, 0xB5, 0x9C,
		0xFC, 0x93, 0x84,
		0xFC, 0x93, 0x84,
		0x96, 0x94, 0x84,
		0x79, 0x94, 0x84,
		0xFC, 0x93, 0x84,
		0xFC, 0x93, 0x84,
		0x47, 0x94, 0x84,
		0x47, 0x94, 0x84,
		0xFC, 0x93, 0x84,
		0xFC, 0x93, 0x84,
		0x60, 0x94, 0x84,
		0x60, 0x94, 0x84,
		0xB3, 0x94, 0x84,
		0xB3, 0x94, 0x84,
		0xFC, 0x93, 0x84,
		0xFC, 0x93, 0x84,
		0x15, 0x94, 0x84,
		0x2E, 0x94, 0x84,
		0xB3, 0x94, 0x84,
		0xB3, 0x94, 0x84,
		0xB3, 0x94, 0x84,
		0xFA, 0xCC, 0x8D,
		0x74, 0xCD, 0x8D,
		0x31, 0xE6, 0x8D,
		0xB0, 0xE6, 0x8D,
		0x40, 0xA1, 0x9B,
		0x40, 0xA1, 0x9B,
		0x31, 0xA2, 0x9B,
		0x6C, 0xA2, 0x9B,
		0xA7, 0xA2, 0x9B,
		0xA7, 0xA2, 0x9B,
		0x30, 0xEF, 0x84,
		0x49, 0xEF, 0x84,
		0x30, 0xEF, 0x84,
		0x49, 0xEF, 0x84,
		0x62, 0xEF, 0x84,
		0xDB, 0x80, 0x86,
		0xF0, 0x80, 0x86,
		0x59, 0x81, 0x86,
		0xF0, 0x80, 0x86,
		0x1A, 0x81, 0x86,
		0x1A, 0x81, 0x86,
		0x44, 0x81, 0x86,
		0x44, 0x81, 0x86,
		0x6E, 0x81, 0x86,
		0x6E, 0x81, 0x86,
		0x87, 0x81, 0x86,
		0x87, 0x81, 0x86,
		0x2F, 0x81, 0x86,
		0x2F, 0x81, 0x86
		0x05, 0x81, 0x86,
		0x05, 0x81, 0x86,
		0xA0, 0x81, 0x86
	}

	public void L80D279()
	{
		Stack.Push(B);
		Stack.Push(Y);
		Stack.Push(X);
		Stack.Push(K);
		B = Stack.Pop();
		X = [0x14];
		A = [0x1238 + X];
		A &= 0x0007;
		A <<= 1;
		X = A;
		return [(0xD28F + X)]();
	}

	public void L80D3AC()
	{
		this.L80D738();
		this.L80D4DC();
		this.L80D8B6();
		X = [0x18];
		Y = [0x1766 + X];
		A = [0x1726 + Y];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L80D41A();

		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80D41A();

		temp = A & 0x0008;
		
		if (Z == 0)
			return this.L80D41A();

		this.L80D490();
		
		if (Z == 1)
			return this.L80D3DB();

		A--;
		
		if (Z == 1)
			return this.L80D41A();

		A--;
		
		if (Z == 0)
			return this.L80D3DB();

		return this.L80D47B();
	}

	public void L80D3DB()
	{
		A = [0x1726 + Y];
		temp = A & 0x0004;
		
		if (Z == 0)
			return this.L80D454();

		temp = A & 0x0400;
		
		if (Z == 0)
			return this.L80D41B();

		A = [0x1B79];
		
		if (Z == 0)
			return this.L80D41B();

	}

	public void L80D3ED()
	{
		X = [0x12];
		A = [0x117C + X];
		A <<= 1;
		X = A;
		A = [0x150C];
		temp = A & 0x0801;
		
		if (Z == 0)
			return this.L80D411();

		C = 1;
		A = [0x1826 + Y];
		A -= [0x7E3DC3 + X] - !C;
		[0x1826 + Y] = A;
		A = [0x1866 + Y];
		A -= [0x7E40C3 + X] - !C;
		[0x1866 + Y] = A;
	}

	public void L80D411()
	{
		A = [0x1726 + Y];
		A |= 0x0008;
		[0x1726 + Y] = A;
	}

	public void L80D41A()
	{
		return;
	}

	public void L80D41B()
	{
		X = [0x18];
		
		if (Z == 1)
			return this.L80D3ED();

		A = [0x1766 + X];
		
		if (Z == 1)
			return this.L80D3ED();

		X = A;
		A = [0x1726 + X];
		temp = A & 0x0020;
		
		if (Z == 0)
			return this.L80D3ED();

		X = [0x12];
		A = [0x1238 + X];
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L80D3ED();

		A &= 0x0007;
		temp = A - 0x0002;
		
		if (N == 1)
			return this.L80D3ED();

		A = [0x150C];
		temp = A & 0x0801;
		
		if (Z == 0)
			return this.L80D453();

		A = 0xFFFF;
		[0x1826 + Y] = A;
		A = 0xFFFF;
		[0x1866 + Y] = A;
	}

	public void L80D453()
	{
		return;
	}

	public void L80D454()
	{
		X = [0x12];
		A = [0x1238 + X];
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L80D411();

		A &= 0x0007;
		temp = A - 0x0004;
		
		if (N == 1)
			return this.L80D411();

		A = [0x150C];
		temp = A & 0x0801;
		
		if (Z == 0)
			return this.L80D47A();

		A = 0xFFFF;
		[0x1826 + Y] = A;
		A = 0xFFFF;
		[0x1866 + Y] = A;
	}

	public void L80D47A()
	{
		return;
	}

	public void L80D47B()
	{
		A = [0x150C];
		temp = A & 0x0801;
		
		if (Z == 0)
			return this.L80D47A();

		A = 0xFFFF;
		[0x1826 + Y] = A;
		A = 0xFFFF;
		[0x1866 + Y] = A;
		return;
	}

	public void L80D490()
	{
		Stack.Push(X);
		Stack.Push(Y);
		Y = A;
		X = [0x12];
		A = [0x1238 + X];
		temp = A & 0x0080;
		
		if (Z == 1)
			return this.L80D4A5();

		A = Y;
		temp = A & 0x0020;
		
		if (Z == 1)
			return this.L80D4CE();

		return this.L80D4C2();
	}

	public void L80D4A5()
	{
		A = Y;
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L80D4C2();

		A = [0x1B79];
		
		if (Z == 1)
			return this.L80D4C0();

		A = [0x1238 + X];
		A &= 0x0007;
		X = A;
		A = [0x80D4D4 + X];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L80D4C2();

	}

	public void L80D4C0()
	{
		return this.L80D4C8();
	}

	public void L80D4C2()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = 0x0000;
		return;
	}

	public void L80D4C8()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = 0x0001;
		return;
	}

	public void L80D4CE()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = 0x0002;
		return;
	}

	public void L80D4DC()
	{
		X = [0x18];
		Y = [0x1766 + X];
		A = [0x1726 + Y];
		[0x1512] = A;
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L80D513();

		this.L80D490();
		A--;
		
		if (Z == 1)
			return this.L80D513();

		X = [0x12];
		A = [0x1238 + X];
		A &= 0x0007;
		temp = A - 0x0001;
		
		if (C == 0)
			return this.L80D513();

		X = [0x12];
		A = [0x1238 + X];
		A &= 0x0007;
		X = A;
		A = [0x80D522 + X];
		A &= 0x00FF;
		this.L81F437();
	}

	public void L80D513()
	{
		A = [0x1510];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L80D521();

		A = [0x1512];
		[0x1510] = A;
	}

	public void L80D521()
	{
		return;
	}

	public void L80D52A()
	{
		X = [0x18];
		Y = [0x1766 + X];
		A = [0x1866 + Y];
		
		if (N == 1)
			return this.L80D566();

		A = [0x1726 + Y];
		this.L80D490();
		A--;
		
		if (Z == 1)
			return this.L80D566();

		X = [0x12];
		A = [0x117C + X];
		A <<= 1;
		X = A;
		A = [0x1926 + Y];
		temp = A - [0x7E46C3 + X];
		
		if (C == 1)
			return this.L80D566();

		A = [0x1926 + Y];
		A >>= 1;
		
		if (C == 1)
			return this.L80D55C();

		A = [0x7E46C3 + X];
		A &= 0xFFFE;
		return this.L80D563();
	}

	public void L80D55C()
	{
		A = [0x7E46C3 + X];
		A |= 0x0001;
	}

	public void L80D563()
	{
		[0x1926 + Y] = A;
	}

	public void L80D566()
	{
		return;
	}

	public void L80D567()
	{
		Y = [0x18];
		X = [0x1766 + Y];
		A = [0x1726 + X];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L80D577();

		return this.L80D6C9();
	}

	public void L80D577()
	{
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80D57F();

		return this.L80D6C9();
	}

	public void L80D57F()
	{
		this.L80D490();
		A--;
		
		if (Z == 0)
			return this.L80D588();

		return this.L80D6C9();
	}

	public void L80D588()
	{
		X = [0x12];
		A = [0x117C + X];
		A <<= 1;
		X = A;
		A = [0x7E3DC3 + X];
		[0x1AA5] = A;
		[0x1AB9] = A;
		A = [0x7E40C3 + X];
		[0x1AA7] = A;
		[0x1ABB] = A;
		A = [0x1AB9];
		A <<= 1;
		[0x1ABD] = A;
		A = [0x1ABB];
		Cpu.ROL();
		[0x1ABF] = A;
		[0x1AA7] >>= 1;
		Cpu.ROR(0x1AA5);
		A = [0x1AA5];
		[0x1AB5] = A;
		A = [0x1AA7];
		[0x1AB7] = A;
		[0x1AA7] >>= 1;
		Cpu.ROR(0x1AA5);
		A = [0x1AA5];
		[0x1AB1] = A;
		A = [0x1AA7];
		[0x1AB3] = A;
		[0x1AA7] >>= 1;
		Cpu.ROR(0x1AA5);
		A = [0x1AA5];
		[0x1AAD] = A;
		A = [0x1AA7];
		[0x1AAF] = A;
		[0x1AA7] >>= 1;
		Cpu.ROR(0x1AA5);
		A = [0x1AA5];
		[0x1AA9] = A;
		A = [0x1AA7];
		[0x1AAB] = A;
		[0x1AA7] >>= 1;
		Cpu.ROR(0x1AA5);
		[0x22] = 0;
		[0x24] = 0;
		Y = [0x18];
		X = [0x1766 + Y];
		A = [0x7E3CF3 + X];
		temp = A & 0x0001;
		
		if (Z == 1)
			return this.L80D620();

		C = 0;
		A = [0x22];
		A += [0x1AA5] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1AA7] + C;
		[0x24] = A;
	}

	public void L80D620()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0002;
		
		if (Z == 1)
			return this.L80D638();

		C = 0;
		A = [0x22];
		A += [0x1AA9] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1AAB] + C;
		[0x24] = A;
	}

	public void L80D638()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0004;
		
		if (Z == 1)
			return this.L80D650();

		C = 0;
		A = [0x22];
		A += [0x1AAD] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1AAF] + C;
		[0x24] = A;
	}

	public void L80D650()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0008;
		
		if (Z == 1)
			return this.L80D668();

		C = 0;
		A = [0x22];
		A += [0x1AB1] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1AB3] + C;
		[0x24] = A;
	}

	public void L80D668()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0010;
		
		if (Z == 1)
			return this.L80D680();

		C = 0;
		A = [0x22];
		A += [0x1AB5] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1AB7] + C;
		[0x24] = A;
	}

	public void L80D680()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0020;
		
		if (Z == 1)
			return this.L80D698();

		C = 0;
		A = [0x22];
		A += [0x1AB9] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1ABB] + C;
		[0x24] = A;
	}

	public void L80D698()
	{
		A = [0x7E3CF3 + X];
		temp = A & 0x0040;
		
		if (Z == 1)
			return this.L80D6B0();

		C = 0;
		A = [0x22];
		A += [0x1ABD] + C;
		[0x22] = A;
		A = [0x24];
		A += [0x1ABF] + C;
		[0x24] = A;
	}

	public void L80D6B0()
	{
		A = [0x150C];
		temp = A & 0x0801;
		
		if (Z == 0)
			return this.L80D6C9();

		C = 1;
		A = [0x1826];
		A -= [0x22] - !C;
		[0x1826] = A;
		A = [0x1866];
		A -= [0x24] - !C;
		[0x1866] = A;
	}

	public void L80D6C9()
	{
		return;
	}

	public void L80D6CA()
	{
		Y = [0x14];
		A = [0x117C + Y];
		A <<= 1;
		X = A;
		A = [0x150C];
		temp = A & 0x1002;
		
		if (Z == 0)
			return this.L80D6EE();

		C = 1;
		A = [0x1966];
		A -= [0x7E3DC3 + X] - !C;
		[0x1966] = A;
		A = [0x1968];
		A -= [0x7E40C3 + X] - !C;
		[0x1968] = A;
	}

	public void L80D6EE()
	{
		this.L80D6F3();
		return;
	}

	public void L80D6F3()
	{
		X = [0x14];
		A = [0x117C + X];
		A <<= 1;
		X = A;
		C = 0;
		A = [0x196A];
		A += [0x7E55C3 + X] + C;
		[0x196A] = A;
		A = [0x196C];
		A += [0x7E58C3 + X] + C;
		[0x196C] = A;
		C = 1;
		A = [0x196A];
		A -= [0x196E] - !C;
		[0x88] = A;
		A = [0x196C];
		A -= [0x1970] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80D728();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D728()
	{
		
		if (N == 1)
			return this.L80D737();

		A = 0x0000;
		[0x196A] = A;
		[0x196C] = A;
		this.L968A39();
	}

	public void L80D737()
	{
		return;
	}

	public void L80D738()
	{
		X = [0x18];
		Y = [0x1766 + X];
		A = [0x1726 + Y];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L80D7A6();

		temp = A & 0x0008;
		
		if (Z == 0)
			return this.L80D7A6();

		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80D7A6();

		this.L80D490();
		A--;
		
		if (Z == 1)
			return this.L80D7A6();

		X = [0x12];
		A = [0x117C + X];
		A <<= 1;
		X = A;
		C = 0;
		A = [0x7E39E7];
		A += [0x7E55C3 + X] + C;
		[0x7E39E7] = A;
		A = [0x7E39E9];
		A += [0x7E58C3 + X] + C;
		[0x7E39E9] = A;
		C = 1;
		A = [0x7E39E7];
		A -= [0x7E39EB] - !C;
		[0x88] = A;
		A = [0x7E39E9];
		A -= [0x7E39ED] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80D792();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D792()
	{
		
		if (N == 1)
			return this.L80D7A6();

		A = 0x0000;
		[0x7E39E7] = A;
		[0x7E39E9] = A;
		A = 0x0001;
		this.L81F437();
	}

	public void L80D7A6()
	{
		return;
	}

	public void L80D7A7()
	{
		C = 1;
		A = [0x196A];
		A -= [0x1972] - !C;
		[0x196A] = A;
		A = [0x196C];
		A -= [0x1974] - !C;
		[0x196C] = A;
		A = [0x196C];
		
		if (N == 0)
			return this.L80D7C8();

		A = 0x0000;
		[0x196A] = A;
		[0x196C] = A;
	}

	public void L80D7C8()
	{
		C = 1;
		A = [0x7E39E7];
		A -= [0x7E39EF] - !C;
		[0x7E39E7] = A;
		A = [0x7E39E9];
		A -= [0x7E39F1] - !C;
		[0x7E39E9] = A;
		A = [0x7E39E9];
		
		if (N == 0)
			return this.L80D7F2();

		A = 0x0000;
		[0x7E39E7] = A;
		[0x7E39E9] = A;
	}

	public void L80D7F2()
	{
		return;
	}

	public void L80D7F3()
	{
		A = [0x1976];
		temp = A & 0x0008;
		
		if (Z == 0)
			return this.L80D819();

		A = [0x1968];
		
		if (N == 1)
			return this.L80D813();

		temp = A - 0x0080;
		
		if (N == 0)
			return this.L80D80B();

		A++;
		[0x0375] = A;
		return this.L80D819();
	}

	public void L80D80B()
	{
		A = 0x0080;
		[0x0375] = A;
		return this.L80D819();
	}

	public void L80D813()
	{
		A = 0x0000;
		[0x0375] = A;
	}

	public void L80D819()
	{
		A = [0x1976];
		temp = A & 0x0004;
		
		if (Z == 0)
			return this.L80D83F();

		A = [0x1866];
		
		if (N == 1)
			return this.L80D839();

		temp = A - 0x0080;
		
		if (N == 0)
			return this.L80D831();

		A++;
		[0x0377] = A;
		return this.L80D83F();
	}

	public void L80D831()
	{
		A = 0x0080;
		[0x0377] = A;
		return this.L80D83F();
	}

	public void L80D839()
	{
		A = 0x0000;
		[0x0377] = A;
	}

	public void L80D83F()
	{
		A = [0x1968];
		
		if (N == 1)
			return this.L80D84B();

		A = [0x1866];
		
		if (N == 1)
			return this.L80D84B();

		return this.L80D851();
	}

	public void L80D84B()
	{
		A = 0x1800;
		temp = A & [0x150C]; [0x150C] |= A;
	}

	public void L80D851()
	{
		return;
	}

	public void L80D852()
	{
		A = 0x0008;
		temp = A & [0x1726]; [0x1726] &= ~A;
		temp = A & [0x1728]; [0x1728] &= ~A;
		temp = A & [0x172A]; [0x172A] &= ~A;
		temp = A & [0x172C]; [0x172C] &= ~A;
		temp = A & [0x172E]; [0x172E] &= ~A;
		temp = A & [0x1730]; [0x1730] &= ~A;
		temp = A & [0x1732]; [0x1732] &= ~A;
		temp = A & [0x1734]; [0x1734] &= ~A;
		temp = A & [0x1736]; [0x1736] &= ~A;
		temp = A & [0x1738]; [0x1738] &= ~A;
		temp = A & [0x173A]; [0x173A] &= ~A;
		temp = A & [0x173C]; [0x173C] &= ~A;
		temp = A & [0x173E]; [0x173E] &= ~A;
		temp = A & [0x1740]; [0x1740] &= ~A;
		temp = A & [0x1742]; [0x1742] &= ~A;
		temp = A & [0x1744]; [0x1744] &= ~A;
		temp = A & [0x1746]; [0x1746] &= ~A;
		temp = A & [0x1748]; [0x1748] &= ~A;
		temp = A & [0x174A]; [0x174A] &= ~A;
		temp = A & [0x174C]; [0x174C] &= ~A;
		temp = A & [0x174E]; [0x174E] &= ~A;
		temp = A & [0x1750]; [0x1750] &= ~A;
		temp = A & [0x1752]; [0x1752] &= ~A;
		temp = A & [0x1754]; [0x1754] &= ~A;
		temp = A & [0x1756]; [0x1756] &= ~A;
		temp = A & [0x1758]; [0x1758] &= ~A;
		temp = A & [0x175A]; [0x175A] &= ~A;
		temp = A & [0x175C]; [0x175C] &= ~A;
		temp = A & [0x175E]; [0x175E] &= ~A;
		temp = A & [0x1760]; [0x1760] &= ~A;
		temp = A & [0x1762]; [0x1762] &= ~A;
		temp = A & [0x1764]; [0x1764] &= ~A;
		return;
	}

	public void L80D8B6()
	{
		A = [0x1512];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L80D926();

		this.L80D490();
		A--;
		
		if (Z == 1)
			return this.L80D926();

		A = [0x150E];
		
		if (Z == 1)
			return this.L80D8D2();

		A--;
		
		if (Z == 1)
			return this.L80D8E9();

		A--;
		
		if (Z == 1)
			return this.L80D900();

		A--;
		
		if (Z == 1)
			return this.L80D917();

	}

	public void L80D8D2()
	{
		A = [0x14D6];
		temp = A - 0x0010;
		
		if (Z == 1)
			return this.L80D917();

		A = [0x14D8];
		this.L809977();
		A |= 0x0079;
		this.L8094BA();
		return;
	}

	public void L80D8E9()
	{
		A = [0x1512];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L80D917();

		A = [0x14D8];
		this.L809977();
		A |= 0x007A;
		this.L8094BA();
		return;
	}

	public void L80D900()
	{
		A = [0x1512];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L80D917();

		A = [0x14D8];
		this.L809977();
		A |= 0x007B;
		this.L8094BA();
		return;
	}

	public void L80D917()
	{
		A = [0x14D8];
		this.L809977();
		A |= 0x007C;
		this.L8094BA();
		return;
	}

	public void L80D926()
	{
		return;
	}

	public void L80D927()
	{
		A = [0x150C];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80D945();

		this.L80D954();
		this.L80E40D();
		this.L80DF8B();
		this.L80D97C();
		this.L80DF3F();
		this.L80D967();
	}

	public void L80D945()
	{
		A = [0x14DC];
		[0x7E5BDF] = A;
		A = [0x14EA];
		[0x7E5BE1] = A;
		return;
	}

	public void L80D954()
	{
		A = [0x1B79];
		
		if (Z == 0)
			return this.L80D960();

		A = 0x00C0;
		temp = A & [0x1976]; [0x1976] &= ~A;
		return;
	}

	public void L80D960()
	{
		A = 0x00C0;
		temp = A & [0x1976]; [0x1976] |= A;
		return;
	}

	public void L80D967()
	{
		A = [0x1968];
		A |= [0x1866];
		
		if (N == 0)
			return this.L80D97B();

		A = 0x03F0;
		temp = A & [0x1976]; [0x1976] &= ~A;
		A = 0x0008;
		temp = A & [0x150C]; [0x150C] &= ~A;
	}

	public void L80D97B()
	{
		return;
	}

	public void L80D97C()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80D987();

		return this.L80DB31();
	}

	public void L80D987()
	{
		A = [0x1990];
		[0x12] = A;
		A = [0x1992];
		[0x14] = A;
		C = 0;
		A = [0x12];
		A += 0xFFFF + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		A = [0x14];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x1976];
		temp = A & 0xC800;
		
		if (Z == 1)
			return this.L80D9B0();

		return this.L80DA67();
	}

	public void L80D9B0()
	{
		C = 1;
		A = [0x1980];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x1982];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80D9C9();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D9C9()
	{
		
		if (Z == 0)
			return this.L80D9CE();

		return this.L80DA67();
	}

	public void L80D9CE()
	{
		A = [0x1982];
		
		if (N == 1)
			return this.L80D9F0();

		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0003 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80D9EC();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80D9EC()
	{
		
		if (N == 0)
			return this.L80DA67();

		return this.L80DA0D();
	}

	public void L80D9F0()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0xFFFD - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DA09();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DA09()
	{
		
		if (N == 1)
			return this.L80DA67();

		return this.L80DA0D();
	}

	public void L80DA0D()
	{
		A = [0x1980];
		[0x12] = A;
		A = [0x1982];
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80DA30();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80DA30()
	{
		[0x12] <<= 1;
		Cpu.ROL(0x14);
		C = 0;
		A = [0x12];
		A += 0x8000 + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x80DB32 + X] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x80DB34 + X] - !C;
		[0x14] = A;
		C = 0;
		A = [0x1990];
		A += [0x12] + C;
		[0x1990] = A;
		A = [0x1992];
		A += [0x14] + C;
		[0x1992] = A;
		return this.L80DA7E();
	}

	public void L80DA67()
	{
		C = 1;
		A = [0x1990];
		A -= [0x80DBA6 + X] - !C;
		[0x1990] = A;
		A = [0x1992];
		A -= [0x80DBA8 + X] - !C;
		[0x1992] = A;
		return this.L80DA7E();
	}

	public void L80DA7E()
	{
		C = 1;
		A = [0x1990];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x1992];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DA97();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DA97()
	{
		
		if (N == 0)
			return this.L80DAA5();

		A = 0x0000;
		[0x1990] = A;
		A = 0x0000;
		[0x1992] = A;
	}

	public void L80DAA5()
	{
		A = [0x1990];
		[0x1994] = A;
		A = [0x1992];
		[0x1996] = A;
		C = 1;
		A = [0x1994];
		A -= [0x199C] - !C;
		[0x1994] = A;
		A = [0x1996];
		A -= [0x199E] - !C;
		[0x1996] = A;
		A = [0x1994];
		[0x1998] = A;
		A = [0x1996];
		[0x199A] = A;
		C = 1;
		A = [0x1998];
		A -= [0x19A0] - !C;
		[0x1998] = A;
		A = [0x199A];
		A -= [0x19A2] - !C;
		[0x199A] = A;
		A = [0x1998];
		[0x12] = A;
		A = [0x199A];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x19A4] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x19A6] - !C;
		[0x14] = A;
		A = [0x1990];
		[0x199C] = A;
		A = [0x1992];
		[0x199E] = A;
		A = [0x1994];
		[0x19A0] = A;
		A = [0x1996];
		[0x19A2] = A;
		A = [0x1998];
		[0x19A4] = A;
		A = [0x199A];
		[0x19A6] = A;
		C = 0;
		A = [0x198C];
		A += [0x12] + C;
		[0x198C] = A;
		A = [0x198E];
		A += [0x14] + C;
		[0x198E] = A;
	}

	public void L80DB31()
	{
		return;
	}

	public void L80DC2A()
	{
		A = 0xC000;
		temp = A & [0x1976]; [0x1976] &= ~A;
		C = 0;
		A = [0x197C];
		A += [0x1980] + C;
		[0x197C] = A;
		A = [0x197E];
		A += [0x1982] + C;
		[0x197E] = A;
		A = [0x7E3997];
		[0x12] = A;
		A = [0x7E3999];
		[0x14] = A;
		A = [0x7E39AB];
		[0x16] = A;
		A = [0x7E39AD];
		[0x18] = A;
		this.L80DD8A();
		A = [0x197E];
		
		if (N == 1)
			return this.L80DC91();

		C = 1;
		A = [0x197C];
		A -= [0x12] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x14] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DC7A();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DC7A()
	{
		
		if (N == 0)
			return this.L80DC7F();

		return this.L80DCC1();
	}

	public void L80DC7F()
	{
		A = [0x12];
		[0x197C] = A;
		A = [0x14];
		[0x197E] = A;
		A = 0x8000;
		temp = A & [0x1976]; [0x1976] |= A;
		return this.L80DCC1();
	}

	public void L80DC91()
	{
		C = 1;
		A = [0x197C];
		A -= [0x16] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x18] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DCA8();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DCA8()
	{
		
		if (Z == 1)
			return this.L80DCAF();

		
		if (N == 1)
			return this.L80DCAF();

		return this.L80DCC1();
	}

	public void L80DCAF()
	{
		A = [0x16];
		[0x197C] = A;
		A = [0x18];
		[0x197E] = A;
		A = 0x8000;
		temp = A & [0x1976]; [0x1976] |= A;
		return this.L80DCC1();
	}

	public void L80DCC1()
	{
		C = 0;
		A = [0x1978];
		A += [0x197C] + C;
		[0x1978] = A;
		A = [0x197A];
		A += [0x197E] + C;
		[0x197A] = A;
		C = 0;
		A = [0x1988];
		A += [0x198C] + C;
		[0x1988] = A;
		A = [0x198A];
		A += [0x198E] + C;
		[0x198A] = A;
		A = [0x198A];
		
		if (N == 1)
			return this.L80DD22();

		C = 1;
		A = [0x1988];
		A -= [0x7E39BF] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C1] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DD07();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DD07()
	{
		
		if (N == 0)
			return this.L80DD0C();

		return this.L80DD5A();
	}

	public void L80DD0C()
	{
		A = [0x7E39BF];
		[0x1988] = A;
		A = [0x7E39C1];
		[0x198A] = A;
		A = 0x4000;
		temp = A & [0x1976]; [0x1976] |= A;
		return this.L80DD5A();
	}

	public void L80DD22()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39D3] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39D5] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DD3D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DD3D()
	{
		
		if (Z == 1)
			return this.L80DD44();

		
		if (N == 1)
			return this.L80DD44();

		return this.L80DD5A();
	}

	public void L80DD44()
	{
		A = [0x7E39D3];
		[0x1988] = A;
		A = [0x7E39D5];
		[0x198A] = A;
		A = 0x4000;
		temp = A & [0x1976]; [0x1976] |= A;
		return this.L80DD5A();
	}

	public void L80DD5A()
	{
		C = 0;
		A = [0x1984];
		A += [0x1988] + C;
		[0x1984] = A;
		A = [0x1986];
		A += [0x198A] + C;
		[0x1986] = A;
		this.L80DE80();
		Cpu.NOP();
		A = [0x197C];
		[0x0456] = A;
		A = [0x197E];
		[0x0458] = A;
		A = [0x1988];
		[0x0452] = A;
		A = [0x198A];
		[0x0454] = A;
		return;
	}

	public void L80DD8A()
	{
		A = [0x1AED];
		temp = A - 0x0001;
		
		if (C == 1)
			return this.L80DD95();

		return this.L80DE5F();
	}

	public void L80DD95()
	{
		A = [0x7E5BC3];
		
		if (N == 0)
			return this.L80DD9F();

		A ^= 0xFFFF;
		A++;
	}

	public void L80DD9F()
	{
		temp = A - 0x00A0;
		
		if (C == 0)
			return this.L80DDA9();

		X = 0x001C;
		return this.L80DDF1();
	}

	public void L80DDA9()
	{
		temp = A - 0x0090;
		
		if (C == 0)
			return this.L80DDB3();

		X = 0x0018;
		return this.L80DDF1();
	}

	public void L80DDB3()
	{
		temp = A - 0x0080;
		
		if (C == 0)
			return this.L80DDBD();

		X = 0x0014;
		return this.L80DDF1();
	}

	public void L80DDBD()
	{
		temp = A - 0x0070;
		
		if (C == 0)
			return this.L80DDC7();

		X = 0x0010;
		return this.L80DDF1();
	}

	public void L80DDC7()
	{
		temp = A - 0x0060;
		
		if (C == 0)
			return this.L80DDD1();

		X = 0x000C;
		return this.L80DDF1();
	}

	public void L80DDD1()
	{
		temp = A - 0x0050;
		
		if (C == 0)
			return this.L80DDDB();

		X = 0x0008;
		return this.L80DDF1();
	}

	public void L80DDDB()
	{
		temp = A - 0x0040;
		
		if (C == 0)
			return this.L80DDE5();

		X = 0x0004;
		return this.L80DDF1();
	}

	public void L80DDE5()
	{
		temp = A - 0x0030;
		
		if (C == 0)
			return this.L80DDEF();

		X = 0x0000;
		return this.L80DDF1();
	}

	public void L80DDEF()
	{
		return this.L80DE5F();
	}

	public void L80DDF1()
	{
		A = [0x7E5BC3];
		
		if (N == 1)
			return this.L80DE2B();

		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DE10();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DE10()
	{
		
		if (Z == 1)
			return this.L80DE5F();

		
		if (N == 1)
			return this.L80DE5F();

		C = 0;
		A = [0x197C];
		A += [0x80DE60 + X] + C;
		[0x197C] = A;
		A = [0x197E];
		A += [0x80DE62 + X] + C;
		[0x197E] = A;
		return this.L80DE5F();
	}

	public void L80DE2B()
	{
		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80DE44();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80DE44()
	{
		
		if (Z == 1)
			return this.L80DE5F();

		
		if (N == 0)
			return this.L80DE5F();

		C = 1;
		A = [0x197C];
		A -= [0x80DE60 + X] - !C;
		[0x197C] = A;
		A = [0x197E];
		A -= [0x80DE62 + X] - !C;
		[0x197E] = A;
		return this.L80DE5F();
	}

	public void L80DE5F()
	{
		return;
	}

	public void L80DE80()
	{
		return;
	}

	public void L80DF3F()
	{
		A = [0x1976];
		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L80DF52();

		temp = A & 0x0400;
		
		if (Z == 0)
			return this.L80DF4F();

		return this.L80DF8A();
	}

	public void L80DF4F()
	{
		return this.L80DF8A();
	}

	public void L80DF52()
	{
		A = [0x19A9];
		[0x01] = A;
		A = [0x19A8];
		[0x00] = A;
		A = [[0x00]];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L80DF68();

		A &= 0x007F;
		return this.L80DF6B();
	}

	public void L80DF68()
	{
		A |= 0xFF80;
	}

	public void L80DF6B()
	{
		temp = A - 0x007F;
		
		if (Z == 0)
			return this.L80DF79();

		A = 0x0800;
		temp = A & [0x1976]; [0x1976] &= ~A;
		return this.L80DF8A();
	}

	public void L80DF79()
	{
		C = 0;
		A += [0x198E] + C;
		[0x198E] = A;
		A = [0x19A8];
		C = 0;
		A += 0x0001 + C;
		[0x19A8] = A;
	}

	public void L80DF8A()
	{
		return;
	}

	public void L80DF8B()
	{
		A = [0x150C];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L80DFF2();

		A = [0x7E3985];
		
		if (Z == 0)
			return this.L80DF9C();

		return this.L80DFF2();
	}

	public void L80DF9C()
	{
		A = [0x50];
		temp = A & 0x4300;
		
		if (Z == 0)
			return this.L80DFA6();

		this.L80E0B3();
	}

	public void L80DFA6()
	{
		A = [0x50];
		temp = A & 0x4C00;
		
		if (Z == 0)
			return this.L80DFB0();

		this.L80E1E9();
	}

	public void L80DFB0()
	{
		A = [0x50];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80DFBA();

		this.L80E374();
	}

	public void L80DFBA()
	{
		A = [0x50];
		temp = A & 0x0200;
		
		if (Z == 1)
			return this.L80DFC4();

		this.L80E023();
	}

	public void L80DFC4()
	{
		A = [0x50];
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L80DFCE();

		this.L80DFF3();
	}

	public void L80DFCE()
	{
		A = [0x50];
		temp = A & 0x0800;
		
		if (Z == 1)
			return this.L80DFDB();

		this.L80E083();
		this.L80E31F();
	}

	public void L80DFDB()
	{
		A = [0x50];
		temp = A & 0x0400;
		
		if (Z == 1)
			return this.L80DFE5();

		this.L80E053();
	}

	public void L80DFE5()
	{
		A = [0x50];
		temp = A & 0x8040;
		
		if (Z == 1)
			return this.L80DFF2();

		this.L80E14E();
		this.L80E284();
	}

	public void L80DFF2()
	{
		return;
	}

	public void L80DFF3()
	{
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80E022();

		A = [0x50];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80E012();

		A = [0x7E39A7];
		[0x1980] = A;
		A = [0x7E39A9];
		[0x1982] = A;
		return this.L80E022();
	}

	public void L80E012()
	{
		A = [0x7E39A3];
		[0x1980] = A;
		A = [0x7E39A5];
		[0x1982] = A;
		return this.L80E022();
	}

	public void L80E022()
	{
		return;
	}

	public void L80E023()
	{
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80E052();

		A = [0x50];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80E042();

		A = [0x7E39BB];
		[0x1980] = A;
		A = [0x7E39BD];
		[0x1982] = A;
		return this.L80E052();
	}

	public void L80E042()
	{
		A = [0x7E39B7];
		[0x1980] = A;
		A = [0x7E39B9];
		[0x1982] = A;
		return this.L80E052();
	}

	public void L80E052()
	{
		return;
	}

	public void L80E053()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80E082();

		A = [0x50];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80E072();

		A = [0x7E39CF];
		[0x198C] = A;
		A = [0x7E39D1];
		[0x198E] = A;
		return this.L80E082();
	}

	public void L80E072()
	{
		A = [0x7E39CB];
		[0x198C] = A;
		A = [0x7E39CD];
		[0x198E] = A;
		return this.L80E082();
	}

	public void L80E082()
	{
		return;
	}

	public void L80E083()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80E0B2();

		A = [0x50];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L80E0A2();

		A = [0x7E39E3];
		[0x198C] = A;
		A = [0x7E39E5];
		[0x198E] = A;
		return this.L80E0B2();
	}

	public void L80E0A2()
	{
		A = [0x7E39DF];
		[0x198C] = A;
		A = [0x7E39E1];
		[0x198E] = A;
		return this.L80E0B2();
	}

	public void L80E0B2()
	{
		return;
	}

	public void L80E0B3()
	{
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L80E0BE();

		return this.L80E14D();
	}

	public void L80E0BE()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E0D7();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E0D7()
	{
		
		if (Z == 1)
			return this.L80E135();

		
		if (N == 0)
			return this.L80E108();

		C = 1;
		A = [0x197C];
		A -= [0x7E39AF] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39B1] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E0F6();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E0F6()
	{
		
		if (N == 0)
			return this.L80E135();

		A = [0x7E399B];
		[0x1980] = A;
		A = [0x7E399D];
		[0x1982] = A;
		return this.L80E14D();
	}

	public void L80E108()
	{
		C = 1;
		A = [0x197C];
		A -= [0x7E399B] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E399D] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E123();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E123()
	{
		
		if (N == 1)
			return this.L80E135();

		A = [0x7E39AF];
		[0x1980] = A;
		A = [0x7E39B1];
		[0x1982] = A;
		return this.L80E14D();
	}

	public void L80E135()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = 0x0000;
		[0x197C] = A;
		A = 0x0000;
		[0x197E] = A;
	}

	public void L80E14D()
	{
		return;
	}

	public void L80E14E()
	{
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L80E159();

		return this.L80E1E8();
	}

	public void L80E159()
	{
		C = 1;
		A = [0x197C];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x197E];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E172();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E172()
	{
		
		if (Z == 1)
			return this.L80E1D0();

		
		if (N == 0)
			return this.L80E1A3();

		C = 1;
		A = [0x197C];
		A -= [0x7E39B3] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39B5] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E191();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E191()
	{
		
		if (N == 0)
			return this.L80E1D0();

		A = [0x7E399F];
		[0x1980] = A;
		A = [0x7E39A1];
		[0x1982] = A;
		return this.L80E1E8();
	}

	public void L80E1A3()
	{
		C = 1;
		A = [0x197C];
		A -= [0x7E399F] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x7E39A1] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E1BE();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E1BE()
	{
		
		if (N == 1)
			return this.L80E1D0();

		A = [0x7E39B3];
		[0x1980] = A;
		A = [0x7E39B5];
		[0x1982] = A;
		return this.L80E1E8();
	}

	public void L80E1D0()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = 0x0000;
		[0x197C] = A;
		A = 0x0000;
		[0x197E] = A;
	}

	public void L80E1E8()
	{
		return;
	}

	public void L80E1E9()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80E1F4();

		return this.L80E283();
	}

	public void L80E1F4()
	{
		C = 1;
		A = [0x1988];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x198A];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E20D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E20D()
	{
		
		if (Z == 1)
			return this.L80E26B();

		
		if (N == 0)
			return this.L80E23E();

		C = 1;
		A = [0x1988];
		A -= [0x7E39D7] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39D9] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E22C();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E22C()
	{
		
		if (N == 0)
			return this.L80E26B();

		A = [0x7E39C3];
		[0x198C] = A;
		A = [0x7E39C5];
		[0x198E] = A;
		return this.L80E283();
	}

	public void L80E23E()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39C3] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C5] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E259();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E259()
	{
		
		if (N == 1)
			return this.L80E26B();

		A = [0x7E39D7];
		[0x198C] = A;
		A = [0x7E39D9];
		[0x198E] = A;
		return this.L80E283();
	}

	public void L80E26B()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		A = 0x0000;
		[0x1988] = A;
		A = 0x0000;
		[0x198A] = A;
	}

	public void L80E283()
	{
		return;
	}

	public void L80E284()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80E28F();

		return this.L80E31E();
	}

	public void L80E28F()
	{
		C = 1;
		A = [0x1988];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x198A];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E2A8();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2A8()
	{
		
		if (Z == 1)
			return this.L80E306();

		
		if (N == 0)
			return this.L80E2D9();

		C = 1;
		A = [0x1988];
		A -= [0x7E39DB] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39DD] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E2C7();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2C7()
	{
		
		if (N == 0)
			return this.L80E306();

		A = [0x7E39C7];
		[0x198C] = A;
		A = [0x7E39C9];
		[0x198E] = A;
		return this.L80E31E();
	}

	public void L80E2D9()
	{
		C = 1;
		A = [0x1988];
		A -= [0x7E39C7] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x7E39C9] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E2F4();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E2F4()
	{
		
		if (N == 1)
			return this.L80E306();

		A = [0x7E39DB];
		[0x198C] = A;
		A = [0x7E39DD];
		[0x198E] = A;
		return this.L80E31E();
	}

	public void L80E306()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		A = 0x0000;
		[0x1988] = A;
		A = 0x0000;
		[0x198A] = A;
	}

	public void L80E31E()
	{
		return;
	}

	public void L80E31F()
	{
		A = [0x1976];
		temp = A & 0x0400;
		
		if (Z == 1)
			return this.L80E33D();

		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80E33D();

		A = [0x0381];
		
		if (Z == 1)
			return this.L80E33A();

		A--;
		
		if (Z == 1)
			return this.L80E337();

		return this.L80E33D();
	}

	public void L80E337()
	{
		return this.L80E359();
	}

	public void L80E33A()
	{
		return this.L80E33E();
	}

	public void L80E33D()
	{
		return;
	}

	public void L80E33E()
	{
		A = [0x1976];
		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L80E358();

		A = 0x8000;
		[0x19A9] = A;
		A = 0xF979;
		[0x19A8] = A;
		A = 0x0800;
		temp = A & [0x1976]; [0x1976] |= A;
	}

	public void L80E358()
	{
		return;
	}

	public void L80E359()
	{
		A = [0x1976];
		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L80E373();

		A = 0x8000;
		[0x19A9] = A;
		A = 0xF9BF;
		[0x19A8] = A;
		A = 0x0800;
		temp = A & [0x1976]; [0x1976] |= A;
	}

	public void L80E373()
	{
		return;
	}

	public void L80E374()
	{
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80E3C0();

		A = [0x7E5BC3];
		C = 0;
		A += 0x0040 + C;
		temp = A - 0x0180;
		
		if (C == 0)
			return this.L80E3B2();

		A = [0x7E5BC3];
		temp = A - 0x0080;
		
		if (N == 0)
			return this.L80E3A2();

		A = [0x7E39AF];
		[0x1980] = A;
		A = [0x7E39B1];
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3A2()
	{
		A = [0x7E399B];
		[0x1980] = A;
		A = [0x7E399D];
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3B2()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		return this.L80E3C0();
	}

	public void L80E3C0()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80E40C();

		A = [0x7E5BC5];
		C = 0;
		A += 0x0040 + C;
		temp = A - 0x0128;
		
		if (C == 0)
			return this.L80E3FE();

		A = [0x7E5BC5];
		temp = A - 0x0060;
		
		if (N == 0)
			return this.L80E3EE();

		A = [0x7E39D7];
		[0x198C] = A;
		A = [0x7E39D9];
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E3EE()
	{
		A = [0x7E39C3];
		[0x198C] = A;
		A = [0x7E39C5];
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E3FE()
	{
		A = 0x0000;
		[0x198C] = A;
		A = 0x0000;
		[0x198E] = A;
		return this.L80E40C();
	}

	public void L80E40C()
	{
		return;
	}

	public void L80E40D()
	{
		A = [0x150C];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L80E454();

		A = [0x7E3985];
		
		if (Z == 0)
			return this.L80E454();

		this.L80E50B();
		A = [0x1976];
		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L80E434();

		A = [0x7E3983];
		
		if (Z == 1)
			return this.L80E431();

		this.L80EE67();
		return this.L80E434();
	}

	public void L80E431()
	{
		this.L80EF67();
	}

	public void L80E434()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L80E43F();

		this.L80F060();
	}

	public void L80E43F()
	{
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L80E454();

		temp = A & 0x0400;
		
		if (Z == 1)
			return this.L80E454();

		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L80E454();

		this.L80E4E3();
	}

	public void L80E454()
	{
		return;
	}

	public void L80E455()
	{
		A = [0x1976];
		temp = A & 0x02B0;
		
		if (Z == 1)
			return this.L80E499();

		A = [0x14D8];
		temp = A - [0x7E5BE3];
		
		if (N == 1)
			return this.L80E499();

		temp = A - [0x7E5BE7];
		
		if (N == 0)
			return this.L80E499();

		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		C = 1;
		A = [0x197C];
		A -= [0x14E2] - !C;
		[0x197C] = A;
		A = [0x197E];
		A -= [0x14E4] - !C;
		[0x197E] = A;
		A = [0x14E2];
		[0x1980] = A;
		A = [0x14E4];
		[0x1982] = A;
		C = 1;
		return;
	}

	public void L80E499()
	{
		C = 0;
		return;
	}

	public void L80E49B()
	{
		A = [0x1976];
		temp = A & 0x0170;
		
		if (Z == 1)
			return this.L80E4DF();

		A = [0x14E6];
		temp = A - [0x7E5BE5];
		
		if (N == 1)
			return this.L80E4DF();

		temp = A - [0x7E5BE9];
		
		if (N == 0)
			return this.L80E4DF();

		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		C = 1;
		A = [0x1988];
		A -= [0x14F0] - !C;
		[0x1988] = A;
		A = [0x198A];
		A -= [0x14F2] - !C;
		[0x198A] = A;
		A = [0x14F0];
		[0x198C] = A;
		A = [0x14F2];
		[0x198E] = A;
		C = 1;
		return;
	}

	public void L80E4DF()
	{
		C = 0;
		return;
	}

	public void L80E4E3()
	{
		A = [0x14EA];
		temp = A - 0xFFE0;
		
		if (N == 0)
			return this.L80E507();

		A = [0x14EA];
		temp = A - [0x7E5BE1];
		
		if (N == 0)
			return this.L80E507();

		A = [0x14D8];
		temp = A - 0xFFF0;
		
		if (N == 1)
			return this.L80E507();

		temp = A - 0x0110;
		
		if (N == 0)
			return this.L80E507();

		this.L80E31F();
		return this.L80E50A();
	}

	public void L80E507()
	{
		return this.L80E50A();
	}

	public void L80E50A()
	{
		return;
	}

	public void L80E50B()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80E5C2();
		
		if (C == 0)
			return this.L80E51F();

		A = [0x1866];
		
		if (N == 1)
			return this.L80E51F();

		A = [0x1968];
		
		if (N == 1)
			return this.L80E51F();

		return this.L80E52D();
	}

	public void L80E51F()
	{
		A = 0x0000;
		[0x7E5BC7] = A;
		[0x7E5BC9] = A;
		return this.L80E59E();
	}

	public void L80E52D()
	{
		A = [0x7E5BDB];
		
		if (Z == 1)
			return this.L80E53F();

		A = [0x7E5BDB];
		A--;
		[0x7E5BDB] = A;
		return this.L80E59E();
	}

	public void L80E53F()
	{
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0xE5A0 + X];
		C = 0;
		A += [0x7E5BDD] + C;
		X = A;
		A = [0x0000 + X];
		A |= [0x0001 + X];
		
		if (Z == 0)
			return this.L80E55F();

		A = 0x0000;
		[0x7E5BDD] = A;
		return this.L80E53F();
	}

	public void L80E55F()
	{
		A = [0x0002 + X];
		A &= 0x00FF;
		A--;
		[0x7E5BDB] = A;
		A = [0x0000 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L80E577();

		A &= 0x007F;
		return this.L80E57A();
	}

	public void L80E577()
	{
		A |= 0xFF80;
	}

	public void L80E57A()
	{
		[0x7E5BC7] = A;
		A = [0x0001 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L80E58B();

		A &= 0x007F;
		return this.L80E58E();
	}

	public void L80E58B()
	{
		A |= 0xFF80;
	}

	public void L80E58E()
	{
		[0x7E5BC9] = A;
		A = [0x7E5BDD];
		C = 0;
		A += 0x0003 + C;
		[0x7E5BDD] = A;
	}

	public void L80E59E()
	{
		B = Stack.Pop();
		return;
	}

	public void L80E5C2()
	{
		A = [0x14];
		
		if (N == 0)
			return this.L80E5DB();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80E5DB()
	{
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x14E0];
		
		if (N == 0)
			return this.L80E600();

		C = 0;
		A = [0x14DE];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14E0];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
		return this.L80E60A();
	}

	public void L80E600()
	{
		A = [0x14DE];
		[0x12] = A;
		A = [0x14E0];
		[0x14] = A;
	}

	public void L80E60A()
	{
		A = [0xF2BD + X];
		
		if (N == 0)
			return this.L80E616();

		A = [0x151E];
		
		if (Z == 0)
			return this.L80E67E();

		return this.L80E62F();
	}

	public void L80E616()
	{
		C = 1;
		A = [0x12];
		A -= [0xF2BB + X] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0xF2BD + X] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E62D();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E62D()
	{
		
		if (N == 0)
			return this.L80E67E();

	}

	public void L80E62F()
	{
		A = [0x14EE];
		
		if (N == 0)
			return this.L80E64D();

		C = 0;
		A = [0x14EC];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14EE];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
		return this.L80E657();
	}

	public void L80E64D()
	{
		A = [0x14EC];
		[0x12] = A;
		A = [0x14EE];
		[0x14] = A;
	}

	public void L80E657()
	{
		A = [0xF2C1 + X];
		
		if (N == 0)
			return this.L80E663();

		A = [0x1520];
		
		if (Z == 0)
			return this.L80E67E();

		return this.L80E67C();
	}

	public void L80E663()
	{
		C = 1;
		A = [0x12];
		A -= [0xF2BF + X] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0xF2C1 + X] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E67A();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E67A()
	{
		
		if (N == 0)
			return this.L80E67E();

	}

	public void L80E67C()
	{
		C = 0;
		return;
	}

	public void L80E67E()
	{
		C = 1;
		return;
	}

	public void L80E680()
	{
		A = 0x000F;
		[0x7E5BCF] = A;
		A = 0x0000;
		[0x7E5BD1] = A;
		A = 0x000F;
		[0x7E5BD3] = A;
		A = 0x0000;
		[0x7E5BD5] = A;
		A = 0x0008;
		[0x7E5BD7] = A;
		A = 0x0000;
		[0x7E5BD9] = A;
		A = 0x0000;
		[0x7E5BC7] = A;
		A = 0x0000;
		[0x7E5BC9] = A;
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x80F233 + X];
		[0x7E5BE3] = A;
		A = [0x80F235 + X];
		[0x7E5BE5] = A;
		A = [0x80F237 + X];
		[0x7E5BE7] = A;
		A = [0x80F239 + X];
		[0x7E5BE9] = A;
		A = 0x0000;
		[0x7E5BCB] = A;
		[0x7E5BCD] = A;
		return;
	}

	public void L80E6EB()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L80E6FA();

		return this.L80EF67();
	}

	public void L80E6FA()
	{
		this.L80E455();
		
		if (C == 0)
			return this.L80E702();

		return this.L80E89C();
	}

	public void L80E702()
	{
		A = [0x197C];
		[0x1A] = A;
		A = [0x197E];
		[0x1C] = A;
		A = [0x1C];
		
		if (N == 0)
			return this.L80E725();

		C = 0;
		A = [0x1A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1A] = A;
		A = [0x1C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1C] = A;
	}

	public void L80E725()
	{
		A = [0x14D8];
		temp = A - 0xFFD0;
		
		if (N == 1)
			return this.L80E740();

		temp = A - 0x0130;
		
		if (N == 0)
			return this.L80E740();

		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80E74E();
	}

	public void L80E740()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80E74E();
	}

	public void L80E74E()
	{
		A = [0x197C];
		[0x00] = A;
		A = [0x197E];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14DE] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14E0] - !C;
		[0x03] = A;
		A = [0x22];
		[0x06] = A;
		A = [0x24];
		[0x09] = A;
		A = [0x03];
		
		if (N == 0)
			return this.L80E788();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E788()
	{
		A = [0x09];
		
		if (N == 0)
			return this.L80E7A1();

		C = 0;
		A = [0x06];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x06] = A;
		A = [0x09];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x09] = A;
	}

	public void L80E7A1()
	{
		A = [0x01];
		[0x2C] = A;
		A = [0x03];
		[0x2D] = A;
		A = [0x07];
		[0x2E] = A;
		A = [0x09];
		[0x2F] = A;
		this.L8086B1();
		A = [0x2C];
		A >>= 1;
		[0x26] = A;
		A = [0x1B];
		[0x28] = A;
		this.L8085A5();
		A = [0x7E5BC3];
		C = 1;
		A -= [0x7E5BC7] - !C;
		
		if (N == 0)
			return this.L80E7D1();

		A ^= 0xFFFF;
		A++;
	}

	public void L80E7D1()
	{
		temp = A - [0x2B];
		
		if (Z == 1)
			return this.L80E7DA();

		
		if (N == 1)
			return this.L80E7DA();

		return this.L80E871();
	}

	public void L80E7DA()
	{
		A = [0x197C];
		[0x00] = A;
		A = [0x197E];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14DE] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14E0] - !C;
		[0x03] = A;
		A = [0x03];
		
		if (N == 0)
			return this.L80E80C();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E80C()
	{
		C = 1;
		A = [0x00];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x03];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E821();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E821()
	{
		
		if (N == 0)
			return this.L80E83B();

		A = 0x0000;
		[0x22] = A;
		A = 0x0000;
		[0x24] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80E86F();
	}

	public void L80E83B()
	{
		C = 1;
		A = [0x197C];
		A -= [0x14DE] - !C;
		[0x88] = A;
		A = [0x197E];
		A -= [0x14E0] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E854();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E854()
	{
		
		if (N == 1)
			return this.L80E86D();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
		return this.L80E86F();
	}

	public void L80E86D()
	{
		return this.L80E86F();
	}

	public void L80E86F()
	{
		return this.L80E892();
	}

	public void L80E871()
	{
		A = [0x7E5BC3];
		temp = A - [0x7E5BC7];
		
		if (N == 0)
			return this.L80E890();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
	}

	public void L80E890()
	{
		return this.L80E892();
	}

	public void L80E892()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
	}

	public void L80E89C()
	{
		return;
	}

	public void L80E89D()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L80E8AC();

		return this.L80F060();
	}

	public void L80E8AC()
	{
		this.L80E49B();
		
		if (C == 0)
			return this.L80E8B4();

		return this.L80EA31();
	}

	public void L80E8B4()
	{
		A = [0x1988];
		[0x1A] = A;
		A = [0x198A];
		[0x1C] = A;
		A = [0x1C];
		
		if (N == 0)
			return this.L80E8D7();

		C = 0;
		A = [0x1A];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1A] = A;
		A = [0x1C];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1C] = A;
	}

	public void L80E8D7()
	{
		A = [0x7E39CB];
		[0x22] = A;
		A = [0x7E39CD];
		[0x24] = A;
		A = [0x1988];
		[0x00] = A;
		A = [0x198A];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14EC] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14EE] - !C;
		[0x03] = A;
		A = [0x22];
		[0x06] = A;
		A = [0x24];
		[0x09] = A;
		A = [0x03];
		
		if (N == 0)
			return this.L80E91D();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E91D()
	{
		A = [0x09];
		
		if (N == 0)
			return this.L80E936();

		C = 0;
		A = [0x06];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x06] = A;
		A = [0x09];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x09] = A;
	}

	public void L80E936()
	{
		A = [0x01];
		[0x2C] = A;
		A = [0x03];
		[0x2D] = A;
		A = [0x07];
		[0x2E] = A;
		A = [0x09];
		[0x2F] = A;
		this.L8086B1();
		A = [0x2C];
		A >>= 1;
		[0x26] = A;
		A = [0x1B];
		[0x28] = A;
		this.L8085A5();
		A = [0x7E5BC5];
		C = 1;
		A -= [0x7E5BC9] - !C;
		
		if (N == 0)
			return this.L80E966();

		A ^= 0xFFFF;
		A++;
	}

	public void L80E966()
	{
		temp = A - [0x2B];
		
		if (Z == 1)
			return this.L80E96F();

		
		if (N == 1)
			return this.L80E96F();

		return this.L80EA06();
	}

	public void L80E96F()
	{
		A = [0x1988];
		[0x00] = A;
		A = [0x198A];
		[0x03] = A;
		C = 1;
		A = [0x00];
		A -= [0x14EC] - !C;
		[0x00] = A;
		A = [0x03];
		A -= [0x14EE] - !C;
		[0x03] = A;
		A = [0x03];
		
		if (N == 0)
			return this.L80E9A1();

		C = 0;
		A = [0x00];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x00] = A;
		A = [0x03];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x03] = A;
	}

	public void L80E9A1()
	{
		C = 1;
		A = [0x00];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x03];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E9B6();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E9B6()
	{
		
		if (N == 0)
			return this.L80E9D0();

		A = 0x0000;
		[0x22] = A;
		A = 0x0000;
		[0x24] = A;
		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		return this.L80EA04();
	}

	public void L80E9D0()
	{
		C = 1;
		A = [0x1988];
		A -= [0x14EC] - !C;
		[0x88] = A;
		A = [0x198A];
		A -= [0x14EE] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80E9E9();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80E9E9()
	{
		
		if (N == 1)
			return this.L80EA02();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
		return this.L80EA04();
	}

	public void L80EA02()
	{
		return this.L80EA04();
	}

	public void L80EA04()
	{
		return this.L80EA27();
	}

	public void L80EA06()
	{
		A = [0x7E5BC5];
		temp = A - [0x7E5BC9];
		
		if (N == 0)
			return this.L80EA25();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x22] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x24] = A;
	}

	public void L80EA25()
	{
		return this.L80EA27();
	}

	public void L80EA27()
	{
		A = [0x22];
		[0x198C] = A;
		A = [0x24];
		[0x198E] = A;
	}

	public void L80EA31()
	{
		return;
	}

	public void L80EA43()
	{
		A = [0x7E3983];
		
		if (Z == 0)
			return this.L80EA4C();

		return this.L80E6EB();
	}

	public void L80EA4C()
	{
		this.L80E455();
		
		if (C == 0)
			return this.L80EA54();

		return this.L80ECB0();
	}

	public void L80EA54()
	{
		A = [0x14E2];
		A |= [0x14E4];
		
		if (Z == 1)
			return this.L80EAB7();

		A = [0x1980];
		A |= [0x1982];
		
		if (Z == 1)
			return this.L80EAB7();

		A = [0x14DE];
		[0x12] = A;
		A = [0x14E0];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x197C] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x197E] - !C;
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80EA96();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EA96()
	{
		C = 1;
		A = [0x12];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14];
		A -= 0x0002 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80EAAD();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EAAD()
	{
		
		if (C == 1)
			return this.L80EAC5();

		A = [0x14E0];
		A ^= [0x197E];
		
		if (N == 1)
			return this.L80EAC5();

	}

	public void L80EAB7()
	{
		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80EAD3();
	}

	public void L80EAC5()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80EAD3();
	}

	public void L80EAD3()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x14DE] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x14E0] - !C;
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80EB05();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EB05()
	{
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		A = [0x22];
		[0x2E] = A;
		A = [0x24];
		[0x30] = A;
		this.L809DE5();
		A = [0x2A];
		[0x12] = A;
		A = [0x2C];
		[0x14] = A;
		A = [0x14E2];
		[0x1A] = A;
		A = [0x14E4];
		[0x1C] = A;
		A = [0x1A];
		[0x26] = A;
		A = [0x1C];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x1A] = A;
		A = [0x32];
		[0x1C] = A;
		A = [0x1C];
		Cpu.ROL();
		Cpu.ROR(0x1C);
		Cpu.ROR(0x1A);
		C = 0;
		A = [0x1A];
		A += [0x14DE] + C;
		[0x1A] = A;
		A = [0x1C];
		A += [0x14E0] + C;
		[0x1C] = A;
		A = [0x1A];
		[0x26] = A;
		A = [0x1C];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x1A] = A;
		A = [0x32];
		[0x1C] = A;
		C = 0;
		A = [0x1A];
		A += 0x0000 + C;
		[0x1A] = A;
		A = [0x1C];
		A += [0x7E5BC3] + C;
		[0x1C] = A;
		C = 1;
		A = [0x1A];
		A -= 0x0000 - !C;
		[0x1A] = A;
		A = [0x1C];
		A -= [0x7E5BC7] - !C;
		[0x1C] = A;
		A = [0x197C];
		[0x16] = A;
		A = [0x197E];
		[0x18] = A;
		C = 0;
		A = [0x16];
		A += [0x14DE] + C;
		[0x16] = A;
		A = [0x18];
		A += [0x14E0] + C;
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x18];
		Cpu.ROL();
		Cpu.ROR(0x18);
		Cpu.ROR(0x16);
		A = [0x7E5BC3];
		C = 1;
		A -= [0x7E5BC7] - !C;
		
		if (N == 0)
			return this.L80EBE4();

		A ^= 0xFFFF;
		A++;
	}

	public void L80EBE4()
	{
		temp = A - 0x0002;
		
		if (C == 0)
			return this.L80EBEC();

		return this.L80EC53();
	}

	public void L80EBEC()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		C = 1;
		A = [0x12];
		A -= [0x14DE] - !C;
		[0x12] = A;
		A = [0x14];
		A -= [0x14E0] - !C;
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80EC1E();

		C = 0;
		A = [0x12];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x12] = A;
		A = [0x14];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x14] = A;
	}

	public void L80EC1E()
	{
		C = 1;
		A = [0x12];
		A -= [0x22] - !C;
		[0x88] = A;
		A = [0x14];
		A -= [0x24] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80EC33();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EC33()
	{
		
		if (Z == 1)
			return this.L80EC39();

		
		if (C == 0)
			return this.L80EC39();

		return this.L80EC53();
	}

	public void L80EC39()
	{
		A = 0x0000;
		[0x1980] = A;
		A = 0x0000;
		[0x1982] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80ECB0();
	}

	public void L80EC53()
	{
		C = 1;
		A = [0x1A];
		A -= [0x16] - !C;
		[0x88] = A;
		A = [0x1C];
		A -= [0x18] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L80EC68();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L80EC68()
	{
		
		if (N == 1)
			return this.L80EC87();

		return this.L80EC7A();
	}

	public void L80EC7A()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
		return this.L80ECB0();
	}

	public void L80EC87()
	{
		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1980] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1982] = A;
		return this.L80ECB0();
	}

	public void L80ECB0()
	{
		return;
	}

	public void L80EE37()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x14E0];
		A ^= [0x197E];
		
		if (N == 0)
			return this.L80EE47();

		this.L80EA43();
		return this.L80EE59();
	}

	public void L80EE47()
	{
		A = [0x1AED];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x81EF48 + X];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xEE5B + X)]();
	}

	public void L80EE59()
	{
		B = Stack.Pop();
		return;
	}

	public void L80EE67()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80EE97();
		A = [0x14E0];
		A ^= [0x197E];
		
		if (N == 0)
			return this.L80EE7B();

		this.L80EE37();
		return this.L80EE83();
	}

	public void L80EE7B()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		return [(0xEE85 + X)]();
	}

	public void L80EE83()
	{
		B = Stack.Pop();
		return;
	}

	public void L80EE97()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		A = [0x80EF45 + X];
		[0x14] = A;
		A ^= 0xFFFF;
		A++;
		[0x12] = A;
		A = [0x7E5BC3];
		temp = A - [0x12];
		
		if (N == 1)
			return this.L80EEBC();

		temp = A - [0x14];
		
		if (N == 0)
			return this.L80EEBC();

		this.L80EEC5();
		this.L80EEED();
		return this.L80EEC4();
	}

	public void L80EEBC()
	{
		this.L80EED8();
		this.L80EF17();
		return this.L80EEC4();
	}

	public void L80EEC4()
	{
		return;
	}

	public void L80EEC5()
	{
		A = [0x1AE1];
		A++;
		
		if (Z == 1)
			return this.L80EECE();

		[0x1AE1] = A;
	}

	public void L80EECE()
	{
		A = [0x1AE3];
		
		if (Z == 1)
			return this.L80EED7();

		A--;
		[0x1AE3] = A;
	}

	public void L80EED7()
	{
		return;
	}

	public void L80EED8()
	{
		A = [0x1AE1];
		temp = A - 0x0258;
		
		if (C == 1)
			return this.L80EEE6();

		A = 0x000A;
		[0x1AE3] = A;
	}

	public void L80EEE6()
	{
		A = 0x0000;
		[0x1AE1] = A;
		return;
	}

	public void L80EEED()
	{
		A = [0x1AE9];
		A++;
		
		if (Z == 1)
			return this.L80EEF6();

		[0x1AE9] = A;
	}

	public void L80EEF6()
	{
		A = [0x1AEB];
		
		if (Z == 1)
			return this.L80EEFF();

		A--;
		[0x1AEB] = A;
	}

	public void L80EEFF()
	{
		A = [0x1AED];
		A <<= 1;
		X = A;
		A = [0x80EF55 + X];
		temp = A - [0x1AEB];
		
		if (C == 0)
			return this.L80EF16();

		A = [0x1AED];
		
		if (Z == 1)
			return this.L80EF16();

		A--;
		[0x1AED] = A;
	}

	public void L80EF16()
	{
		return;
	}

	public void L80EF17()
	{
		A = [0x1AE9];
		
		if (Z == 1)
			return this.L80EF2F();

		A = [0x1AEB];
		
		if (Z == 0)
			return this.L80EF23();

		return this.L80EF2F();
	}

	public void L80EF23()
	{
		A = [0x1AED];
		A++;
		temp = A - 0x0008;
		
		if (C == 1)
			return this.L80EF2F();

		[0x1AED] = A;
	}

	public void L80EF2F()
	{
		A = [0x1AE9];
		temp = A - 0x0258;
		
		if (C == 1)
			return this.L80EF3E();

		A = [0x80EF65];
		[0x1AEB] = A;
	}

	public void L80EF3E()
	{
		A = 0x0000;
		[0x1AE9] = A;
		return;
	}

	public void L80EF67()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L80EF76();

		return this.L80E6EB();
	}

	public void L80EF76()
	{
		this.L80E455();
		
		if (C == 0)
			return this.L80EF7E();

		return this.L80F05F();
	}

	public void L80EF7E()
	{
		A = [0x14D8];
		temp = A - 0xFFD0;
		
		if (N == 1)
			return this.L80EF99();

		temp = A - 0x0130;
		
		if (N == 0)
			return this.L80EF99();

		A = [0x7E39A3];
		[0x22] = A;
		A = [0x7E39A5];
		[0x24] = A;
		return this.L80EFA7();
	}

	public void L80EF99()
	{
		A = [0x7E39A7];
		[0x22] = A;
		A = [0x7E39A9];
		[0x24] = A;
		return this.L80EFA7();
	}

	public void L80EFA7()
	{
		P |= 0x20;
		A = [0x197D];
		[0x12] = A;
		A = [0x197E];
		[0x13] = A;
		A = [0x14DF];
		[0x14] = A;
		A = [0x14E0];
		[0x15] = A;
		P &= ~0x20;
		A = [0x12];
		C = 1;
		A -= [0x14] - !C;
		[0x12] = A;
		A = [0x12];
		
		if (N == 1)
			return this.L80EFD2();

		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		return this.L80EFE0();
	}

	public void L80EFD2()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		A ^= 0xFFFF;
		A++;
	}

	public void L80EFE0()
	{
		[0x12] = A;
		A = [0x7E5BC7];
		C = 1;
		A -= [0x7E5BC3] - !C;
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80EFF5();

		A ^= 0xFFFF;
		A++;
	}

	public void L80EFF5()
	{
		temp = A - 0x0003;
		
		if (C == 1)
			return this.L80F01E();

		A = [0x12];
		
		if (N == 0)
			return this.L80F002();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F002()
	{
		temp = A - 0x0004;
		
		if (C == 1)
			return this.L80F01E();

		A = 0x0000;
		[0x1980] = A;
		[0x1982] = A;
		A = [0x14DE];
		[0x197C] = A;
		A = [0x14E0];
		[0x197E] = A;
		return this.L80F05F();
	}

	public void L80F01E()
	{
		A = [0x12];
		
		if (N == 1)
			return this.L80F02D();

		A <<= 1;
		X = A;
		A = [0x14];
		C = 1;
		A -= [0x7F0412 + X] - !C;
		return this.L80F03A();
	}

	public void L80F02D()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		X = A;
		A = [0x14];
		C = 0;
		A += [0x7F0412 + X] + C;
	}

	public void L80F03A()
	{
		
		if (N == 1)
			return this.L80F055();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x1980] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x1982] = A;
		return this.L80F05F();
	}

	public void L80F055()
	{
		A = [0x22];
		[0x1980] = A;
		A = [0x24];
		[0x1982] = A;
	}

	public void L80F05F()
	{
		return;
	}

	public void L80F060()
	{
		X = [0x14D6];
		A = [0x80EA32 + X];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L80F06F();

		return this.L80E89D();
	}

	public void L80F06F()
	{
		this.L80E49B();
		
		if (C == 0)
			return this.L80F077();

		return this.L80F158();
	}

	public void L80F077()
	{
		A = [0x14E6];
		temp = A - 0xFFD0;
		
		if (N == 1)
			return this.L80F092();

		temp = A - 0x0130;
		
		if (N == 0)
			return this.L80F092();

		A = [0x7E39CB];
		[0x22] = A;
		A = [0x7E39CD];
		[0x24] = A;
		return this.L80F0A0();
	}

	public void L80F092()
	{
		A = [0x7E39CF];
		[0x22] = A;
		A = [0x7E39D1];
		[0x24] = A;
		return this.L80F0A0();
	}

	public void L80F0A0()
	{
		P |= 0x20;
		A = [0x1989];
		[0x12] = A;
		A = [0x198A];
		[0x13] = A;
		A = [0x14ED];
		[0x14] = A;
		A = [0x14EE];
		[0x15] = A;
		P &= ~0x20;
		A = [0x12];
		C = 1;
		A -= [0x14] - !C;
		[0x12] = A;
		A = [0x12];
		
		if (N == 1)
			return this.L80F0CB();

		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		return this.L80F0D9();
	}

	public void L80F0CB()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		A <<= 1;
		A = (A >> 4) | (A << 4);
		A &= 0x00FF;
		A ^= 0xFFFF;
		A++;
	}

	public void L80F0D9()
	{
		[0x12] = A;
		A = [0x7E5BC9];
		C = 1;
		A -= [0x7E5BC5] - !C;
		[0x14] = A;
		A = [0x14];
		
		if (N == 0)
			return this.L80F0EE();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F0EE()
	{
		temp = A - 0x0003;
		
		if (C == 1)
			return this.L80F117();

		A = [0x12];
		
		if (N == 0)
			return this.L80F0FB();

		A ^= 0xFFFF;
		A++;
	}

	public void L80F0FB()
	{
		temp = A - 0x0004;
		
		if (C == 1)
			return this.L80F117();

		A = 0x0000;
		[0x198C] = A;
		[0x198E] = A;
		A = [0x14EC];
		[0x1988] = A;
		A = [0x14EE];
		[0x198A] = A;
		return this.L80F158();
	}

	public void L80F117()
	{
		A = [0x12];
		
		if (N == 1)
			return this.L80F126();

		A <<= 1;
		X = A;
		A = [0x14];
		C = 1;
		A -= [0x7F0412 + X] - !C;
		return this.L80F133();
	}

	public void L80F126()
	{
		A ^= 0xFFFF;
		A++;
		A <<= 1;
		X = A;
		A = [0x7F0412 + X];
		C = 0;
		A += [0x14] + C;
	}

	public void L80F133()
	{
		
		if (N == 1)
			return this.L80F14E();

		C = 0;
		A = [0x22];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x198C] = A;
		A = [0x24];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x198E] = A;
		return this.L80F158();
	}

	public void L80F14E()
	{
		A = [0x22];
		[0x198C] = A;
		A = [0x24];
		[0x198E] = A;
	}

	public void L80F158()
	{
		return;
	}

	public void L80F159()
	{
		Stack.Push(P);
		Stack.Push(X);
		P &= ~0x30;
		[0x12] = 0;
		[0x14] = 0;
		[0x22] = 0;
		A = 0x0080;
		[0x24] = A;
	}

	public void L80F168()
	{
		A = [0x12];
		[0x16] = A;
		A = [0x14];
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x16];
		[0x2A] = A;
		A = [0x18];
		[0x2C] = A;
		A = [0x7E39A3];
		[0x2E] = A;
		A = [0x7E39A5];
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x16] = A;
		A = [0x2C];
		[0x18] = A;
		A = [0x16];
		A >>= 1;
		A ^= 0xFFFF;
		A++;
		X = [0x22];
		[0x7F0412 + X] = A;
		A = [0x12];
		[0x16] = A;
		A = [0x14];
		[0x18] = A;
		A = [0x16];
		[0x26] = A;
		A = [0x18];
		[0x28] = A;
		A = [0x12];
		[0x2A] = A;
		A = [0x14];
		[0x2C] = A;
		this.L809D7D();
		A = [0x30];
		[0x16] = A;
		A = [0x32];
		[0x18] = A;
		A = [0x16];
		[0x2A] = A;
		A = [0x18];
		[0x2C] = A;
		A = [0x7E39CB];
		[0x2E] = A;
		A = [0x7E39CD];
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x16] = A;
		A = [0x2C];
		[0x18] = A;
		A = [0x16];
		A >>= 1;
		A ^= 0xFFFF;
		A++;
		X = [0x22];
		[0x7F0412 + X] = A;
		C = 0;
		A = [0x12];
		A += 0x4000 + C;
		[0x12] = A;
		A = [0x14];
		A += 0x0000 + C;
		[0x14] = A;
		A = [0x22];
		C = 0;
		A += 0x0002 + C;
		[0x22] = A;
		[0x24]--;
		
		if (Z == 1)
			return this.L80F230();

		return this.L80F168();
	}

	public void L80F230()
	{
		X = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L818001()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L81800F();
		A = [0x1ACF];
		[0x1AD1] = A;
		B = Stack.Pop();
		return;
	}

	public void L81800F()
	{
		A = [0x1ACF];
		
		if (Z == 1)
			return this.L818049();

		temp = A - [0x1AD1];
		
		if (Z == 1)
			return this.L818042();

		A <<= 1;
		X = A;
		A = [0x804A + X];
		[0x1ACB] = A;
		[0x1ACD] = 0;
		A = 0x4000;
		temp = A & [0x1AC3]; [0x1AC3] |= A;
		A = 0x8000;
		temp = A & [0x1AC3]; [0x1AC3] &= ~A;
		A = 0xFFFF;
		[0x1AC9] = A;
		A = [0x1AC1];
		A &= 0xFFFC;
		A |= 0x0000;
		[0x1AC1] = A;
	}

	public void L818042()
	{
		this.L818066();
		this.L81816E();
	}

	public void L818049()
	{
		return;
	}

	public void L818066()
	{
		A = [0x1AC3];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L818092();

		A = [0x1AC1];
		temp = A & 0x0008;
		
		if (Z == 1)
			return this.L818079();

		[0x1ACD]++;
	}

	public void L818079()
	{
		A = [0x1ACD];
		
		if (Z == 0)
			return this.L81808B();

	}

	public void L81807E()
	{
		this.L818093();
		
		if (C == 1)
			return this.L818086();

		this.L8180C7();
	}

	public void L818086()
	{
		A = [0x1ACD];
		
		if (Z == 1)
			return this.L81807E();

	}

	public void L81808B()
	{
		A = [0x1ACD];
		A--;
		[0x1ACD] = A;
	}

	public void L818092()
	{
		return;
	}

	public void L818093()
	{
		X = [0x1ACB];
		A = [0x0000 + X];
		A &= 0x00FF;
		temp = A - 0x0040;
		
		if (Z == 0)
			return this.L8180A6();

		this.L8180A8();
		C = 1;
		return;
	}

	public void L8180A6()
	{
		C = 0;
		return;
	}

	public void L8180A8()
	{
		X = [0x1ACB];
		A = [0x0002 + X];
		[0x01] = A;
		A = [0x0001 + X];
		[0x00] = A;
		A = [0x1ACB];
		C = 0;
		A += 0x0004 + C;
		[0x1ACB] = A;
		this.L8180C4();
		return;
	}

	public void L8180C4()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L8180C7()
	{
		A = [0x1AC1];
		A &= 0x0003;
		temp = A - 0x0000;
		
		if (Z == 1)
			return this.L8180DE();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L81811E();

		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L818146();

	}

	public void L8180DC()
	{
		return this.L8180DC();
	}

	public void L8180DE()
	{
		X = [0x1ACB];
		A = [0x0000 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L8180EE();

		A &= 0x007F;
		return this.L8180F1();
	}

	public void L8180EE()
	{
		A |= 0xFF80;
	}

	public void L8180F1()
	{
		C = 0;
		A += [0x1AC5] + C;
		[0x1AC5] = A;
		A = [0x0001 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L818105();

		A &= 0x007F;
		return this.L818108();
	}

	public void L818105()
	{
		A |= 0xFF80;
	}

	public void L818108()
	{
		C = 0;
		A += [0x1AC7] + C;
		[0x1AC7] = A;
		A = [0x1ACB];
		A++;
		A++;
		[0x1ACB] = A;
		A = 0x0001;
		[0x1ACD] = A;
		return;
	}

	public void L81811E()
	{
		X = [0x1ACB];
		A = [0x0000 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L81812E();

		A &= 0x007F;
		return this.L818131();
	}

	public void L81812E()
	{
		A |= 0xFF80;
	}

	public void L818131()
	{
		C = 0;
		A += [0x1AC5] + C;
		[0x1AC5] = A;
		A = [0x1ACB];
		A++;
		[0x1ACB] = A;
		A = 0x0001;
		[0x1ACD] = A;
		return;
	}

	public void L818146()
	{
		X = [0x1ACB];
		A = [0x0000 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L818156();

		A &= 0x007F;
		return this.L818159();
	}

	public void L818156()
	{
		A |= 0xFF80;
	}

	public void L818159()
	{
		C = 0;
		A += [0x1AC7] + C;
		[0x1AC7] = A;
		A = [0x1ACB];
		A++;
		[0x1ACB] = A;
		A = 0x0001;
		[0x1ACD] = A;
		return;
	}

	public void L81816E()
	{
		A = [0xA4];
		Stack.Push(A);
		A = [0xA3];
		Stack.Push(A);
		A = [0x1AC1];
		temp = A & 0x0004;
		
		if (Z == 1)
			return this.L81817F();

		return this.L818211();
	}

	public void L81817F()
	{
		A = [0x1AC5];
		C = 0;
		A += 0x0050 + C;
		temp = A - 0x01A0;
		
		if (C == 0)
			return this.L81818E();

		return this.L818211();
	}

	public void L81818E()
	{
		A = [0x1AC7];
		C = 0;
		A += 0x0050 + C;
		temp = A - 0x0148;
		
		if (C == 1)
			return this.L818211();

		A = [0x1AC9];
		A++;
		
		if (Z == 1)
			return this.L818211();

		this.L818218();
		A = [0x1AC5];
		[0xB0] = A;
		A = [0x1AC7];
		[0xB2] = A;
		A = [0x1AC9];
		[0xB4] = A;
		A = 0x8000;
		[0xA4] = A;
		A = 0xBD58;
		[0xA3] = A;
		A = 0xC1FF;
		[0xA8] = A;
		A = [0x1AC9];
		A &= 0x7FFF;
		temp = A - 0x0014;
		
		if (Z == 0)
			return this.L8181D1();

		A = 0x3E00;
		return this.L8181D6();
	}

	public void L8181D1()
	{
		A = 0x3C00;
		return this.L8181D6();
	}

	public void L8181D6()
	{
		[0xAA] = A;
		P |= 0x20;
		A = [0x0101];
		A &= 0xE7;
		[0x0101] = A;
		P &= ~0x20;
		A = [0xB4];
		
		if (N == 1)
			return this.L818206();

		A = [0x014C];
		A >>= 1;
		A >>= 1;
		
		if (C == 0)
			return this.L8181F4();

		A = 0x3C00;
		return this.L8181F9();
	}

	public void L8181F4()
	{
		A = 0x3000;
		return this.L8181F9();
	}

	public void L8181F9()
	{
		[0xAA] = A;
		A = 0xC1FF;
		[0xA8] = A;
		this.L8280C2();
		return this.L818211();
	}

	public void L818206()
	{
		A &= 0xFFFF;
		[0xB4] = A;
		this.L82876C();
		return this.L818211();
	}

	public void L818211()
	{
		A = Stack.Pop();
		[0xA3] = A;
		A = Stack.Pop();
		[0xA4] = A;
		return;
	}

	public void L818218()
	{
		A = [0xA4];
		Stack.Push(A);
		A = [0xA3];
		Stack.Push(A);
		A = 0x8000;
		[0xA4] = A;
		A = 0xBD58;
		[0xA3] = A;
		A = 0xC1FF;
		[0xA8] = A;
		A = 0x3E00;
		[0xAA] = A;
		A = [0x1AD3];
		
		if (Z == 1)
			return this.L818295();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L818246();

		temp = A - 0x0002;
		
		if (Z == 0)
			return this.L818244();

		return this.L8182A4();
	}

	public void L818244()
	{
		return this.L818295();
	}

	public void L818246()
	{
		A = 0x0003;
		[0x12] = A;
	}

	public void L81824B()
	{
		A = [0x014C];
		A ^= 0xFFFF;
		A >>= 1;
		C = 0;
		A += [0x12] + C;
		A &= 0x0007;
		C = 0;
		A += 0x000B + C;
		[0xB4] = A;
		X = [0x12];
		A = [0x81829C + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L81826E();

		A &= 0x007F;
		return this.L818271();
	}

	public void L81826E()
	{
		A |= 0xFF80;
	}

	public void L818271()
	{
		C = 0;
		A += [0x1AC5] + C;
		[0xB0] = A;
		A = [0x82A0 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L818284();

		A &= 0x007F;
		return this.L818287();
	}

	public void L818284()
	{
		A |= 0xFF80;
	}

	public void L818287()
	{
		C = 0;
		A += [0x1AD5] + C;
		[0xB2] = A;
		this.L82876C();
		[0x12]--;
		
		if (N == 0)
			return this.L81824B();

	}

	public void L818295()
	{
		A = Stack.Pop();
		[0xA3] = A;
		A = Stack.Pop();
		[0xA4] = A;
		return;
	}

	public void L8182A4()
	{
		A = [0x1AC5];
		[0xB0] = A;
		A = [0x1AC7];
		[0xB2] = A;
		A = 0x0013;
		[0xB4] = A;
		this.L82876C();
		return this.L818295();
	}

	public void L81865D()
	{
		return;
	}

	public void L819E82()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L819EA5();
		this.L819EA6();
		this.L819F28();
		this.L819F97();
		this.L81A0A5();
		this.L81A14A();
		this.L81A306();
		this.L81A544();
		this.L81A7D6();
		this.L81A886();
		B = Stack.Pop();
		return;
	}

	public void L819EA5()
	{
		return;
	}

	public void L819EA6()
	{
		X = 0x003E;
	}

	public void L819EA9()
	{
		A = 0xFFFF;
		[0x001826 + X] = A;
		A = 0xFFFF;
		[0x001866 + X] = A;
		A = 0xFFFF;
		[0x7E39F3 + X] = A;
		A = 0xFFFF;
		[0x7E3A33 + X] = A;
		A = 0x0000;
		[0x001926 + X] = A;
		A = 0x0000;
		[0x7E3A73 + X] = A;
		A = 0x0000;
		[0x7E3AB3 + X] = A;
		A = 0x0000;
		[0x7E3AF3 + X] = A;
		A = 0x8000;
		[0x7E3B33 + X] = A;
		A = 0x0000;
		[0x7E3B73 + X] = A;
		A = 0x8000;
		[0x7E3BB3 + X] = A;
		A = 0x0000;
		[0x7E3BF3 + X] = A;
		A = 0x8000;
		[0x7E3C33 + X] = A;
		A = 0x0000;
		[0x7E3C73 + X] = A;
		A = 0x0000;
		[0x7E3CB3 + X] = A;
		A = 0x0000;
		[0x7E3CF3 + X] = A;
		A = 0xFFFF;
		[0x7E3D33 + X] = A;
		X--;
		X--;
		
		if (N == 1)
			return this.L819F27();

		return this.L819EA9();
	}

	public void L819F27()
	{
		return;
	}

	public void L819F28()
	{
		this.L81AB0D();
		A = [0x0B3A];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		A = 0x0000;
		[0x1966] = A;
		A = [[0x00]];
		[0x1968] = A;
		A = [0x00];
		C = 0;
		A += 0x0010 + C;
		[0x00] = A;
		A = [0x0B3A];
		A <<= 1;
		[0x1AA3] = A;
		A = [0x00];
		C = 1;
		A -= [0x1AA3] - !C;
		[0x00] = A;
		A = 0x0000;
		[0x196A] = A;
		A = 0x0000;
		[0x196C] = A;
		A = [[0x00]];
		[0x196E] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1970] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1972] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x1974] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		return;
	}

	public void L819F97()
	{
		this.L81AB40();
		A = [[0x00]];
		[0x1AA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		Y = [0x1AA1];
		X = 0x0000;
		A = [0x0B38];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
	}

	public void L819FB6()
	{
		A = [[0x00]];
		[0x7E3A33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0010 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E39F3 + X] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L819FD3();

		return this.L819FB6();
	}

	public void L819FD3()
	{
		A = [0x0B38];
		A <<= 1;
		[0x1AA3] = A;
		A = [0x00];
		C = 1;
		A -= [0x1AA3] - !C;
		[0x00] = A;
		Y = [0x1AA1];
		X = 0x0000;
	}

	public void L819FE8()
	{
		A = [[0x00]];
		[0x7E3AB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3B33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3BB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3C33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3CB3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E3A73 + X] = A;
		[0x7E3AF3 + X] = A;
		[0x7E3B73 + X] = A;
		[0x7E3BF3 + X] = A;
		[0x7E3C73 + X] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A04D();

		return this.L819FE8();
	}

	public void L81A04D()
	{
		Y = [0x1AA1];
		X = 0x0000;
	}

	public void L81A053()
	{
		A = [[0x00]];
		A <<= 1;
		[0x001766 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		A <<= 1;
		[0x0017A6 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3CF3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		A <<= 1;
		[0x7E3D33 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001726 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A0A4();

		return this.L81A053();
	}

	public void L81A0A4()
	{
		return;
	}

	public void L81A0A5()
	{
		this.L81AB23();
		Y = 0x0040;
		X = 0x0000;
	}

	public void L81A0AE()
	{
		A = 0x0000;
		[0x7E49C3 + X] = A;
		A = [[0x00]];
		[0x7E4CC3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E4FC3 + X] = A;
		A = [[0x00]];
		[0x7E52C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E55C3 + X] = A;
		A = [[0x00]];
		[0x7E58C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E46C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [0x7E46C3 + X];
		C = 0;
		A += 0x0001 + C;
		[0x7E46C3 + X] = A;
		A = [[0x00]];
		[0x7E43C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A11D();

		return this.L81A0AE();
	}

	public void L81A11D()
	{
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		Y = 0x0040;
		X = 0x0000;
	}

	public void L81A12C()
	{
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0022 + C;
		[0x00] = A;
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81A149();

		return this.L81A12C();
	}

	public void L81A149()
	{
		return;
	}

	public void L81A14A()
	{
		Y = 0x00F8;
		X = 0x0000;
		this.L81A1B4();
		X = 0x0002;
		this.L81A1B4();
		X = 0x0004;
		this.L81A1B4();
		X = 0x0006;
		this.L81A1B4();
		X = 0x0008;
		this.L81A1B4();
		X = 0x000A;
		this.L81A1B4();
		X = 0x000C;
		this.L81A1B4();
		X = 0x000E;
		this.L81A1B4();
		X = 0x0010;
		this.L81A1B4();
		X = 0x0012;
		this.L81A1B4();
		X = 0x0014;
		this.L81A1B4();
		X = 0x0016;
		this.L81A1B4();
		X = 0x0018;
		this.L81A1B4();
		X = 0x001A;
		this.L81A1B4();
		X = 0x001C;
		this.L81A1B4();
		X = 0x001E;
		this.L81A1B4();
		X = 0x0020;
		this.L81A1B4();
		return;
	}

	public void L81A1B4()
	{
		Stack.Push(Y);
		A = [0x81A2E4 + X];
		[0x01] = A;
		A = [0x81A2C2 + X];
		[0x00] = A;
		A = [[0x00]];
		[0x1AA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [0x1AA1];
		[0x1AA3] = A;
	}

	public void L81A1D4()
	{
		A = [0x0381];
		
		if (Z == 1)
			return this.L81A1DF();

		A--;
		
		if (Z == 1)
			return this.L81A202();

		A--;
		
		if (Z == 1)
			return this.L81A225();

	}

	public void L81A1DF()
	{
		A = [0x00];
		C = 0;
		A += 0x0000 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0006 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A202()
	{
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0004 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A225()
	{
		A = [0x00];
		C = 0;
		A += 0x0004 + C;
		[0x00] = A;
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E3DC3 + X] = A;
		A = [[0x00]];
		[0x7E40C3 + X] = A;
		X = Stack.Pop();
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		return this.L81A248();
	}

	public void L81A248()
	{
		Y++;
		Y++;
		[0x1AA1]--;
		
		if (Z == 1)
			return this.L81A252();

		return this.L81A1D4();
	}

	public void L81A252()
	{
		Y = Stack.Pop();
		A = [0x1AA3];
		[0x1AA1] = A;
	}

	public void L81A259()
	{
		Stack.Push(X);
		X = Y;
		A = 0x0000;
		[0x7E49C3 + X] = A;
		A = [[0x00]];
		[0x7E4CC3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E4FC3 + X] = A;
		A = [[0x00]];
		[0x7E52C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = 0x0000;
		[0x7E55C3 + X] = A;
		A = [[0x00]];
		[0x7E58C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E46C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E43C3 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		X = Stack.Pop();
		Y++;
		Y++;
		[0x1AA1]--;
		
		if (Z == 1)
			return this.L81A2C1();

		return this.L81A259();
	}

	public void L81A2C1()
	{
		return;
	}

	public void L81A306()
	{
		this.L81AAF7();
		A = [[0x00]];
		[0x7E3997] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3999] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E399F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39A9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E3997];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39AB] = A;
		A = [0x7E3999];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39AD] = A;
		C = 0;
		A = [0x7E399B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39AF] = A;
		A = [0x7E399D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B1] = A;
		C = 0;
		A = [0x7E399F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39B3] = A;
		A = [0x7E39A1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B5] = A;
		C = 0;
		A = [0x7E39A3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39B7] = A;
		A = [0x7E39A5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39B9] = A;
		C = 0;
		A = [0x7E39A7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39BB] = A;
		A = [0x7E39A9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39BD] = A;
		A = [[0x00]];
		[0x7E39BF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39C9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CD] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39CF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39D1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E39BF];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39D3] = A;
		A = [0x7E39C1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39D5] = A;
		C = 0;
		A = [0x7E39C3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39D7] = A;
		A = [0x7E39C5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39D9] = A;
		C = 0;
		A = [0x7E39C7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39DB] = A;
		A = [0x7E39C9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39DD] = A;
		C = 0;
		A = [0x7E39CB];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39DF] = A;
		A = [0x7E39CD];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39E1] = A;
		C = 0;
		A = [0x7E39CF];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E39E3] = A;
		A = [0x7E39D1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E39E5] = A;
		return;
	}

	public void L81A544()
	{
		this.L81AB70();
		A = [[0x00]];
		[0x7E3D73] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D75] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D77] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D79] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D7F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D81] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D83] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D85] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9B] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9D] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3D9F] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA3] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA5] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA7] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DA9] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DAB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E3DAD] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001500] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x001506] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39EB] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39ED] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39EF] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		A = [[0x00]];
		[0x7E39F1] = A;
		A = [0x00];
		C = 0;
		A += 0x0002 + C;
		[0x00] = A;
		C = 0;
		A = [0x7E3D73];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D87] = A;
		A = [0x7E3D75];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D89] = A;
		C = 0;
		A = [0x7E3D77];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D8B] = A;
		A = [0x7E3D79];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D8D] = A;
		C = 0;
		A = [0x7E3D7B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D8F] = A;
		A = [0x7E3D7D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D91] = A;
		C = 0;
		A = [0x7E3D7F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D93] = A;
		A = [0x7E3D81];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D95] = A;
		C = 0;
		A = [0x7E3D83];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3D97] = A;
		A = [0x7E3D85];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3D99] = A;
		C = 0;
		A = [0x7E3D9B];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DAF] = A;
		A = [0x7E3D9D];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB1] = A;
		C = 0;
		A = [0x7E3D9F];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DB3] = A;
		A = [0x7E3DA1];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB5] = A;
		C = 0;
		A = [0x7E3DA3];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DB7] = A;
		A = [0x7E3DA5];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DB9] = A;
		C = 0;
		A = [0x7E3DA7];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DBB] = A;
		A = [0x7E3DA9];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DBD] = A;
		C = 0;
		A = [0x7E3DAB];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x7E3DBF] = A;
		A = [0x7E3DAD];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x7E3DC1] = A;
		return;
	}

	public void L81A7D6()
	{
		A = 0x0000;
		[0x1AA1] = A;
		A = 0x0080;
		[0x1AA3] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		A = [0x1968];
		[0x2E] = A;
		A = 0x0000;
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x1AA1] = A;
		A = [0x2C];
		[0x1AA3] = A;
		A = [0x1966];
		Stack.Push(A);
		A = [0x1968];
		[0x1966] = A;
		A = Stack.Pop();
		[0x1968] = A;
		A = [0x1966];
		[0x26] = A;
		A = [0x1968];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x1966] = A;
		A = [0x30];
		[0x1968] = A;
		X = 0x00F8;
	}

	public void L81A83F()
	{
		A = [0x7E3DC3 + X];
		Stack.Push(A);
		A = [0x7E40C3 + X];
		[0x7E3DC3 + X] = A;
		A = Stack.Pop();
		[0x7E40C3 + X] = A;
		A = [0x7E3DC3 + X];
		[0x26] = A;
		A = [0x7E40C3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3DC3 + X] = A;
		A = [0x30];
		[0x7E40C3 + X] = A;
		X++;
		X++;
		temp = X - 0x02A2;
		
		if (Z == 1)
			return this.L81A885();

		return this.L81A83F();
	}

	public void L81A885()
	{
		return;
	}

	public void L81A886()
	{
		A = 0x0000;
		[0x1AA1] = A;
		A = 0x0080;
		[0x1AA3] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		A = [0x7E3A33];
		[0x2E] = A;
		A = 0x0000;
		[0x30] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L8086DC();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2A];
		[0x1AA1] = A;
		A = [0x2C];
		[0x1AA3] = A;
		Y = 0x0020;
		X = 0x0000;
	}

	public void L81A8BF()
	{
		A = [0x7E3A33 + X];
		
		if (N == 1)
			return this.L81A901();

		A = [0x7E39F3 + X];
		Stack.Push(A);
		A = [0x7E3A33 + X];
		[0x7E39F3 + X] = A;
		A = Stack.Pop();
		[0x7E3A33 + X] = A;
		A = [0x7E39F3 + X];
		[0x26] = A;
		A = [0x7E3A33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E39F3 + X] = A;
		A = [0x30];
		[0x7E3A33 + X] = A;
	}

	public void L81A901()
	{
		A = [0x7E39F3 + X];
		[0x001826 + X] = A;
		A = [0x7E3A33 + X];
		[0x001866 + X] = A;
		A = [0x7E39F3 + X];
		[0x0018A6 + X] = A;
		A = [0x7E3A33 + X];
		[0x0018E6 + X] = A;
		A = [0x7E3A73 + X];
		Stack.Push(A);
		A = [0x7E3AB3 + X];
		[0x7E3A73 + X] = A;
		A = Stack.Pop();
		[0x7E3AB3 + X] = A;
		A = [0x7E3A73 + X];
		[0x26] = A;
		A = [0x7E3AB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3A73 + X] = A;
		A = [0x30];
		[0x7E3AB3 + X] = A;
		A = [0x7E3B33 + X];
		
		if (N == 1)
			return this.L81A9A2();

		A = [0x7E3AF3 + X];
		Stack.Push(A);
		A = [0x7E3B33 + X];
		[0x7E3AF3 + X] = A;
		A = Stack.Pop();
		[0x7E3B33 + X] = A;
		A = [0x7E3AF3 + X];
		[0x26] = A;
		A = [0x7E3B33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3AF3 + X] = A;
		A = [0x30];
		[0x7E3B33 + X] = A;
		return this.L81A9AF();
	}

	public void L81A9A2()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81A9AF();

		A = [0x7E3B33 + X];
		[0x7E3AF3 + X] = A;
	}

	public void L81A9AF()
	{
		A = [0x7E3BB3 + X];
		
		if (N == 1)
			return this.L81A9F4();

		A = [0x7E3B73 + X];
		Stack.Push(A);
		A = [0x7E3BB3 + X];
		[0x7E3B73 + X] = A;
		A = Stack.Pop();
		[0x7E3BB3 + X] = A;
		A = [0x7E3B73 + X];
		[0x26] = A;
		A = [0x7E3BB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3B73 + X] = A;
		A = [0x30];
		[0x7E3BB3 + X] = A;
		return this.L81AA01();
	}

	public void L81A9F4()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AA01();

		A = [0x7E3BB3 + X];
		[0x7E3B73 + X] = A;
	}

	public void L81AA01()
	{
		A = [0x7E3C33 + X];
		
		if (N == 1)
			return this.L81AA46();

		A = [0x7E3BF3 + X];
		Stack.Push(A);
		A = [0x7E3C33 + X];
		[0x7E3BF3 + X] = A;
		A = Stack.Pop();
		[0x7E3C33 + X] = A;
		A = [0x7E3BF3 + X];
		[0x26] = A;
		A = [0x7E3C33 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3BF3 + X] = A;
		A = [0x30];
		[0x7E3C33 + X] = A;
		return this.L81AA53();
	}

	public void L81AA46()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AA53();

		A = [0x7E3C33 + X];
		[0x7E3BF3 + X] = A;
	}

	public void L81AA53()
	{
		A = [0x7E3CB3 + X];
		
		if (N == 1)
			return this.L81AA98();

		A = [0x7E3C73 + X];
		Stack.Push(A);
		A = [0x7E3CB3 + X];
		[0x7E3C73 + X] = A;
		A = Stack.Pop();
		[0x7E3CB3 + X] = A;
		A = [0x7E3C73 + X];
		[0x26] = A;
		A = [0x7E3CB3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3C73 + X] = A;
		A = [0x30];
		[0x7E3CB3 + X] = A;
		return this.L81AAA5();
	}

	public void L81AA98()
	{
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L81AAA5();

		A = [0x7E3CB3 + X];
		[0x7E3C73 + X] = A;
	}

	public void L81AAA5()
	{
		X++;
		X++;
		Y--;
		
		if (Z == 1)
			return this.L81AAAD();

		return this.L81A8BF();
	}

	public void L81AAAD()
	{
		X = 0x0000;
	}

	public void L81AAB0()
	{
		A = [0x7E3DC3 + X];
		Stack.Push(A);
		A = [0x7E40C3 + X];
		[0x7E3DC3 + X] = A;
		A = Stack.Pop();
		[0x7E40C3 + X] = A;
		A = [0x7E3DC3 + X];
		[0x26] = A;
		A = [0x7E40C3 + X];
		[0x28] = A;
		A = [0x1AA1];
		[0x2A] = A;
		A = [0x1AA3];
		[0x2C] = A;
		Stack.Push(X);
		Stack.Push(Y);
		this.L80860D();
		Y = Stack.Pop();
		X = Stack.Pop();
		A = [0x2E];
		[0x7E3DC3 + X] = A;
		A = [0x30];
		[0x7E40C3 + X] = A;
		X++;
		X++;
		temp = X - 0x0080;
		
		if (Z == 1)
			return this.L81AAF6();

		return this.L81AAB0();
	}

	public void L81AAF6()
	{
		return;
	}

	public void L81AAF7()
	{
		Stack.Push(X);
		A = [0x0381];
		A <<= 1;
		C = 0;
		A += [0x0381] + C;
		X = A;
		A = [0xAB2F + X];
		[0x01] = A;
		A = [0xAB2E + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB0D()
	{
		Stack.Push(X);
		A = [0x0381];
		A <<= 1;
		C = 0;
		A += [0x0381] + C;
		X = A;
		A = [0xAB38 + X];
		[0x01] = A;
		A = [0xAB37 + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB23()
	{
		A = 0x8100;
		[0x01] = A;
		A = 0xACE1;
		[0x00] = A;
		return;
	}

	public void L81AB40()
	{
		Stack.Push(X);
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x14D6] + C;
		X = A;
		A = [0x81AB89 + X];
		[0x01] = A;
		A = [0x81AB88 + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81AB70()
	{
		Stack.Push(X);
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x14D6] + C;
		X = A;
		A = [0x81ABEF + X];
		[0x01] = A;
		A = [0x81ABEE + X];
		[0x00] = A;
		X = Stack.Pop();
		return;
	}

	public void L81E739()
	{
		Stack.Push(B);
		this.L81E741();
		B = Stack.Pop();
		return this.L81E765();
	}

	public void L81E741()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E74B();

	}

	public void L81E749()
	{
		return this.L81E749();
	}

	public void L81E74B()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E76D + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E76F + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E765()
	{
		this.L838000();
		return this.L80A0ED();
	}

	public void L81E7A7()
	{
		Stack.Push(B);
		this.L81E7AF();
		B = Stack.Pop();
		return this.L81E7D3();
	}

	public void L81E7AF()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E7B9();

	}

	public void L81E7B7()
	{
		return this.L81E7B7();
	}

	public void L81E7B9()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E7D4 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E7D6 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E7D3()
	{
		return;
	}

	public void L81E807()
	{
		A = [0x150C];
		A &= 0xDFFF;
		[0x150C] = A;
		Stack.Push(B);
		this.L81E818();
		B = Stack.Pop();
		return this.L81E83C();
	}

	public void L81E818()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E822();

	}

	public void L81E820()
	{
		return this.L81E820();
	}

	public void L81E822()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E83D + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E83F + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E83C()
	{
		return;
	}

	public void L81E870()
	{
		A = 0x0010;
		temp = A & [0x1726]; [0x1726] &= ~A;
		temp = A & [0x1728]; [0x1728] &= ~A;
		temp = A & [0x172A]; [0x172A] &= ~A;
		temp = A & [0x172C]; [0x172C] &= ~A;
		temp = A & [0x172E]; [0x172E] &= ~A;
		temp = A & [0x1730]; [0x1730] &= ~A;
		temp = A & [0x1732]; [0x1732] &= ~A;
		temp = A & [0x1734]; [0x1734] &= ~A;
		temp = A & [0x1736]; [0x1736] &= ~A;
		temp = A & [0x1738]; [0x1738] &= ~A;
		temp = A & [0x173A]; [0x173A] &= ~A;
		temp = A & [0x173C]; [0x173C] &= ~A;
		temp = A & [0x173E]; [0x173E] &= ~A;
		temp = A & [0x1740]; [0x1740] &= ~A;
		temp = A & [0x1742]; [0x1742] &= ~A;
		temp = A & [0x1744]; [0x1744] &= ~A;
		temp = A & [0x1746]; [0x1746] &= ~A;
		temp = A & [0x1748]; [0x1748] &= ~A;
		temp = A & [0x174A]; [0x174A] &= ~A;
		temp = A & [0x174C]; [0x174C] &= ~A;
		temp = A & [0x174E]; [0x174E] &= ~A;
		temp = A & [0x1750]; [0x1750] &= ~A;
		temp = A & [0x1752]; [0x1752] &= ~A;
		temp = A & [0x1754]; [0x1754] &= ~A;
		temp = A & [0x1756]; [0x1756] &= ~A;
		temp = A & [0x1758]; [0x1758] &= ~A;
		temp = A & [0x175A]; [0x175A] &= ~A;
		temp = A & [0x175C]; [0x175C] &= ~A;
		temp = A & [0x175E]; [0x175E] &= ~A;
		temp = A & [0x1760]; [0x1760] &= ~A;
		temp = A & [0x1762]; [0x1762] &= ~A;
		temp = A & [0x1764]; [0x1764] &= ~A;
		Stack.Push(B);
		this.L81E8DB();
		B = Stack.Pop();
		return this.L81E8FF();
	}

	public void L81E8DB()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E8E5();

	}

	public void L81E8E3()
	{
		return this.L81E8E3();
	}

	public void L81E8E5()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E900 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E902 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E8FF()
	{
		return;
	}

	public void L81E934()
	{
		Stack.Push(B);
		this.L81E93C();
		B = Stack.Pop();
		return this.L81E960();
	}

	public void L81E93C()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E946();

	}

	public void L81E944()
	{
		return this.L81E944();
	}

	public void L81E946()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E961 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E963 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E960()
	{
		return;
	}

	public void L81E994()
	{
		Stack.Push(B);
		this.L81E99C();
		B = Stack.Pop();
		return this.L81E9C0();
	}

	public void L81E99C()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81E9A6();

	}

	public void L81E9A4()
	{
		return this.L81E9A4();
	}

	public void L81E9A6()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81E9C1 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81E9C3 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81E9C0()
	{
		return;
	}

	public void L81E9F4()
	{
		Stack.Push(B);
		this.L81E9FC();
		B = Stack.Pop();
		return this.L81EA20();
	}

	public void L81E9FC()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81EA06();

	}

	public void L81EA04()
	{
		return this.L81EA04();
	}

	public void L81EA06()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EA21 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EA23 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81EA20()
	{
		return;
	}

	public void L81EA54()
	{
		Stack.Push(B);
		this.L81EA5C();
		B = Stack.Pop();
		return this.L81EA80();
	}

	public void L81EA5C()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81EA66();

	}

	public void L81EA64()
	{
		return this.L81EA64();
	}

	public void L81EA66()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EA81 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EA83 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81EA80()
	{
		return;
	}

	public void L81EAB4()
	{
		Stack.Push(B);
		this.L81EABC();
		B = Stack.Pop();
		return this.L81EAE0();
	}

	public void L81EABC()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81EAC6();

	}

	public void L81EAC4()
	{
		return this.L81EAC4();
	}

	public void L81EAC6()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EAE5 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EAE7 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81EAE0()
	{
		this.L80F159();
		return;
	}

	public void L81EB18()
	{
		Stack.Push(B);
		this.L81EB20();
		B = Stack.Pop();
		return this.L81EB44();
	}

	public void L81EB20()
	{
		A = [0x14D6];
		temp = A - 0x0011;
		
		if (N == 1)
			return this.L81EB2A();

	}

	public void L81EB28()
	{
		return this.L81EB28();
	}

	public void L81EB2A()
	{
		A <<= 1;
		A += [0x14D6] + C;
		X = A;
		A = [0x81EB45 + X];
		[0x0F] = A;
		P |= 0x20;
		A = [0x81EB47 + X];
		[0x11] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x000F]]();	//24-Bit Address
	}

	public void L81EB44()
	{
		return;
	}

	public void L81ECAB()
	{
		A = [0x14D6];
		temp = A - 0x000F;
		
		if (Z == 0)
			return this.L81ECB4();

		return;
	}

	public void L81ECB4()
	{
		this.L81EE0C();
		[0x151E] = 0;
		A = [0x14E0];
		
		if (N == 1)
			return this.L81ECF5();

		C = 1;
		A = [0x14DE];
		A -= [0x7E3D73] - !C;
		[0x88] = A;
		A = [0x14E0];
		A -= [0x7E3D75] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L81ECDA();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ECDA()
	{
		
		if (N == 0)
			return this.L81ECDF();

		return this.L81ED2D();
	}

	public void L81ECDF()
	{
		A = [0x7E3D73];
		[0x14DE] = A;
		A = [0x7E3D75];
		[0x14E0] = A;
		A = 0x0001;
		[0x151E] = A;
		return this.L81ED2D();
	}

	public void L81ECF5()
	{
		C = 1;
		A = [0x14DE];
		A -= [0x7E3D87] - !C;
		[0x88] = A;
		A = [0x14E0];
		A -= [0x7E3D89] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L81ED10();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ED10()
	{
		
		if (Z == 1)
			return this.L81ED17();

		
		if (N == 1)
			return this.L81ED17();

		return this.L81ED2D();
	}

	public void L81ED17()
	{
		A = [0x7E3D87];
		[0x14DE] = A;
		A = [0x7E3D89];
		[0x14E0] = A;
		A = 0x0001;
		[0x151E] = A;
		return this.L81ED2D();
	}

	public void L81ED2D()
	{
		C = 0;
		A = [0x14DA];
		A += [0x14DE] + C;
		[0x14DA] = A;
		A = [0x14DC];
		A += [0x14E0] + C;
		[0x14DC] = A;
		C = 0;
		A = [0x14EC];
		A += [0x14F0] + C;
		[0x14EC] = A;
		A = [0x14EE];
		A += [0x14F2] + C;
		[0x14EE] = A;
		[0x1520] = 0;
		A = [0x14EE];
		
		if (N == 1)
			return this.L81ED91();

		C = 1;
		A = [0x14EC];
		A -= [0x7E3D9B] - !C;
		[0x88] = A;
		A = [0x14EE];
		A -= [0x7E3D9D] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L81ED76();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81ED76()
	{
		
		if (N == 0)
			return this.L81ED7B();

		return this.L81EDC9();
	}

	public void L81ED7B()
	{
		A = [0x7E3D9B];
		[0x14EC] = A;
		A = [0x7E3D9D];
		[0x14EE] = A;
		A = 0x0001;
		[0x1520] = A;
		return this.L81EDC9();
	}

	public void L81ED91()
	{
		C = 1;
		A = [0x14EC];
		A -= [0x7E3DAF] - !C;
		[0x88] = A;
		A = [0x14EE];
		A -= [0x7E3DB1] - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L81EDAC();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81EDAC()
	{
		
		if (Z == 1)
			return this.L81EDB3();

		
		if (N == 1)
			return this.L81EDB3();

		return this.L81EDC9();
	}

	public void L81EDB3()
	{
		A = [0x7E3DAF];
		[0x14EC] = A;
		A = [0x7E3DB1];
		[0x14EE] = A;
		A = 0x0001;
		[0x1520] = A;
		return this.L81EDC9();
	}

	public void L81EDC9()
	{
		C = 0;
		A = [0x14E8];
		A += [0x14EC] + C;
		[0x14E8] = A;
		A = [0x14EA];
		A += [0x14EE] + C;
		[0x14EA] = A;
		C = 1;
		A = [0x14E2];
		A -= 0x0000 - !C;
		[0x88] = A;
		A = [0x14E4];
		A -= 0x0000 - !C;
		[0x8A] = A;
		A |= [0x88];
		
		if (Z == 1)
			return this.L81EDF5();

		A = [0x8A];
		P &= ~0x02;
	}

	public void L81EDF5()
	{
		
		if (Z == 1)
			return this.L81EDFE();

		
		if (N == 1)
			return this.L81EE03();

		A = 0x0001;
		return this.L81EE08();
	}

	public void L81EDFE()
	{
		A = 0x0000;
		return this.L81EE08();
	}

	public void L81EE03()
	{
		A = 0xFFFF;
		return this.L81EE08();
	}

	public void L81EE08()
	{
		[0x1516] = A;
		return;
	}

	public void L81EE0C()
	{
		C = 0;
		A = [0x14DE];
		A += [0x14E2] + C;
		[0x14DE] = A;
		A = [0x14E0];
		A += [0x14E4] + C;
		[0x14E0] = A;
		return;
	}

	public void L81F437()
	{
		Stack.Push(A);
		Stack.Push(X);
		Stack.Push(Y);
		Y = A;
		A = [0x1B41];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L81F454();

		A = Y;
		temp = A - 0x0004;
		
		if (N == 1)
			return this.L81F44C();

		A = 0x0003;
	}

	public void L81F44C()
	{
		temp = A - [0x150E];
		
		if (C == 0)
			return this.L81F454();

		[0x150E] = A;
	}

	public void L81F454()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = Stack.Pop();
		return;
	}

	public void L828000()
	{
		Stack.Push(P);
		P &= ~0x30;
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0xB4];
		A <<= 1;
		X = A;
		A = [0x8A2A + X];
		C = 0;
		A += 0x8A2A + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82802A();

		A = 0x8200;
		[0x01] = A;
		Y++;
		Y++;
		[0x00] = Y;
		this.L828027();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828027()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L82802A()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828054();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828045();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828057();
	}

	public void L828045()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828057();
	}

	public void L828054()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828057()
	{
		A = [0x9E];
		A <<= 1;
		A <<= 1;
		X = A;
		Y++;
		Y++;
	}

	public void L82805E()
	{
		A = [0x0000 + Y];
		
		if (N == 1)
			return this.L82807C();

		C = 0;
		A += [0xB0] + C;
		[0x7800 + X] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8280A1();

		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x82B8 + X];
		[(0x9E)] = A;
		return this.L8280A1();
	}

	public void L82807C()
	{
		C = 0;
		A += [0xB0] + C;
		[0x7800 + X] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L828095();

		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x84B8 + X];
		[(0x9E)] = A;
		return this.L8280A1();
	}

	public void L828095()
	{
		A = [0x82B6 + X];
		[0x9E] = A;
		A = [(0x9E)];
		A |= [0x84B6 + X];
		[(0x9E)] = A;
	}

	public void L8280A1()
	{
		A = [0x0002 + Y];
		C = 0;
		A += [0xB2] + C;
		[0x7801 + X] = A;
		A = [0x0003 + Y];
		[0x7802 + X] = A;
		Y++;
		Y++;
		Y++;
		Y++;
		Y++;
		X++;
		X++;
		X++;
		X++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L82805E();

		[0xA6] = X;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8280C2()
	{
		Stack.Push(P);
		P &= ~0x30;
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0xB4];
		A <<= 1;
		X = A;
		A = [0x8A2A + X];
		C = 0;
		A += 0x8A2A + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L8280EC();

		A = 0x8200;
		[0x01] = A;
		Y++;
		Y++;
		[0x00] = Y;
		this.L8280E9();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8280E9()
	{
		return [[0x0000]]();	//24-Bit Address
	}

	public void L8280EC()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828116();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828107();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828107()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828119();
	}

	public void L828116()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828119()
	{
		A = [0x7FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L828124()
	{
		[0x7FF6] = X;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82813A();

		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A |= 0x0200;
		[0x7FF3] = A;
		return this.L828146();
	}

	public void L82813A()
	{
		C = 0;
		A += [0xB0] + C;
		[0x7FF0] = A;
		A &= 0xFDFF;
		[0x7FF3] = A;
	}

	public void L828146()
	{
		C = 0;
		A = [0x0002 + Y];
		A += [0xB2] + C;
		[0x7FF1] = A;
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x7FF2] = A;
		C = 0;
		A = Y;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L828124();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8286B6()
	{
		Stack.Push(P);
		Stack.Push(B);
		P |= 0x30;
		A = [0xA5];
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		A = [0xB4];
		A <<= 1;
		Y = A;
		A = [(0xA3) + Y];
		C = 0;
		A += [0xA3] + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L8286E8();

		temp = A - 0xFFFE;
		
		if (Z == 1)
			return this.L8286DC();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L8286E2();

		return this.L8286E8();
	}

	public void L8286DC()
	{
		this.L828875();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8286E2()
	{
		this.L828927();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8286E8()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828712();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L828703();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L828715();
	}

	public void L828703()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L828715();
	}

	public void L828712()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828715()
	{
		A = [0x007FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L828721()
	{
		A = X;
		[0x007FF6] = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82873B();

		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A |= 0x0200;
		[0x007FF3] = A;
		return this.L828749();
	}

	public void L82873B()
	{
		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A &= 0xFDFF;
		[0x007FF3] = A;
	}

	public void L828749()
	{
		C = 0;
		A = [0x0002 + Y];
		A += [0xB2] + C;
		[0x007FF1] = A;
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x007FF2] = A;
		C = 0;
		A = Y;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L828721();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L82876C()
	{
		Stack.Push(P);
		Stack.Push(B);
		P |= 0x30;
		A = [0xA5];
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		A = [0xB4];
		A <<= 1;
		Y = A;
		A = [(0xA3) + Y];
		C = 0;
		A += [0xA3] + C;
		Y = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L82879E();

		temp = A - 0xFFFE;
		
		if (Z == 1)
			return this.L828792();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L828798();

		return this.L82879E();
	}

	public void L828792()
	{
		this.L828875();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828798()
	{
		this.L828927();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L82879E()
	{
		[0xA1] = A;
		A = [0xA6];
		A >>= 1;
		A >>= 1;
		[0x9E] = A;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L8287C8();

		C = 0;
		A += [0xA1] + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L8287B9();

		A <<= 1;
		A <<= 1;
		[0xA6] = A;
		return this.L8287CB();
	}

	public void L8287B9()
	{
		A = 0x0080;
		C = 1;
		A -= [0x9E] - !C;
		[0xA1] = A;
		A = 0x0200;
		[0xA6] = A;
		return this.L8287CB();
	}

	public void L8287C8()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L8287CB()
	{
		A = [0x007FF6];
		A &= 0xFF00;
		A |= [0x9E];
		X = A;
		Y++;
		Y++;
	}

	public void L8287D7()
	{
		A = X;
		[0x007FF6] = A;
		A = [0x0000 + Y];
		
		if (N == 0)
			return this.L8287F1();

		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A |= 0x0200;
		[0x007FF3] = A;
		return this.L8287FF();
	}

	public void L8287F1()
	{
		C = 0;
		A += [0xB0] + C;
		[0x007FF0] = A;
		A &= 0xFDFF;
		[0x007FF3] = A;
	}

	public void L8287FF()
	{
		A = [0x0002 + Y];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L82880C();

		A &= 0x007F;
		return this.L82880F();
	}

	public void L82880C()
	{
		A |= 0xFF80;
	}

	public void L82880F()
	{
		C = 0;
		A += [0xB2] + C;
		[0x007FF1] = A;
		C = 0;
		A += 0x0010 + C;
		temp = A - 0x0100;
		
		if (C == 0)
			return this.L828826();

		A = 0x00F0;
		[0x007FF1] = A;
	}

	public void L828826()
	{
		A = [0x0003 + Y];
		A &= [0xA8];
		A |= [0xAA];
		[0x007FF2] = A;
		A = Y;
		C = 0;
		A += 0x0005 + C;
		Y = A;
		X++;
		[0xA1]--;
		
		if (Z == 1)
			return this.L82883F();

		return this.L8287D7();
	}

	public void L82883F()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L828875()
	{
		this.L828982();
		A = [0xB4];
		temp = A - [0xB6];
		
		if (Z == 0)
			return this.L828881();

		return this.L82891F();
	}

	public void L828881()
	{
		[0xB6] = A;
		A = [0xB8];
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L82888D();

		return this.L82891E();
	}

	public void L82888D()
	{
		A = [0xBA];
		temp = A & [0xB8]; [0xB8] |= A;
		Y++;
		Y++;
	}

	public void L828893()
	{
		A = [0x0000 + Y];
		temp = A - 0xFFFF;
		
		if (Z == 0)
			return this.L82889E();

		return this.L82891E();
	}

	public void L82889E()
	{
		X = A;
		A = [0x0002 + Y];
		[0xA1] = A;
		Y++;
		Y++;
		Y++;
		Y++;
		temp = A & 0x0003;
		
		if (Z == 1)
			return this.L8288E9();

		temp = A & 0x0001;
		
		if (Z == 1)
			return this.L8288C4();

	}

	public void L8288B2()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		X++;
		X++;
		Y++;
		Y++;
		[0xA1]--;
		
		if (Z == 0)
			return this.L8288B2();

		return this.L828893();
	}

	public void L8288C4()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		A = [0x0002 + Y];
		[0x7E0002 + X] = A;
		A = X;
		C = 0;
		A += 0x0004 + C;
		X = A;
		A = Y;
		C = 0;
		A += 0x0004 + C;
		Y = A;
		A = [0xA1];
		A--;
		A--;
		[0xA1] = A;
		
		if (Z == 0)
			return this.L8288C4();

		return this.L828893();
	}

	public void L8288E9()
	{
		A = [0x0000 + Y];
		[0x7E0000 + X] = A;
		A = [0x0002 + Y];
		[0x7E0002 + X] = A;
		A = [0x0004 + Y];
		[0x7E0004 + X] = A;
		A = [0x0006 + Y];
		[0x7E0006 + X] = A;
		A = X;
		C = 0;
		A += 0x0008 + C;
		X = A;
		A = Y;
		C = 0;
		A += 0x0008 + C;
		Y = A;
		A = [0xA1];
		C = 1;
		A -= 0x0004 - !C;
		[0xA1] = A;
		
		if (Z == 0)
			return this.L8288E9();

		return this.L828893();
	}

	public void L82891E()
	{
		return;
	}

	public void L82891F()
	{
		A = [0xBA];
		A &= 0x0C00;
		temp = A & [0xB8]; [0xB8] |= A;
		return;
	}

	public void L828927()
	{
		this.L828982();
		A = [0xB4];
		temp = A - [0xB6];
		
		if (Z == 0)
			return this.L828933();

		return this.L82897A();
	}

	public void L828933()
	{
		[0xB6] = A;
		A = [0xB8];
		temp = A & 0x3200;
		
		if (Z == 0)
			return this.L828979();

		A = [0xBC];
		temp = A & [0xB8]; [0xB8] |= A;
		A = [0x0152];
		X = A;
		C = 0;
		A += 0x0009 + C;
		[0x0152] = A;
		A = [0x0002 + Y];
		[0x0155 + X] = A;
		A = [0x0006 + Y];
		[0x0159 + X] = A;
		A = [0x0008 + Y];
		[0x015B + X] = A;
		A = [0x000A + Y];
		[0x015D + X] = A;
		A = Y;
		C = 0;
		A += 0x000C + C;
		[0x0156 + X] = A;
		P |= 0x20;
		Stack.Push(B);
		A = Stack.Pop();
		[0x0158 + X] = A;
		A = 0x01;
		[0x0154] = A;
		P &= ~0x20;
	}

	public void L828979()
	{
		return;
	}

	public void L82897A()
	{
		A = [0xBC];
		A &= 0x0C00;
		temp = A & [0xB8]; [0xB8] |= A;
		return;
	}

	public void L828982()
	{
		A = [0xB8];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L82898D();

		this.L82898E();
	}

	public void L82898D()
	{
		return;
	}

	public void L82898E()
	{
		A = 0x0000;
		C = 1;
		A -= [0xBE] - !C;
		C = 1;
		A -= [0xB0] - !C;
		[0x010F] = A;
		A = 0x0000;
		C = 1;
		A -= [0xC0] - !C;
		C = 1;
		A -= [0xB2] - !C;
		[0x0111] = A;
		return;
	}

	public void L8289A7()
	{
		A = [0xB8];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8289E8();

		A = [0xB8];
		temp = A & 0x0040;
		
		if (Z == 0)
			return this.L8289C8();

		temp = A & 0x0800;
		
		if (Z == 1)
			return this.L8289C2();

		A = 0x0001;
		[0x0400] = A;
		return this.L8289C8();
	}

	public void L8289C2()
	{
		A = 0x0000;
		[0x0400] = A;
	}

	public void L8289C8()
	{
		A = [0xB8];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L8289E8();

		A = 0x8200;
		[0x01] = A;
		A = 0x89DF;
		[0x00] = A;
		this.L8087A4();
		return this.L8289E8();
	}

	public void L8289E8()
	{
		A = [0xB8];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L828A29();

		A = [0xB8];
		temp = A & 0x0020;
		
		if (Z == 0)
			return this.L828A09();

		temp = A & 0x0400;
		
		if (Z == 1)
			return this.L828A03();

		A = 0x0001;
		[0x0400] = A;
		return this.L828A09();
	}

	public void L828A03()
	{
		A = 0x0000;
		[0x0400] = A;
	}

	public void L828A09()
	{
		A = [0xB8];
		temp = A & 0x1000;
		
		if (Z == 1)
			return this.L828A29();

		A = 0x8200;
		[0x01] = A;
		A = 0x8A20;
		[0x00] = A;
		this.L8087A4();
		return this.L828A29();
	}

	public void L828A29()
	{
		return;
	}

	public void L838000()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x19EB];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L83800E();

		return this.L83813E();
	}

	public void L83800E()
	{
		A = [0x19EB];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838021();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838021();

		Y = 0x0000;
		this.L838160();
	}

	public void L838021()
	{
		A = [0x19ED];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838034();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838034();

		Y = 0x0001;
		this.L838160();
	}

	public void L838034()
	{
		A = [0x19EF];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838047();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838047();

		Y = 0x0002;
		this.L838160();
	}

	public void L838047()
	{
		A = [0x19F1];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L83805A();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L83805A();

		Y = 0x0003;
		this.L838160();
	}

	public void L83805A()
	{
		A = [0x19F3];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L83806D();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L83806D();

		Y = 0x0004;
		this.L838160();
	}

	public void L83806D()
	{
		A = [0x19F5];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838080();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838080();

		Y = 0x0005;
		this.L838160();
	}

	public void L838080()
	{
		A = [0x19F7];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838093();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838093();

		Y = 0x0006;
		this.L838160();
	}

	public void L838093()
	{
		A = [0x19F9];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8380A6();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L8380A6();

		Y = 0x0007;
		this.L838160();
	}

	public void L8380A6()
	{
		A = [0x19FB];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8380B9();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L8380B9();

		Y = 0x0008;
		this.L838160();
	}

	public void L8380B9()
	{
		A = [0x19FD];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8380CC();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L8380CC();

		Y = 0x0009;
		this.L838160();
	}

	public void L8380CC()
	{
		A = [0x19FF];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8380DF();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L8380DF();

		Y = 0x000A;
		this.L838160();
	}

	public void L8380DF()
	{
		A = [0x1A01];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8380F2();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L8380F2();

		Y = 0x000B;
		this.L838160();
	}

	public void L8380F2()
	{
		A = [0x1A03];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838105();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838105();

		Y = 0x000C;
		this.L838160();
	}

	public void L838105()
	{
		A = [0x1A05];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L838118();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838118();

		Y = 0x000D;
		this.L838160();
	}

	public void L838118()
	{
		A = [0x1A07];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L83812B();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L83812B();

		Y = 0x000E;
		this.L838160();
	}

	public void L83812B()
	{
		A = [0x1A09];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L83813E();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L83813E();

		Y = 0x000F;
		this.L838160();
	}

	public void L83813E()
	{
		B = Stack.Pop();
		return;
	}

	public void L838160()
	{
		[0x1A7B] = Y;
		A = [0x8140 + Y];
		A &= 0x00FF;
		[0x1A7D] = A;
		A = [0x8150 + Y];
		A &= 0x00FF;
		[0x1A7F] = A;
		A = [0x19DB + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8381CB();

		X = [0x1A7F];
		A = [0x19AC + X];
		[0x9C] = A;
		A = [0x19AB + X];
		[0x9B] = A;
	}

	public void L83818A()
	{
		A = [[0x9B]];
		A &= 0x00FF;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L838199();

		this.L838442();
		return this.L8381A8();
	}

	public void L838199()
	{
		A ^= 0x00FF;
		temp = A - 0x0039;
		
		if (C == 0)
			return this.L8381A3();

	}

	public void L8381A1()
	{
		return this.L8381A1();
	}

	public void L8381A3()
	{
		A <<= 1;
		X = A;
		return [(0x81D6 + X)]();
	}

	public void L8381A8()
	{
		X = [0x1A7D];
		A = [0x19EB + X];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L8381D5();

		Y = [0x1A7B];
		A = [0x19DB + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L83818A();

		X = [0x1A7F];
		A = [0x9C];
		[0x19AC + X] = A;
		A = [0x9B];
		[0x19AB + X] = A;
	}

	public void L8381CB()
	{
		X = [0x1A7B];
		P |= 0x20;
		[0x19DB + X]--;
		P &= ~0x20;
	}

	public void L8381D5()
	{
		return;
	}

	public void L838316()
	{
		A = 0x0000;
		[0x1514] = A;
		A = 0xD000;
		temp = A & [0x19ED]; [0x19ED] &= ~A;
		temp = A & [0x19EF]; [0x19EF] &= ~A;
		temp = A & [0x19F1]; [0x19F1] &= ~A;
		temp = A & [0x19F3]; [0x19F3] &= ~A;
		temp = A & [0x19F5]; [0x19F5] &= ~A;
		temp = A & [0x19F7]; [0x19F7] &= ~A;
		temp = A & [0x19F9]; [0x19F9] &= ~A;
		temp = A & [0x19FB]; [0x19FB] &= ~A;
		temp = A & [0x19FD]; [0x19FD] &= ~A;
		temp = A & [0x19FF]; [0x19FF] &= ~A;
		temp = A & [0x1A01]; [0x1A01] &= ~A;
		temp = A & [0x1A03]; [0x1A03] &= ~A;
		temp = A & [0x1A05]; [0x1A05] &= ~A;
		temp = A & [0x1A07]; [0x1A07] &= ~A;
		temp = A & [0x1A09]; [0x1A09] &= ~A;
		A = 0x0000;
		[0x7E3963] = A;
		[0x7E3965] = A;
		[0x7E3967] = A;
		[0x7E3969] = A;
		[0x7E396B] = A;
		[0x7E396D] = A;
		[0x7E396F] = A;
		[0x7E3971] = A;
		[0x7E3973] = A;
		[0x7E3975] = A;
		[0x7E3977] = A;
		[0x7E3979] = A;
		[0x7E397B] = A;
		[0x7E397D] = A;
		[0x7E397F] = A;
		[0x7E3981] = A;
		A = 0x0010;
		temp = A & [0x1976]; [0x1976] &= ~A;
		A = 0x0008;
		temp = A & [0x150C]; [0x150C] &= ~A;
		A = 0xFFFF;
		[0x7E5CCC] = A;
		return;
	}

	public void L838442()
	{
		X = [0x1A7F];
		A = [0x1A1B + X];
		[0x8F] = A;
		A = [0x1A1C + X];
		[0x90] = A;
		A = [[0x9B]];
		A &= 0x00FF;
		[[]] = A;
		[0xAE9BE6] = A;
		Cpu.TDC();
		A++;
		P |= 0x20;
		A = [[0x9B]];
		[0x19DB + X] = A;
		P &= ~0x20;
		[0x9B]++;
		return;
	}

	public void L838EE1()
	{
		A = [0x150C];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L838EFF();

		A = [0x197A];
		[0x12] = A;
		A = 0x0000;
		[0x14] = A;
		A = [0x1986];
		[0x16] = A;
		A = 0x0000;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838EFF()
	{
		A = [0x14DC];
		[0x12] = A;
		A = 0xFFD8;
		[0x14] = A;
		A = [0x14EA];
		[0x16] = A;
		A = 0xFFE8;
		[0x18] = A;
		return this.L838F15();
	}

	public void L838F15()
	{
		A = [0x14DC];
		C = 1;
		A -= [0x12] - !C;
		[0x7E5BC3] = A;
		C = 0;
		A += 0x0080 + C;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x14F6] + C;
		[0x14D8] = A;
		A = [0x14EA];
		C = 1;
		A -= [0x16] - !C;
		[0x7E5BC5] = A;
		C = 0;
		A += [0x1500] + C;
		C = 0;
		A += [0x1508] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		C = 0;
		A += [0x14F8] + C;
		[0x14E6] = A;
		A = [0x7E5BC3];
		C = 0;
		A += [0x7E5BCB] + C;
		[0x7E5BC3] = A;
		A = [0x7E5BC5];
		C = 0;
		A += [0x7E5BCD] + C;
		[0x7E5BC5] = A;
		A = [0x14D8];
		[0x1502] = A;
		A = [0x1500];
		C = 1;
		A -= [0x16] - !C;
		C = 0;
		A += [0x1506] + C;
		C = 0;
		A += [0x150A] + C;
		C = 0;
		A += [0x18] + C;
		[0x1504] = A;
		return;
	}

	public void L8391CD()
	{
		X = 0x003E;
	}

	public void L8391D0()
	{
		A = 0xFFFF;
		[0x16A6 + X] = A;
		A = 0x0000;
		[0x16E6 + X] = A;
		A = 0x8000;
		[0x1726 + X] = A;
		A = 0x0000;
		[0x1926 + X] = A;
		A = 0xFFFF;
		[0x1826 + X] = A;
		A = 0xFFFF;
		[0x1766 + X] = A;
		[0x17A6 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L8391D0();

		A = 0x0000;
		[0x14DA] = A;
		[0x14DC] = A;
		[0x14DE] = A;
		[0x14E0] = A;
		[0x14E2] = A;
		[0x14E4] = A;
		[0x14E8] = A;
		[0x14EA] = A;
		[0x14EC] = A;
		[0x14EE] = A;
		[0x14F0] = A;
		[0x14F2] = A;
		[0x14F4] = A;
		[0x14F6] = A;
		[0x14F8] = A;
		[0x14FA] = A;
		[0x14FC] = A;
		[0x1504] = A;
		[0x1506] = A;
		[0x1500] = A;
		[0x1508] = A;
		A = 0x0180;
		[0x14D8] = A;
		[0x14E6] = A;
		A = 0x0000;
		[0x150E] = A;
		[0x1514] = A;
		[0x1516] = A;
		[0x151A] = A;
		[0x151E] = A;
		[0x1520] = A;
		[0x1AE1] = A;
		[0x1AE3] = A;
		[0x1AE5] = A;
		[0x1AE7] = A;
		[0x1AE9] = A;
		[0x1AEB] = A;
		[0x1AED] = A;
		[0x1AEF] = A;
		[0x1AF1] = A;
		[0x1AF3] = A;
		[0x7E39E7] = A;
		[0x7E39E9] = A;
		A |= 0x1000;
		A |= 0x0800;
		A = [0x150C];
		A &= 0x4113;
		A |= 0x2000;
		[0x150C] = A;
		this.L8393B5();
		A = 0x0000;
		[0x7E5BF1] = A;
		A = 0xFFFF;
		[0x1AC9] = A;
		A = 0x8000;
		[0x1AC5] = A;
		[0x1AC7] = A;
		A = 0x0000;
		[0x1AC1] = A;
		[0x1AC3] = A;
		[0x1AD3] = A;
		[0x1AD5] = A;
		[0x1ACF] = A;
		[0x1AD1] = A;
		A = 0x0000;
		[0x7E3987] = A;
		[0x7E398B] = A;
		[0x7E3989] = A;
		[0x7E398D] = A;
		[0x7E398F] = A;
		[0x7E3993] = A;
		[0x7E3991] = A;
		[0x7E3995] = A;
		A = 0x0000;
		[0x7E5CCC] = A;
		[0x7E5D0E] = A;
		[0x7E5DAE] = A;
		[0xB8] = 0;
		A = 0xFFFF;
		[0xB6] = A;
		A = 0x0000;
		[0x1978] = A;
		[0x197A] = A;
		[0x197C] = A;
		[0x197E] = A;
		[0x1980] = A;
		[0x1982] = A;
		[0x1984] = A;
		[0x1986] = A;
		[0x1988] = A;
		[0x198A] = A;
		[0x198C] = A;
		[0x198E] = A;
		[0x1990] = A;
		[0x1992] = A;
		[0x1994] = A;
		[0x1996] = A;
		[0x1998] = A;
		[0x199A] = A;
		[0x199C] = A;
		[0x199E] = A;
		[0x19A0] = A;
		[0x19A2] = A;
		[0x19A4] = A;
		[0x19A6] = A;
		A = 0x0000;
		[0x1976] = 0;
		[0x196A] = A;
		[0x196C] = A;
		this.L80E680();
		A = 0x0000;
		[0x7E5BEB] = A;
		[0x7E5BED] = A;
		A = 0x7FFF;
		[0x001BA5] = A;
		[0x001BA7] = A;
		[0x001BA9] = A;
		[0x001BAB] = A;
		[0x001BAD] = A;
		[0x001BAF] = A;
		[0x001BB1] = A;
		[0x001BB3] = A;
		[0x001BB5] = A;
		[0x001BB7] = A;
		[0x7E5C18] = A;
		[0x7E5C1A] = A;
		[0x7E5C1C] = A;
		[0x7E5C1E] = A;
		[0x7E5C20] = A;
		[0x7E5C22] = A;
		[0x7E5C24] = A;
		[0x7E5C26] = A;
		[0x7E5C28] = A;
		[0x7E5C2A] = A;
		return;
	}

	public void L8393B5()
	{
		A = [0x50];
		[0x1B11] = A;
		A = 0x0060;
		temp = A & [0x150C]; [0x150C] &= ~A;
		A = [0x036F];
		A--;
		
		if (Z == 0)
			return this.L8393E2();

		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L8393E2();

		A = [0x036D];
		temp = A - 0x0004;
		
		if (C == 0)
			return this.L8393D9();

		A = 0x0003;
	}

	public void L8393D9()
	{
		A <<= 1;
		X = A;
		A = [0x83940E + X];
		temp = A & [0x150C]; [0x150C] |= A;
	}

	public void L8393E2()
	{
		A = [0x50];
		temp = A & 0x0210;
		
		if (Z == 1)
			return this.L83940D();

		A = 0x0060;
		temp = A & [0x150C]; [0x150C] &= ~A;
		X = 0x0000;
		A = [0x50];
		temp = A & 0x0020;
		
		if (Z == 1)
			return this.L8393FB();

		X++;
		X++;
	}

	public void L8393FB()
	{
		A = [0x50];
		temp = A & 0x0010;
		
		if (Z == 1)
			return this.L839406();

		X++;
		X++;
		X++;
		X++;
	}

	public void L839406()
	{
		A = [0x83940E + X];
		temp = A & [0x150C]; [0x150C] |= A;
	}

	public void L83940D()
	{
		return;
	}

	public void L839416()
	{
		X = 0x001E;
	}

	public void L839419()
	{
		A = 0x0000;
		[0x19EB + X] = A;
		[0x7E5CCE + X] = A;
		[0x7E5D6E + X] = A;
		[0x7E5D8E + X] = A;
		[0x7E5CEE + X] = A;
		[0x7E5D2E + X] = A;
		A = 0x0050;
		[0x7E5D0E + X] = A;
		[0x7E5D4E + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L839419();

		return;
	}

	public void L839443()
	{
		A = 0x4110;
		temp = A & [0x150C]; [0x150C] &= ~A;
		return;
	}

	public void L83955A()
	{
		A = [0x014C];
		A >>= 1;
		
		if (C == 0)
			return this.L839563();

		return this.L8396AE();
	}

	public void L839563()
	{
		A = [0x7E3963];
		
		if (Z == 1)
			return this.L83958C();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L83958C();

		A = [0x7E3943];
		[0x16] = A;
		this.L839B44();
	}

	public void L83958C()
	{
		A = [0x7E3967];
		
		if (Z == 1)
			return this.L8395B5();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8395B5();

		A = [0x7E3947];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395B5()
	{
		A = [0x7E396B];
		
		if (Z == 1)
			return this.L8395DE();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8395DE();

		A = [0x7E394B];
		[0x16] = A;
		this.L839B44();
	}

	public void L8395DE()
	{
		A = [0x7E396F];
		
		if (Z == 1)
			return this.L839607();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839607();

		A = [0x7E394F];
		[0x16] = A;
		this.L839B44();
	}

	public void L839607()
	{
		A = [0x7E3973];
		
		if (Z == 1)
			return this.L839630();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839630();

		A = [0x7E3953];
		[0x16] = A;
		this.L839B44();
	}

	public void L839630()
	{
		A = [0x7E3977];
		
		if (Z == 1)
			return this.L839659();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839659();

		A = [0x7E3957];
		[0x16] = A;
		this.L839B44();
	}

	public void L839659()
	{
		A = [0x7E397B];
		
		if (Z == 1)
			return this.L839682();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839682();

		A = [0x7E395B];
		[0x16] = A;
		this.L839B44();
	}

	public void L839682()
	{
		A = [0x7E397F];
		
		if (Z == 1)
			return this.L8396AB();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8396AB();

		A = [0x7E395F];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396AB()
	{
		return this.L8397F6();
	}

	public void L8396AE()
	{
		A = [0x7E3965];
		
		if (Z == 1)
			return this.L8396D7();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8396D7();

		A = [0x7E3945];
		[0x16] = A;
		this.L839B44();
	}

	public void L8396D7()
	{
		A = [0x7E3969];
		
		if (Z == 1)
			return this.L839700();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839700();

		A = [0x7E3949];
		[0x16] = A;
		this.L839B44();
	}

	public void L839700()
	{
		A = [0x7E396D];
		
		if (Z == 1)
			return this.L839729();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839729();

		A = [0x7E394D];
		[0x16] = A;
		this.L839B44();
	}

	public void L839729()
	{
		A = [0x7E3971];
		
		if (Z == 1)
			return this.L839752();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L839752();

		A = [0x7E3951];
		[0x16] = A;
		this.L839B44();
	}

	public void L839752()
	{
		A = [0x7E3975];
		
		if (Z == 1)
			return this.L83977B();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L83977B();

		A = [0x7E3955];
		[0x16] = A;
		this.L839B44();
	}

	public void L83977B()
	{
		A = [0x7E3979];
		
		if (Z == 1)
			return this.L8397A4();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8397A4();

		A = [0x7E3959];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397A4()
	{
		A = [0x7E397D];
		
		if (Z == 1)
			return this.L8397CD();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8397CD();

		A = [0x7E395D];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397CD()
	{
		A = [0x7E3981];
		
		if (Z == 1)
			return this.L8397F6();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 0)
			return this.L8397F6();

		A = [0x7E3961];
		[0x16] = A;
		this.L839B44();
	}

	public void L8397F6()
	{
		return;
	}

	public void L8397F7()
	{
		A = [0x014C];
		A >>= 1;
		
		if (C == 0)
			return this.L839800();

		return this.L83994B();
	}

	public void L839800()
	{
		A = [0x7E3963];
		
		if (Z == 1)
			return this.L839829();

		A = [0x7E3903];
		[0x12] = A;
		A = [0x7E3923];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839829();

		A = [0x7E3943];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839829()
	{
		A = [0x7E3967];
		
		if (Z == 1)
			return this.L839852();

		A = [0x7E3907];
		[0x12] = A;
		A = [0x7E3927];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839852();

		A = [0x7E3947];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839852()
	{
		A = [0x7E396B];
		
		if (Z == 1)
			return this.L83987B();

		A = [0x7E390B];
		[0x12] = A;
		A = [0x7E392B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L83987B();

		A = [0x7E394B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83987B()
	{
		A = [0x7E396F];
		
		if (Z == 1)
			return this.L8398A4();

		A = [0x7E390F];
		[0x12] = A;
		A = [0x7E392F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L8398A4();

		A = [0x7E394F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398A4()
	{
		A = [0x7E3973];
		
		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3913];
		[0x12] = A;
		A = [0x7E3933];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L8398CD();

		A = [0x7E3953];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398CD()
	{
		A = [0x7E3977];
		
		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3917];
		[0x12] = A;
		A = [0x7E3937];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L8398F6();

		A = [0x7E3957];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8398F6()
	{
		A = [0x7E397B];
		
		if (Z == 1)
			return this.L83991F();

		A = [0x7E391B];
		[0x12] = A;
		A = [0x7E393B];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L83991F();

		A = [0x7E395B];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83991F()
	{
		A = [0x7E397F];
		
		if (Z == 1)
			return this.L839948();

		A = [0x7E391F];
		[0x12] = A;
		A = [0x7E393F];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839948();

		A = [0x7E395F];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839948()
	{
		return this.L839A93();
	}

	public void L83994B()
	{
		A = [0x7E3965];
		
		if (Z == 1)
			return this.L839974();

		A = [0x7E3905];
		[0x12] = A;
		A = [0x7E3925];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839974();

		A = [0x7E3945];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839974()
	{
		A = [0x7E3969];
		
		if (Z == 1)
			return this.L83999D();

		A = [0x7E3909];
		[0x12] = A;
		A = [0x7E3929];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L83999D();

		A = [0x7E3949];
		[0x16] = A;
		this.L839BC3();
	}

	public void L83999D()
	{
		A = [0x7E396D];
		
		if (Z == 1)
			return this.L8399C6();

		A = [0x7E390D];
		[0x12] = A;
		A = [0x7E392D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L8399C6();

		A = [0x7E394D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399C6()
	{
		A = [0x7E3971];
		
		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3911];
		[0x12] = A;
		A = [0x7E3931];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L8399EF();

		A = [0x7E3951];
		[0x16] = A;
		this.L839BC3();
	}

	public void L8399EF()
	{
		A = [0x7E3975];
		
		if (Z == 1)
			return this.L839A18();

		A = [0x7E3915];
		[0x12] = A;
		A = [0x7E3935];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839A18();

		A = [0x7E3955];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A18()
	{
		A = [0x7E3979];
		
		if (Z == 1)
			return this.L839A41();

		A = [0x7E3919];
		[0x12] = A;
		A = [0x7E3939];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839A41();

		A = [0x7E3959];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A41()
	{
		A = [0x7E397D];
		
		if (Z == 1)
			return this.L839A6A();

		A = [0x7E391D];
		[0x12] = A;
		A = [0x7E393D];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839A6A();

		A = [0x7E395D];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A6A()
	{
		A = [0x7E3981];
		
		if (Z == 1)
			return this.L839A93();

		A = [0x7E3921];
		[0x12] = A;
		A = [0x7E3941];
		[0x14] = A;
		this.L839C42();
		Y = 0x0002;
		A = [[0x00] + Y];
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L839A93();

		A = [0x7E3961];
		[0x16] = A;
		this.L839BC3();
	}

	public void L839A93()
	{
		A = [0x7E3963];
		
		if (Z == 1)
			return this.L839A9E();

		A--;
		[0x7E3963] = A;
	}

	public void L839A9E()
	{
		A = [0x7E3965];
		
		if (Z == 1)
			return this.L839AA9();

		A--;
		[0x7E3965] = A;
	}

	public void L839AA9()
	{
		A = [0x7E3967];
		
		if (Z == 1)
			return this.L839AB4();

		A--;
		[0x7E3967] = A;
	}

	public void L839AB4()
	{
		A = [0x7E3969];
		
		if (Z == 1)
			return this.L839ABF();

		A--;
		[0x7E3969] = A;
	}

	public void L839ABF()
	{
		A = [0x7E396B];
		
		if (Z == 1)
			return this.L839ACA();

		A--;
		[0x7E396B] = A;
	}

	public void L839ACA()
	{
		A = [0x7E396D];
		
		if (Z == 1)
			return this.L839AD5();

		A--;
		[0x7E396D] = A;
	}

	public void L839AD5()
	{
		A = [0x7E396F];
		
		if (Z == 1)
			return this.L839AE0();

		A--;
		[0x7E396F] = A;
	}

	public void L839AE0()
	{
		A = [0x7E3971];
		
		if (Z == 1)
			return this.L839AEB();

		A--;
		[0x7E3971] = A;
	}

	public void L839AEB()
	{
		A = [0x7E3973];
		
		if (Z == 1)
			return this.L839AF6();

		A--;
		[0x7E3973] = A;
	}

	public void L839AF6()
	{
		A = [0x7E3975];
		
		if (Z == 1)
			return this.L839B01();

		A--;
		[0x7E3975] = A;
	}

	public void L839B01()
	{
		A = [0x7E3977];
		
		if (Z == 1)
			return this.L839B0C();

		A--;
		[0x7E3977] = A;
	}

	public void L839B0C()
	{
		A = [0x7E3979];
		
		if (Z == 1)
			return this.L839B17();

		A--;
		[0x7E3979] = A;
	}

	public void L839B17()
	{
		A = [0x7E397B];
		
		if (Z == 1)
			return this.L839B22();

		A--;
		[0x7E397B] = A;
	}

	public void L839B22()
	{
		A = [0x7E397D];
		
		if (Z == 1)
			return this.L839B2D();

		A--;
		[0x7E397D] = A;
	}

	public void L839B2D()
	{
		A = [0x7E397F];
		
		if (Z == 1)
			return this.L839B38();

		A--;
		[0x7E397F] = A;
	}

	public void L839B38()
	{
		A = [0x7E3981];
		
		if (Z == 1)
			return this.L839B43();

		A--;
		[0x7E3981] = A;
	}

	public void L839B43()
	{
		return;
	}

	public void L839B44()
	{
		A = [0x1866 + X];
		
		if (N == 1)
			return this.L839BA0();

		A = [[0x00]];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L839B55();

		A &= 0x007F;
		return this.L839B58();
	}

	public void L839B55()
	{
		A |= 0xFF80;
	}

	public void L839B58()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;
		
		if (C == 1)
			return this.L839BA0();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L839B76();

		A &= 0x007F;
		return this.L839B79();
	}

	public void L839B76()
	{
		A |= 0xFF80;
	}

	public void L839B79()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;
		
		if (C == 1)
			return this.L839BA0();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839BA1 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839BA0()
	{
		return;
	}

	public void L839BC3()
	{
		A = [0x1866 + X];
		
		if (N == 1)
			return this.L839C1F();

		A = [[0x00]];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L839BD4();

		A &= 0x007F;
		return this.L839BD7();
	}

	public void L839BD4()
	{
		A |= 0xFF80;
	}

	public void L839BD7()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;
		
		if (C == 1)
			return this.L839C1F();

		Y = 0x0001;
		A = [[0x00] + Y];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L839BF5();

		A &= 0x007F;
		return this.L839BF8();
	}

	public void L839BF5()
	{
		A |= 0xFF80;
	}

	public void L839BF8()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;
		
		if (C == 1)
			return this.L839C1F();

		A = 0xC1FF;
		[0xA8] = A;
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x839C20 + X];
		[0xAA] = A;
		A = [0x16];
		[0xB4] = A;
		this.L8280C2();
	}

	public void L839C1F()
	{
		return;
	}

	public void L839C42()
	{
		A = [0x7E3901];
		[0x01] = A;
		A = [0x7E3900];
		[0x00] = A;
		A = [0x12];
		A <<= 1;
		X = A;
		A = [0x1666 + X];
		A <<= 1;
		Y = A;
		A = [[0x00] + Y];
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		A = [0x14];
		A <<= 1;
		C = 0;
		A += [0x14] + C;
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		return;
	}

	public void L839C9C()
	{
		A = [0x1A81];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839CB0();

		A &= 0x7FFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839CB0()
	{
		A = [0x1A83];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839CC4();

		A &= 0x7FFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839CC4()
	{
		A = [0x1A85];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839CD8();

		A &= 0x7FFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839CD8()
	{
		A = [0x1A87];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839CEC();

		A &= 0x7FFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839CEC()
	{
		A = [0x1A89];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D00();

		A &= 0x7FFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839D00()
	{
		A = [0x1A8B];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D14();

		A &= 0x7FFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839D14()
	{
		A = [0x1A8D];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D28();

		A &= 0x7FFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839D28()
	{
		A = [0x1A8F];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D3C();

		A &= 0x7FFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839D3C()
	{
		A = [0x1A91];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D50();

		A &= 0x7FFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839D50()
	{
		A = [0x1A93];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D64();

		A &= 0x7FFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839D64()
	{
		A = [0x1A95];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D78();

		A &= 0x7FFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839D78()
	{
		A = [0x1A97];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839D8C();

		A &= 0x7FFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839D8C()
	{
		A = [0x1A99];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DA0();

		A &= 0x7FFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839DA0()
	{
		A = [0x1A9B];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DB4();

		A &= 0x7FFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839DB4()
	{
		A = [0x1A9D];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DC8();

		A &= 0x7FFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839DC8()
	{
		A = [0x1A9F];
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L839DDC();

		A &= 0x7FFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839DDC()
	{
		return;
	}

	public void L839DDD()
	{
		A = [0x1A81];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839DF1();

		A &= 0xBFFF;
		[0x1A81] = A;
		X = 0x0000;
		this.L839F1E();
	}

	public void L839DF1()
	{
		A = [0x1A83];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E05();

		A &= 0xBFFF;
		[0x1A83] = A;
		X = 0x0002;
		this.L839F1E();
	}

	public void L839E05()
	{
		A = [0x1A85];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E19();

		A &= 0xBFFF;
		[0x1A85] = A;
		X = 0x0004;
		this.L839F1E();
	}

	public void L839E19()
	{
		A = [0x1A87];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E2D();

		A &= 0xBFFF;
		[0x1A87] = A;
		X = 0x0006;
		this.L839F1E();
	}

	public void L839E2D()
	{
		A = [0x1A89];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E41();

		A &= 0xBFFF;
		[0x1A89] = A;
		X = 0x0008;
		this.L839F1E();
	}

	public void L839E41()
	{
		A = [0x1A8B];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E55();

		A &= 0xBFFF;
		[0x1A8B] = A;
		X = 0x000A;
		this.L839F1E();
	}

	public void L839E55()
	{
		A = [0x1A8D];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E69();

		A &= 0xBFFF;
		[0x1A8D] = A;
		X = 0x000C;
		this.L839F1E();
	}

	public void L839E69()
	{
		A = [0x1A8F];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E7D();

		A &= 0xBFFF;
		[0x1A8F] = A;
		X = 0x000E;
		this.L839F1E();
	}

	public void L839E7D()
	{
		A = [0x1A91];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839E91();

		A &= 0xBFFF;
		[0x1A91] = A;
		X = 0x0010;
		this.L839F1E();
	}

	public void L839E91()
	{
		A = [0x1A93];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EA5();

		A &= 0xBFFF;
		[0x1A93] = A;
		X = 0x0012;
		this.L839F1E();
	}

	public void L839EA5()
	{
		A = [0x1A95];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EB9();

		A &= 0xBFFF;
		[0x1A95] = A;
		X = 0x0014;
		this.L839F1E();
	}

	public void L839EB9()
	{
		A = [0x1A97];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839ECD();

		A &= 0xBFFF;
		[0x1A97] = A;
		X = 0x0016;
		this.L839F1E();
	}

	public void L839ECD()
	{
		A = [0x1A99];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EE1();

		A &= 0xBFFF;
		[0x1A99] = A;
		X = 0x0018;
		this.L839F1E();
	}

	public void L839EE1()
	{
		A = [0x1A9B];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839EF5();

		A &= 0xBFFF;
		[0x1A9B] = A;
		X = 0x001A;
		this.L839F1E();
	}

	public void L839EF5()
	{
		A = [0x1A9D];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839F09();

		A &= 0xBFFF;
		[0x1A9D] = A;
		X = 0x001C;
		this.L839F1E();
	}

	public void L839F09()
	{
		A = [0x1A9F];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L839F1D();

		A &= 0xBFFF;
		[0x1A9F] = A;
		X = 0x001E;
		this.L839F1E();
	}

	public void L839F1D()
	{
		return;
	}

	public void L839F1E()
	{
		A = [0x7E5C2C + X];
		[0xB0] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x0140;
		
		if (C == 1)
			return this.L839F52();

		A = [0x7E5C4C + X];
		[0xB2] = A;
		C = 0;
		A += 0x0020 + C;
		temp = A - 0x00E8;
		
		if (C == 1)
			return this.L839F52();

		A = [0x7E5C6C + X];
		[0xB4] = A;
		A = [0x7E5C8C + X];
		[0xA8] = A;
		A = [0x7E5CAC + X];
		[0xAA] = A;
		this.L8280C2();
	}

	public void L839F52()
	{
		return;
	}

	public void L858000()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		C = 1;
		A = [0x7E5E2C];
		A -= [0x197C] - !C;
		[0x7E5E2C] = A;
		A = [0x7E5E2E];
		A -= [0x197E] - !C;
		[0x7E5E2E] = A;
		C = 1;
		A = [0x7E5E30];
		A -= [0x1988] - !C;
		[0x7E5E30] = A;
		A = [0x7E5E32];
		A -= [0x198A] - !C;
		[0x7E5E32] = A;
		A = [0x7E5E2E];
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E36] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E3E] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E46] = A;
		A = [0x7E5E32];
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E3A] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E42] = A;
		temp = A - 0x8000;
		Cpu.ROR();
		[0x7E5E4A] = A;
		A = 0x0000;
		[0xAA] = A;
		A = 0xFFFF;
		[0xA8] = A;
		A = [0x7E5E2E];
		[0x14] = A;
		A = [0x7E5E32];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8609] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858092();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8580AD();

	}

	public void L858092()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x860B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8580A7();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8580AD();

	}

	public void L8580A7()
	{
		[0xB2] = A;
		this.L858681();
	}

	public void L8580AD()
	{
		A = [0x14];
		C = 0;
		A += [0x860D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8580C0();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8580DB();

	}

	public void L8580C0()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x860F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8580D5();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8580DB();

	}

	public void L8580D5()
	{
		[0xB2] = A;
		this.L858681();
	}

	public void L8580DB()
	{
		A = [0x7E5E36];
		[0x14] = A;
		A = [0x7E5E3A];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8611] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8580FA();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858115();

	}

	public void L8580FA()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8613] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85810F();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858115();

	}

	public void L85810F()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858115()
	{
		A = [0x14];
		C = 0;
		A += [0x8615] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858128();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858143();

	}

	public void L858128()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8617] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85813D();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858143();

	}

	public void L85813D()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858143()
	{
		A = [0x14];
		C = 0;
		A += [0x8619] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858156();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858171();

	}

	public void L858156()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x861B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85816B();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858171();

	}

	public void L85816B()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L858171()
	{
		A = [0x14];
		C = 0;
		A += [0x861D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858184();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85819F();

	}

	public void L858184()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x861F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858199();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85819F();

	}

	public void L858199()
	{
		[0xB2] = A;
		this.L858751();
	}

	public void L85819F()
	{
		A = [0x7E5E3E];
		[0x14] = A;
		A = [0x7E5E42];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8621] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8581BE();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8581D9();

	}

	public void L8581BE()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8623] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8581D3();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8581D9();

	}

	public void L8581D3()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8581D9()
	{
		A = [0x14];
		C = 0;
		A += [0x8625] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8581EC();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858207();

	}

	public void L8581EC()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8627] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858201();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858207();

	}

	public void L858201()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858207()
	{
		A = [0x14];
		C = 0;
		A += [0x8629] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L85821A();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858235();

	}

	public void L85821A()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x862B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85822F();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858235();

	}

	public void L85822F()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858235()
	{
		A = [0x14];
		C = 0;
		A += [0x862D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858248();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858263();

	}

	public void L858248()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x862F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85825D();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858263();

	}

	public void L85825D()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858263()
	{
		A = [0x14];
		C = 0;
		A += [0x8631] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858276();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858291();

	}

	public void L858276()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8633] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85828B();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858291();

	}

	public void L85828B()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L858291()
	{
		A = [0x14];
		C = 0;
		A += [0x8635] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8582A4();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8582BF();

	}

	public void L8582A4()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8637] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8582B9();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8582BF();

	}

	public void L8582B9()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8582BF()
	{
		A = [0x14];
		C = 0;
		A += [0x8639] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8582D2();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8582ED();

	}

	public void L8582D2()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x863B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8582E7();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8582ED();

	}

	public void L8582E7()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L8582ED()
	{
		A = [0x14];
		C = 0;
		A += [0x863D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858300();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85831B();

	}

	public void L858300()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x863F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858315();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85831B();

	}

	public void L858315()
	{
		[0xB2] = A;
		this.L8587CB();
	}

	public void L85831B()
	{
		A = [0x7E5E46];
		[0x14] = A;
		A = [0x7E5E4A];
		[0x16] = A;
		A = [0x14];
		C = 0;
		A += [0x8641] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L85833A();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858355();

	}

	public void L85833A()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8643] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85834F();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858355();

	}

	public void L85834F()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858355()
	{
		A = [0x14];
		C = 0;
		A += [0x8645] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858368();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858383();

	}

	public void L858368()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8647] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85837D();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858383();

	}

	public void L85837D()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858383()
	{
		A = [0x14];
		C = 0;
		A += [0x8649] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858396();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8583B1();

	}

	public void L858396()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x864B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8583AB();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8583B1();

	}

	public void L8583AB()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8583B1()
	{
		A = [0x14];
		C = 0;
		A += [0x864D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8583C4();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8583DF();

	}

	public void L8583C4()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x864F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8583D9();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8583DF();

	}

	public void L8583D9()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8583DF()
	{
		A = [0x14];
		C = 0;
		A += [0x8651] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8583F2();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85840D();

	}

	public void L8583F2()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8653] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858407();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85840D();

	}

	public void L858407()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85840D()
	{
		A = [0x14];
		C = 0;
		A += [0x8655] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858420();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85843B();

	}

	public void L858420()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8657] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858435();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85843B();

	}

	public void L858435()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85843B()
	{
		A = [0x14];
		C = 0;
		A += [0x8659] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L85844E();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858469();

	}

	public void L85844E()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x865B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858463();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858469();

	}

	public void L858463()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858469()
	{
		A = [0x14];
		C = 0;
		A += [0x865D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L85847C();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858497();

	}

	public void L85847C()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x865F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858491();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858497();

	}

	public void L858491()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858497()
	{
		A = [0x14];
		C = 0;
		A += [0x8661] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8584AA();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8584C5();

	}

	public void L8584AA()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8663] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8584BF();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8584C5();

	}

	public void L8584BF()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8584C5()
	{
		A = [0x14];
		C = 0;
		A += [0x8665] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8584D8();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8584F3();

	}

	public void L8584D8()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8667] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8584ED();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8584F3();

	}

	public void L8584ED()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8584F3()
	{
		A = [0x14];
		C = 0;
		A += [0x8669] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858506();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858521();

	}

	public void L858506()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x866B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L85851B();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858521();

	}

	public void L85851B()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858521()
	{
		A = [0x14];
		C = 0;
		A += [0x866D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858534();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85854F();

	}

	public void L858534()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x866F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858549();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85854F();

	}

	public void L858549()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85854F()
	{
		A = [0x14];
		C = 0;
		A += [0x8671] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858562();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L85857D();

	}

	public void L858562()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8673] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858577();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L85857D();

	}

	public void L858577()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L85857D()
	{
		A = [0x14];
		C = 0;
		A += [0x8675] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L858590();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8585AB();

	}

	public void L858590()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x8677] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8585A5();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8585AB();

	}

	public void L8585A5()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8585AB()
	{
		A = [0x14];
		C = 0;
		A += [0x8679] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8585BE();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L8585D9();

	}

	public void L8585BE()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x867B] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L8585D3();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L8585D9();

	}

	public void L8585D3()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L8585D9()
	{
		A = [0x14];
		C = 0;
		A += [0x867D] + C;
		A &= 0x01FF;
		temp = A - 0x01EB;
		
		if (C == 1)
			return this.L8585EC();

		temp = A - 0x0114;
		
		if (C == 1)
			return this.L858607();

	}

	public void L8585EC()
	{
		[0xB0] = A;
		A = [0x16];
		C = 0;
		A += [0x867F] + C;
		A &= 0x00FF;
		temp = A - 0x00EB;
		
		if (C == 1)
			return this.L858601();

		temp = A - 0x00BC;
		
		if (C == 1)
			return this.L858607();

	}

	public void L858601()
	{
		[0xB2] = A;
		this.L858816();
	}

	public void L858607()
	{
		B = Stack.Pop();
		return;
	}

	public void L858681()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01F1;
		
		if (C == 0)
			return this.L85868F();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L85868F()
	{
		A = Y;
		C = 0;
		A += 0x0010 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8586B2();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L8586B2()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0EA6;
		[0x7802 + Y] = A;
		A = [0xB0];
		C = 0;
		A += 0x01F0 + C;
		[0x7804 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8586D7();

		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BC + Y];
		[0x00 + X] = A;
		return this.L8586E1();
	}

	public void L8586D7()
	{
		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BA + Y];
		[0x00 + X] = A;
	}

	public void L8586E1()
	{
		A = [0xB2];
		[0x7805 + Y] = A;
		A = 0x0EA4;
		[0x7806 + Y] = A;
		A = [0xB0];
		[0x7808 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L858702();

		X = [0x82BE + Y];
		A = [0x00 + X];
		A |= [0x84C0 + Y];
		[0x00 + X] = A;
		return this.L85870C();
	}

	public void L858702()
	{
		X = [0x82BE + Y];
		A = [0x00 + X];
		A |= [0x84BE + Y];
		[0x00 + X] = A;
	}

	public void L85870C()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x7809 + Y] = A;
		A = 0x0E86;
		[0x780A + Y] = A;
		A = [0xB0];
		C = 0;
		A += 0x01F0 + C;
		[0x780C + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L858735();

		X = [0x82C2 + Y];
		A = [0x00 + X];
		A |= [0x84C4 + Y];
		[0x00 + X] = A;
		return this.L85873F();
	}

	public void L858735()
	{
		X = [0x82C2 + Y];
		A = [0x00 + X];
		A |= [0x84C2 + Y];
		[0x00 + X] = A;
	}

	public void L85873F()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x780D + Y] = A;
		A = 0x0E84;
		[0x780E + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858751()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01F9;
		
		if (C == 0)
			return this.L85875F();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L85875F()
	{
		A = Y;
		C = 0;
		A += 0x0008 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L858784();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B8 + Y];
		[0x00 + X] = A;
		return this.L85878E();
	}

	public void L858784()
	{
		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B6 + Y];
		[0x00 + X] = A;
	}

	public void L85878E()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0EA8;
		[0x7802 + Y] = A;
		A = [0xB0];
		[0x7804 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8587AF();

		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BC + Y];
		[0x00 + X] = A;
		return this.L8587B9();
	}

	public void L8587AF()
	{
		X = [0x82BA + Y];
		A = [0x00 + X];
		A |= [0x84BA + Y];
		[0x00 + X] = A;
	}

	public void L8587B9()
	{
		A = [0xB2];
		C = 0;
		A += 0x01F0 + C;
		[0x7805 + Y] = A;
		A = 0x0E88;
		[0x7806 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L8587CB()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L8587D9();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L8587D9()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L8587FE();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B8 + Y];
		[0x00 + X] = A;
		return this.L858808();
	}

	public void L8587FE()
	{
		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x84B6 + Y];
		[0x00 + X] = A;
	}

	public void L858808()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0E8A;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858816()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L858824();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L858824()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L858847();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L858847()
	{
		A = [0xB2];
		[0x7801 + Y] = A;
		A = 0x0E8C;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L86CA1C()
	{
		A = [0x7FB3EF];
		
		if (N == 1)
			return this.L86CA27();

		temp = A - 0x02D0;
		
		if (C == 1)
			return this.L86CA7C();

	}

	public void L86CA27()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0xB2] = A;
		A = [0x7FB3EF];
		
		if (N == 1)
			return this.L86CA69();

		temp = A - 0x01E0;
		
		if (C == 0)
			return this.L86CA4B();

		A = 0x00C9;
		return this.L86CA6C();
	}

	public void L86CA4B()
	{
		temp = A - 0x0168;
		
		if (C == 0)
			return this.L86CA55();

		A = 0x00C8;
		return this.L86CA6C();
	}

	public void L86CA55()
	{
		temp = A - 0x00F0;
		
		if (C == 0)
			return this.L86CA5F();

		A = 0x00C7;
		return this.L86CA6C();
	}

	public void L86CA5F()
	{
		temp = A - 0x0078;
		
		if (C == 0)
			return this.L86CA69();

		A = 0x00C6;
		return this.L86CA6C();
	}

	public void L86CA69()
	{
		A = 0x00C0;
	}

	public void L86CA6C()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CA7C()
	{
		return;
	}

	public void L86CA7D()
	{
		A = [0x7FB3EF];
		
		if (N == 1)
			return this.L86CA88();

		temp = A - 0x0258;
		
		if (C == 1)
			return this.L86CAE9();

	}

	public void L86CA88()
	{
		A = 0x0080;
		[0xB0] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A++;
		A &= 0x00FF;
		A <<= 1;
		A <<= 1;
		[0x26] = A;
		A <<= 1;
		C = 0;
		A += [0x26] + C;
		[0xB2] = A;
		A = [0x7FB3EF];
		
		if (N == 1)
			return this.L86CAD6();

		temp = A - 0x01E0;
		
		if (C == 0)
			return this.L86CAB1();

		A = 0x00C5;
		return this.L86CAD9();
	}

	public void L86CAB1()
	{
		temp = A - 0x0168;
		
		if (C == 0)
			return this.L86CABB();

		A = 0x00C4;
		return this.L86CAD9();
	}

	public void L86CABB()
	{
		temp = A - 0x00F0;
		
		if (C == 0)
			return this.L86CAC5();

		A = 0x00C3;
		return this.L86CAD9();
	}

	public void L86CAC5()
	{
		temp = A - 0x0078;
		
		if (C == 0)
			return this.L86CACF();

		A = 0x00C2;
		return this.L86CAD9();
	}

	public void L86CACF()
	{
		
		if (N == 1)
			return this.L86CAD6();

		A = 0x00C1;
		return this.L86CAD9();
	}

	public void L86CAD6()
	{
		A = 0x00BF;
	}

	public void L86CAD9()
	{
		[0xB4] = A;
		A = 0xCFFF;
		[0xA8] = A;
		A = 0x2000;
		[0xAA] = A;
		this.L8286B6();
	}

	public void L86CAE9()
	{
		return;
	}

	public void L8B8000()
	{
		A = 0x0000;
		[0x7E6A82] = A;
		[0x7E6A84] = A;
		this.L8B8018();
		return;
	}

	public void L8B8010()
	{
		this.L8B8000();
		[0x026D]++;
		return;
	}

	public void L8B8018()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x7E6A82] = A;
		[0x7E6A84] = A;
		this.L8B85FF();
		this.L8B863B();
		A = 0xFFFF;
		[0x7E6AC6] = A;
		[0x7E6AC8] = A;
		[0x7E6ACA] = A;
		[0x7E6ACC] = A;
		[0x7E6ACE] = A;
		[0x7E6AD0] = A;
		[0x7E6AD2] = A;
		[0x7E6AD4] = A;
		[0x7E6A80] = A;
		A = [0x014D];
		[0x7E6A8E] = A;
		A &= 0x0001;
		[0x7E6AB1] = A;
		A = 0x0000;
		[0x7E6AB3] = A;
		[0x7E6AA1] = A;
		[0x7E6AA5] = A;
		[0x7E6A7A] = A;
		[0x7E6A7E] = A;
		[0x7E6AA9] = A;
		[0x7E6AAB] = A;
		[0x7E6AAD] = A;
		[0x7E6AA7] = A;
		[0x7E6A8A] = A;
		P |= 0x20;
		A = 0xFF;
		[0x7E6AB5] = A;
		P &= ~0x20;
		A = 0xFFFF;
		[0x7E6A88] = A;
		[0x7E6A7C] = A;
		this.L8B80AD();
		this.L8B86C6();
		this.L8B80E8();
		this.L8B80C9();
		return;
	}

	public void L8B80AD()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x00;
		[0x7E6A90] = A;
		X = 0x000F;
	}

	public void L8B80B9()
	{
		A = X;
		A &= 0x0F;
		[0x7E6A91 + X] = A;
		X--;
		
		if (N == 0)
			return this.L8B80B9();

		P = Stack.Pop();
		return;
	}

	public void L8B80C9()
	{
		A = [0x0B3C];
		A &= 0xFFFC;
	}

	public void L8B80CF()
	{
		
		if (Z == 0)
			return this.L8B80CF();

		X = [0x0381];
		A = [0x8B80E4 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x0B3C] + C;
		[0x7E6AD6] = A;
		return;
	}

	public void L8B80E8()
	{
		Stack.Push(P);
		P |= 0x20;
		P &= ~0x10;
		X = 0x000F;
		A = 0x00;
	}

	public void L8B80F2()
	{
		[0x7E6AD8 + X] = A;
		X--;
		
		if (N == 0)
			return this.L8B80F2();

		P = Stack.Pop();
		A = [0x014D];
		C = 0;
		A += [0x014C] + C;
		[0x7E6AD8] = A;
		A = [0x014D];
		[0x7E6ADC] = A;
		return;
	}

	public void L8B85FF()
	{
		A = [0x7E3D73];
		[0x7E6AB6] = A;
		[0x7E6AC6] = A;
		A = [0x7E3D75];
		[0x7E6AB8] = A;
		[0x7E6AC8] = A;
		A = [0x7E3D87];
		[0x7E6ABA] = A;
		[0x7E6ACA] = A;
		A = [0x7E3D89];
		[0x7E6ABC] = A;
		[0x7E6ACC] = A;
		A = 0x2000;
		A |= [0x7E6AE0];
		[0x7E6AE0] = A;
		return;
	}

	public void L8B863B()
	{
		A = [0x7E3D9B];
		[0x7E6ABE] = A;
		[0x7E6ACE] = A;
		A = [0x7E3D9D];
		[0x7E6AC0] = A;
		[0x7E6AD0] = A;
		A = [0x7E3DAF];
		[0x7E6AC2] = A;
		[0x7E6AD2] = A;
		A = [0x7E3DB1];
		[0x7E6AC4] = A;
		[0x7E6AD4] = A;
		A = 0x2000;
		A |= [0x7E6AE0];
		[0x7E6AE0] = A;
		return;
	}

	public void L8B86C6()
	{
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x8B8EEC + X];
		[0x12] = A;
		A = [0x7E6AD6];
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		A = [0x8B0000 + X];
		[0x7E6AA3] = A;
		return;
	}

	public void L8CC0E4()
	{
		this.L8CC9C7();
		return;
	}

	public void L8CC0E8()
	{
		P &= ~0x30;
		this.L80823D();
		P |= 0x20;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		A = 0x10;
		[0x2102] = A;
		[0x0102] = A;
		A = 0x00;
		[0x2103] = A;
		[0x0103] = A;
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;
		A = 0x10;
		[0x2109] = A;
		[0x0108] = A;
		A = 0x00;
		[0x210C] = A;
		[0x010B] = A;
		A = 0x04;
		[0x212C] = A;
		[0x0126] = A;
		A = 0x00;
		[0x212D] = A;
		[0x0127] = A;
		A = 0x81;
		[0x4200] = A;
		[0x013C] = A;
		P &= ~0x20;
		A = 0x8C00;
		[0x01] = A;
		A = 0xC1C2;
		[0x00] = A;
		this.L8087A4();
		A = 0x8C00;
		[0x01] = A;
		A = 0xC1D4;
		[0x00] = A;
		this.L8087A4();
		this.L808202();
		A = 0x0000;
		Y = 0x0800;
		X = 0x0000;
	}

	public void L8CC163()
	{
		[0x7E2000 + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L8CC163();

		Y = 0x0050;
		X = 0x0000;
	}

	public void L8CC173()
	{
		A = [0x8CC1DB + X];
		[0x7E2318 + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L8CC173();

		A = 0x8C00;
		[0x01] = A;
		A = 0xC1CB;
		[0x00] = A;
		this.L8087A4();
		this.L808202();
		this.L808252();
		return;
	}

	public void L8CC22F()
	{
		this.L80A10A();
		this.L908453();
		[0x1BB9] = 0;
		[0x026D]++;
		return;
	}

	public void L8CC23E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BB9];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xC258 + X)]();
	}

	public void L8CC264()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BB9];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xC28A + X)]();
	}

	public void L8CC91F()
	{
		this.L908453();
		[0x14CE] = 0;
		A = 0xFFFF;
		[0x02F3] = A;
		A = 0x8014;
		[0x02EB] = A;
		P |= 0x20;
		A = 0x01;
		[0x0101] = A;
		P &= ~0x20;
		[0x1BB9] = 0;
		[0x1BD9] = 0;
		[0x026D]++;
		return;
	}

	public void L8CC945()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BB9];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xC95B + X)]();
	}

	public void L8CC9C7()
	{
		A = [0x1BD7];
		
		if (N == 1)
			return this.L8CC9D1();

		[0x1BD7]--;
		
		if (Z == 1)
			return this.L8CC9D2();

	}

	public void L8CC9D1()
	{
		return;
	}

	public void L8CC9D2()
	{
		[0x14CC] = 0;
		return;
	}

	public void L8CC9D6()
	{
		A = 0x0001;
		[0x14CC] = A;
		A = [0x0400];
		[0x1BBD] = A;
		[0x0400] = 0;
		A = 0x0000;
		[0x0117] = A;
		[0x7F0002] = A;
		this.L909993();
		this.L908DCF();
		A = 0x8019;
		[0x02EB] = A;
		P |= 0x20;
		A = 0x01;
		[0x026B] = A;
		A = 0x00;
		[0x010D] = A;
		[0x010E] = A;
		A = 0xE0;
		[0x011F] = A;
		A = 0x00;
		[0x0120] = A;
		A = 0xFF;
		[0x0121] = A;
		P &= ~0x20;
		[0x1C13] = 0;
		[0x1C15] = 0;
		[0x1C17] = 0;
		[0x1C19] = 0;
		[0x1C1B] = 0;
		[0x1C1D] = 0;
		[0x1BB9] = 0;
		[0x1BD9] = 0;
		[0x039B] = 0;
		[0x026D]++;
		A = [0x14D6];
		temp = A - 0x000F;
		
		if (Z == 0)
			return this.L8CCA55();

		P |= 0x20;
		A = 0x15;
		[0x0126] = A;
		[0x0994] = A;
		[0x0996] = A;
		[0x0998] = A;
		P &= ~0x20;
	}

	public void L8CCA55()
	{
		return;
	}

	public void L8CCA56()
	{
		P |= 0x20;
		[0x012B] = 0;
		P &= ~0x20;
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BB9];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xCA6F + X)]();
	}

	public void L8CD253()
	{
		this.L908453();
		[0x14CE] = 0;
		A = 0xFFFF;
		[0x02F3] = A;
		P |= 0x20;
		A = 0x01;
		[0x0101] = A;
		P &= ~0x20;
		this.L9084A0();
		this.L9084BD();
		[0x1BB9] = 0;
		[0x1BD9] = 0;
		[0x039B] = 0;
		[0x026D]++;
		return;
	}

	public void L8CD27E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BB9];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xD29C + X)]();
	}

	public void L8CD2AE()
	{
		this.L908453();
		this.L9084A0();
		this.L9084BD();
		A = 0x0001;
		[0x09FC] = A;
		this.L91AA76();
		A = [0x09FC];
		
		if (N == 1)
			return this.L8CD2CA();

		return;
	}

	public void L8CD2CA()
	{
		this.L9081B1();
		[0x026D]++;
		return;
	}

	public void L8D8002()
	{
		A = [0x1866];
		
		if (N == 0)
			return this.L8D8065();

		[0x14CE] = 0;
		A = [0x026F];
		
		if (Z == 0)
			return this.L8D8015();

		A = 0x8013;
		[0x02EB] = A;
	}

	public void L8D8015()
	{
		[0x026F]++;
		A = [0x0371];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L8D8053();

		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L8D8053();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L8D8053();

		A = [0x14D6];
		temp = A - 0x0010;
		
		if (Z == 1)
			return this.L8D8058();

		temp = A - 0x0006;
		
		if (Z == 1)
			return this.L8D8058();

		temp = A - 0x000E;
		
		if (Z == 1)
			return this.L8D8058();

		temp = A - 0x0005;
		
		if (Z == 1)
			return this.L8D8058();

		A = [0x036F];
		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L8D8053();

		A = [0x14D6];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L8D8058();

		return this.L8D8053();
	}

	public void L8D8053()
	{
		this.L8D8092();
		
		if (C == 1)
			return this.L8D8065();

	}

	public void L8D8058()
	{
		this.L9682B5();
		A = 0x001D;
		[0x026D] = A;
		[0x026F] = 0;
	}

	public void L8D8065()
	{
		A = [0x1968];
		
		if (N == 0)
			return this.L8D8091();

		[0x14CE] = 0;
		A = [0x026F];
		
		if (Z == 0)
			return this.L8D8078();

		A = 0x8015;
		[0x02EB] = A;
	}

	public void L8D8078()
	{
		[0x026F]++;
		A = [0x026F];
		temp = A - 0x003C;
		
		if (C == 0)
			return this.L8D8091();

		A = [0x0379];
		
		if (Z == 0)
			return this.L8D8091();

		A = 0x0030;
		[0x026D] = A;
		[0x026F] = 0;
	}

	public void L8D8091()
	{
		return;
	}

	public void L8D8092()
	{
		X = 0x003E;
	}

	public void L8D8095()
	{
		A = [0x1726 + X];
		A &= 0x8000;
		
		if (Z == 1)
			return this.L8D80A3();

	}

	public void L8D809D()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L8D8095();

		return this.L8D80AE();
	}

	public void L8D80A3()
	{
		A = [0x1726 + X];
		A &= 0x0010;
		
		if (Z == 1)
			return this.L8D809D();

		return this.L8D8228();
	}

	public void L8D80AE()
	{
		A = [0x117C];
		
		if (N == 1)
			return this.L8D80B6();

		return this.L8D8228();
	}

	public void L8D80B6()
	{
		A = [0x117E];
		
		if (N == 1)
			return this.L8D80BE();

		return this.L8D8228();
	}

	public void L8D80BE()
	{
		A = [0x1180];
		
		if (N == 1)
			return this.L8D80C6();

		return this.L8D8228();
	}

	public void L8D80C6()
	{
		A = [0x1182];
		
		if (N == 1)
			return this.L8D80CE();

		return this.L8D8228();
	}

	public void L8D80CE()
	{
		A = [0x1184];
		
		if (N == 1)
			return this.L8D80D6();

		return this.L8D8228();
	}

	public void L8D80D6()
	{
		A = [0x1186];
		
		if (N == 1)
			return this.L8D80DE();

		return this.L8D8228();
	}

	public void L8D80DE()
	{
		A = [0x1188];
		
		if (N == 1)
			return this.L8D80E6();

		return this.L8D8228();
	}

	public void L8D80E6()
	{
		A = [0x118A];
		
		if (N == 1)
			return this.L8D80EE();

		return this.L8D8228();
	}

	public void L8D80EE()
	{
		A = [0x118C];
		
		if (N == 1)
			return this.L8D80F6();

		return this.L8D8228();
	}

	public void L8D80F6()
	{
		A = [0x118E];
		
		if (N == 1)
			return this.L8D80FE();

		return this.L8D8228();
	}

	public void L8D80FE()
	{
		A = [0x1190];
		
		if (N == 1)
			return this.L8D8106();

		return this.L8D8228();
	}

	public void L8D8106()
	{
		A = [0x1192];
		
		if (N == 1)
			return this.L8D810E();

		return this.L8D8228();
	}

	public void L8D810E()
	{
		A = [0x1194];
		
		if (N == 1)
			return this.L8D8116();

		return this.L8D8228();
	}

	public void L8D8116()
	{
		A = [0x1196];
		
		if (N == 1)
			return this.L8D811E();

		return this.L8D8228();
	}

	public void L8D811E()
	{
		A = [0x1198];
		
		if (N == 1)
			return this.L8D8126();

		return this.L8D8228();
	}

	public void L8D8126()
	{
		A = [0x119A];
		
		if (N == 1)
			return this.L8D812E();

		return this.L8D8228();
	}

	public void L8D812E()
	{
		A = [0x119C];
		
		if (N == 1)
			return this.L8D8136();

		return this.L8D8228();
	}

	public void L8D8136()
	{
		A = [0x119E];
		
		if (N == 1)
			return this.L8D813E();

		return this.L8D8228();
	}

	public void L8D813E()
	{
		A = [0x11A0];
		
		if (N == 1)
			return this.L8D8146();

		return this.L8D8228();
	}

	public void L8D8146()
	{
		A = [0x11A2];
		
		if (N == 1)
			return this.L8D814E();

		return this.L8D8228();
	}

	public void L8D814E()
	{
		A = [0x11A4];
		
		if (N == 1)
			return this.L8D8156();

		return this.L8D8228();
	}

	public void L8D8156()
	{
		A = [0x11A6];
		
		if (N == 1)
			return this.L8D815E();

		return this.L8D8228();
	}

	public void L8D815E()
	{
		A = [0x11A8];
		
		if (N == 1)
			return this.L8D8166();

		return this.L8D8228();
	}

	public void L8D8166()
	{
		A = [0x11AA];
		
		if (N == 1)
			return this.L8D816E();

		return this.L8D8228();
	}

	public void L8D816E()
	{
		A = [0x11AC];
		
		if (N == 1)
			return this.L8D8176();

		return this.L8D8228();
	}

	public void L8D8176()
	{
		A = [0x11AE];
		
		if (N == 1)
			return this.L8D817E();

		return this.L8D8228();
	}

	public void L8D817E()
	{
		A = [0x11B0];
		
		if (N == 1)
			return this.L8D8186();

		return this.L8D8228();
	}

	public void L8D8186()
	{
		A = [0x11B2];
		
		if (N == 1)
			return this.L8D818E();

		return this.L8D8228();
	}

	public void L8D818E()
	{
		A = [0x11B4];
		
		if (N == 1)
			return this.L8D8196();

		return this.L8D8228();
	}

	public void L8D8196()
	{
		A = [0x11B6];
		
		if (N == 1)
			return this.L8D819E();

		return this.L8D8228();
	}

	public void L8D819E()
	{
		A = [0x11B8];
		
		if (N == 1)
			return this.L8D81A6();

		return this.L8D8228();
	}

	public void L8D81A6()
	{
		A = [0x11BA];
		
		if (N == 1)
			return this.L8D81AE();

		return this.L8D8228();
	}

	public void L8D81AE()
	{
		A = [0x11BC];
		
		if (N == 1)
			return this.L8D81B6();

		return this.L8D8228();
	}

	public void L8D81B6()
	{
		A = [0x11BE];
		
		if (N == 1)
			return this.L8D81BE();

		return this.L8D8228();
	}

	public void L8D81BE()
	{
		A = [0x11C0];
		
		if (N == 1)
			return this.L8D81C6();

		return this.L8D8228();
	}

	public void L8D81C6()
	{
		A = [0x11C2];
		
		if (N == 1)
			return this.L8D81CE();

		return this.L8D8228();
	}

	public void L8D81CE()
	{
		A = [0x11C4];
		
		if (N == 1)
			return this.L8D81D6();

		return this.L8D8228();
	}

	public void L8D81D6()
	{
		A = [0x11C6];
		
		if (N == 1)
			return this.L8D81DE();

		return this.L8D8228();
	}

	public void L8D81DE()
	{
		A = [0x11C8];
		
		if (N == 1)
			return this.L8D81E6();

		return this.L8D8228();
	}

	public void L8D81E6()
	{
		A = [0x11CA];
		
		if (N == 1)
			return this.L8D81EE();

		return this.L8D8228();
	}

	public void L8D81EE()
	{
		A = [0x11CC];
		
		if (N == 1)
			return this.L8D81F6();

		return this.L8D8228();
	}

	public void L8D81F6()
	{
		A = [0x11CE];
		
		if (N == 1)
			return this.L8D81FE();

		return this.L8D8228();
	}

	public void L8D81FE()
	{
		A = [0x11D0];
		
		if (N == 1)
			return this.L8D8206();

		return this.L8D8228();
	}

	public void L8D8206()
	{
		A = [0x11D2];
		
		if (N == 1)
			return this.L8D820E();

		return this.L8D8228();
	}

	public void L8D820E()
	{
		A = [0x11D4];
		
		if (N == 1)
			return this.L8D8216();

		return this.L8D8228();
	}

	public void L8D8216()
	{
		A = [0x11D6];
		
		if (N == 1)
			return this.L8D821E();

		return this.L8D8228();
	}

	public void L8D821E()
	{
		A = [0x11D8];
		
		if (N == 1)
			return this.L8D8226();

		return this.L8D8228();
	}

	public void L8D8226()
	{
		C = 0;
		return;
	}

	public void L8D8228()
	{
		C = 1;
		return;
	}

	public void L8E98BE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x98D4 + X)]();
	}

	public void L8EAE4F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80CC06();
		this.L839C9C();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xAE75 + X)]();
	}

	public void L8ECB6E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7E6AF6];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xCB84 + X)]();
	}

	public void L908000()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x03AD] = A;
		[0x03AF] = A;
		[0x036F] = 0;
		[0x03FA] = 0;
		[0x03FC] = 0;
		A = 0x0000;
		[0x7F0512] = A;
		[0x7F0527] = A;
		A = 0xFFFF;
		[0x7F051B] = A;
		[0x7F051D] = A;
		[0x7F051F] = A;
		[0x7F0521] = A;
		[0x7F0523] = A;
		[0x7F0525] = A;
		P |= 0x20;
		A = 0x01;
		[0x03B2] = A;
		A = 0x02;
		[0x03CF] = A;
		A = 0xFF;
		[0x03B1] = A;
		P &= ~0x20;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908052()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B06F();
		this.L91AA56();
		this.L91AD68();
		P |= 0x20;
		A = 0xFF;
		[0x03EA] = A;
		P &= ~0x20;
		A = 0x0080;
		[0x0375] = A;
		[0x0379] = A;
		[0x0377] = A;
		[0x037B] = A;
		A = 0xFFFF;
		[0x00037F] = A;
		[0x0393] = 0;
		[0x0395] = 0;
		[0x0404] = 0;
		[0x0408] = 0;
		[0x0408] = 0;
		[0x040A] = 0;
		[0x040C] = 0;
		[0x040E] = 0;
		[0x045A] = 0;
		[0x045C] = 0;
		[0x045E] = 0;
		[0x0460] = 0;
		[0x0462] = 0;
		[0x0464] = 0;
		[0x0466] = 0;
		[0x0468] = 0;
		[0x046A] = 0;
		[0x046C] = 0;
		[0x046E] = 0;
		[0x0470] = 0;
		[0x0452] = 0;
		[0x0454] = 0;
		[0x0456] = 0;
		[0x0458] = 0;
		[0x1BF5] = 0;
		[0x03BB] = 0;
		[0x03BD] = 0;
		[0x03BF] = 0;
		A = 0x0005;
		[0x03DE] = A;
		this.L9082B7();
		this.L949B0B();
		this.L9089DB();
		this.L908A56();
		this.L9088FD();
		this.L94B383();
		this.L948D87();
		A = 0xFFFF;
		[0x0312] = A;
		[0x0402] = A;
		[0x03AD] = A;
		[0x03AF] = A;
		[0x038D] = A;
		[0x035D] = 0;
		[0x035F] = 0;
		B = Stack.Pop();
		return;
	}

	public void L9081B1()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80823D();
		this.L80827B();
		this.L8082A3();
		P |= 0x20;
		A = 0x80;
		[0x4340] = A;
		A = 0x32;
		[0x4341] = A;
		A = 0x5C;
		[0x4342] = A;
		A = 0x82;
		[0x4343] = A;
		A = 0x90;
		[0x4344] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4350] = A;
		A = 0x32;
		[0x4351] = A;
		A = 0x5C;
		[0x4352] = A;
		A = 0x82;
		[0x4353] = A;
		A = 0x90;
		[0x4354] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4360] = A;
		A = 0x32;
		[0x4361] = A;
		A = 0x5C;
		[0x4362] = A;
		A = 0x82;
		[0x4363] = A;
		A = 0x90;
		[0x4364] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x80;
		[0x4370] = A;
		A = 0x32;
		[0x4371] = A;
		A = 0x5C;
		[0x4372] = A;
		A = 0x82;
		[0x4373] = A;
		A = 0x90;
		[0x4374] = A;
		P &= ~0x20;
		P |= 0x20;
		A = [0x013C];
		A &= 0x81;
		[0x013C] = A;
		[0x420C] = 0;
		[0x0141] = 0;
		[0x4A] = 0;
		[0x434A] = 0;
		[0x435A] = 0;
		[0x436A] = 0;
		[0x437A] = 0;
		P &= ~0x20;
		this.L808202();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90825D()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B091();
		this.L91AA76();
		this.L949269();
		this.L948AD5();
		this.L948BEB();
		this.L948CE0();
		this.L948D87();
		this.L94817D();
		this.L948267();
		this.L94B8B0();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90828C()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L908999();
		this.L90AAFB();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9082B7()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x07FE;
		A = 0x0000;
	}

	public void L9082C3()
	{
		[0x7E3000 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9082C3();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908453()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B091();
		this.L908907();
		this.L908DCF();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908479()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L949269();
		this.L948AD5();
		this.L948BEB();
		this.L948CE0();
		this.L948D87();
		this.L94817D();
		this.L948267();
		this.L94B8B0();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9084A0()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		temp = A - 0x0007;
		
		if (Z == 1)
			return this.L9084B6();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L9084B6();

		temp = A - 0x0002;
		
		if (Z == 0)
			return this.L9084BA();

	}

	public void L9084B6()
	{
		this.L908479();
	}

	public void L9084BA()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9084BD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		temp = A - 0x0007;
		
		if (Z == 1)
			return this.L9084D6();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L9084F4();

		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L9084FA();

	}

	public void L9084D3()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9084D6()
	{
		A = [0x7FB3EF];
		
		if (N == 0)
			return this.L9084E4();

		this.L86CA7D();
		this.L86CA1C();
	}

	public void L9084E4()
	{
		A = [0x036F];
		
		if (Z == 0)
			return this.L9084F2();

		A = [0x0381];
		
		if (Z == 0)
			return this.L9084F2();

		this.L90C047();
	}

	public void L9084F2()
	{
		return this.L9084D3();
	}

	public void L9084F4()
	{
		this.L9BD1EC();
		return this.L9084D3();
	}

	public void L9084FA()
	{
		this.L858000();
		return this.L9084D3();
	}

	public void L908500()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		X = 0x0000;
	}

	public void L908507()
	{
		A = [0x0B04 + X];
		
		if (N == 0)
			return this.L908512();

		A = 0x0001;
		[0x0B04 + X] = A;
	}

	public void L908512()
	{
		X++;
		X++;
		temp = X - 0x000C;
		
		if (C == 0)
			return this.L908507();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9086B7()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x30;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		A = 0x01;
		[0x2101] = A;
		[0x0101] = A;
		[0x2102] = 0;
		[0x0102] = 0;
		A = 0x80;
		[0x2103] = A;
		[0x0103] = A;
		[0x2104] = 0;
		[0x2104] = 0;
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;
		[0x2106] = 0;
		[0x0105] = 0;
		A = 0x01;
		[0x2107] = A;
		[0x0106] = A;
		A = 0x09;
		[0x2108] = A;
		[0x0107] = A;
		A = 0x10;
		[0x2109] = A;
		[0x0108] = A;
		A = 0x00;
		[0x210A] = A;
		[0x0109] = A;
		A = 0x44;
		[0x210B] = A;
		[0x010A] = A;
		A = 0x41;
		[0x210C] = A;
		[0x010B] = A;
		[0x210D] = 0;
		[0x210D] = 0;
		[0x210E] = 0;
		[0x210E] = 0;
		[0x210F] = 0;
		[0x210F] = 0;
		[0x2110] = 0;
		[0x2110] = 0;
		[0x2111] = 0;
		[0x2111] = 0;
		[0x2112] = 0;
		[0x2112] = 0;
		[0x2113] = 0;
		[0x2113] = 0;
		[0x2114] = 0;
		[0x2114] = 0;
		[0x2115] = 0;
		[0x211A] = 0;
		[0x010C] = 0;
		[0x211B] = 0;
		[0x211C] = 0;
		[0x211D] = 0;
		[0x211E] = 0;
		[0x211F] = 0;
		[0x2120] = 0;
		[0x2123] = 0;
		[0x010D] = 0;
		[0x2123] = 0;
		[0x010D] = 0;
		[0x2124] = 0;
		[0x010E] = 0;
		[0x2125] = 0;
		[0x011F] = 0;
		[0x2126] = 0;
		[0x0120] = 0;
		[0x2127] = 0;
		[0x0121] = 0;
		[0x2128] = 0;
		[0x0122] = 0;
		[0x2129] = 0;
		[0x0123] = 0;
		[0x212A] = 0;
		[0x0124] = 0;
		[0x212B] = 0;
		[0x0125] = 0;
		A = 0x17;
		[0x212C] = A;
		[0x0126] = A;
		[0x212E] = 0;
		[0x0128] = 0;
		A = 0x00;
		[0x212D] = A;
		[0x0127] = A;
		[0x212F] = 0;
		[0x0129] = 0;
		A = 0x02;
		[0x2130] = A;
		[0x012A] = A;
		A = 0x3F;
		[0x2131] = A;
		[0x012B] = A;
		A = 0xE0;
		[0x2132] = A;
		[0x012C] = A;
		[0x012E] = A;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x2133] = A;
		[0x012F] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9088FD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L9098E7();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908907()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L909245();
		this.L909492();
		this.L9094EE();
		this.L90941C();
		this.L9097A0();
		this.L9096CC();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908999()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L908DE9();
		this.L909018();
		this.L909245();
		this.L90941C();
		this.L909492();
		this.L9094EE();
		this.L9097A0();
		this.L9096CC();
		this.L9099B2();
		A = [0x0371];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x89CB + X)]();
	}

	public void L9089DB()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		P &= ~0x10;
		X = 0xC0E1;
		[0x3E] = X;
		A = 0xA2;
		[0x40] = A;
		X = 0xAB38;
		[0x43] = X;
		A = 0x7E;
		[0x45] = A;
		this.L808888();
		P &= ~0x30;
		A = 0x9000;
		[0x01] = A;
		A = 0x8A44;
		[0x00] = A;
		this.L8087A4();
		A = 0x9000;
		[0x01] = A;
		A = 0x8A4D;
		[0x00] = A;
		this.L8087A4();
		P &= ~0x20;
		Y = 0x003E;
		X = 0x0000;
	}

	public void L908A1F()
	{
		A = [0x95D700 + X];
		[0x7F0563 + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L908A1F();

		Y = 0x003E;
		X = 0x0000;
	}

	public void L908A33()
	{
		A = [0x95D700 + X];
		[0x7F1063 + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L908A33();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L908A56()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0381];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8AC3 + X)]();
	}

	public void L908DCF()
	{
		Stack.Push(P);
		A = 0x9000;
		[0x01] = A;
		A = 0x8DE0;
		[0x00] = A;
		this.L8087A4();
		P = Stack.Pop();
		return;
	}

	public void L908DE9()
	{
		P &= ~0x30;
		this.L908E29();
		A = [0x0381];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8E21 + X)]();
	}

	public void L908E29()
	{
		A = 0x28C8;
		[0x7E3554] = A;
		[0x7E3556] = A;
		[0x7E3558] = A;
		[0x7E355A] = A;
		[0x7E355C] = A;
		[0x7E355E] = A;
		[0x7E3560] = A;
		[0x7E3562] = A;
		[0x7E3564] = A;
		[0x7E3566] = A;
		[0x7E3568] = A;
		[0x7E356A] = A;
		A = [0x0393];
		temp = A - 0x0060;
		
		if (C == 1)
			return this.L908EB3();

		A &= 0x00F8;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x0393];
		A &= 0x0007;
		C = 0;
		A += 0x00C0 + C;
		A |= 0x2800;
		[0x7E3554 + X] = A;
		X++;
		X++;
		A = 0x28C0;
		return [(0x8EB4 + X)]();
	}

	public void L908EB3()
	{
		return;
	}

	public void L909018()
	{
		A = [0x1BC7];
		A--;
		
		if (Z == 1)
			return this.L909036();

		A = [0x1968];
		
		if (N == 1)
			return this.L909033();

		A = [0x1866];
		
		if (N == 1)
			return this.L909033();

		A = [0x03C1];
		A &= 0x0001;
		A <<= 1;
		X = A;
		return [(0x9037 + X)]();
	}

	public void L909033()
	{
		this.L9090C7();
	}

	public void L909036()
	{
		return;
	}

	public void L9090C7()
	{
		X = [0x03C7];
		A = [0x9B23 + X];
		Y = 0x013A;
		this.L90912C();
		A = [0x03C5];
		Y = 0x0134;
		this.L90912C();
		A = [0x03C3];
		Y = 0x0130;
		this.L90910A();
		return;
	}

	public void L90910A()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x00A0 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		C = 0;
		A += 0x0010 + C;
		[0x7E3040 + X] = A;
		return;
	}

	public void L90912C()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B61 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x00A0 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		C = 0;
		A += 0x0010 + C;
		[0x7E3040 + X] = A;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x00A0 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3002 + X] = A;
		C = 0;
		A += 0x0010 + C;
		[0x7E3042 + X] = A;
		return;
	}

	public void L90916D()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		return;
	}

	public void L909187()
	{
		A &= 0x00FF;
		A <<= 1;
		X = A;
		A = [0x9B61 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3000 + X] = A;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		A = [0x9B60 + X];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		Stack.Push(X);
		X = Y;
		Y = Stack.Pop();
		[0x7E3002 + X] = A;
		return;
	}

	public void L909245()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1BC7];
		A--;
		
		if (Z == 1)
			return this.L909252();

		this.L909258();
	}

	public void L909252()
	{
		this.L909335();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909258()
	{
		A = [0x0375];
		temp = A - [0x0379];
		
		if (Z == 1)
			return this.L90926A();

		
		if (N == 0)
			return this.L909267();

		[0x0379]--;
		return this.L90926A();
	}

	public void L909267()
	{
		[0x0379]++;
	}

	public void L90926A()
	{
		A = 0x3089;
		[0x7E30CC] = A;
		[0x7E30CE] = A;
		[0x7E30D0] = A;
		[0x7E30D2] = A;
		[0x7E30D4] = A;
		[0x7E30D6] = A;
		[0x7E30D8] = A;
		[0x7E30DA] = A;
		[0x7E30DC] = A;
		[0x7E30DE] = A;
		[0x7E30E0] = A;
		[0x7E30E2] = A;
		[0x7E30E4] = A;
		[0x7E30E6] = A;
		[0x7E30E8] = A;
		[0x7E30EA] = A;
		A = [0x0379];
		temp = A - 0x0080;
		
		if (Z == 1)
			return this.L909312();

		A &= 0x00F8;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x0379];
		A &= 0x0007;
		C = 0;
		A += 0x0081 + C;
		A |= 0x3000;
		[0x7E30CC + X] = A;
		A = 0x3081;
		return [(0x9313 + X)]();
	}

	public void L909312()
	{
		return;
	}

	public void L909335()
	{
		A = [0x0377];
		temp = A - [0x037B];
		
		if (Z == 1)
			return this.L909347();

		
		if (N == 0)
			return this.L909344();

		[0x037B]--;
		return this.L909347();
	}

	public void L909344()
	{
		[0x037B]++;
	}

	public void L909347()
	{
		A = 0x3089;
		[0x7E310C] = A;
		[0x7E310E] = A;
		[0x7E3110] = A;
		[0x7E3112] = A;
		[0x7E3114] = A;
		[0x7E3116] = A;
		[0x7E3118] = A;
		[0x7E311A] = A;
		[0x7E311C] = A;
		[0x7E311E] = A;
		[0x7E3120] = A;
		[0x7E3122] = A;
		[0x7E3124] = A;
		[0x7E3126] = A;
		[0x7E3128] = A;
		[0x7E312A] = A;
		A = [0x037B];
		temp = A - 0x0080;
		
		if (Z == 1)
			return this.L9093EF();

		A &= 0x00F8;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x037B];
		A &= 0x0007;
		C = 0;
		A += 0x0081 + C;
		A |= 0x3000;
		[0x7E310C + X] = A;
		A = 0x3081;
		return [(0x93F0 + X)]();
	}

	public void L9093EF()
	{
		return;
	}

	public void L90941C()
	{
		A = [0x1968];
		
		if (N == 1)
			return this.L90947F();

		A = [0x026D];
		temp = A - 0x00D2;
		
		if (Z == 1)
			return this.L90947F();

		A = 0x0080;
		[0x7E31AE] = A;
		[0x7E31B0] = A;
		[0x7E31B2] = A;
		[0x7E31B4] = A;
		[0x7E31B6] = A;
		[0x7E31B8] = A;
		[0x7E31BA] = A;
		[0x7E31BC] = A;
		A = [0x03FE];
		temp = A - 0x0008;
		
		if (C == 1)
			return this.L90945C();

		A <<= 1;
		X = A;
		A = 0x30FE;
		return [(0x9480 + X)]();
	}

	public void L90945C()
	{
		A = 0x30FE;
		[0x7E31AE] = A;
		[0x7E31B0] = A;
		[0x7E31B2] = A;
		[0x7E31B4] = A;
		[0x7E31B6] = A;
		[0x7E31B8] = A;
		[0x7E31BA] = A;
		[0x7E31BC] = A;
	}

	public void L90947F()
	{
		return;
	}

	public void L909492()
	{
		A = [0x014C];
		A &= 0x0007;
		temp = A - 0x0007;
		
		if (Z == 0)
			return this.L9094C5();

		A = [0x03DE];
		A--;
		
		if (N == 0)
			return this.L9094A6();

		A = 0x0004;
	}

	public void L9094A6()
	{
		[0x03DE] = A;
		A <<= 1;
		C = 0;
		A += [0x03DE] + C;
		A <<= 1;
		X = A;
		A = [0x94C6 + X];
		[0x7E35C2] = A;
		A = [0x94C8 + X];
		[0x7E35CE] = A;
		A = [0x94CA + X];
		[0x7E35D0] = A;
	}

	public void L9094C5()
	{
		return;
	}

	public void L9094EE()
	{
		A = [0x0458];
		
		if (N == 0)
			return this.L9094F7();

		A ^= 0xFFFF;
		A++;
	}

	public void L9094F7()
	{
		A &= 0x000E;
		A ^= 0x000E;
		A >>= 1;
		[0x12] = A;
		A = [0x03E2];
		[0x03E2]++;
		temp = A - [0x12];
		
		if (C == 0)
			return this.L90952D();

		[0x03E2] = 0;
		A = [0x03E0];
		A--;
		
		if (N == 0)
			return this.L909516();

		A = 0x0003;
	}

	public void L909516()
	{
		[0x03E0] = A;
		A <<= 1;
		C = 0;
		A += [0x03E0] + C;
		X = A;
		A = [0x952F + X];
		[0x01] = A;
		A = [0x952E + X];
		[0x00] = A;
		this.L8087A4();
	}

	public void L90952D()
	{
		return;
	}

	public void L90955E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x80;
		[0x03D5] = A;
		A = 0x95;
		[0x03D2] = A;
		P &= ~0x20;
		A = 0x0060;
		[0x03D3] = A;
		X = 0x0006;
	}

	public void L909579()
	{
		A = [0x03F2 + X];
		
		if (N == 1)
			return this.L9095B3();

		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		[0x12] = A;
		C = 0;
		A += 0x8880 + C;
		[0x03D0] = A;
		A = X;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		C = 0;
		A += 0x1730 + C;
		[0x03D6] = A;
		Stack.Push(X);
		A = 0x0000;
		[0x01] = A;
		A = 0x03CF;
		[0x00] = A;
		this.L8087A4();
		X = Stack.Pop();
	}

	public void L9095B3()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L909579();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9095BA()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L9095BE()
	{
		[0x03FC]++;
		A = [0x03FC];
		temp = A - 0x0004;
		
		if (N == 1)
			return this.L9095CC();

		A = 0x0000;
	}

	public void L9095CC()
	{
		[0x03FC] = A;
		A <<= 1;
		X = A;
		A = [0x03F2 + X];
		
		if (N == 1)
			return this.L9095BE();

		[0x03FA] = A;
		this.L909606();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9095E0()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x03FC] = 0;
		A = [0x03F2];
		[0x03FA] = A;
		this.L909606();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909606()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		X = 0x0000;
		Y = 0x0614;
		this.L909631();
		X = 0x0002;
		Y = 0x061A;
		this.L909631();
		X = 0x0004;
		Y = 0x0620;
		this.L909631();
		X = 0x0006;
		Y = 0x0626;
		this.L909631();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909631()
	{
		A = [0x03F2 + X];
		
		if (N == 1)
			return this.L90963E();

		A = X;
		A >>= 1;
		[0x12] = A;
		this.L909642();
		return;
	}

	public void L90963E()
	{
		this.L9096A0();
		return;
	}

	public void L909642()
	{
		A = [0x9698 + X];
		[0x16] = A;
		A = [0x12];
		temp = A - [0x03FC];
		
		if (Z == 0)
			return this.L909655();

		A = 0x3400;
		[0x14] = A;
		return this.L90965A();
	}

	public void L909655()
	{
		A = 0x2400;
		[0x14] = A;
	}

	public void L90965A()
	{
		X = Y;
		A = [0x14];
		A |= [0x16];
		[0x7E3000 + X] = A;
		[0x16]++;
		A = [0x14];
		A |= [0x16];
		[0x7E3002 + X] = A;
		[0x16]++;
		A = [0x14];
		A |= [0x16];
		[0x7E3004 + X] = A;
		[0x16]++;
		A = [0x14];
		A |= [0x16];
		[0x7E3040 + X] = A;
		[0x16]++;
		A = [0x14];
		A |= [0x16];
		[0x7E3042 + X] = A;
		[0x16]++;
		A = [0x14];
		A |= [0x16];
		[0x7E3044 + X] = A;
		[0x16]++;
		return;
	}

	public void L9096A0()
	{
		X = Y;
		A = 0x3CE0;
		[0x7E3000 + X] = A;
		A = 0x3CE1;
		[0x7E3002 + X] = A;
		A = 0x3CE2;
		[0x7E3004 + X] = A;
		A = 0x3CE3;
		[0x7E3040 + X] = A;
		A = 0x3CE4;
		[0x7E3042 + X] = A;
		A = 0x3CE5;
		[0x7E3044 + X] = A;
		return;
	}

	public void L9096CC()
	{
		A = [0x0367];
		temp = A - 0x0007;
		
		if (Z == 1)
			return this.L909735();

		A = [0x0456];
		[0x28] = A;
		A = [0x0458];
		[0x2A] = A;
		
		if (N == 0)
			return this.L9096F6();

		A = [0x0456];
		A ^= 0xFFFF;
		C = 0;
		A += 0x0001 + C;
		[0x28] = A;
		A = [0x2A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x2A] = A;
	}

	public void L9096F6()
	{
		A = [0x28];
		A = (A >> 4) | (A << 4);
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A &= 0x0007;
		Y = 0x0678;
		this.L90916D();
		A = [0x2A];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x2A] + C;
		temp = A - 0x0064;
		
		if (C == 0)
			return this.L909723();

		C = 1;
		A -= 0x0064 - !C;
		[0x26] = A;
		A = 0x2091;
		[0x7E3670] = A;
		return this.L90972C();
	}

	public void L909723()
	{
		[0x26] = A;
		A = 0x2090;
		[0x7E3670] = A;
	}

	public void L90972C()
	{
		Y = 0x0672;
		A = [0x26];
		this.L909187();
		return;
	}

	public void L909735()
	{
		A = [0x0452];
		[0x26] = A;
		A = [0x0454];
		[0x28] = A;
		
		if (N == 0)
			return this.L909745();

		[0x26] = 0;
		[0x28] = 0;
	}

	public void L909745()
	{
		A = [0x27];
		A &= 0x0FFF;
		[0x2C] = A;
		A <<= 1;
		C = 0;
		A += [0x2C] + C;
		[0x2C] = A;
		temp = A - 0x270F;
		
		if (C == 0)
			return this.L90975C();

		A = 0x270F;
		[0x2C] = A;
	}

	public void L90975C()
	{
		Y = 0x0670;
		A = 0x03E8;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0672;
		A = [0x26];
		[0x2C] = A;
		A = 0x0064;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0674;
		A = [0x26];
		[0x2C] = A;
		A = 0x000A;
		[0x2E] = A;
		this.L8086B1();
		A = [0x2C];
		this.L90916D();
		Y = 0x0678;
		A = [0x26];
		this.L90916D();
		return;
	}

	public void L9097A0()
	{
		A = [0x14D8];
		C = 1;
		A -= 0x0080 - !C;
		[0x0385] = A;
		A = [0x0385];
		
		if (N == 0)
			return this.L9097B3();

		A ^= 0xFFFF;
		A++;
	}

	public void L9097B3()
	{
		[0x28] = A;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		temp = A - 0x0064;
		
		if (N == 1)
			return this.L9097C0();

		A = 0x0063;
	}

	public void L9097C0()
	{
		[0x26] = A;
		Y = 0x060E;
		this.L909187();
		A = 0x208A;
		[0x7E3604] = A;
		[0x7E3606] = A;
		[0x7E3608] = A;
		[0x7E360A] = A;
		A = [0x28];
		
		if (Z == 1)
			return this.L909828();

		temp = A - 0x003F;
		
		if (N == 0)
			return this.L909815();

		A = 0x003F;
		C = 1;
		A -= [0x28] - !C;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A &= 0xFFFE;
		X = A;
		A = [0x28];
		A &= 0xFFF0;
		C = 1;
		A -= [0x28] - !C;
		A ^= 0xFFFF;
		A++;
		A >>= 1;
		A >>= 1;
		C = 0;
		A += 0x208A + C;
		[0x7E3604 + X] = A;
		A = 0x208E;
		return [(0x980D + X)]();
	}

	public void L909815()
	{
		A = 0x208E;
		[0x7E3604] = A;
		[0x7E3606] = A;
		[0x7E3608] = A;
		[0x7E360A] = A;
	}

	public void L909828()
	{
		A = [0x0385];
		
		if (N == 0)
			return this.L909835();

		A = 0x388F;
		[0x7E360C] = A;
		return;
	}

	public void L909835()
	{
		A = 0x788F;
		[0x7E360C] = A;
		return;
	}

	public void L9098E7()
	{
		P |= 0x20;
		P &= ~0x10;
		X = 0xD095;
		[0x3E] = X;
		A = 0xA2;
		[0x40] = A;
		X = 0xAB38;
		[0x43] = X;
		A = 0x7E;
		[0x45] = A;
		this.L808888();
		P &= ~0x30;
		P |= 0x20;
		A = 0x7E;
		[0x03D2] = A;
		A = 0x80;
		[0x03D5] = A;
		P &= ~0x20;
		A = 0x0080;
		[0x03D3] = A;
		A = 0x16C0;
		[0x03D6] = A;
		A = [0x0367];
		A <<= 1;
		X = A;
		A = [0x9942 + X];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += 0xAB38 + C;
		[0x03D0] = A;
		A = 0x0000;
		[0x01] = A;
		A = 0x03CF;
		[0x00] = A;
		this.L8087A4();
		return;
	}

	public void L909993()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x037F] = A;
		X = 0x0216;
		this.L909ACF();
		X = 0x04C6;
		this.L909ACF();
		A = 0xFFFF;
		[0x02F3] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9099B2()
	{
		A = [0x037F];
		
		if (N == 0)
			return this.L9099C9();

		A = [0x0375];
		temp = A - 0x0020;
		
		if (C == 1)
			return this.L9099C8();

		[0x037F] = 0;
		A = 0x801C;
		[0x02F3] = A;
	}

	public void L9099C8()
	{
		return;
	}

	public void L9099C9()
	{
		A = [0x0375];
		temp = A - 0x0020;
		
		if (C == 0)
			return this.L9099D6();

		this.L909993();
		return;
	}

	public void L9099D6()
	{
		A = [0x037F];
		A &= 0x4000;
		
		if (Z == 0)
			return this.L909A14();

		[0x037F]++;
		A = [0x037F];
		A &= 0x00FF;
		temp = A - 0x0018;
		
		if (C == 1)
			return this.L9099F3();

	}

	public void L9099EC()
	{
		X = 0x0216;
		this.L909A34();
		return;
	}

	public void L9099F3()
	{
		A = [0x037F];
		A &= 0xFF00;
		[0x037F] = A;
		A = [0x0380];
		A++;
		[0x0380] = A;
		A &= 0x000F;
		temp = A - 0x0003;
		
		if (C == 0)
			return this.L9099EC();

		A = [0x037F];
		A |= 0x4000;
		[0x037F] = A;
	}

	public void L909A14()
	{
		[0x037F]++;
		A = [0x037F];
		A &= 0x00FF;
		temp = A - 0x0018;
		
		if (C == 1)
			return this.L909A29();

	}

	public void L909A22()
	{
		X = 0x04C6;
		this.L909A34();
		return;
	}

	public void L909A29()
	{
		A = [0x037F];
		A &= 0xFF00;
		[0x037F] = A;
		return this.L909A22();
	}

	public void L909A34()
	{
		A = [0x037F];
		A &= 0x00FF;
		temp = A - 0x0010;
		
		if (C == 0)
			return this.L909A42();

		return this.L909ACF();
	}

	public void L909A42()
	{
		A = 0x3180;
		[0x7E3000 + X] = A;
		A = 0x3181;
		[0x7E3002 + X] = A;
		A = 0x3182;
		[0x7E3004 + X] = A;
		A = 0x3183;
		[0x7E3006 + X] = A;
		A = 0x3184;
		[0x7E3008 + X] = A;
		A = 0x3185;
		[0x7E300A + X] = A;
		A = 0x3186;
		[0x7E300C + X] = A;
		A = 0x3187;
		[0x7E300E + X] = A;
		A = 0x3188;
		[0x7E3010 + X] = A;
		A = 0x3189;
		[0x7E3012 + X] = A;
		A = 0x318A;
		[0x7E3040 + X] = A;
		A = 0x318B;
		[0x7E3042 + X] = A;
		A = 0x318C;
		[0x7E3044 + X] = A;
		A = 0x318D;
		[0x7E3046 + X] = A;
		A = 0x318E;
		[0x7E3048 + X] = A;
		A = 0x318F;
		[0x7E304A + X] = A;
		A = 0x3190;
		[0x7E304C + X] = A;
		A = 0x3191;
		[0x7E304E + X] = A;
		A = 0x3192;
		[0x7E3050 + X] = A;
		A = 0x3193;
		[0x7E3052 + X] = A;
		return;
	}

	public void L909ACF()
	{
		A = 0x0080;
		[0x7E3000 + X] = A;
		[0x7E3002 + X] = A;
		[0x7E3004 + X] = A;
		[0x7E3006 + X] = A;
		[0x7E3008 + X] = A;
		[0x7E300A + X] = A;
		[0x7E300C + X] = A;
		[0x7E300E + X] = A;
		[0x7E3010 + X] = A;
		[0x7E3012 + X] = A;
		[0x7E3040 + X] = A;
		[0x7E3042 + X] = A;
		[0x7E3044 + X] = A;
		[0x7E3046 + X] = A;
		[0x7E3048 + X] = A;
		[0x7E304A + X] = A;
		[0x7E304C + X] = A;
		[0x7E304E + X] = A;
		[0x7E3050 + X] = A;
		[0x7E3052 + X] = A;
		return;
	}

	public void L909CDE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80823D();
		this.L9081B1();
		this.L94E94E();
		this.L908000();
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}

	public void L909CF9()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L91B06F();
		A = 0x0000;
		[0x7E6AF6] = A;
		[0x7E5BF3] = A;
		[0x035D] = 0;
		[0x035F] = 0;
		[0x0365] = 0;
		[0x0371] = 0;
		[0x1BC7] = 0;
		[0x03C1] = 0;
		A = 0x0001;
		[0x0373] = A;
		A = 0x0002;
		[0x7E6B22] = A;
		[0x7E6B24] = A;
		A = 0x0000;
		[0x7FE717] = A;
		[0x7F052B] = A;
		this.L90A5AD();
		A = 0x0000;
		[0x7F0527] = A;
		A = 0x0009;
		[0x7F051B] = A;
		[0x7F051D] = A;
		[0x7F051F] = A;
		[0x7F0521] = A;
		[0x7F0523] = A;
		[0x7F0525] = A;
		this.L809559();
		A = 0x00E0;
		this.L809517();
		A = 0x00F9;
		this.L8094E2();
		P |= 0x20;
		A = 0xFF;
		[0x03B1] = A;
		P &= ~0x20;
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}

	public void L909D82()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 0)
			return this.L909D91();

		[0x036F] = 0;
	}

	public void L909D91()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909D97()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909DA1()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L9081B1();
		this.L9086B7();
		this.L908052();
		A = [0x0371];
		
		if (Z == 1)
			return this.L909DC5();

		temp = A - 0x0003;
		
		if (C == 0)
			return this.L909DCB();

		temp = A - 0x0005;
		
		if (C == 1)
			return this.L909DCB();

		this.L90A597();
		return this.L909DCB();
	}

	public void L909DC5()
	{
		this.L90A7DE();
		this.L90A8CF();
	}

	public void L909DCB()
	{
		A = [0x0381];
		
		if (Z == 0)
			return this.L909DE5();

		A = [0x0367];
		temp = A - 0x000E;
		
		if (Z == 0)
			return this.L909DE5();

		A = [0x7F052B];
		A--;
		
		if (Z == 0)
			return this.L909DE5();

		this.L90955E();
		return this.L909DE9();
	}

	public void L909DE5()
	{
		this.L90EF24();
	}

	public void L909DE9()
	{
		A = [0x0367];
		temp = A - 0x0009;
		
		if (Z == 1)
			return this.L909DF8();

	}

	public void L909DF1()
	{
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}

	public void L909DF8()
	{
		A = [0x150C];
		temp = A & 0x0100;
		
		if (Z == 0)
			return this.L909DF1();

		A = 0x8033;
		[0x02EB] = A;
		return this.L909DF1();
	}

	public void L909E46()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x20;
		A = 0x9000;
		[0x01] = A;
		A = 0x9EDC;
		[0x00] = A;
		this.L8087A4();
		A = [0x1BC7];
		
		if (Z == 0)
			return this.L909E6F();

		A = [0x0371];
		
		if (Z == 0)
			return this.L909E6F();

		A = 0x0000;
		[0x706020] = A;
		this.L94E927();
	}

	public void L909E6F()
	{
		this.L908500();
		this.L80A10A();
		this.L908453();
		this.L908479();
		this.L9681FF();
		Y = 0x000C;
		X = 0x0000;
	}

	public void L909E89()
	{
		A = [0x7F051B + X];
		[0x7FE70B + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L909E89();

		A = [0x7F0527];
		[0x7FE717] = A;
		A = [0x03FE];
		[0x7FE719] = A;
		Y = 0x0008;
		X = 0x0000;
	}

	public void L909EAC()
	{
		A = [0x0003F2 + X];
		[0x7FE71B + X] = A;
		X++;
		Y--;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L909EAC();

		A = [0x036F];
		A--;
		
		if (Z == 1)
			return this.L909ED2();

		A = [0x0371];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L909ED2();

		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L909ED2();

		temp = A - 0x0004;
		
		if (Z == 0)
			return this.L909ED6();

	}

	public void L909ED2()
	{
		this.L90AC9A();
	}

	public void L909ED6()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909EE5()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L908453();
		this.L9084BD();
		A = [0x0367];
		temp = A - 0x0009;
		
		if (Z == 1)
			return this.L909EFF();

		[0x026D]++;
	}

	public void L909EFC()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909EFF()
	{
		A = 0x0055;
		[0x026D] = A;
		return this.L909EFC();
	}

	public void L909F08()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x14CE] = 0;
		A = 0xFFFF;
		[0x038D] = A;
		A = 0x0000;
		[0x0117] = A;
		[0x7F0002] = A;
		this.L909993();
		this.L80A10A();
		this.L908453();
		this.L9084A0();
		A = [0x0371];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L909F8F();

		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L909FA6();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L909FBC();

		this.L90A0CC();
		this.L90A06E();
		this.L90A963();
		
		if (C == 1)
			return this.L909F50();

		this.L94F255();
	}

	public void L909F50()
	{
		this.L90A071();
		this.L94EC82();
		A = [0x036F];
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L909F62();

		return this.L90A08F();
	}

	public void L909F62()
	{
		[0x0365]++;
	}

	public void L909F65()
	{
		this.L90A7DE();
		A = [0x0367];
		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L909FCB();

		temp = A - 0x0007;
		
		if (Z == 1)
			return this.L909FD3();

		temp = A - 0x000F;
		
		if (Z == 1)
			return this.L909FDB();

		temp = A - 0x0005;
		
		if (Z == 1)
			return this.L909FE3();

		temp = A - 0x000D;
		
		if (Z == 1)
			return this.L909FEB();

		temp = A - 0x000E;
		
		if (Z == 1)
			return this.L909FFA();

		[0x026D]++;
	}

	public void L909F8C()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909F8F()
	{
		P |= 0x20;
		A = 0xE0;
		[0x012E] = A;
		[0x012D] = A;
		[0x012C] = A;
		P &= ~0x20;
		A = 0x0024;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FA6()
	{
		A = 0x002B;
		[0x026D] = A;
		this.L90A06E();
		this.L94F255();
		this.L94EC82();
		this.L90A0CC();
		return this.L909F8C();
	}

	public void L909FBC()
	{
		this.L90A06E();
		this.L94F255();
		A = 0x0027;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FCB()
	{
		A = 0x0059;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FD3()
	{
		A = 0x006E;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FDB()
	{
		A = 0x007B;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FE3()
	{
		A = 0x0087;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FEB()
	{
		A = 0x0000;
		[0x7F2873] = A;
		A = 0x0094;
		[0x026D] = A;
		return this.L909F8C();
	}

	public void L909FFA()
	{
		X = [0x036D];
		A = [0xA048 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x70601C] + C;
		temp = A - 0x00F8;
		
		if (C == 0)
			return this.L90A010();

		A = 0x00F8;
	}

	public void L90A010()
	{
		[0x70601C] = A;
		this.L94EE56();
		this.L94FC54();
		A = 0x0001;
		[0x706026] = A;
		A = 0x0000;
		[0x706020] = A;
		this.L90A626();
		this.L94E927();
		A = [0x1884];
		
		if (N == 0)
			return this.L90A03F();

		A = 0x00AC;
		[0x026D] = A;
		return this.L90A045();
	}

	public void L90A03F()
	{
		A = 0x00A8;
		[0x026D] = A;
	}

	public void L90A045()
	{
		return this.L909F8C();
	}

	public void L90A06E()
	{
		this.L90A8F4();
	}

	public void L90A071()
	{
		A = [0x7F055B];
		[0x26] = A;
		A = [0x7F055D];
		[0x28] = A;
		A = [0x7F055F];
		[0x2A] = A;
		A = [0x7F052B];
		[0x2C] = A;
		A = [0x0381];
		[0x2E] = A;
		return;
	}

	public void L90A08F()
	{
		[0x0365] = 0;
	}

	public void L90A092()
	{
		A = [0x0365];
		A <<= 1;
		X = A;
		A = [0x9C5C + X];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x7060B5 + X];
		A &= 0x00FF;
		temp = A - 0x00FF;
		
		if (Z == 1)
			return this.L90A0AE();

		[0x0365]++;
		return this.L90A092();
	}

	public void L90A0AE()
	{
		A = [0x0367];
		temp = A - 0x000D;
		
		if (Z == 1)
			return this.L90A0B9();

		return this.L909F65();
	}

	public void L90A0B9()
	{
		A = 0x0000;
		[0x7F2873] = A;
		A = 0x009D;
		[0x026D] = A;
		this.L90A7DE();
		return this.L909F8C();
	}

	public void L90A0CC()
	{
		A = [0x0367];
		A <<= 1;
		X = A;
		A = 0x0001;
		[0x706090 + X] = A;
		this.L94E927();
		return;
	}

	public void L90A0DD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x035D];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xA0FB + X)]();
	}

	public void L90A14F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A16C();

		A = [0x0371];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A16C();

		A = 0x0008;
		[0x026D] = A;
	}

	public void L90A169()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A16C()
	{
		A = 0x0003;
		[0x026D] = A;
		return this.L90A169();
	}

	public void L90A267()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x7F052B] = A;
		[0x7F055B] = A;
		[0x7F055D] = A;
		[0x7F055F] = A;
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L90A29A();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L90A29A();

		this.L90A9A8();
		this.L90A7DE();
		this.L90A8CF();
	}

	public void L90A294()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A29A()
	{
		A = 0x0001;
		[0x0373] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		A = [0x0365];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		A = [0x036F];
		
		if (Z == 0)
			return this.L90A2D3();

		A = [0x9C76 + X];
		[0x0367] = A;
		A = [0x9C78 + X];
		[0x14D6] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		X = A;
		A = [0xA2EE + X];
		[0x7F052D] = A;
		return this.L90A294();
	}

	public void L90A2D3()
	{
		A = [0x9CA6 + X];
		[0x0367] = A;
		A = [0x9CA8 + X];
		[0x14D6] = A;
		A = [0x036D];
		A--;
		A <<= 1;
		X = A;
		A = [0xA2F4 + X];
		[0x7F052D] = A;
		return this.L90A294();
	}

	public void L90A324()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x03C1] = 0;
		[0x03FC] = 0;
		[0x0395] = 0;
		[0x0393] = 0;
		A = 0x0001;
		[0x03FE] = A;
		A = 0x0002;
		[0x0371] = A;
		A = 0x0007;
		[0x0B36] = A;
		A = 0x0001;
		[0x7E3983] = A;
		A = 0x0000;
		[0x7E3985] = A;
		A = 0x0000;
		[0x03F2] = A;
		[0x03FA] = A;
		A = 0x0003;
		[0x03F4] = A;
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		A = 0x004E;
		[0x026D] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A597()
	{
		A = 0x0000;
		[0x7E3983] = A;
		[0x7E3985] = A;
		[0x0B3A] = A;
		[0x0B38] = A;
		this.L90A5AD();
		return;
	}

	public void L90A5AD()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0001;
		[0x03FE] = A;
		A = 0x0000;
		[0x03F2] = A;
		[0x03FA] = A;
		A = 0x0003;
		[0x03F4] = A;
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A626()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x7F055B] = A;
		[0x7F055D] = A;
		[0x7F055F] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A782()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.L80A10A();
		this.L908453();
		this.L908479();
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 0)
			return this.L90A7D8();

		A = [0x036B];
		
		if (Z == 1)
			return this.L90A7D8();

		A = [0x7F052B];
		
		if (Z == 0)
			return this.L90A7D8();

		A = [0x0365];
		
		if (Z == 0)
			return this.L90A7B9();

		A = [0x026D];
		A++;
		[0x14CA] = A;
		A = 0x001B;
		[0x026D] = A;
		return this.L90A7DB();
	}

	public void L90A7B9()
	{
		A = [0x0369];
		
		if (Z == 0)
			return this.L90A7CC();

		A = [0x1BBF];
		[0x025D] = A;
		A = [0x1BC1];
		[0x025F] = A;
		return this.L90A7D8();
	}

	public void L90A7CC()
	{
		A = [0x1BC3];
		[0x025D] = A;
		A = [0x1BC5];
		[0x025F] = A;
	}

	public void L90A7D8()
	{
		[0x026D]++;
	}

	public void L90A7DB()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90A7DE()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A7F6();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A7F6();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A7F7();

	}

	public void L90A7F6()
	{
		return;
	}

	public void L90A7F7()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x706020] = A;
		A = [0x0381];
		[0x70605A] = A;
		A = [0x0365];
		[0x70605C] = A;
		A = [0x036D];
		[0x70605E] = A;
		A = [0x036F];
		[0x706060] = A;
		A = [0x0371];
		[0x706062] = A;
		A = [0x03FE];
		[0x70606C] = A;
		A = [0x7F052B];
		[0x70607C] = A;
		A = [0x7F0527];
		[0x70607A] = A;
		A = [0x03F2];
		[0x706064] = A;
		A = [0x03F4];
		[0x706066] = A;
		A = [0x03F6];
		[0x706068] = A;
		A = [0x03F8];
		[0x70606A] = A;
		A = [0x7F051B];
		[0x70606E] = A;
		A = [0x7F051D];
		[0x706070] = A;
		A = [0x7F051F];
		[0x706072] = A;
		A = [0x7F0521];
		[0x706074] = A;
		A = [0x7F0523];
		[0x706076] = A;
		A = [0x7F0525];
		[0x706078] = A;
		A = [0x7E3983];
		[0x70607E] = A;
		A = [0x7E3985];
		[0x706080] = A;
		A = [0x0B36];
		[0x706082] = A;
		A = [0x0B38];
		[0x706084] = A;
		A = [0x0B3A];
		[0x706086] = A;
		A = [0x0B3C];
		[0x706088] = A;
		A = [0x7F055B];
		[0x70608A] = A;
		A = [0x7F055D];
		[0x70608C] = A;
		A = [0x7F055F];
		[0x70608E] = A;
		this.L94E927();
		return;
	}

	public void L90A8CF()
	{
		A = [0x7F0512];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x1BC7];
		
		if (Z == 0)
			return this.L90A8E7();

		A = [0x036F];
		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L90A8E7();

		A = [0x0371];
		
		if (Z == 1)
			return this.L90A8E8();

	}

	public void L90A8E7()
	{
		return;
	}

	public void L90A8E8()
	{
		A = 0x0001;
		[0x706020] = A;
		this.L94E927();
		return;
	}

	public void L90A8F4()
	{
		X = [0x03C7];
		A = [0x909B23 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x7F055F] + C;
		[0x7F055F] = A;
		temp = A - 0x0064;
		
		if (C == 0)
			return this.L90A91D();

		C = 1;
		A -= 0x0064 - !C;
		[0x7F055F] = A;
		A = [0x7F055D];
		A++;
		[0x7F055D] = A;
	}

	public void L90A91D()
	{
		A = [0x03C5];
		C = 0;
		A += [0x7F055D] + C;
		[0x7F055D] = A;
		temp = A - 0x003C;
		
		if (C == 0)
			return this.L90A93F();

		C = 1;
		A -= 0x003C - !C;
		[0x7F055D] = A;
		A = [0x7F055B];
		A++;
		[0x7F055B] = A;
	}

	public void L90A93F()
	{
		A = [0x03C3];
		C = 0;
		A += [0x7F055B] + C;
		temp = A - 0x003C;
		
		if (C == 0)
			return this.L90A95A();

		A = 0x0063;
		[0x7F055F] = A;
		A = 0x003B;
		[0x7F055D] = A;
	}

	public void L90A95A()
	{
		[0x7F055B] = A;
		this.L94E927();
		return;
	}

	public void L90A963()
	{
		[0x12] = 0;
		[0x14] = 0;
		A = [0x7F0527];
		[0x12] = A;
		A = [0x03F6];
		
		if (N == 1)
			return this.L90A974();

		[0x12]++;
	}

	public void L90A974()
	{
		A = [0x03F8];
		
		if (N == 1)
			return this.L90A97B();

		[0x12]++;
	}

	public void L90A97B()
	{
		A = [0x7FE717];
		[0x14] = A;
		A = [0x7FE71F];
		
		if (N == 1)
			return this.L90A989();

		[0x14]++;
	}

	public void L90A989()
	{
		A = [0x7FE721];
		
		if (N == 1)
			return this.L90A991();

		[0x14]++;
	}

	public void L90A991()
	{
		A = [0x14];
		temp = A - [0x12];
		
		if (Z == 0)
			return this.L90A9A6();

		A = [0x7FE719];
		C = 1;
		A -= [0x03FE] - !C;
		temp = A - 0x0002;
		
		if (C == 1)
			return this.L90A9A6();

		C = 0;
		return;
	}

	public void L90A9A6()
	{
		C = 1;
		return;
	}

	public void L90A9A8()
	{
		A = [0x0365];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x9C28 + X];
		[0x0367] = A;
		A = [0x9C2A + X];
		[0x14D6] = A;
		A = [0x0367];
		temp = A - 0x0009;
		
		if (Z == 0)
			return this.L90A9CE();

		A = [0x7F052B];
		
		if (Z == 1)
			return this.L90A9CE();

		A = 0x0004;
		[0x0367] = A;
	}

	public void L90A9CE()
	{
		return;
	}

	public void L90AAFB()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = [0x038D];
		
		if (N == 0)
			return this.L90AB09();

	}

	public void L90AB06()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90AB09()
	{
		A <<= 1;
		X = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xF9;
		[0x4A] = A;
		P &= ~0x20;
		A = 0x4000;
		temp = A & [0x1B43]; [0x1B43] |= A;
		[0x038D]++;
		A = [0x038F];
		
		if (Z == 1)
			return this.L90AB5A();

		A = [0xABB9 + X];
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L90AB92();

		[0x0117] = A;
		[0x7F0002] = A;
		A = [0xABEB + X];
		
		if (Z == 0)
			return this.L90ABA8();

		P |= 0x20;
		A = 0x3F;
		[0x012B] = A;
		A = 0x3F;
		[0x012E] = A;
		[0x012D] = 0;
		[0x012C] = 0;
		A = 0x20;
		[0x011F] = A;
		[0x0120] = 0;
		A = 0xFF;
		[0x0121] = A;
		P &= ~0x20;
		return this.L90AB06();
	}

	public void L90AB5A()
	{
		A = [0xAC1D + X];
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L90AB92();

		[0x0117] = A;
		[0x7F0002] = A;
		A = [0xAC3F + X];
		
		if (Z == 0)
			return this.L90ABA8();

		P |= 0x20;
		A = 0x3F;
		[0x012B] = A;
		A = 0xF0;
		[0x012E] = A;
		[0x012D] = 0;
		[0x012C] = 0;
		A = 0x20;
		[0x011F] = A;
		[0x0120] = 0;
		A = 0xFF;
		[0x0121] = A;
		P &= ~0x20;
		return this.L90AB06();
	}

	public void L90AB92()
	{
		A = 0xFFFF;
		[0x038D] = A;
		[0x0117] = 0;
		A = 0x0000;
		[0x7F0002] = A;
		A = 0x4000;
		temp = A & [0x1B43]; [0x1B43] &= ~A;
	}

	public void L90ABA8()
	{
		P |= 0x20;
		A = 0x3F;
		[0x012B] = A;
		A = 0xE0;
		[0x012C] = A;
		P &= ~0x20;
		return this.L90AB06();
	}

	public void L90AC9A()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		temp = A - 0x0007;
		
		if (Z == 0)
			return this.L90ACAF();

		A = 0x0001;
		[0x001C6A] = A;
		return this.L90ACD1();
	}

	public void L90ACAF()
	{
		temp = A - 0x0004;
		
		if (Z == 0)
			return this.L90ACBD();

		A = 0x0001;
		[0x001C4E] = A;
		return this.L90ACD1();
	}

	public void L90ACBD()
	{
		temp = A - 0x000F;
		
		if (Z == 0)
			return this.L90ACD1();

		A = [0x0371];
		temp = A - 0x0004;
		
		if (Z == 0)
			return this.L90ACD1();

		A = 0x0001;
		[0x001C4E] = A;
	}

	public void L90ACD1()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90ACD4()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x026B] = A;
		A = [0x0367];
		temp = A - 0x000E;
		
		if (Z == 1)
			return this.L90ACEC();

	}

	public void L90ACE6()
	{
		[0x026D]++;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90ACEC()
	{
		A = [0x7F052B];
		[0x7FE725] = A;
		return this.L90ACE6();
	}

	public void L90C047()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L90C04B()
	{
		A = [0x7FB3F1];
		
		if (N == 0)
			return this.L90C054();

		return this.L90C0DA();
	}

	public void L90C054()
	{
		X = A;
		A = [0x7FB3F5];
		[0x03E6] = A;
		A = [0xC104 + X];
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L90C0DD();

		temp = A - 0x8001;
		
		if (Z == 1)
			return this.L90C0E6();

		temp = A - 0x8002;
		
		if (Z == 0)
			return this.L90C071();

		return this.L90C0F9();
	}

	public void L90C071()
	{
		A &= 0x0F00;
		
		if (Z == 1)
			return this.L90C0A0();

		A = 0x0001;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0x20;
		[0x012E] = A;
		A = 0xCF;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x012A] = A;
		A = 0xBF;
		[0x012B] = A;
		A = [0x4A];
		A &= 0xFC;
		[0x4A] = A;
		P &= ~0x20;
		return this.L90C0BA();
	}

	public void L90C0A0()
	{
		A = 0x0000;
		[0x7FB3F5] = A;
		P |= 0x20;
		A = 0xB3;
		[0x012B] = A;
		A = 0x12;
		[0x012A] = A;
		A = 0xE0;
		[0x012C] = A;
		P &= ~0x20;
	}

	public void L90C0BA()
	{
		A = [0xC104 + X];
		
		if (N == 1)
			return this.L90C0C4();

		A &= 0x000F;
		return this.L90C0C7();
	}

	public void L90C0C4()
	{
		A |= 0x0F00;
	}

	public void L90C0C7()
	{
		[0x0117] = A;
		[0x7F0002] = A;
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
	}

	public void L90C0DA()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90C0DD()
	{
		A = 0xFFFF;
		[0x7FB3F1] = A;
		return this.L90C0DA();
	}

	public void L90C0E6()
	{
		A = [0x7FB3F1];
		C = 0;
		A += 0x0002 + C;
		[0x7FB3F1] = A;
		[0x7FB3F3] = A;
		return this.L90C04B();
	}

	public void L90C0F9()
	{
		A = [0x7FB3F3];
		[0x7FB3F1] = A;
		return this.L90C04B();
	}

	public void L90C72F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L90C733()
	{
		A = [0x7F1EEF];
		
		if (N == 0)
			return this.L90C746();

		A = 0x0000;
		[0x0117] = A;
		[0x7F0002] = A;
		return this.L90C779();
	}

	public void L90C746()
	{
		X = A;
		A = [0xC7A3 + X];
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L90C77C();

		temp = A - 0x8001;
		
		if (Z == 1)
			return this.L90C785();

		temp = A - 0x8002;
		
		if (Z == 1)
			return this.L90C798();

		A = [0xC7A3 + X];
		
		if (N == 1)
			return this.L90C763();

		A &= 0x000F;
		return this.L90C766();
	}

	public void L90C763()
	{
		A |= 0x0F00;
	}

	public void L90C766()
	{
		[0x0117] = A;
		[0x7F0002] = A;
		A = [0x7F1EEF];
		C = 0;
		A += 0x0002 + C;
		[0x7F1EEF] = A;
	}

	public void L90C779()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90C77C()
	{
		A = 0xFFFF;
		[0x7F1EEF] = A;
		return this.L90C779();
	}

	public void L90C785()
	{
		A = [0x7F1EEF];
		C = 0;
		A += 0x0002 + C;
		[0x7F1EEF] = A;
		[0x7F1EF1] = A;
		return this.L90C733();
	}

	public void L90C798()
	{
		A = [0x7F1EF1];
		[0x7F1EEF] = A;
		return this.L90C733();
	}

	public void L90CF85()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
	}

	public void L90CF89()
	{
		A = [0x7F2CC3];
		
		if (N == 0)
			return this.L90CFAB();

		P |= 0x20;
		A = 0xE0;
		[0x012E] = A;
		[0x012D] = A;
		[0x012C] = A;
		P &= ~0x20;
		A = 0x0000;
		[0x0117] = A;
		[0x7F0002] = A;
		return this.L90D031();
	}

	public void L90CFAB()
	{
		X = A;
		A = [0x7F2CC5];
		[0x03E6] = A;
		A = [0xD05B + X];
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L90D034();

		temp = A - 0x8001;
		
		if (Z == 1)
			return this.L90D03D();

		temp = A - 0x8002;
		
		if (Z == 0)
			return this.L90CFC8();

		return this.L90D050();
	}

	public void L90CFC8()
	{
		A &= 0x0F00;
		
		if (Z == 1)
			return this.L90CFF7();

		A = 0x0001;
		[0x7F2CC5] = A;
		P |= 0x20;
		A = 0x20;
		[0x012E] = A;
		A = 0xCF;
		[0x012D] = A;
		[0x012C] = A;
		A = 0x00;
		[0x012A] = A;
		A = 0xBF;
		[0x012B] = A;
		A = [0x4A];
		A &= 0xFC;
		[0x4A] = A;
		P &= ~0x20;
		return this.L90D011();
	}

	public void L90CFF7()
	{
		A = 0x0000;
		[0x7F2CC5] = A;
		P |= 0x20;
		A = 0xB3;
		[0x012B] = A;
		A = 0x12;
		[0x012A] = A;
		A = 0xE0;
		[0x012C] = A;
		P &= ~0x20;
	}

	public void L90D011()
	{
		A = [0xD05B + X];
		
		if (N == 1)
			return this.L90D01B();

		A &= 0x000F;
		return this.L90D01E();
	}

	public void L90D01B()
	{
		A |= 0x0F00;
	}

	public void L90D01E()
	{
		[0x0117] = A;
		[0x7F0002] = A;
		A = [0x7F2CC3];
		C = 0;
		A += 0x0002 + C;
		[0x7F2CC3] = A;
	}

	public void L90D031()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90D034()
	{
		A = 0xFFFF;
		[0x7F2CC3] = A;
		return this.L90D031();
	}

	public void L90D03D()
	{
		A = [0x7F2CC3];
		C = 0;
		A += 0x0002 + C;
		[0x7F2CC3] = A;
		[0x7F2CC7] = A;
		return this.L90CF89();
	}

	public void L90D050()
	{
		A = [0x7F2CC7];
		[0x7F2CC3] = A;
		return this.L90CF89();
	}

	public void L90D15F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];
		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L90D175();

		temp = A - 0x0003;
		
		if (Z == 0)
			return this.L90D17D();

		A = [0x0369];
		
		if (Z == 1)
			return this.L90D17D();

	}

	public void L90D175()
	{
		[0x026D]++;
		[0x035D] = 0;
		return this.L90D1B3();
	}

	public void L90D17D()
	{
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xD1B6 + X)]();
	}

	public void L90D1B3()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EEAE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x12] = A;
		A &= 0xFFFF;
		
		if (N == 0)
			return this.L90EEBC();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EEBC()
	{
		Y = 0x0005;
		X = 0x0008;
	}

	public void L90EEC2()
	{
		A = [0x7F051B + X];
		[0x7F051D + X] = A;
		X--;
		X--;
		Y--;
		
		if (Z == 0)
			return this.L90EEC2();

		A = [0x12];
		[0x7F051B] = A;
		A = [0x7F0527];
		A++;
		[0x7F0527] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EF07()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x7F0527];
		A <<= 1;
		X = A;
		A = 0xFFFF;
	}

	public void L90EF14()
	{
		temp = X - 0x000C;
		
		if (N == 0)
			return this.L90EF21();

		[0x7F051B + X] = A;
		X++;
		X++;
		return this.L90EF14();
	}

	public void L90EF21()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EF24()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x03F8];
		this.L90EEAE();
		A = [0x03F6];
		this.L90EEAE();
		A = 0xFFFF;
		[0x03F6] = A;
		[0x03F8] = A;
		this.L90EF07();
		A = [0x0381];
		
		if (Z == 0)
			return this.L90EF6A();

		A = [0x7F0527];
		temp = A - 0x0003;
		
		if (C == 1)
			return this.L90EF6A();

		A = [0x7F051B];
		[0x03F6] = A;
		A = [0x7F051D];
		[0x03F8] = A;
		A = 0x0000;
		[0x7F0527] = A;
		this.L90EF07();
	}

	public void L90EF6A()
	{
		this.L90955E();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L90EF71()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x12] = A;
		[0x18] = 0;
		A = [0x7F0527];
		[0x16] = A;
		Y = A;
		
		if (Z == 1)
			return this.L90EF91();

		X = 0x0000;
	}

	public void L90EF85()
	{
		A = [0x7F051B + X];
		this.L90F05A();
		X++;
		X++;
		Y--;
		
		if (Z == 0)
			return this.L90EF85();

	}

	public void L90EF91()
	{
		A = [0x03F6];
		
		if (N == 1)
			return this.L90EF9B();

		this.L90F05A();
		[0x16]++;
	}

	public void L90EF9B()
	{
		A = [0x03F8];
		
		if (N == 1)
			return this.L90EFA5();

		this.L90F05A();
		[0x16]++;
	}

	public void L90EFA5()
	{
		X = 0x0000;
		P |= 0x20;
	}

	public void L90EFAA()
	{
		A = [0xF0DA + X];
		temp = A - 0xFF;
		
		if (Z == 1)
			return this.L90EFC1();

		temp = A - [0x12];
		
		if (Z == 1)
			return this.L90EFC5();

	}

	public void L90EFB5()
	{
		P &= ~0x20;
		A = X;
		C = 0;
		A += 0x0009 + C;
		X = A;
		P |= 0x20;
		return this.L90EFAA();
	}

	public void L90EFC1()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		C = 1;
		return;
	}

	public void L90EFC5()
	{
		A = [0xF0DB + X];
		
		if (N == 1)
			return this.L90EFDF();

		temp = A - [0x03C3];
		
		if (Z == 1)
			return this.L90EFD3();

		
		if (C == 0)
			return this.L90EFDF();

		return this.L90EFB5();
	}

	public void L90EFD3()
	{
		A = [0xF0DC + X];
		temp = A - [0x03C5];
		
		if (Z == 1)
			return this.L90EFDF();

		
		if (C == 0)
			return this.L90EFDF();

		return this.L90EFB5();
	}

	public void L90EFDF()
	{
		A = [0xF0DD + X];
		
		if (N == 1)
			return this.L90EFF7();

		temp = A - [0x03C3];
		
		if (Z == 1)
			return this.L90EFED();

		
		if (C == 1)
			return this.L90EFF7();

		return this.L90EFB5();
	}

	public void L90EFED()
	{
		A = [0xF0DE + X];
		temp = A - [0x03C5];
		
		if (C == 1)
			return this.L90EFF7();

		return this.L90EFB5();
	}

	public void L90EFF7()
	{
		A = [0x7F052B];
		temp = A - [0xF0DF + X];
		
		if (C == 1)
			return this.L90F002();

		return this.L90EFB5();
	}

	public void L90F002()
	{
		A = [0x7F052B];
		temp = A - [0xF0E0 + X];
		
		if (Z == 1)
			return this.L90F00F();

		
		if (C == 0)
			return this.L90F00F();

		return this.L90EFB5();
	}

	public void L90F00F()
	{
		A = [0xF0E1 + X];
		temp = A - 0xFF;
		
		if (Z == 1)
			return this.L90F01D();

		temp = A - [0x036D];
		
		if (Z == 1)
			return this.L90F01D();

		return this.L90EFB5();
	}

	public void L90F01D()
	{
		A = [0xF0E2 + X];
		[0x14] = A;
		temp = A - 0x03;
		
		if (Z == 0)
			return this.L90F02F();

		A = [0x03FE];
		temp = A - 0x05;
		
		if (Z == 0)
			return this.L90F04B();

		return this.L90EFB5();
	}

	public void L90F02F()
	{
		A = [0x18];
		
		if (Z == 0)
			return this.L90F042();

		A = [0x16];
		temp = A - 0x05;
		
		if (C == 0)
			return this.L90F04B();

		A = [0x14];
		temp = A - 0x0E;
		
		if (Z == 1)
			return this.L90F042();

		return this.L90EFB5();
	}

	public void L90F042()
	{
		A = [0x16];
		temp = A - 0x06;
		
		if (C == 0)
			return this.L90F04B();

		return this.L90EFB5();
	}

	public void L90F04B()
	{
		P &= ~0x20;
		A = [0x14];
		A &= 0x00FF;
		[0x7F0529] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		C = 0;
		return;
	}

	public void L90F05A()
	{
		temp = A - 0x000E;
		
		if (Z == 0)
			return this.L90F061();

		[0x18]++;
	}

	public void L90F061()
	{
		return;
	}

	public void L918054()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x01;
		[0x7FE75E] = A;
		P &= ~0x20;
		A = 0x0000;
		[0x7FE751] = A;
		A = [0x00];
		[0x7FE753] = A;
		A = [0x01];
		[0x7FE754] = A;
		A = 0x0002;
		[0x7FE756] = A;
		[0x7FE758] = A;
		A = 0x0000;
		[0x7FE74F] = A;
		[0x7FE75A] = A;
		[0x7FE75C] = A;
		[0x7FE815] = A;
		[0x7FE817] = A;
		A = 0x9500;
		[0x7FE765] = A;
		A = 0xAE80;
		[0x7FE764] = A;
		A = 0x9100;
		[0x7FE768] = A;
		A = 0x8BF1;
		[0x7FE767] = A;
		X = 0x0000;
		A = 0x0000;
	}

	public void L9180B6()
	{
		[0x7FE76E + X] = A;
		X++;
		X++;
		temp = X - 0x0010;
		
		if (C == 0)
			return this.L9180B6();

		A = 0x7E00;
		[0x7FE80F] = A;
		A = 0x3154;
		[0x7FE80E] = A;
		A = 0x0808;
		[0x7FE813] = A;
		A = 0x0000;
		[0x7FE827] = A;
		A = 0x7E00;
		[0x7FE80F] = A;
		A = 0x3210;
		[0x7FE80E] = A;
		A = 0x1C00;
		[0x7FE811] = A;
		A = 0x0810;
		[0x7FE813] = A;
		A = 0x2180;
		[0x7FE760] = A;
		A = 0x0080;
		[0x7FE762] = A;
		A = 0xFFFF;
		[0x7FE81C] = A;
		[0x7FE81E] = A;
		P = Stack.Pop();
		return;
	}

	public void L918C64()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x03AB] = 0;
		A = [0x026D];
		A++;
		[0x12] = A;
		A = 0xC000;
		[0x14] = A;
		A = [0x0367];
		temp = A - 0x000D;
		
		if (Z == 0)
			return this.L918C83();

		A = 0x0093;
		[0x12] = A;
	}

	public void L918C83()
	{
		A = [0x0381];
		
		if (Z == 0)
			return this.L918C99();

		A = [0x0367];
		temp = A - 0x000E;
		
		if (Z == 0)
			return this.L918C99();

		A = [0x7F052B];
		A--;
		
		if (Z == 0)
			return this.L918C99();

		[0x14] = 0;
	}

	public void L918C99()
	{
		A = [0x036F];
		A--;
		
		if (Z == 0)
			return this.L918CA2();

		return this.L918D1E();
	}

	public void L918CA2()
	{
		A = [0x0371];
		temp = A - 0x0002;
		
		if (C == 1)
			return this.L918D17();

		A = [0x14];
		[0x03AB] = A;
	}

	public void L918CAF()
	{
		A = [0x7F052B];
		
		if (Z == 0)
			return this.L918D04();

		A = [0x0367];
		A <<= 1;
		C = 0;
		A += [0x0367] + C;
		X = A;
		A = [0x0381];
		
		if (Z == 1)
			return this.L918CC9();

		A = X;
		C = 0;
		A += 0x0030 + C;
		X = A;
	}

	public void L918CC9()
	{
		A = [0x8D26 + X];
		[0x00] = A;
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L918CF9();

		A = [0x8D27 + X];
		[0x01] = A;
	}

	public void L918CD8()
	{
		A = [0x12];
		[0x03A1] = A;
		A = 0x0053;
		[0x026D] = A;
		this.L918054();
	}

	public void L918CE7()
	{
		P |= 0x20;
		A = [0x0101];
		A &= 0xE7;
		[0x0101] = A;
		P &= ~0x20;
		this.L91A8EC();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L918CF9()
	{
		A = [0x03AB];
		A |= 0x0200;
		[0x03AB] = A;
		return this.L918CD8();
	}

	public void L918D04()
	{
		this.L918D86();
		
		if (C == 1)
			return this.L918CF9();

		A = [(0x03)];
		
		if (Z == 1)
			return this.L918CF9();

		[0x00] = A;
		[0x03]++;
		A = [(0x03)];
		[0x01] = A;
		return this.L918CD8();
	}

	public void L918D17()
	{
		A = [0x12];
		[0x026D] = A;
		return this.L918CE7();
	}

	public void L918D1E()
	{
		A = 0xC200;
		[0x03AB] = A;
		return this.L918CAF();
	}

	public void L918D86()
	{
		A = [0x0367];
		A <<= 1;
		X = A;
		A = [0x0381];
		
		if (Z == 0)
			return this.L918D9B();

		A = [0x8DE0 + X];
	}

	public void L918D93()
	{
		[0x03] = A;
		[0x06] = A;
		
		if (Z == 0)
			return this.L918DA0();

		C = 1;
		return;
	}

	public void L918D9B()
	{
		A = [0x8E63 + X];
		return this.L918D93();
	}

	public void L918DA0()
	{
		A = [0x7F052B];
		[0x0337] = A;
	}

	public void L918DA7()
	{
		this.L918DB9();
		[0x0337]--;
		
		if (Z == 0)
			return this.L918DA7();

		A = [0x03];
		C = 1;
		A -= 0x0003 - !C;
		[0x03] = A;
		C = 0;
		return;
	}

	public void L918DB9()
	{
		A = [(0x03)];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L918DCE();

		temp = A - 0xFFFE;
		
		if (Z == 1)
			return this.L918DDA();

		A = [0x03];
		C = 0;
		A += 0x0003 + C;
		[0x03] = A;
		return;
	}

	public void L918DCE()
	{
		A = [0x03];
		C = 0;
		A += 0x0002 + C;
		[0x03] = A;
		[0x06] = A;
		return this.L918DB9();
	}

	public void L918DDA()
	{
		A = [0x06];
		[0x03] = A;
		return this.L918DB9();
	}

	public void L918EC2()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];
		temp = A - 0x0002;
		
		if (C == 1)
			return this.L918F3B();

		A = [0x036F];
		A--;
		
		if (Z == 1)
			return this.L918F40();

		A = [0x0367];
		A <<= 1;
		C = 0;
		A += [0x0367] + C;
		X = A;
		A = [0x0381];
		
		if (Z == 1)
			return this.L918EE8();

		A = X;
		C = 0;
		A += 0x0030 + C;
		X = A;
	}

	public void L918EE8()
	{
		A = [0x8F56 + X];
		[0x00] = A;
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L918F3B();

		A = [0x8F57 + X];
		[0x01] = A;
	}

	public void L918EF7()
	{
		A = [0x026D];
		A++;
		[0x03A1] = A;
		A = 0x0053;
		[0x026D] = A;
		this.L918054();
		A = [0x0367];
		A <<= 1;
		X = A;
		A = [0x8FB6 + X];
		[0x03AB] = A;
		A = [0x0367];
		A <<= 1;
		X = A;
		A = [0x8FD6 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L918F23();

		[0x02EB] = A;
	}

	public void L918F23()
	{
		this.L91A8EC();
		A = 0xFFFF;
		[0x02F3] = A;
		P |= 0x20;
		A = [0x0101];
		A &= 0xE7;
		[0x0101] = A;
		P &= ~0x20;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L918F3B()
	{
		[0x026D]++;
		return this.L918F23();
	}

	public void L918F40()
	{
		this.L918FF6();
		
		if (C == 1)
			return this.L918F3B();

		A = [0x0367];
		temp = A - 0x0005;
		
		if (Z == 0)
			return this.L918F54();

		A = 0x803D;
		[0x02EB] = A;
	}

	public void L918F54()
	{
		return this.L918EF7();
	}

	public void L918FF6()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		A <<= 1;
		X = A;
		A = [0x0381];
		
		if (Z == 0)
			return this.L919009();

		A = [0x9046 + X];
		return this.L91900C();
	}

	public void L919009()
	{
		A = [0x9066 + X];
	}

	public void L91900C()
	{
		
		if (Z == 1)
			return this.L919042();

		this.L90EF71();
		
		if (C == 1)
			return this.L919042();

		C = 1;
		A -= 0x0003 - !C;
		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		A = [0x0381];
		
		if (Z == 0)
			return this.L919032();

		A = [0x918001 + X];
		[0x01] = A;
		A = [0x918000 + X];
		[0x00] = A;
		return this.L91903E();
	}

	public void L919032()
	{
		A = [0x91802B + X];
		[0x01] = A;
		A = [0x91802A + X];
		[0x00] = A;
	}

	public void L91903E()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		C = 0;
		return;
	}

	public void L919042()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		C = 1;
		return;
	}

	public void L91A8EC()
	{
		this.L908453();
		A = [0x03AB];
		A &= 0x1000;
		
		if (Z == 0)
			return this.L91A8FE();

		this.L80A10A();
		return this.L91A902();
	}

	public void L91A8FE()
	{
		this.L9084BD();
	}

	public void L91A902()
	{
		A = [0x03AB];
		A &= 0x0800;
		
		if (Z == 1)
			return this.L91A90E();

		this.L818001();
	}

	public void L91A90E()
	{
		A = [0x03AB];
		A &= 0x2000;
		
		if (Z == 1)
			return this.L91A91A();

		this.L908479();
	}

	public void L91A91A()
	{
		A = [0x03AB];
		A &= 0x0080;
		
		if (Z == 1)
			return this.L91A926();

		this.L90C72F();
	}

	public void L91A926()
	{
		A = [0x03AB];
		A &= 0x0040;
		
		if (Z == 1)
			return this.L91A932();

		this.L90CF85();
	}

	public void L91A932()
	{
		A = [0x03AB];
		A &= 0x0020;
		
		if (Z == 1)
			return this.L91A93E();

		this.L94B8B0();
	}

	public void L91A93E()
	{
		return;
	}

	public void L91AA56()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x09FC] = A;
		[0x09FE] = A;
		[0x09FA] = 0;
		X = 0x0000;
	}

	public void L91AA69()
	{
		[0x0A01 + X] = 0;
		X++;
		X++;
		temp = X - 0x001E;
		
		if (C == 0)
			return this.L91AA69();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91AA76()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x09FC];
		temp = A - [0x09FE];
		
		if (Z == 0)
			return this.L91AABA();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91AAB1();

		A = [0x0A79];
		
		if (Z == 1)
			return this.L91AA9D();

		X = [0x09FA];
		A = 0x0000;
	}

	public void L91AA92()
	{
		A |= [0x0A01 + X];
		
		if (Z == 0)
			return this.L91AA9D();

		X--;
		X--;
		
		if (N == 0)
			return this.L91AA92();

		return this.L91AAB4();
	}

	public void L91AA9D()
	{
		X = [0x09FA];
	}

	public void L91AAA0()
	{
		A = [0x0A01 + X];
		
		if (Z == 1)
			return this.L91AAAD();

		A = [0x0A1F + X];
		
		if (Z == 1)
			return this.L91AAE7();

		[0x0A1F + X]--;
	}

	public void L91AAAD()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L91AAA0();

	}

	public void L91AAB1()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91AAB4()
	{
		A = 0xFFFF;
		[0x09FC] = A;
	}

	public void L91AABA()
	{
		A = [0x09FC];
		[0x09FE] = A;
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91AAB1();

		A <<= 1;
		C = 0;
		A += [0x09FC] + C;
		X = A;
		this.L91AAD1();
		return this.L91AA9D();
	}

	public void L91AAD1()
	{
		A = [0xE3F6 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xE3F8 + X];
		[0x02] = A;
		[0x0A00] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();	//24-Bit Address
	}

	public void L91AAE7()
	{
		P |= 0x20;
		A = [0x0A00];
		[0x02] = A;
		P &= ~0x20;
		A = [0x0A3D + X];
		[0x00] = A;
		A = [[0x00]];
		A &= 0x00FF;
		temp = A & 0x0080;
		
		if (Z == 1)
			return this.L91AB02();

		return this.L91AB74();
	}

	public void L91AB02()
	{
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L91AB0A();

		return this.L91AB80();
	}

	public void L91AB0A()
	{
		temp = A - 0x0014;
		
		if (Z == 0)
			return this.L91AB12();

		return this.L91AB86();
	}

	public void L91AB12()
	{
		temp = A - 0x0015;
		
		if (Z == 0)
			return this.L91AB1A();

		return this.L91ABBD();
	}

	public void L91AB1A()
	{
		temp = A - 0x0002;
		
		if (Z == 0)
			return this.L91AB22();

		return this.L91ACE4();
	}

	public void L91AB22()
	{
		temp = A - 0x0006;
		
		if (Z == 0)
			return this.L91AB2A();

		return this.L91AC1E();
	}

	public void L91AB2A()
	{
		temp = A - 0x0008;
		
		if (Z == 0)
			return this.L91AB32();

		return this.L91AC62();
	}

	public void L91AB32()
	{
		temp = A - 0x000A;
		
		if (Z == 0)
			return this.L91AB3A();

		return this.L91AC7D();
	}

	public void L91AB3A()
	{
		temp = A - 0x000B;
		
		if (Z == 0)
			return this.L91AB42();

		return this.L91ACE7();
	}

	public void L91AB42()
	{
		temp = A - 0x000C;
		
		if (Z == 0)
			return this.L91AB4A();

		return this.L91AD1A();
	}

	public void L91AB4A()
	{
		temp = A - 0x0007;
		
		if (Z == 0)
			return this.L91AB52();

		return this.L91AC3E();
	}

	public void L91AB52()
	{
		temp = A - 0x0004;
		
		if (Z == 0)
			return this.L91AB5A();

		return this.L91ACC6();
	}

	public void L91AB5A()
	{
		temp = A - 0x0005;
		
		if (Z == 0)
			return this.L91AB62();

		return this.L91ACDB();
	}

	public void L91AB62()
	{
		temp = A - 0x0009;
		
		if (Z == 0)
			return this.L91AB6A();

		return this.L91AC9C();
	}

	public void L91AB6A()
	{
		temp = A - 0x0016;
		
		if (Z == 0)
			return this.L91AB72();

		return this.L91AD44();
	}

	public void L91AB72()
	{
		return this.L91AB72();
	}

	public void L91AB74()
	{
		A &= 0x007F;
		[0x0A1F + X] = A;
		[0x0A3D + X]++;
		return this.L91AAA0();
	}

	public void L91AB80()
	{
		[0x0A01 + X] = 0;
		return this.L91AAAD();
	}

	public void L91AB86()
	{
		Stack.Push(X);
		A = [0x09FF];
		[0x04] = A;
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		X = A;
		Y++;
		Y++;
		A = 0x7E00;
		[0x07] = A;
		A = [[0x00] + Y];
		[0x06] = A;
		Y = 0x0000;
	}

	public void L91ABA6()
	{
		A = [[0x03] + Y];
		[[0x06] + Y] = A;
		Y++;
		Y++;
		X--;
		
		if (Z == 0)
			return this.L91ABA6();

		X = Stack.Pop();
		A = [0x0A3D + X];
		C = 0;
		A += 0x0007 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91ABBD()
	{
		Stack.Push(X);
		A = [0x09FF];
		[0x04] = A;
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		Y++;
		Y++;
		A = [[0x00] + Y];
		A &= 0x00FF;
		[0x0A7B] = A;
		X = A;
		Y++;
		A = [[0x00] + Y];
		A &= 0x00FF;
		[0x0A7D] = A;
		Y++;
		A = 0x7E00;
		[0x07] = A;
		A = [[0x00] + Y];
		[0x06] = A;
		Y = 0x0000;
	}

	public void L91ABEB()
	{
		A = [[0x03] + Y];
		[[]] = A;
		[0xE6] <<= 1;
		[0xE6] <<= 1;
		[0xC8] <<= 1;
		Y++;
		X--;
		
		if (N == 0)
			return this.L91ABEB();

		X = [0x0A7B];
		A = [0x06];
		C = 0;
		A += 0x003E + C;
		C = 1;
		A -= [0x0A7B] - !C;
		C = 1;
		A -= [0x0A7B] - !C;
		[0x06] = A;
		[0x0A7D]--;
		
		if (N == 0)
			return this.L91ABEB();

		X = Stack.Pop();
		A = [0x0A3D + X];
		C = 0;
		A += 0x0007 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AC1E()
	{
		Y = 0x0001;
		A = 0x7E00;
		[0x04] = A;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		[[]] = A;
		A |= [0xBD];
		A &= [0x180A + X];
		A += 0x0005 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AC3E()
	{
		Y = 0x0001;
		A = 0x7E00;
		[0x04] = A;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		[0x06] = A;
		A = [(0x06)];
		[[]] = A;
		A |= [0xBD];
		A &= [0x180A + X];
		A += 0x0005 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AC62()
	{
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		[(0x03)] = A;
		A = [0x0A3D + X];
		C = 0;
		A += 0x0005 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AC7D()
	{
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		P |= 0x20;
		[(0x03)] = A;
		P &= ~0x20;
		A = [0x0A3D + X];
		C = 0;
		A += 0x0004 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AC9C()
	{
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		[0x06] = A;
		A = [(0x03)];
		[(0x06)] = A;
		A = [0x0A3D + X];
		C = 0;
		A += 0x0005 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91ACC6()
	{
		A = [0x0A3D + X];
		C = 0;
		A += 0x0003 + C;
		[0x0A5B + X] = A;
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91ACDB()
	{
		A = [0x0A5B + X];
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91ACE4()
	{
		return this.L91AAB4();
	}

	public void L91ACE7()
	{
		Y = 0x0001;
		A = 0x7E00;
		[0x04] = A;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		A &= 0x00FF;
		C = 0;
		A += 0x00A0 + C;
		A |= 0x2000;
		[[]] = A;
		A |= [0x18];
		A += 0x0010 + C;
		Y = 0x0040;
		[[0x03] + Y] = A;
		A = [0x0A3D + X];
		C = 0;
		A += 0x0004 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AD1A()
	{
		Y = 0x0001;
		A = 0x7E00;
		[0x04] = A;
		A = [[0x00] + Y];
		[0x03] = A;
		Y = 0x0003;
		A = [[0x00] + Y];
		A &= 0x00FF;
		C = 0;
		A += 0x0090 + C;
		A |= 0x2000;
		[[]] = A;
		A |= [0xBD];
		A &= [0x180A + X];
		A += 0x0004 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AD44()
	{
		Y = 0x0001;
		A = [[0x00] + Y];
		[0x03] = A;
		A = [(0x03)];
		
		if (N == 0)
			return this.L91AD5A();

		Y = 0x0003;
		A = [[0x00] + Y];
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AD5A()
	{
		A = [0x0A3D + X];
		C = 0;
		A += 0x0005 + C;
		[0x0A3D + X] = A;
		return this.L91AAA0();
	}

	public void L91AD68()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x0AB5] = A;
		[0x0AB7] = A;
		[0x0AFB] = A;
		X = 0x0000;
	}

	public void L91AD7B()
	{
		[0x0ABB + X] = 0;
		[0x0ADF + X] = 0;
		X++;
		X++;
		temp = X - 0x0006;
		
		if (C == 0)
			return this.L91AD7B();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B06F()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0xFFFF;
		[0x0B00] = A;
		[0x0B02] = A;
		X = 0x0000;
	}

	public void L91B081()
	{
		[0x0B04 + X] = 0;
		[0x0B1C + X] = 0;
		X++;
		X++;
		temp = X - 0x000C;
		
		if (C == 0)
			return this.L91B081();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B091()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0B00];
		temp = A - [0x0B02];
		
		if (Z == 0)
			return this.L91B0D2();

		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91B0C9();

		A = [0x0B04];
		A |= [0x0B06];
		A |= [0x0B08];
		A |= [0x0B0A];
		A |= [0x0B0C];
		A |= [0x0B0E];
		
		if (Z == 0)
			return this.L91B0BB();

		A = [0x0B34];
		
		if (Z == 0)
			return this.L91B0CC();

	}

	public void L91B0BB()
	{
		X = 0x000A;
	}

	public void L91B0BE()
	{
		A = [0x0B04 + X];
		
		if (Z == 1)
			return this.L91B0C5();

		
		if (N == 0)
			return this.L91B117();

	}

	public void L91B0C5()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L91B0BE();

	}

	public void L91B0C9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L91B0CC()
	{
		A = 0xFFFF;
		[0x0B00] = A;
	}

	public void L91B0D2()
	{
		[0x0B0E] = 0;
		[0x0B26] = 0;
		A = [0x0B00];
		[0x0B02] = A;
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L91B0F0();

		[0x12] = A;
		A <<= 1;
		C = 0;
		A += [0x12] + C;
		X = A;
		this.L91B104();
		return this.L91B0BB();
	}

	public void L91B0F0()
	{
		[0x0B04] = 0;
		[0x0B06] = 0;
		[0x0B08] = 0;
		[0x0B0A] = 0;
		[0x0B0C] = 0;
		[0x0B0E] = 0;
		return this.L91B0C9();
	}

	public void L91B104()
	{
		A = [0xB2A5 + X];
		[0x00] = A;
		P |= 0x20;
		A = [0xB2A7 + X];
		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		return [[0x0000]]();	//24-Bit Address
	}

	public void L91B117()
	{
		A = [0x0B1C + X];
		
		if (Z == 1)
			return this.L91B121();

		[0x0B1C + X]--;
		return this.L91B0C5();
	}

	public void L91B121()
	{
		A = [0x0B10 + X];
		[0x00] = A;
		A = [(0x00)];
		A &= 0x00FF;
		temp = A - 0x0081;
		
		if (Z == 0)
			return this.L91B133();

		return this.L91B17E();
	}

	public void L91B133()
	{
		temp = A - 0x0083;
		
		if (Z == 0)
			return this.L91B13B();

		return this.L91B216();
	}

	public void L91B13B()
	{
		Y = A;
		A &= 0x00C0;
		temp = A - 0x00C0;
		
		if (Z == 0)
			return this.L91B147();

		return this.L91B221();
	}

	public void L91B147()
	{
		A = Y;
		A &= 0x00A0;
		temp = A - 0x00A0;
		
		if (Z == 0)
			return this.L91B153();

		return this.L91B23B();
	}

	public void L91B153()
	{
		A = Y;
		temp = A - 0x0085;
		
		if (Z == 0)
			return this.L91B15C();

		return this.L91B29F();
	}

	public void L91B15C()
	{
		temp = A - 0x0086;
		
		if (Z == 0)
			return this.L91B164();

		return this.L91B263();
	}

	public void L91B164()
	{
		temp = A - 0x0087;
		
		if (Z == 0)
			return this.L91B16C();

		return this.L91B281();
	}

	public void L91B16C()
	{
		temp = A - 0x0082;
		
		if (Z == 0)
			return this.L91B174();

		return this.L91B1C8();
	}

	public void L91B174()
	{
		A &= 0x0080;
		
		if (Z == 0)
			return this.L91B17C();

		return this.L91B208();
	}

	public void L91B17C()
	{
		return this.L91B17C();
	}

	public void L91B17E()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B198()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		Y = A;
		A = [0x7F1261 + X];
		X = [0x12];
		[0x7F1061 + X] = A;
		A = Y;
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;
		
		if (Z == 0)
			return this.L91B198();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B1C8()
	{
		Stack.Push(X);
		Y = 0x0001;
		A = [(0x00) + Y];
		A &= 0x00FF;
		A <<= 1;
		[0x12] = A;
		Y++;
		A = [(0x00) + Y];
		A &= 0x00FF;
		[0x14] = A;
		Y++;
		A = [(0x00) + Y];
		A <<= 1;
		[0x16] = A;
	}

	public void L91B1E2()
	{
		X = [0x16];
		A = [0x7F0761 + X];
		X = [0x12];
		[0x7F0561 + X] = A;
		[0x12]++;
		[0x12]++;
		[0x16]++;
		[0x16]++;
		[0x14]--;
		
		if (Z == 0)
			return this.L91B1E2();

		X = Stack.Pop();
		A = [0x0B10 + X];
		C = 0;
		A += 0x0005 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B208()
	{
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B1C + X] = A;
		[0x0B10 + X]++;
		return this.L91B0C5();
	}

	public void L91B216()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B221()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		[0x00]++;
		A = [(0x00)];
		A &= 0x00FF;
		[0x0B28 + Y] = A;
		[0x0B10 + X]++;
		[0x0B10 + X]++;
		return this.L91B121();
	}

	public void L91B23B()
	{
		A = [(0x00)];
		A &= 0x001F;
		A <<= 1;
		Y = A;
		A = [0x0B28 + Y];
		A--;
		[0x0B28 + Y] = A;
		
		if (Z == 1)
			return this.L91B256();

		Y = 0x0001;
		A = [(0x00) + Y];
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B256()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0003 + C;
		[0x0B10 + X] = A;
		return this.L91B121();
	}

	public void L91B263()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];
		
		if (Z == 1)
			return this.L91B274();

		A = 0xFFFF;
		[0x0B04 + Y] = A;
	}

	public void L91B274()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B281()
	{
		Y = 0x0001;
		A = [(0x00) + Y];
		Y = A;
		A = [0x0B04 + Y];
		
		if (Z == 1)
			return this.L91B292();

		A = 0x0001;
		[0x0B04 + Y] = A;
	}

	public void L91B292()
	{
		A = [0x0B10 + X];
		C = 0;
		A += 0x0002 + C;
		[0x0B10 + X] = A;
		return this.L91B0C5();
	}

	public void L91B29F()
	{
		[0x0B04 + X] = 0;
		return this.L91B0C5();
	}

	public byte[] FunctionPointerTable91B2A5 = new byte[]
	{
		0x44, 0xBF, 0x91,
		0x58, 0xCE, 0x91,
		0xAB, 0xCE, 0x91,
		0xF4, 0xD8, 0x91,
		0x36, 0xD9, 0x91,
		0xFD, 0xDA, 0x91,
		0x11, 0xB3, 0x91,
		0x15, 0xDC, 0x91,
		0xE5, 0xDC, 0x91,
		0x12, 0xB3, 0x91,
		0x13, 0xB3, 0x91,
		0x28, 0xDF, 0x91,
		0x2A, 0xB4, 0x91,
		0xAA, 0xDF, 0x91,
		0xAA, 0xDF, 0x91,
		0xAA, 0xDF, 0x91,
		0xAA, 0xDF, 0x91,
		0xA2, 0xB3, 0x91,
		0xE6, 0xB3, 0x91,
		0xF3, 0xE0, 0x91,
		0x5D, 0xB4, 0x91,
		0xAF, 0xB4, 0x91,
		0x0D, 0xB5, 0x91,
		0x6B, 0xB5, 0x91,
		0x8D, 0xB5, 0x91,
		0xD3, 0xB5, 0x91,
		0x82, 0xB8, 0x91,
		0xDE, 0xB7, 0x91,
		0x0C, 0xB8, 0x91,
		0x02, 0xB9, 0x91,
		0x74, 0xBA, 0x91,
		0x40, 0xBC, 0x91,
		0x7D, 0xBC, 0x91,
		0xB1, 0xBC, 0x91,
		0x7D, 0xBE, 0x91,
		0xC7, 0xBB, 0x91,
		//0x6B, 0x6B, 0x8B,
		//0x08, 0x4B, 0xAB,
		//0xA9, 0x01, 0x00,
		//0x8D, 0x04, 0x0B,
		//0xA9, 0x3B, 0xB3,
	}

	public byte[] FunctionPointerTable91E3F6 = new byte[]
	{
		0x23, 0xE4, 0x91,
		0x5A, 0xE4, 0x91,
		0x52, 0xF0, 0x91,
		0x52, 0xF0, 0x91,
		0x91, 0xE4, 0x91,
		0x52, 0xF0, 0x91,
		0x52, 0xF0, 0x91,
		0x52, 0xF0, 0x91,
		0x52, 0xF0, 0x91,
		0x0D, 0xF3, 0x91,
		0x60, 0xF4, 0x91,
		0xF2, 0xF3, 0x91,
		0x29, 0xF4, 0x91,
		0x52, 0xF0, 0x91,
		0x71, 0xF3, 0x91,
		//0x8B, 0x08, 0x4B,
		//0xAB, 0xA9, 0x00,
		//0x00, 0x8D, 0xFA,
		//0x09, 0xA9, 0x01,
	}

	public void L94817D()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x81;
		[0x03D5] = A;
		P &= ~0x20;
		A = [0x0410];
		
		if (Z == 1)
			return this.L9481AF();

		A = [0x0498];
		
		if (Z == 1)
			return this.L9481AC();

		
		if (N == 1)
			return this.L9481AC();

		A = [0x0416];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x825B + X)]();
	}

	public void L9481AC()
	{
		[0x0410] = 0;
	}

	public void L9481AF()
	{
		A = [0x0412];
		
		if (Z == 1)
			return this.L9481D4();

		A = [0x049A];
		
		if (Z == 1)
			return this.L9481D1();

		
		if (N == 1)
			return this.L9481D1();

		A = [0x0418];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x825F + X)]();
	}

	public void L9481D1()
	{
		[0x0412] = 0;
	}

	public void L9481D4()
	{
		A = [0x0414];
		
		if (Z == 1)
			return this.L948218();

		A = [0x049C];
		
		if (Z == 1)
			return this.L948215();

		
		if (N == 1)
			return this.L948215();

		A = [0x041A];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8263 + X)]();
	}

	public void L948215()
	{
		[0x0414] = 0;
	}

	public void L948218()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L948267()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x80;
		[0x03D5] = A;
		P &= ~0x20;
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8282 + X)]();
	}

	public void L948AD5()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0498];
		
		if (Z == 0)
			return this.L948AE0();

		return this.L948B2F();
	}

	public void L948AE0()
	{
		A = [0x045A];
		A |= [0x045C];
		
		if (Z == 1)
			return this.L948B2F();

		A = [0x0434];
		C = 0;
		A += [0x045A] + C;
		[0x0434] = A;
		A = [0x0436];
		[0x0438] = A;
		A += [0x045C] + C;
		[0x0436] = A;
		A = [0x045C];
		
		if (N == 0)
			return this.L948B08();

		this.L948B32();
		return this.L948B0B();
	}

	public void L948B08()
	{
		this.L948B8E();
	}

	public void L948B0B()
	{
		A = [0x0436];
		A &= 0x01FF;
		[0x010F] = A;
		A = [0x0438];
		A ^= [0x0436];
		A &= 0xFFF0;
		
		if (Z == 1)
			return this.L948B2F();

		A = [0x0436];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		[0x042E] = A;
		A = 0x0001;
		[0x0410] = A;
	}

	public void L948B2F()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L948B32()
	{
		A = 0x0000;
		[0x0416] = A;
		A = [0x049E];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8B44 + X)]();
	}

	public void L948B8E()
	{
		A = 0x0001;
		[0x0416] = A;
		A = [0x049E];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8BA0 + X)]();
	}

	public void L948BEB()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x049A];
		
		if (Z == 0)
			return this.L948BF6();

		return this.L948C45();
	}

	public void L948BF6()
	{
		A = [0x0462];
		A |= [0x0464];
		
		if (Z == 1)
			return this.L948C45();

		A = [0x043E];
		C = 0;
		A += [0x0462] + C;
		[0x043E] = A;
		A = [0x0440];
		[0x0442] = A;
		A += [0x0464] + C;
		[0x0440] = A;
		A = [0x0464];
		
		if (N == 0)
			return this.L948C1E();

		this.L948C48();
		return this.L948C21();
	}

	public void L948C1E()
	{
		this.L948C9A();
	}

	public void L948C21()
	{
		A = [0x0440];
		A &= 0x01FF;
		[0x0113] = A;
		A = [0x0442];
		A ^= [0x0440];
		A &= 0xFFF0;
		
		if (Z == 1)
			return this.L948C45();

		A = [0x0440];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		[0x0430] = A;
		A = 0x0001;
		[0x0412] = A;
	}

	public void L948C45()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L948C48()
	{
		A = 0x0000;
		[0x0418] = A;
		A = [0x04A0];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8C5A + X)]();
	}

	public void L948C9A()
	{
		A = 0x0001;
		[0x0418] = A;
		A = [0x04A0];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8CAC + X)]();
	}

	public void L948CE0()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x049C];
		
		if (Z == 0)
			return this.L948CEB();

		return this.L948D3B();
	}

	public void L948CEB()
	{
		A = [0x046A];
		A |= [0x046C];
		
		if (Z == 1)
			return this.L948D3B();

		A = [0x0448];
		C = 0;
		A += [0x046A] + C;
		[0x0448] = A;
		A = [0x044A];
		[0x044C] = A;
		A += [0x046C] + C;
		[0x044A] = A;
		A = [0x046C];
		
		if (N == 0)
			return this.L948D13();

		this.L948D3E();
		return this.L948D16();
	}

	public void L948D13()
	{
		this.L948D61();
	}

	public void L948D16()
	{
		A = [0x044A];
		A &= 0x01FF;
		[0x7F000A] = A;
		A = [0x044C];
		A ^= [0x044A];
		A &= 0xFFF0;
		
		if (Z == 1)
			return this.L948D3B();

		A = [0x044A];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		[0x0432] = A;
		A = 0x0001;
		[0x0414] = A;
	}

	public void L948D3B()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L948D3E()
	{
		A = 0x0000;
		[0x041A] = A;
		A = [0x04A2];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8D50 + X)]();
	}

	public void L948D61()
	{
		A = 0x0001;
		[0x041A] = A;
		A = [0x04A2];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x8D73 + X)]();
	}

	public void L948D87()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x040C];
		C = 0;
		A += [0x0408] + C;
		[0x040C] = A;
		A = [0x040E];
		A += [0x040A] + C;
		[0x040E] = A;
		A = [0x040E];
		A &= [0x0406];
		A <<= 1;
		X = A;
		A = [0x7FB361 + X];
		[0x7FB3E1] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L949269()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x03E8];
		
		if (Z == 1)
			return this.L94927E();

		[0x0458] = 0;
		[0x0456] = 0;
		[0x0454] = 0;
		[0x0452] = 0;
	}

	public void L94927E()
	{
		this.L949287();
		this.L94953B();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L949287()
	{
		A = [0x0456];
		[0x14] = A;
		A = [0x0458];
		[0x12] = A;
		
		if (N == 1)
			return this.L949306();

		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE727] = A;
		A = [0x14];
		[0x7FE729] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE72B] = A;
		A = [0x14];
		[0x7FE72D] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE72F] = A;
		A = [0x14];
		[0x7FE731] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE733] = A;
		A = [0x14];
		[0x7FE735] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE737] = A;
		A = [0x14];
		[0x7FE739] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE73B] = A;
		A = [0x14];
		[0x7FE73D] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE73F] = A;
		A = [0x14];
		[0x7FE741] = A;
		return this.L949417();
	}

	public void L949306()
	{
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L94931C();

		A = [0x14];
		
		if (Z == 1)
			return this.L949321();

	}

	public void L94931C()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949321()
	{
		A = [0x12];
		[0x7FE727] = A;
		A = [0x14];
		[0x7FE729] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L949343();

		A = [0x14];
		
		if (Z == 1)
			return this.L949348();

	}

	public void L949343()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949348()
	{
		A = [0x12];
		[0x7FE72B] = A;
		A = [0x14];
		[0x7FE72D] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L94936A();

		A = [0x14];
		
		if (Z == 1)
			return this.L94936F();

	}

	public void L94936A()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L94936F()
	{
		A = [0x12];
		[0x7FE72F] = A;
		A = [0x14];
		[0x7FE731] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L949391();

		A = [0x14];
		
		if (Z == 1)
			return this.L949396();

	}

	public void L949391()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949396()
	{
		A = [0x12];
		[0x7FE733] = A;
		A = [0x14];
		[0x7FE735] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L9493B8();

		A = [0x14];
		
		if (Z == 1)
			return this.L9493BD();

	}

	public void L9493B8()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L9493BD()
	{
		A = [0x12];
		[0x7FE737] = A;
		A = [0x14];
		[0x7FE739] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L9493DF();

		A = [0x14];
		
		if (Z == 1)
			return this.L9493E4();

	}

	public void L9493DF()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L9493E4()
	{
		A = [0x12];
		[0x7FE73B] = A;
		A = [0x14];
		[0x7FE73D] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L949406();

		A = [0x14];
		
		if (Z == 1)
			return this.L94940B();

	}

	public void L949406()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L94940B()
	{
		A = [0x12];
		[0x7FE73F] = A;
		A = [0x14];
		[0x7FE741] = A;
	}

	public void L949417()
	{
		A = [0x0458];
		[0x12] = A;
		A = [0x0456];
		[0x14] = A;
		[0x14] <<= 1;
		Cpu.ROL(0x12);
		A = [0x12];
		[0x7FE749] = A;
		A = [0x14];
		[0x7FE747] = A;
		[0x14] <<= 1;
		Cpu.ROL(0x12);
		A = [0x12];
		[0x7FE74D] = A;
		A = [0x14];
		[0x7FE74B] = A;
		A = [0x0458];
		[0x12] = A;
		A = [0x0456];
		[0x14] = A;
		A = [0x0367];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		Y = A;
		X = Y;
		return [(0x94BB + X)]();
	}

	public void L94953B()
	{
		A = [0x0452];
		[0x14] = A;
		A = [0x0454];
		[0x12] = A;
		
		if (N == 0)
			return this.L94954A();

		return this.L9495D9();
	}

	public void L94954A()
	{
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE727] = A;
		A = [0x14];
		[0x7FE729] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE72B] = A;
		A = [0x14];
		[0x7FE72D] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE72F] = A;
		A = [0x14];
		[0x7FE731] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE733] = A;
		A = [0x14];
		[0x7FE735] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE737] = A;
		A = [0x14];
		[0x7FE739] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE73B] = A;
		A = [0x14];
		[0x7FE73D] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE73F] = A;
		A = [0x14];
		[0x7FE741] = A;
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		[0x12] >>= 1;
		Cpu.ROR(0x14);
		A = [0x12];
		[0x7FE743] = A;
		A = [0x14];
		[0x7FE745] = A;
		return this.L9496F3();
	}

	public void L9495D9()
	{
		A = [0x0367];
		temp = A - 0x0007;
		
		if (Z == 0)
			return this.L9495E2();

		return;
	}

	public void L9495E2()
	{
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L9495F8();

		A = [0x14];
		
		if (Z == 1)
			return this.L9495FD();

	}

	public void L9495F8()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L9495FD()
	{
		A = [0x12];
		[0x7FE727] = A;
		A = [0x14];
		[0x7FE729] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L94961F();

		A = [0x14];
		
		if (Z == 1)
			return this.L949624();

	}

	public void L94961F()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949624()
	{
		A = [0x12];
		[0x7FE72B] = A;
		A = [0x14];
		[0x7FE72D] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L949646();

		A = [0x14];
		
		if (Z == 1)
			return this.L94964B();

	}

	public void L949646()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L94964B()
	{
		A = [0x12];
		[0x7FE72F] = A;
		A = [0x14];
		[0x7FE731] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L94966D();

		A = [0x14];
		
		if (Z == 1)
			return this.L949672();

	}

	public void L94966D()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949672()
	{
		A = [0x12];
		[0x7FE733] = A;
		A = [0x14];
		[0x7FE735] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L949694();

		A = [0x14];
		
		if (Z == 1)
			return this.L949699();

	}

	public void L949694()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L949699()
	{
		A = [0x12];
		[0x7FE737] = A;
		A = [0x14];
		[0x7FE739] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L9496BB();

		A = [0x14];
		
		if (Z == 1)
			return this.L9496C0();

	}

	public void L9496BB()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L9496C0()
	{
		A = [0x12];
		[0x7FE73B] = A;
		A = [0x14];
		[0x7FE73D] = A;
		A = [0x14];
		C = 0;
		A += 0x0001 + C;
		[0x14] = A;
		A = [0x12];
		C = 0;
		A += 0x0000 + C;
		[0x12] = A;
		
		if (Z == 0)
			return this.L9496E2();

		A = [0x14];
		
		if (Z == 1)
			return this.L9496E7();

	}

	public void L9496E2()
	{
		C = 1;
		Cpu.ROR(0x12);
		Cpu.ROR(0x14);
	}

	public void L9496E7()
	{
		A = [0x12];
		[0x7FE73F] = A;
		A = [0x14];
		[0x7FE741] = A;
	}

	public void L9496F3()
	{
		A = [0x0454];
		[0x12] = A;
		A = [0x0452];
		[0x14] = A;
		[0x12] <<= 1;
		Cpu.ROL(0x14);
		A = [0x12];
		[0x7FE749] = A;
		A = [0x14];
		[0x7FE747] = A;
		[0x12] <<= 1;
		Cpu.ROL(0x14);
		A = [0x12];
		[0x7FE74D] = A;
		A = [0x14];
		[0x7FE74B] = A;
		A = [0x0454];
		[0x12] = A;
		A = [0x0452];
		[0x14] = A;
		A = [0x0367];
		A <<= 1;
		[0x16] = A;
		A <<= 1;
		C = 0;
		A += [0x16] + C;
		Y = A;
		X = Y;
		return [(0x9763 + X)]();
	}

	public void L949B0B()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		X = [0x0367];
		
		if (Z == 1)
			return this.L949B1E();

	}

	public void L949B17()
	{
		C = 0;
		A += 0x0020 + C;
		X--;
		
		if (Z == 0)
			return this.L949B17();

	}

	public void L949B1E()
	{
		X = A;
		A = [0x94990B + X];
		[0x1BA3] = A;
		A = [0x94990D + X];
		[0x049E] = A;
		A = [0x94990F + X];
		[0x0498] = A;
		A = [0x949911 + X];
		[0x0481] = A;
		A <<= 1;
		[0x047B] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x0487] = A;
		A = [0x949913 + X];
		[0x041C] = A;
		A = [0x949915 + X];
		[0x0428] = A;
		A = [0x949917 + X];
		[0x04A0] = A;
		A = [0x949919 + X];
		[0x049A] = A;
		A = [0x94991B + X];
		[0x0483] = A;
		A <<= 1;
		[0x047D] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x0489] = A;
		A = [0x94991D + X];
		[0x041E] = A;
		A = [0x94991F + X];
		[0x042A] = A;
		A = [0x949921 + X];
		[0x04A2] = A;
		A = [0x949923 + X];
		[0x049C] = A;
		A = [0x949925 + X];
		[0x0485] = A;
		A <<= 1;
		[0x047F] = A;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x048B] = A;
		A = [0x949927 + X];
		[0x0420] = A;
		A = [0x949929 + X];
		[0x042C] = A;
		A = 0xFFFF;
		[0x7FE4E3] = A;
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0x9BC2 + X)]();
	}

	public void L94B383()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x7F0000] = A;
		[0x7F0002] = A;
		A = 0x0100;
		[0x7F0004] = A;
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xB3A7 + X)]();
	}

	public void L94B8B0()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xB8C8 + X)]();
	}

	public void L94BC35()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0000;
		[0x0387] = A;
		A = [0x26];
		
		if (N == 1)
			return this.L94BC79();

		temp = A - 0x0100;
		
		if (N == 0)
			return this.L94BC79();

		A = [0x28];
		
		if (N == 1)
			return this.L94BC79();

		temp = A - 0x00A8;
		
		if (N == 0)
			return this.L94BC79();

		A = [0x0367];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xBC7E + X)]();
	}

	public void L94BC79()
	{
		[0x2A] = 0;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94C700()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x035D];
		A &= 0x00FF;
		A <<= 1;
		X = A;
		return [(0xC722 + X)]();
	}

	public void L94E927()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		P &= ~0x10;
		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E935()
	{
		A = [0xE90F + X];
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E935();

		P &= ~0x20;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94E94E()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E95A()
	{
		A = [0x706002 + X];
		temp = A - [0xE90F + X];
		
		if (Z == 0)
			return this.L94E974();

		X++;
		Y--;
		
		if (N == 0)
			return this.L94E95A();

		P &= ~0x20;
		this.L94E9F3();
		A = [0x12];
		temp = A - [0x706000];
		
		if (Z == 1)
			return this.L94E977();

	}

	public void L94E974()
	{
		this.L94E97A();
	}

	public void L94E977()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94E97A()
	{
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94E982()
	{
		A = 0xFF;
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E982();

		Y = 0x0017;
		X = 0x0000;
	}

	public void L94E992()
	{
		A = [0xE90F + X];
		[0x706002 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E992();

		A = 0x00;
		[0x706058] = A;
		[0x706059] = A;
		[0x706057] = A;
		A = 0x07;
		[0x706056] = A;
		Y = 0x001F;
		X = 0x0000;
		A = 0x00;
	}

	public void L94E9B9()
	{
		[0x706028 + X] = A;
		[0x706090 + X] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94E9B9();

		P &= ~0x20;
		A = 0x001F;
		[0x70601A] = A;
		A = 0x0000;
		[0x70601E] = A;
		[0x70601C] = A;
		[0x706020] = A;
		[0x706022] = A;
		[0x706024] = A;
		[0x706026] = A;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		return;
	}

	public void L94E9F3()
	{
		Stack.Push(P);
		P &= ~0x20;
		[0x12] = 0;
		P |= 0x20;
		Y = 0x0387;
		X = 0x0000;
	}

	public void L94EA00()
	{
		A = [0x706002 + X];
		C = 0;
		A += [0x12] + C;
		[0x12] = A;
		A = [0x13];
		A += 0x00 + C;
		[0x13] = A;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94EA00();

		P = Stack.Pop();
		return;
	}

	public void L94EB88()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];
		
		if (Z == 0)
			return this.L94EBBE();

		A = [0x0367];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x7060B5 + X];
		A &= 0x00FF;
		[0x26] = A;
		A = [0x7060B6 + X];
		A &= 0x00FF;
		[0x28] = A;
		A = [0x7060B7 + X];
		A &= 0x00FF;
		[0x2A] = A;
		A = [0x7060B8 + X];
		A &= 0x00FF;
		[0x2C] = A;
	}

	public void L94EBBB()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94EBBE()
	{
		A = [0x0369];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x0365] + C;
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x7060F5 + X];
		A &= 0x00FF;
		[0x26] = A;
		A = [0x7060F6 + X];
		A &= 0x00FF;
		[0x28] = A;
		A = [0x7060F7 + X];
		A &= 0x00FF;
		[0x2A] = A;
		A = [0x7060F8 + X];
		A &= 0x00FF;
		[0x2C] = A;
		return this.L94EBBB();
	}

	public void L94EC82()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L94ECD2();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L94ECD2();

		A = [0x0367];
		A <<= 1;
		A <<= 1;
		X = A;
		P |= 0x20;
		A = [0x26];
		[0x7060B5 + X] = A;
		A = [0x28];
		[0x7060B6 + X] = A;
		A = [0x2A];
		[0x7060B7 + X] = A;
		A = [0x2C];
		[0x7060B8 + X] = A;
		P &= ~0x20;
		A = X;
		A >>= 1;
		X = A;
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L94ED07();

	}

	public void L94ECC0()
	{
		A = [0x32];
		[0x7F0533 + X] = A;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94ECD2()
	{
		A = [0x0369];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x0365] + C;
		A <<= 1;
		A <<= 1;
		X = A;
		P |= 0x20;
		A = [0x26];
		[0x7060F5 + X] = A;
		A = [0x28];
		[0x7060F6 + X] = A;
		A = [0x2A];
		[0x7060F7 + X] = A;
		A = [0x2C];
		[0x7060F8 + X] = A;
		P &= ~0x20;
		A = X;
		A >>= 1;
		X = A;
		A = [0x0371];
		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L94ED07();

		return this.L94ECC0();
	}

	public void L94ED07()
	{
		A = [0x036B];
		
		if (Z == 1)
			return this.L94ECC0();

		A = [0x0369];
		
		if (Z == 1)
			return this.L94ECC0();

		A = [0x32];
		
		if (Z == 1)
			return this.L94ECC0();

		A = [0x7F052B + X];
		temp = A - [0x32];
		
		if (C == 0)
			return this.L94ECC0();

		A++;
		temp = A - 0x0006;
		
		if (C == 0)
			return this.L94ED26();

		A = 0x0000;
	}

	public void L94ED26()
	{
		[0x7F052B + X] = A;
		return this.L94ECC0();
	}

	public void L94EDAC()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = [0x036D];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		C = 1;
		A -= [0x036D] - !C;
		C = 1;
		A -= [0x036D] - !C;
		X = A;
		[0x03] = A;
		C = 0;
		A += 0x001E + C;
		[0x16] = A;
		A = 0x0001;
		[0x18] = A;
		P |= 0x20;
	}

	public void L94EDD2()
	{
		A = [0x70611D + X];
		temp = A - [0x26];
		
		if (Z == 1)
			return this.L94EDDE();

		
		if (C == 1)
			return this.L94EE14();

		return this.L94EDF2();
	}

	public void L94EDDE()
	{
		A = [0x70611E + X];
		temp = A - [0x28];
		
		if (Z == 1)
			return this.L94EDEA();

		
		if (C == 1)
			return this.L94EE14();

		return this.L94EDF2();
	}

	public void L94EDEA()
	{
		A = [0x70611F + X];
		temp = A - [0x2A];
		
		if (C == 1)
			return this.L94EE14();

	}

	public void L94EDF2()
	{
		A = X;
		C = 0;
		A += 0x06 + C;
		temp = A - [0x16];
		
		if (C == 1)
			return this.L94EDFF();

		X = A;
		[0x18]++;
		return this.L94EDD2();
	}

	public void L94EDFF()
	{
		P &= ~0x20;
		A = 0x0000;
		[0x7F052F] = A;
	}

	public void L94EE08()
	{
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94EE14()
	{
		P &= ~0x20;
		A = [0x18];
		[0x7F052F] = A;
		Y = 0x0006;
		A = 0x7000;
		[0x01] = A;
		A = 0x611D;
		[0x00] = A;
		this.L94F2E2();
		P |= 0x20;
		A = [0x26];
		[0x70611D + X] = A;
		A = [0x28];
		[0x70611E + X] = A;
		A = [0x2A];
		[0x70611F + X] = A;
		A = [0x2C];
		[0x706120 + X] = A;
		A = [0x2E];
		[0x706121 + X] = A;
		A = [0x30];
		[0x706122 + X] = A;
		P &= ~0x20;
		return this.L94EE08();
	}

	public void L94EE56()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		[0x26] = 0;
		[0x28] = 0;
		[0x2A] = 0;
		[0x2C] = 0;
		Y = 0x000F;
		X = 0x0000;
	}

	public void L94EE6A()
	{
		A = [0x7060B5 + X];
		A &= 0x00FF;
		temp = A - 0x00FF;
		
		if (Z == 1)
			return this.L94EEBD();

		C = 0;
		A += [0x26] + C;
		[0x26] = A;
		A = [0x7060B6 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x28] + C;
		[0x28] = A;
		A = [0x7060B7 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x2A] + C;
		[0x2A] = A;
		A = [0x7060B8 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x2C] + C;
		[0x2C] = A;
		A = [0x2A];
		temp = A - 0x0064;
		
		if (C == 0)
			return this.L94EEAE();

		C = 1;
		A -= 0x0064 - !C;
		[0x2A] = A;
		[0x28]++;
	}

	public void L94EEAE()
	{
		A = [0x28];
		temp = A - 0x003C;
		
		if (C == 0)
			return this.L94EEBD();

		C = 1;
		A -= 0x003C - !C;
		[0x28] = A;
		[0x26]++;
	}

	public void L94EEBD()
	{
		X++;
		X++;
		X++;
		X++;
		Y--;
		
		if (N == 0)
			return this.L94EE6A();

		A = [0x26];
		temp = A - 0x00F0;
		
		if (C == 0)
			return this.L94EEDA();

		A = 0x00EF;
		[0x26] = A;
		A = 0x003B;
		[0x28] = A;
		A = 0x0063;
		[0x2A] = A;
	}

	public void L94EEDA()
	{
		A = [0x2C];
		temp = A - 0x0063;
		
		if (C == 0)
			return this.L94EEE6();

		A = 0x0063;
		[0x2C] = A;
	}

	public void L94EEE6()
	{
		A = [0x0381];
		[0x2E] = A;
		this.L94FBA9();
		X = [0x30];
		P |= 0x20;
		A = [0x706028 + X];
		temp = A - 0x63;
		
		if (Z == 1)
			return this.L94EEFC();

		A++;
	}

	public void L94EEFC()
	{
		[0x706028 + X] = A;
		P &= ~0x20;
		P |= 0x20;
		A = [0x26];
		[0x7060B0] = A;
		A = [0x28];
		[0x7060B1] = A;
		A = [0x2A];
		[0x7060B2] = A;
		A = [0x2C];
		[0x7060B3] = A;
		A = [0x30];
		[0x7060B4] = A;
		P &= ~0x20;
		this.L94EDAC();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94F255()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		A = 0x0001;
		[0x32] = A;
		A = [0x0367];
		A <<= 1;
		A <<= 1;
		[0x14] = A;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x14] + C;
		X = A;
		[0x03] = A;
		C = 0;
		A += 0x0014 + C;
		[0x16] = A;
		P |= 0x20;
	}

	public void L94F277()
	{
		A = [0x706249 + X];
		temp = A - [0x26];
		
		if (Z == 1)
			return this.L94F283();

		
		if (C == 1)
			return this.L94F2B4();

		return this.L94F297();
	}

	public void L94F283()
	{
		A = [0x70624A + X];
		temp = A - [0x28];
		
		if (Z == 1)
			return this.L94F28F();

		
		if (C == 1)
			return this.L94F2B4();

		return this.L94F297();
	}

	public void L94F28F()
	{
		A = [0x70624B + X];
		temp = A - [0x2A];
		
		if (C == 1)
			return this.L94F2B4();

	}

	public void L94F297()
	{
		[0x32]++;
		A = X;
		C = 0;
		A += 0x04 + C;
		temp = A - [0x16];
		
		if (C == 1)
			return this.L94F2A4();

		X = A;
		return this.L94F277();
	}

	public void L94F2A4()
	{
		[0x32] = 0;
	}

	public void L94F2A6()
	{
		P &= ~0x20;
		this.L94E9F3();
		A = [0x12];
		[0x706000] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94F2B4()
	{
		P &= ~0x20;
		Y = 0x0004;
		A = 0x7000;
		[0x01] = A;
		A = 0x6249;
		[0x00] = A;
		this.L94F2E2();
		P |= 0x20;
		A = [0x26];
		[0x706249 + X] = A;
		A = [0x28];
		[0x70624A + X] = A;
		A = [0x2A];
		[0x70624B + X] = A;
		A = [0x2E];
		[0x70624C + X] = A;
		return this.L94F2A6();
	}

	public void L94F2E2()
	{
		P &= ~0x10;
		P |= 0x20;
		A = [0x02];
		[0x05] = A;
		P &= ~0x20;
		A = X;
		C = 0;
		A += [0x00] + C;
		[0x06] = A;
		A = Y;
		A <<= 1;
		A <<= 1;
		A--;
		C = 0;
		A += [0x00] + C;
		C = 0;
		A += [0x03] + C;
		[0x03] = A;
		A = [0x06];
		temp = A - [0x03];
		
		if (N == 0)
			return this.L94F316();

	}

	public void L94F304()
	{
		P |= 0x20;
		A = [[0x03]];
		[[0x03] + Y] = A;
		P &= ~0x20;
		A = [0x03];
		temp = A - [0x06];
		
		if (Z == 1)
			return this.L94F316();

		[0x03]--;
		return this.L94F304();
	}

	public void L94F316()
	{
		return;
	}

	public void L94FBA9()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		Stack.Push(X);
		[0x12] = 0;
		P |= 0x20;
		A = [0x26];
		[0x211B] = A;
		A = [0x27];
		[0x211B] = 0;
		A = 0x3C;
		[0x211C] = A;
		A = [0x2134];
		[0x12] = A;
		A = [0x2135];
		[0x13] = A;
		A = [0x2136];
		P &= ~0x20;
		A = [0x12];
		C = 0;
		A += [0x28] + C;
		[0x12] = A;
		A = [0x0371];
		
		if (Z == 0)
			return this.L94FBEE();

		A = [0x036D];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0xFC38 + X];
		[0x14] = A;
		A = [0xFC3A + X];
		[0x16] = A;
		return this.L94FC1B();
	}

	public void L94FBEE()
	{
		A = [0x036D];
		A--;
		A <<= 1;
		X = A;
		A = [0x036F];
		
		if (Z == 0)
			return this.L94FC0B();

		A = [0xFC48 + X];
		A &= 0x00FF;
		[0x14] = A;
		A = [0xFC49 + X];
		A &= 0x00FF;
		[0x16] = A;
		return this.L94FC1B();
	}

	public void L94FC0B()
	{
		A = [0xFC4E + X];
		A &= 0x00FF;
		[0x14] = A;
		A = [0xFC4F + X];
		A &= 0x00FF;
		[0x16] = A;
	}

	public void L94FC1B()
	{
		X = 0x0000;
	}

	public void L94FC1E()
	{
		A = [0x12];
		temp = A - [0x14];
		
		if (C == 0)
			return this.L94FC31();

		A = [0x14];
		C = 0;
		A += [0x16] + C;
		[0x14] = A;
		X++;
		temp = X - 0x001F;
		
		if (C == 0)
			return this.L94FC1E();

	}

	public void L94FC31()
	{
		A = X;
		[0x30] = A;
		X = Stack.Pop();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94FC54()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		[0x2E] = 0;
		[0x2C] = 0;
		Y = 0x0013;
		X = 0x0000;
	}

	public void L94FC62()
	{
		Stack.Push(X);
		A = [0x70611D + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L94FC81();

		[0x2E]++;
		A = [0x706122 + X];
		A &= 0x00FF;
		X = A;
		A = [0xFCF5 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x2C] + C;
		[0x2C] = A;
	}

	public void L94FC81()
	{
		A = Stack.Pop();
		C = 0;
		A += 0x0006 + C;
		X = A;
		Y--;
		
		if (N == 0)
			return this.L94FC62();

		Y = 0x001D;
		X = 0x0000;
	}

	public void L94FC90()
	{
		Stack.Push(X);
		A = [0x706195 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L94FCAF();

		[0x2E]++;
		A = [0x70619A + X];
		A &= 0x00FF;
		X = A;
		A = [0xFCF5 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x2C] + C;
		[0x2C] = A;
	}

	public void L94FCAF()
	{
		A = Stack.Pop();
		C = 0;
		A += 0x0006 + C;
		X = A;
		Y--;
		
		if (N == 0)
			return this.L94FC90();

		A = [0x2E];
		
		if (Z == 1)
			return this.L94FCE9();

		this.L8086B1();
		A = [0x2C];
		C = 0;
		A += [0x70601C] + C;
		temp = A - 0x00F8;
		
		if (C == 0)
			return this.L94FCCF();

		A = 0x00F8;
	}

	public void L94FCCF()
	{
		[0x70601E] = A;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		[0x12] = A;
		A = 0x001F;
		C = 1;
		A -= [0x12] - !C;
	}

	public void L94FCDE()
	{
		[0x70601A] = A;
		this.L94E927();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L94FCE9()
	{
		A = 0x0000;
		[0x70601E] = A;
		A = 0x001F;
		return this.L94FCDE();
	}

	public void L968144()
	{
		this.L9681D4();
		this.L9694A7();
		A = 0x0000;
		[0x1B3F] = A;
		[0x1B75] = A;
		[0x1B65] = A;
		[0x1B79] = A;
		[0x1B7B] = A;
		[0x1B81] = A;
		[0x1B2B] = A;
		[0x1B41] = A;
		[0x1B25] = A;
		[0x1B27] = A;
		[0x1B23] = A;
		[0x1B29] = A;
		[0x1B43] = A;
		[0x1B13] = A;
		[0x1B15] = A;
		[0x1B17] = A;
		[0x1B1B] = A;
		[0x1B1D] = A;
		[0x1B19] = A;
		[0x1B1F] = A;
		[0x1B21] = A;
		[0x1B23] = A;
		[0x1B2D] = A;
		[0x1B2F] = A;
		[0x1B31] = A;
		[0x1B33] = A;
		[0x1B99] = A;
		[0x1B9B] = A;
		[0x1B9D] = A;
		[0x1B9F] = A;
		[0x1BA1] = A;
		A = 0xFFFF;
		[0x1B45] = A;
		[0x1B47] = A;
		[0x1B49] = A;
		[0x1B4B] = A;
		[0x1B8F] = A;
		[0x1B91] = A;
		[0x1B93] = A;
		[0x1B95] = A;
		[0x1B97] = A;
		A = 0x0120;
		[0x1BA3] = A;
		[0x026D]++;
		return;
	}

	public void L9681D4()
	{
		X = 0x00E2;
	}

	public void L9681D7()
	{
		A = [0x8000 + X];
		[0x7F0861 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681D7();

		X = 0x001E;
	}

	public void L9681E5()
	{
		A = [0x80E6 + X];
		[0x7F0F61 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681E5();

		X = 0x003E;
	}

	public void L9681F3()
	{
		A = [0x8104 + X];
		[0x7F0FC1 + X] = A;
		X--;
		X--;
		
		if (N == 0)
			return this.L9681F3();

		return;
	}

	public void L9681FF()
	{
		Stack.Push(P);
		P |= 0x20;
		A = 0x10;
		[0x012A] = A;
		P &= ~0x20;
		P = Stack.Pop();
		return;
	}

	public void L968269()
	{
		A = [0x1866];
		
		if (N == 1)
			return this.L968277();

		A = [0x1968];
		
		if (N == 1)
			return this.L968277();

		this.L968453();
	}

	public void L968277()
	{
		return;
	}

	public void L968278()
	{
		P &= ~0x30;
		this.L9682B5();
		
		if (C == 1)
			return this.L9682A4();

		this.L97F92E();
		this.L97FE35();
		this.L9683E9();
		this.L9685AF();
		this.L96865D();
		this.L97E57E();
		this.L969CD8();
		this.L969901();
		this.L969EE3();
	}

	public void L9682A4()
	{
		this.L96EF01();
		this.L97A2EE();
		this.L97AA48();
		this.L96EA80();
		return;
	}

	public void L9682B5()
	{
		A = [0x1866];
		
		if (N == 1)
			return this.L9682C1();

		A = [0x1968];
		
		if (N == 1)
			return this.L9682C1();

		C = 0;
		return;
	}

	public void L9682C1()
	{
		A = [0x1B79];
		
		if (Z == 1)
			return this.L9682D0();

		P |= 0x20;
		A = [0x4A];
		A &= 0xF9;
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L9682D0()
	{
		A = [0x1B7B];
		
		if (Z == 0)
			return this.L9682DC();

		A = [0x1B2B];
		
		if (Z == 0)
			return this.L9682DC();

		return this.L9682E6();
	}

	public void L9682DC()
	{
		P |= 0x20;
		A = [0x4A];
		A &= 0xFD;
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L9682E6()
	{
		[0x1B65] = 0;
		[0x1B7B] = 0;
		[0x1B79] = 0;
		[0x1B81] = 0;
		[0x1B9D] = 0;
		this.L9689E3();
		[0x1B25] = 0;
		C = 1;
		return;
	}

	public void L968395()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x28];
		[0x30] = A;
		A = [0x26];
		temp = A - 0x007F;
		
		if (C == 1)
			return this.L9683AC();

		A = [0x26];
		this.L9683C4();
	}

	public void L9683A9()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9683AC()
	{
		A = 0x0078;
		this.L9683C4();
		A = [0x30];
		C = 0;
		A += [0x2C] + C;
		[0x30] = A;
		A = [0x26];
		C = 1;
		A -= 0x0078 - !C;
		this.L9683C4();
		return this.L9683A9();
	}

	public void L9683C4()
	{
		X = [0x00];
		A |= [0x2A];
		[0x7E0000 + X] = A;
		X++;
		A = [0x30];
		[0x7E0000 + X] = A;
		A = [0x00];
		C = 0;
		A += 0x0003 + C;
		[0x00] = A;
		return;
	}

	public void L9683E9()
	{
		this.L9688BA();
		this.L96892E();
		
		if (C == 1)
			return this.L96840B();

		A = [0x5A];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L96840B();

		A = [0x03FC];
		[0x20] = A;
		this.L9095BA();
		A = [0x03FC];
		temp = A - [0x20];
		
		if (Z == 1)
			return this.L96840B();

		this.L96840C();
	}

	public void L96840B()
	{
		return;
	}

	public void L96840C()
	{
		this.L9688BA();
		this.L9688AB();
		A = [0x968B7D + X];
		[0x1B1F] = A;
		this.L9689E3();
		A = 0x0000;
		[0x1B29] = A;
		A++;
		[0x1B21] = A;
		A = [0x1B1B];
		
		if (Z == 1)
			return this.L96843D();

		A = [0x1B1B];
		A &= 0x00FF;
		A = (A >> 4) | (A << 4);
		A |= 0x00F8;
		this.L8094E2();
		[0x1B1B] = 0;
	}

	public void L96843D()
	{
		A = [0x03FC];
		A <<= 1;
		X = A;
		A = [0x96844B + X];
		this.L809492();
		return;
	}

	public void L968453()
	{
		A = [0x1B43];
		temp = A & 0x8002;
		
		if (Z == 0)
			return this.L96847C();

		A = [0x14D6];
		temp = A - 0x000E;
		
		if (Z == 0)
			return this.L968476();

		A = [0x026B];
		
		if (Z == 0)
			return this.L96847C();

		A = [0x7F2873];
		
		if (Z == 1)
			return this.L96847C();

		A = [0x1B43];
		temp = A & 0x0E00;
		
		if (Z == 0)
			return this.L96847C();

	}

	public void L968476()
	{
		this.L96847D();
		this.L9684B6();
	}

	public void L96847C()
	{
		return;
	}

	public void L96847D()
	{
		A = [0x1B21];
		
		if (Z == 0)
			return this.L9684B1();

		A = [0x1B29];
		
		if (Z == 0)
			return this.L9684B1();

		A = [0x026B];
		
		if (Z == 0)
			return this.L968497();

		A = [0x52];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L968497();

		A = [0x52];
		return this.L968499();
	}

	public void L968497()
	{
		A = [0x5A];
	}

	public void L968499()
	{
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L9684B2();

		A = [0x1B25];
		
		if (Z == 0)
			return this.L9684B1();

		A = [0x1B27];
		temp = A - 0x0030;
		
		if (C == 1)
			return this.L9684B1();

		A = 0x0001;
		[0x1B25] = A;
	}

	public void L9684B1()
	{
		return;
	}

	public void L9684B2()
	{
		[0x1B27] = 0;
		return;
	}

	public void L9684B6()
	{
		A = [0x14D6];
		A <<= 1;
		X = A;
		A = [0x96857B + X];
		
		if (Z == 1)
			return this.L968524();

		A = [0x1B25];
		
		if (Z == 1)
			return this.L968524();

		A--;
		A <<= 1;
		C = 0;
		A += [0x96857B + X] + C;
		X = A;
		A = [0x96857B + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L968525();

		A = 0x2000;
		temp = A & [0x1B43]; [0x1B43] |= A;
		P |= 0x20;
		A = [0x96857B + X];
		[0x012D] = A;
		[0x2132] = A;
		A = [0x96857C + X];
		[0x012C] = A;
		[0x2132] = A;
		A = 0x20;
		[0x011F] = A;
		A = 0x00;
		[0x0120] = A;
		A = 0xFF;
		[0x0121] = A;
		A = [0x1B7B];
		
		if (Z == 0)
			return this.L96850C();

		[0x012E] = 0;
		return this.L968517();
	}

	public void L96850C()
	{
		A = [0x012D];
		A &= 0xDF;
		[0x012D] = A;
		[0x2132] = A;
	}

	public void L968517()
	{
		P &= ~0x20;
		[0x1B25]++;
		A = [0x14D6];
		A <<= 1;
		X = A;
		return [(0x8532 + X)]();
	}

	public void L968524()
	{
		return;
	}

	public void L968525()
	{
		A = 0x0000;
		[0x1B25] = A;
		A = 0x2000;
		temp = A & [0x1B43]; [0x1B43] &= ~A;
		return;
	}

	public void L9685AF()
	{
		A = [0x1B21];
		
		if (Z == 1)
			return this.L9685B9();

		[0x1B21]--;
		return this.L9685F1();
	}

	public void L9685B9()
	{
		A = [0x52];
		A ^= 0xFFFF;
		temp = A & 0x00FF;
		
		if (Z == 0)
			return this.L9685F1();

		this.L96891F();
		temp = A & 0x8000;
		
		if (Z == 1)
			return this.L9685F1();

		this.L96895A();
		
		if (C == 1)
			return this.L9685F1();

		A = [0x0257];
		
		if (Z == 0)
			return this.L9685F5();

		[0x1B27] = 0;
		A = [0x0261];
		[0x1B35] = A;
		A = [0x0263];
		[0x1B37] = A;
		A = [0x1B29];
		
		if (Z == 1)
			return this.L9685ED();

		[0x1B29]--;
		return;
	}

	public void L9685ED()
	{
		this.L968601();
		return;
	}

	public void L9685F1()
	{
		[0x1B29] = 0;
		return;
	}

	public void L9685F5()
	{
		A = [0x1B29];
		
		if (Z == 1)
			return this.L9685FD();

		[0x1B29]--;
	}

	public void L9685FD()
	{
		[0x1B27]++;
		return;
	}

	public void L968601()
	{
		this.L97D6DE();
		
		if (C == 1)
			return this.L96862B();

		this.L9688AB();
		A = [0x968B85 + X];
		A <<= 1;
		X = A;
		return [(0x8613 + X)]();
	}

	public void L96862B()
	{
		this.L9688AB();
		this.L968A21();
		A = [0x968B7B + X];
		[0x1B29] = A;
		return;
	}

	public void L96865D()
	{
		A = [0x1B21];
		
		if (Z == 0)
			return this.L968693();

		A = [0x1B29];
		
		if (Z == 0)
			return this.L968693();

		A = [0x1B1F];
		
		if (Z == 1)
			return this.L968671();

		[0x1B1F]--;
		return this.L968693();
	}

	public void L968671()
	{
		this.L9688AB();
		A = [0x0267];
		temp = A & 0x4000;
		
		if (Z == 1)
			return this.L968690();

		A = [0x1B17];
		
		if (Z == 1)
			return this.L968690();

		A = [0x968B77 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L968690();

		this.L968A21();
		return this.L968693();
	}

	public void L968690()
	{
		this.L9686A0();
	}

	public void L968693()
	{
		A = [0x1B13];
		[0x0393] = A;
		A = [0x1B17];
		[0x0395] = A;
		return;
	}

	public void L9686A0()
	{
		A = [0x968B87 + X];
		
		if (N == 1)
			return this.L9686F3();

		A = [0x1B1B];
		
		if (Z == 0)
			return this.L9686B8();

		A = [0x1B13];
		A |= [0x1B15];
		
		if (Z == 0)
			return this.L9686B8();

		Stack.Push(X);
		this.L968834();
		X = Stack.Pop();
	}

	public void L9686B8()
	{
		A = [0x968B81 + X];
		
		if (Z == 1)
			return this.L9686C3();

		temp = A - [0x1B17];
		
		if (Z == 1)
			return this.L9686F2();

	}

	public void L9686C3()
	{
		this.L9686F8();
		C = 0;
		A = [0x1B15];
		A += [0x1C] + C;
		[0x1B15] = A;
		A = [0x1B13];
		[0x12] = A;
		A += [0x1E] + C;
		[0x1B13] = A;
		A = [0x1B13];
		temp = A - 0x0060;
		
		if (N == 1)
			return this.L9686F2();

		A = 0x0060;
		[0x1B13] = A;
		temp = A - [0x12];
		
		if (Z == 1)
			return this.L9686EE();

		this.L9687AC();
	}

	public void L9686EE()
	{
		this.L968777();
	}

	public void L9686F2()
	{
		return;
	}

	public void L9686F3()
	{
		[0x1B1B] = 0;
		return;
	}

	public void L9686F8()
	{
		Stack.Push(X);
		A = [0x1B1D];
		A <<= 1;
		X = A;
		return [(0x8701 + X)]();
	}

	public void L968777()
	{
		A = [0x968B81 + X];
		
		if (Z == 1)
			return this.L9687A7();

		A = [0x1B19];
		
		if (Z == 1)
			return this.L968787();

		[0x1B19]--;
		return this.L9687A7();
	}

	public void L968787()
	{
		C = 0;
		A = [0x1B17];
		A += [0x968B83 + X] + C;
		[0x1B17] = A;
		A = [0x1B17];
		temp = A - [0x968B81 + X];
		
		if (N == 1)
			return this.L9687A3();

		A = [0x968B81 + X];
		[0x1B17] = A;
		return;
	}

	public void L9687A3()
	{
		this.L968A21();
	}

	public void L9687A7()
	{
		return;
	}

	public void L9687AC()
	{
		Stack.Push(X);
		A = [0x1B1D];
		A <<= 1;
		X = A;
		A = [0x1B13];
		
		if (Z == 1)
			return this.L9687BC();

		A = [0x1B17];
		A++;
		A <<= 1;
	}

	public void L9687BC()
	{
		C = 0;
		A += [0x9687E2 + X] + C;
		X = A;
		A = [0x9687E2 + X];
		[0x1B1B] = A;
		temp = A - 0x00E9;
		
		if (C == 1)
			return this.L9687D8();

		A = [0x9687E2 + X];
		this.L809492();
		return this.L9687E0();
	}

	public void L9687D8()
	{
		A = [0x9687E2 + X];
		this.L8094BA();
	}

	public void L9687E0()
	{
		X = Stack.Pop();
		return;
	}

	public void L968834()
	{
		Stack.Push(X);
		A = [0x1B1D];
		A <<= 1;
		X = A;
		A = [0x1B17];
		A <<= 1;
		C = 0;
		A += [0x968855 + X] + C;
		X = A;
		A = [0x968855 + X];
		[0x1B1B] = A;
		A = [0x968855 + X];
		this.L809492();
		X = Stack.Pop();
		return;
	}

	public void L9688AB()
	{
		A = [0x1B1D];
		A <<= 1;
		X = A;
		A = [0x968B73 + X];
		X = A;
		return;
	}

	public void L9688B6()
	{
		this.L9688BA();
		return;
	}

	public void L9688BA()
	{
		A = [0x1BC7];
		
		if (Z == 0)
			return this.L9688D5();

	}

	public void L9688BF()
	{
		A = [0x03FA];
		
		if (Z == 1)
			return this.L9688CE();

		A <<= 1;
		X = A;
		A = [0x9688E7 + X];
		[0x1B1D] = A;
		return;
	}

	public void L9688CE()
	{
		A = [0x0381];
		[0x1B1D] = A;
		return;
	}

	public void L9688D5()
	{
		A = [0x03FA];
		
		if (Z == 0)
			return this.L9688BF();

		A = [0x1BC9];
		A <<= 1;
		X = A;
		A = [0x968907 + X];
		[0x1B1D] = A;
		return;
	}

	public void L96891F()
	{
		A = [0x52];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L96892A();

		A = [0x0267];
		return;
	}

	public void L96892A()
	{
		A = [0x0265];
		return;
	}

	public void L96892E()
	{
		A = [0x1B23];
		
		if (Z == 0)
			return this.L968958();

		A = [0x1BC7];
		
		if (Z == 1)
			return this.L96893D();

		A = [0x1BD3];
		
		if (Z == 0)
			return this.L968958();

	}

	public void L96893D()
	{
		A = [0x1B7B];
		
		if (Z == 0)
			return this.L968958();

		A = [0x1B79];
		
		if (Z == 0)
			return this.L968958();

		A = [0x1B81];
		
		if (Z == 0)
			return this.L968958();

		A = [0x1B41];
		
		if (Z == 0)
			return this.L968958();

		A = [0x1B75];
		
		if (Z == 0)
			return this.L968958();

		C = 0;
		return;
	}

	public void L968958()
	{
		C = 1;
		return;
	}

	public void L96895A()
	{
		A = [0x1B81];
		
		if (Z == 0)
			return this.L968987();

		A = [0x1BC7];
		
		if (Z == 1)
			return this.L968969();

		A = [0x1BD3];
		
		if (Z == 0)
			return this.L968987();

	}

	public void L968969()
	{
		A = [0x1B1D];
		
		if (Z == 1)
			return this.L968985();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L968985();

		A = [0x0381];
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L968983();

		A = [0x0267];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L968985();

	}

	public void L968983()
	{
		return this.L968989();
	}

	public void L968985()
	{
		C = 0;
		return;
	}

	public void L968987()
	{
		C = 1;
		return;
	}

	public void L968989()
	{
		A = [0x1B3F];
		
		if (Z == 0)
			return this.L9689DA();

		A = [0x1B41];
		
		if (Z == 0)
			return this.L9689DA();

		A = [0x117C];
		temp = A - 0x0018;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x000D;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x0002;
		
		if (C == 0)
			return this.L9689D8();

		temp = A - 0x0008;
		
		if (C == 0)
			return this.L9689DA();

		A = [0x117E];
		temp = A - 0x0018;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x000D;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x0002;
		
		if (C == 0)
			return this.L9689D8();

		temp = A - 0x0008;
		
		if (C == 0)
			return this.L9689DA();

		A = [0x1180];
		temp = A - 0x0018;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x000D;
		
		if (Z == 1)
			return this.L9689DA();

		temp = A - 0x0002;
		
		if (C == 0)
			return this.L9689D8();

		temp = A - 0x0008;
		
		if (C == 0)
			return this.L9689DA();

	}

	public void L9689D8()
	{
		C = 0;
		return;
	}

	public void L9689DA()
	{
		A = 0x00E3;
		this.L8094BA();
		C = 1;
		return;
	}

	public void L9689E3()
	{
		A = [0x0381];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x1B17];
		C = 1;
		A -= [0x968A97 + X] - !C;
		
		if (N == 0)
			return this.L9689F6();

		A = 0x0000;
	}

	public void L9689F6()
	{
		[0x1B17] = A;
		A = 0x0000;
		[0x1B15] = A;
		A = [0x1B13];
		C = 1;
		A -= [0x968A99 + X] - !C;
		
		if (N == 0)
			return this.L968A0C();

		A = 0x0000;
	}

	public void L968A0C()
	{
		[0x1B13] = A;
		this.L9688AB();
		A = [0x968B7D + X];
		[0x1B1F] = A;
		A = [0x968B7F + X];
		[0x1B19] = A;
		return;
	}

	public void L968A21()
	{
		A = 0x0000;
		[0x1B13] = A;
		[0x1B15] = A;
		A = [0x968B7D + X];
		[0x1B1F] = A;
		A = [0x968B7F + X];
		[0x1B19] = A;
		return;
	}

	public void L968A39()
	{
		A = [0x1B1B];
		
		if (Z == 1)
			return this.L968A4F();

		A = [0x1B1B];
		A &= 0x00FF;
		A = (A >> 4) | (A << 4);
		A |= 0x00F8;
		this.L8094E2();
		[0x1B1B] = 0;
	}

	public void L968A4F()
	{
		X = [0x14];
		A = [0x1238 + X];
		A &= 0x0007;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x20] = A;
		A = [0x0381];
		A <<= 1;
		X = A;
		A = [0x968A9F + X];
		C = 0;
		A += [0x20] + C;
		X = A;
		A = [0x1B17];
		C = 1;
		A -= [0x968A9F + X] - !C;
		
		if (N == 0)
			return this.L968A76();

		A = 0x0000;
	}

	public void L968A76()
	{
		[0x1B17] = A;
		A = 0x0000;
		[0x1B15] = A;
		A = [0x1B13];
		C = 1;
		A -= [0x968AA3 + X] - !C;
		
		if (N == 0)
			return this.L968A8C();

		A = 0x0000;
	}

	public void L968A8C()
	{
		[0x1B13] = A;
		A = [0x968AA5 + X];
		[0x1B21] = A;
		return;
	}

	public void L9694A7()
	{
		this.L9698CF();
		P |= 0x20;
		A = 0x41;
		[0x4320] = A;
		A = 0x26;
		[0x4321] = A;
		A = 0xD8;
		[0x4322] = A;
		A = 0x61;
		[0x4323] = A;
		A = 0x7E;
		[0x4324] = A;
		A = 0x7E;
		[0x4327] = A;
		P &= ~0x20;
		return;
	}

	public void L9694CE()
	{
		return;
	}

	public void L9694CF()
	{
		this.L96989E();
		this.L9698C9();
		
		if (C == 1)
			return this.L9694CE();

		Stack.Push(B);
		Stack.Push(X);
		Stack.Push(Y);
		Stack.Push(K);
		B = Stack.Pop();
		this.L969509();
		this.L96953F();
		this.L969596();
		this.L9695FA();
		Y = Stack.Pop();
		X = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L969509()
	{
		A = [0x16];
		A &= 0xFFFE;
		[0x16] = A;
		X = A;
		A = [0xA0C7 + X];
		[0x1B83] = A;
		X = A;
		A = [0xA0C7 + X];
		[0x1B85] = A;
		[0x1B89] = A;
		[0x1A] = A;
		A <<= 1;
		[0x1C] = A;
		A = [0xA0C9 + X];
		[0x1E] = A;
		A <<= 1;
		[0x1B87] = A;
		[0x18] = 0;
		A = [0x014C];
		temp = A & 0x0001;
		
		if (Z == 0)
			return this.L96953E();

		A = 0x0200;
		[0x18] = A;
	}

	public void L96953E()
	{
		return;
	}

	public void L96953F()
	{
		A = [0x16];
		temp = A - [0x14];
		
		if (C == 0)
			return this.L969560();

		A = [0x14];
		temp = A - [0x1E];
		
		if (C == 0)
			return this.L969555();

		A = [0x14];
		C = 1;
		A -= [0x1E] - !C;
		[0x1B85] = A;
		return this.L969560();
	}

	public void L969555()
	{
		A = [0x1E];
		C = 0;
		A += [0x14] + C;
		[0x1B87] = A;
		[0x1B85] = 0;
	}

	public void L969560()
	{
		A = [0x16];
		C = 0;
		A += [0x14] + C;
		temp = A - 0x00BB;
		
		if (C == 0)
			return this.L969595();

		A = [0x14];
		C = 0;
		A += [0x1E] + C;
		temp = A - 0x00BB;
		
		if (C == 1)
			return this.L969582();

		A = 0x00BB;
		C = 1;
		A -= [0x14] - !C;
		C = 1;
		A -= [0x1E] - !C;
		[0x1B89] = A;
		return this.L969595();
	}

	public void L969582()
	{
		A = [0x1B87];
		C = 1;
		A -= [0x14] - !C;
		C = 1;
		A += [0x1E] + C;
		C = 0;
		A += [0x1B89] + C;
		[0x1B87] = A;
		[0x1B89] = 0;
	}

	public void L969595()
	{
		return;
	}

	public void L969596()
	{
		A = 0x0001;
		[0x7E6A76] = A;
		A = [0x18];
		[0x1B8B] = A;
		A = [0x1B85];
		C = 0;
		A += [0x1B89] + C;
		A--;
		A <<= 1;
		C = 0;
		A += [0x18] + C;
		[0x1B8D] = A;
		A = [0x1A];
		C = 1;
		A -= [0x1B85] - !C;
		[0x20] = A;
		A = [0x1A];
		C = 1;
		A -= [0x1B89] - !C;
		[0x22] = A;
		Y = [0x20];
		temp = Y - [0x22];
		
		if (C == 0)
			return this.L9695C9();

		Y = [0x22];
	}

	public void L9695C9()
	{
		this.L96981C();
		temp = Y - [0x20];
		
		if (C == 0)
			return this.L9695DD();

		X = [0x1B8B];
		[0x7E6218 + X] = A;
		[0x1B8B]++;
		[0x1B8B]++;
	}

	public void L9695DD()
	{
		temp = Y - [0x22];
		
		if (C == 0)
			return this.L9695EE();

		X = [0x1B8D];
		[0x7E6218 + X] = A;
		[0x1B8D]--;
		[0x1B8D]--;
	}

	public void L9695EE()
	{
		Y++;
		temp = Y - [0x1A];
		
		if (N == 1)
			return this.L9695C9();

		X = [0x18];
		[0x7E6416 + X] = A;
		return;
	}

	public void L9695FA()
	{
		A = [0x18];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		C = 0;
		A += 0x61D8 + C;
		[0x00] = A;
		A = [0x14];
		C = 1;
		A -= [0x16] - !C;
		
		if (C == 0)
			return this.L969625();

		
		if (Z == 0)
			return this.L969610();

		A++;
	}

	public void L969610()
	{
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0x6A76;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
	}

	public void L969625()
	{
		A = [0x1B85];
		
		if (Z == 1)
			return this.L969642();

		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0x6218;
		C = 0;
		A += [0x18] + C;
		[0x28] = A;
		A = 0x00F0;
		[0x2C] = A;
		this.L968395();
	}

	public void L969642()
	{
		A = [0x1B87];
		
		if (Z == 1)
			return this.L96965F();

		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0x6416;
		C = 0;
		A += [0x18] + C;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
	}

	public void L96965F()
	{
		A = [0x1B89];
		
		if (Z == 1)
			return this.L96967D();

		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0x6218;
		C = 0;
		A += [0x1B8B] + C;
		[0x28] = A;
		A = 0x00F0;
		[0x2C] = A;
		this.L968395();
	}

	public void L96967D()
	{
		X = [0x00];
		A = 0x0001;
		[0x7E0000 + X] = A;
		A = 0x6A76;
		[0x7E0001 + X] = A;
		P |= 0x20;
		A = 0x00;
		[0x7E0003 + X] = A;
		P &= ~0x20;
		A = [0x18];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		C = 0;
		A += 0x61D8 + C;
		[0x18] = A;
		P |= 0x20;
		A = 0x41;
		[0x4320] = A;
		A = 0x26;
		[0x4321] = A;
		A = [0x18];
		[0x4322] = A;
		A = [0x19];
		[0x4323] = A;
		A = 0x7E;
		[0x4324] = A;
		A = 0x7E;
		[0x4327] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x04;
		A |= [0x4A];
		[0x4A] = A;
		P &= ~0x20;
		return;
	}

	public void L96981C()
	{
		A = Y;
		C = 0;
		A += [0x1B83] + C;
		X = A;
		P |= 0x20;
		A = [0xA0CB + X];
		C = 0;
		A += [0x12] + C;
		
		if (C == 0)
			return this.L96982E();

		A = 0xFF;
	}

	public void L96982E()
	{
		A = (A >> 4) | (A << 4);
		A = [0xA0CB + X];
		A ^= 0xFF;
		A++;
		C = 0;
		A += [0x12] + C;
		
		if (C == 1)
			return this.L96983C();

		A = 0x00;
	}

	public void L96983C()
	{
		P &= ~0x20;
		return;
	}

	public void L96989E()
	{
		A = [0x12];
		
		if (N == 1)
			return this.L9698A9();

		temp = A - 0x0100;
		
		if (C == 1)
			return this.L9698AE();

		return this.L9698B1();
	}

	public void L9698A9()
	{
		A = 0x0000;
		return this.L9698B1();
	}

	public void L9698AE()
	{
		A = 0x00FF;
	}

	public void L9698B1()
	{
		[0x12] = A;
		A = [0x14];
		
		if (N == 1)
			return this.L9698BE();

		temp = A - 0x0100;
		
		if (C == 1)
			return this.L9698C3();

		return this.L9698C6();
	}

	public void L9698BE()
	{
		A = 0x0000;
		return this.L9698C6();
	}

	public void L9698C3()
	{
		A = 0x00FF;
	}

	public void L9698C6()
	{
		[0x14] = A;
		return;
	}

	public void L9698C9()
	{
		A = [0x16];
		temp = A - 0x00FF;
		return;
	}

	public void L9698CF()
	{
		A = 0x0000;
		[0x7E61D8] = A;
		A = 0x0000;
		[0x7E61F8] = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFB;
		[0x4A] = A;
		P &= ~0x20;
		return;
	}

	public void L969901()
	{
		A = [0x1B79];
		
		if (Z == 0)
			return this.L969907();

		return;
	}

	public void L969907()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0800;
		temp = A & [0x1B43]; [0x1B43] |= A;
		P |= 0x20;
		[0x012E] = 0;
		A = 0x02;
		temp = A & [0x012A]; [0x012A] &= ~A;
		A = 0x33;
		[0x012B] = A;
		A = [0x011F];
		A |= 0x20;
		A &= 0x6F;
		[0x011F] = A;
		A = 0x00;
		[0x0120] = A;
		A = 0xFF;
		[0x0121] = A;
		P &= ~0x20;
		this.L9699A0();
		A = [0x0381];
		A <<= 1;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x0381] + C;
		A += [0x0381] + C;
		X = A;
		Stack.Push(X);
		this.L969A9C();
		X = Stack.Pop();
		C = 1;
		A = [0x1966];
		A -= [0x968B29 + X] - !C;
		[0x1966] = A;
		A = [0x1968];
		A -= [0x968B2B + X] - !C;
		[0x1968] = A;
		A = [0x968B2F + X];
		temp = A - [0x1968];
		
		if (C == 0)
			return this.L96999E();

		A = 0x0000;
		[0x1B79] = A;
		[0x0117] = A;
		[0x7F0002] = A;
		A = 0x0000;
		[0x7E6618] = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFD;
		[0x4A] = A;
		P &= ~0x20;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFB;
		[0x4A] = A;
		P &= ~0x20;
		A = [0x02F9];
		this.L809517();
		A = 0x0800;
		temp = A & [0x1B43]; [0x1B43] &= ~A;
	}

	public void L96999E()
	{
		B = Stack.Pop();
		return;
	}

	public void L9699A0()
	{
		[0x1B79]++;
	}

	public void L9699A3()
	{
		A = [0x1B79];
		A <<= 1;
		X = A;
		A = [0x99C0 + X];
		temp = A - 0x6666;
		
		if (Z == 1)
			return this.L9699B8();

		[0x0117] = A;
		[0x7F0002] = A;
		return;
	}

	public void L9699B8()
	{
		A = 0x0069;
		[0x1B79] = A;
		return this.L9699A3();
	}

	public void L969A9C()
	{
		A = [0x1B79];
		temp = A - 0x0053;
		
		if (C == 0)
			return this.L969AA7();

		return this.L969B48();
	}

	public void L969AA7()
	{
		A = [0x1B79];
		A <<= 1;
		[0x12] = A;
		A = 0x61D8;
		[0x00] = A;
		A = [0x12];
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBCBB;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x00A6;
		C = 1;
		A -= [0x12] - !C;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2B;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
		A = 0x6618;
		[0x00] = A;
		A = 0x00A6;
		C = 1;
		A -= [0x12] - !C;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2B;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		A = [0x12];
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0001;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2B;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
		return this.L969C6D();
	}

	public void L969B48()
	{
		A = [0x968B2D + X];
		temp = A - [0x1968];
		
		if (C == 0)
			return this.L969B6C();

		A = [0x014C];
		A ^= 0xFFFF;
		A &= 0x000F;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		A = [0x014C];
		A &= 0x000F;
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x14] = A;
		return this.L969B7F();
	}

	public void L969B6C()
	{
		A = [0x014C];
		A ^= 0xFFFF;
		A &= 0x003F;
		[0x12] = A;
		A = [0x014C];
		A &= 0x003F;
		[0x14] = A;
	}

	public void L969B7F()
	{
		A = 0x61D8;
		[0x00] = A;
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBCBB;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBCBB;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0026;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBCBB;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0001;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2B;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
		A = 0x6618;
		[0x00] = A;
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x14] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x14] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0026;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x14] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0001;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2B;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
	}

	public void L969C6D()
	{
		P |= 0x20;
		A = 0x40;
		[0x4310] = A;
		[0x0950] = A;
		A = 0x32;
		[0x4311] = A;
		[0x0951] = A;
		A = 0xD8;
		[0x4312] = A;
		[0x0952] = A;
		A = 0x61;
		[0x4313] = A;
		[0x0953] = A;
		A = 0x7E;
		[0x4314] = A;
		[0x0954] = A;
		A = 0x97;
		[0x4317] = A;
		[0x0955] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x02;
		A |= [0x4A];
		[0x4A] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x40;
		[0x4320] = A;
		A = 0x32;
		[0x4321] = A;
		A = 0x18;
		[0x4322] = A;
		A = 0x66;
		[0x4323] = A;
		A = 0x7E;
		[0x4324] = A;
		A = 0x97;
		[0x4327] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x04;
		A |= [0x4A];
		[0x4A] = A;
		P &= ~0x20;
		return;
	}

	public void L969CD8()
	{
		A = [0x1B7B];
		
		if (Z == 0)
			return this.L969CDE();

		return;
	}

	public void L969CDE()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0x0400;
		temp = A & [0x1B43]; [0x1B43] |= A;
		A = [0x1B7F];
		this.L969E02();
		this.L969DD0();
		A = [0x1B7B];
		this.L969D11();
		A = [0x2E];
		[0x1B7B] = A;
		A = [0x1B7F];
		
		if (N == 0)
			return this.L969D0F();

		A = 0x403C;
		[0x1B7B] = A;
		A = 0x0000;
		[0x1B7F] = A;
	}

	public void L969D0F()
	{
		B = Stack.Pop();
		return;
	}

	public void L969D11()
	{
		[0x002E] = A;
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L969D27();

		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L969D79();

		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L969D26();

		return this.L969DAF();
	}

	public void L969D26()
	{
		return;
	}

	public void L969D27()
	{
		A &= 0x7FFF;
		
		if (Z == 1)
			return this.L969D5D();

		[0x16] = A;
		A = [0x1B43];
		temp = A & 0x7002;
		
		if (Z == 0)
			return this.L969D52();

		A = 0x0080;
		[0x12] = A;
		A = 0x0054;
		[0x14] = A;
		this.L9694CF();
		P |= 0x20;
		A = [0x011F];
		A |= 0x30;
		A &= 0x7F;
		[0x011F] = A;
		P &= ~0x20;
	}

	public void L969D52()
	{
		A = [0x002E];
		C = 1;
		A -= 0x0008 - !C;
		[0x002E] = A;
		return;
	}

	public void L969D5D()
	{
		A = 0x0001;
		[0x002E] = A;
		this.L9698CF();
		P |= 0x20;
		A = 0x02;
		temp = A & [0x012A]; [0x012A] &= ~A;
		A = [0x011F];
		A &= 0xEF;
		[0x011F] = A;
		P &= ~0x20;
		return;
	}

	public void L969D79()
	{
		A--;
		[0x002E] = A;
		A &= 0x00FF;
		
		if (Z == 1)
			return this.L969D89();

		A = 0x0060;
		[0x012D] = A;
		return;
	}

	public void L969D89()
	{
		A = 0x0000;
		[0x002E] = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFD;
		[0x4A] = A;
		A = 0x20;
		[0x012E] = A;
		A = 0x40;
		[0x012D] = A;
		A = 0x80;
		[0x012C] = A;
		P &= ~0x20;
		A = 0x0400;
		temp = A & [0x1B43]; [0x1B43] &= ~A;
		return;
	}

	public void L969DAF()
	{
		X = A;
		P |= 0x20;
		A = [0x9DBE + X];
		[0x012D] = A;
		P &= ~0x20;
		[0x002E]--;
		return;
	}

	public void L969DD0()
	{
		P |= 0x20;
		A = [0x1B7F];
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x9DF1 + X];
		[0x012E] = A;
		temp = A - 0x30;
		
		if (C == 0)
			return this.L969DEE();

		A = [0x014C];
		temp = A & 0x10;
		
		if (Z == 0)
			return this.L969DEE();

		A = 0x20;
		[0x012E] = A;
	}

	public void L969DEE()
	{
		P &= ~0x20;
		return;
	}

	public void L969E02()
	{
		[0x12] = A;
		P |= 0x20;
		A = 0x33;
		[0x012B] = A;
		A = 0x80;
		[0x012C] = A;
		P &= ~0x20;
		A = [0x12];
		temp = A - 0x0010;
		
		if (C == 1)
			return this.L969E25();

		A = [0x014C];
		A &= 0x000F;
		A <<= 1;
		A <<= 1;
		[0x12] = A;
		return this.L969E2D();
	}

	public void L969E25()
	{
		A = [0x014C];
		A &= 0x003F;
		[0x12] = A;
	}

	public void L969E2D()
	{
		A = 0x6618;
		[0x00] = A;
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0026;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBD73;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0001;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBE2C;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
		P |= 0x20;
		A = 0x40;
		[0x4310] = A;
		[0x0950] = A;
		A = 0x32;
		[0x4311] = A;
		[0x0951] = A;
		A = 0x18;
		[0x4312] = A;
		[0x0952] = A;
		A = 0x66;
		[0x4313] = A;
		[0x0953] = A;
		A = 0x7E;
		[0x4314] = A;
		[0x0954] = A;
		A = 0x97;
		[0x4317] = A;
		[0x0955] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x02;
		A |= [0x4A];
		[0x4A] = A;
		P &= ~0x20;
		return;
	}

	public void L969EE3()
	{
		A = [0x1B81];
		
		if (Z == 1)
			return this.L969F0E();

		A = 0x0200;
		temp = A & [0x1B43]; [0x1B43] |= A;
		P |= 0x20;
		A = 0xE0;
		[0x012C] = A;
		[0x012D] = A;
		[0x012E] = A;
		A = 0x20;
		[0x011F] = A;
		P &= ~0x20;
		this.L969F0F();
		this.L969F88();
		[0x1B81]++;
		this.L96A06C();
	}

	public void L969F0E()
	{
		return;
	}

	public void L969F0F()
	{
		A = [0x1B81];
		temp = A - 0x0001;
		
		if (Z == 1)
			return this.L969F2C();

		temp = A - 0x0053;
		
		if (Z == 1)
			return this.L969F1F();

		return this.L969F7D();
	}

	public void L969F1F()
	{
		A = 0x0000;
		[0x1966] = A;
		A = 0x0080;
		[0x1968] = A;
		return;
	}

	public void L969F2C()
	{
		P |= 0x20;
		A = 0x40;
		[0x4310] = A;
		[0x0950] = A;
		A = 0x32;
		[0x4311] = A;
		[0x0951] = A;
		A = 0x18;
		[0x4312] = A;
		[0x0952] = A;
		A = 0x66;
		[0x4313] = A;
		[0x0953] = A;
		A = 0x7E;
		[0x4314] = A;
		[0x0954] = A;
		A = 0x97;
		[0x4317] = A;
		[0x0955] = A;
		P &= ~0x20;
		P |= 0x20;
		A = 0x01;
		[0x4320] = A;
		A = 0x26;
		[0x4321] = A;
		A = 0x7E;
		[0x4322] = A;
		A = 0x9F;
		[0x4323] = A;
		A = 0x96;
		[0x4324] = A;
		P &= ~0x20;
	}

	public void L969F7D()
	{
		return;
	}

	public void L969F88()
	{
		A = [0x1B81];
		temp = A - 0x0053;
		
		if (C == 0)
			return this.L969F93();

		return this.L969FDF();
	}

	public void L969F93()
	{
		A = [0x1B81];
		A <<= 1;
		[0x12] = A;
		A = [0x014C];
		A ^= 0xFFFF;
		A &= 0x003F;
		[0x14] = A;
		A = 0x6618;
		[0x00] = A;
		A = [0x12];
		
		if (Z == 1)
			return this.L969FC5();

		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBE2D;
		C = 0;
		A += [0x14] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
	}

	public void L969FC5()
	{
		X = [0x00];
		A = 0x0001;
		[0x7E0000 + X] = A;
		A = 0xBF1D;
		[0x7E0001 + X] = A;
		A = 0x0000;
		[0x7E0003 + X] = A;
		return this.L96A061();
	}

	public void L969FDF()
	{
		A = [0x014C];
		A ^= 0xFFFF;
		A &= 0x003F;
		[0x12] = A;
		A = 0x6618;
		[0x00] = A;
		A = 0x0026;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBE2D;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBE2D;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0040;
		[0x26] = A;
		A = 0x0080;
		[0x2A] = A;
		A = 0xBE2D;
		C = 0;
		A += [0x12] + C;
		[0x28] = A;
		A = 0x0078;
		[0x2C] = A;
		this.L968395();
		A = 0x0001;
		[0x26] = A;
		A = 0x0000;
		[0x2A] = A;
		A = 0xBF1D;
		[0x28] = A;
		A = 0x0000;
		[0x2C] = A;
		this.L968395();
		X = [0x00];
		A = 0x0000;
		[0x7E0000 + X] = A;
	}

	public void L96A061()
	{
		P |= 0x20;
		A = 0x06;
		A |= [0x4A];
		[0x4A] = A;
		P &= ~0x20;
		return;
	}

	public void L96A06C()
	{
		A = [0x1B81];
		temp = A - 0x0053;
		
		if (C == 0)
			return this.L96A08C();

		A = [0x0379];
		temp = A - 0x007F;
		
		if (C == 0)
			return this.L96A08C();

		this.L9095E0();
		A = 0x0000;
		[0x1B81] = A;
		A = 0x0200;
		temp = A & [0x1B43]; [0x1B43] &= ~A;
	}

	public void L96A08C()
	{
		return;
	}

	public void L96EA80()
	{
		A = [0x014C];
		temp = A & 0x0001;
		
		if (Z == 0)
			return this.L96EAE1();

		A &= 0x0006;
		X = A;
		A = [0x96EAE2 + X];
		X = A;
		A = [0x7F0761 + X];
		[0x7F06C3] = A;
		A = [0x7F1261 + X];
		[0x7F11C3] = A;
		A = [0x7F0763 + X];
		[0x7F06C5] = A;
		A = [0x7F1261 + X];
		[0x7F11C5] = A;
		A = [0x7F0765 + X];
		[0x7F06C7] = A;
		A = [0x7F1261 + X];
		[0x7F11C7] = A;
		A = [0x7F0767 + X];
		[0x7F06C9] = A;
		A = [0x7F1261 + X];
		[0x7F11C9] = A;
		A = [0x7F0769 + X];
		[0x7F06CB] = A;
		A = [0x7F1261 + X];
		[0x7F11CB] = A;
	}

	public void L96EAE1()
	{
		return;
	}

	public void L96EF01()
	{
		A = [0x014C];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A >>= 1;
		A &= 0x0006;
		Y = A;
		A = [0x1B45 + Y];
		
		if (N == 1)
			return this.L96EF16();

		this.L96EF17();
	}

	public void L96EF16()
	{
		return;
	}

	public void L96EF17()
	{
		A = [0x014C];
		A &= 0x0003;
		
		if (Z == 1)
			return this.L96EF20();

		return;
	}

	public void L96EF20()
	{
		A = [0x1B45 + Y];
		A <<= 1;
		X = A;
		A = [0x1726 + X];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L96EF63();

		A = [0x15A6 + X];
		C = 0;
		A += [0x1B4D + Y] + C;
		[0x1B35] = A;
		A = [0x15E6 + X];
		C = 0;
		A += [0x1B55 + Y] + C;
		[0x1B37] = A;
		A = [0x014C];
		A >>= 1;
		A >>= 1;
		A &= 0x001F;
		A <<= 1;
		X = A;
		A = [0x1B5D + Y];
		C = 0;
		A += [0x96EF64 + X] + C;
		A &= 0x001F;
		[0x1B3D] = A;
		A = 0x0056;
		[0x1B3B] = A;
		this.L97E314();
	}

	public void L96EF63()
	{
		return;
	}

	public void L97A2EE()
	{
		A = [0x1B3F];
		
		if (Z == 1)
			return this.L97A346();

		P &= ~0x30;
		A = [0x1B3F];
		A--;
		A &= 0x000F;
		A <<= 1;
		X = A;
		A = [0x97A347 + X];
		X = A;
		A = [0x7F0761 + X];
		[0x7F06D7] = A;
		A = [0x7F0763 + X];
		[0x7F06D9] = A;
		A = [0x7F0765 + X];
		[0x7F06DB] = A;
		A = [0x7F0767 + X];
		[0x7F06DD] = A;
		A = [0x7F1261 + X];
		[0x7F11D7] = A;
		A = [0x7F1263 + X];
		[0x7F11D9] = A;
		A = [0x7F1265 + X];
		[0x7F11DB] = A;
		A = [0x7F1267 + X];
		[0x7F11DD] = A;
		[0x1B3F]++;
	}

	public void L97A346()
	{
		return;
	}

	public void L97AA48()
	{
		A = [0x1B41];
		
		if (Z == 1)
			return this.L97AA72();

		A = [0x1866];
		
		if (N == 0)
			return this.L97AA55();

		return this.L97AAE1();
	}

	public void L97AA55()
	{
		A = [0x1B41];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L97AA73();

		temp = A & 0x2000;
		
		if (Z == 0)
			return this.L97AAA2();

		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L97AACB();

		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L97AAE1();

	}

	public void L97AA6C()
	{
		A = 0x0000;
		[0x1B41] = A;
	}

	public void L97AA72()
	{
		return;
	}

	public void L97AA73()
	{
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x968AE3 + X];
		
		if (Z == 1)
			return this.L97AA6C();

		A = 0x0003;
		[0x150E] = A;
		A = 0x4000;
		[0x1510] = A;
		A = [0x1976];
		A |= 0x0300;
		[0x1976] = A;
		A = 0x00DE;
		this.L8094BA();
		A = 0x2000;
		[0x1B41] = A;
		return;
	}

	public void L97AAA2()
	{
		this.L97AB04();
		this.L97AB76();
		A = [0x1B41];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L97AAB1();

		return;
	}

	public void L97AAB1()
	{
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x968AE3 + X];
		A |= 0x8000;
		[0x1B41] = A;
		A = [0x19EB];
		A |= 0x4000;
		[0x19EB] = A;
		return;
	}

	public void L97AACB()
	{
		A = [0x1B41];
		A--;
		[0x1B41] = A;
		temp = A - 0x8000;
		
		if (Z == 1)
			return this.L97AAE1();

		this.L97AB04();
		this.L97AB76();
		this.L97AB57();
		return;
	}

	public void L97AAE1()
	{
		this.L838316();
		A = [0x19EB];
		A &= 0xBFFF;
		[0x19EB] = A;
		A = 0x0000;
		[0x1B41] = A;
		[0x14FA] = A;
		A = [0x1976];
		A &= 0xFCFF;
		[0x1976] = A;
		this.L97AC03();
		return;
	}

	public void L97AB04()
	{
		A = [0x14D6];
		A <<= 1;
		A <<= 1;
		X = A;
		A = [0x1B41];
		A &= 0x7FFF;
		temp = A - [0x968AE5 + X];
		
		if (C == 1)
			return this.L97AB27();

		A = [0x014C];
		A &= 0x0003;
		A <<= 1;
		X = A;
		A = [0x97AB37 + X];
		return this.L97AB33();
	}

	public void L97AB27()
	{
		A = [0x014C];
		A &= 0x0007;
		A <<= 1;
		X = A;
		A = [0x97AB47 + X];
	}

	public void L97AB33()
	{
		[0x14FA] = A;
		return;
	}

	public void L97AB57()
	{
		A = [0x014C];
		temp = A & 0x007F;
		
		if (Z == 0)
			return this.L97AB75();

		A = [0x15A6];
		[0x1B35] = A;
		A = [0x15E6];
		[0x1B37] = A;
		this.L97E4DE();
		A = 0x0001;
		[0x1B3F] = A;
	}

	public void L97AB75()
	{
		return;
	}

	public void L97AB76()
	{
		A = [0x014C];
		A &= 0x0006;
		X = A;
		A = [0x97ABFB + X];
		X = A;
		A = [0x7F0FC1 + X];
		[0x7F0721] = A;
		A = [0x7F0FC3 + X];
		[0x7F0723] = A;
		A = [0x7F0FC5 + X];
		[0x7F0725] = A;
		A = [0x7F0FC7 + X];
		[0x7F0727] = A;
		A = [0x7F0FC9 + X];
		[0x7F0729] = A;
		A = [0x7F0FCB + X];
		[0x7F072B] = A;
		A = [0x7F0FCD + X];
		[0x7F072D] = A;
		A = [0x7F0FCF + X];
		[0x7F072F] = A;
		A = [0x7F0FD1 + X];
		[0x7F0731] = A;
		A = [0x7F0FD3 + X];
		[0x7F0733] = A;
		A = [0x7F0FD5 + X];
		[0x7F0735] = A;
		A = [0x7F0FD9 + X];
		[0x7F0739] = A;
		A = [0x7F0FDB + X];
		[0x7F073B] = A;
		A = [0x7F0FDD + X];
		[0x7F073D] = A;
		A = [0x7F0FDF + X];
		[0x7F073F] = A;
		return;
	}

	public void L97AC03()
	{
		X = 0x001E;
	}

	public void L97AC06()
	{
		temp = X - 0x0016;
		
		if (Z == 1)
			return this.L97AC13();

		A = [0x7F1221 + X];
		[0x7F0721 + X] = A;
	}

	public void L97AC13()
	{
		X--;
		X--;
		
		if (N == 0)
			return this.L97AC06();

		return;
	}

	public void L97D6DE()
	{
		this.L80C90B();
		
		if (C == 0)
			return this.L97D6E5();

		return;
	}

	public void L97D6E5()
	{
		A = [0x1B1D];
		A <<= 1;
		X = A;
		A = [0x968B73 + X];
		X = A;
		A = [0x0267];
		temp = A & 0x4000;
		
		if (Z == 0)
			return this.L97D724();

	}

	public void L97D6F7()
	{
		A = [0x1B79];
		
		if (Z == 0)
			return this.L97D706();

		A = [0x968B73 + X];
		
		if (N == 1)
			return this.L97D718();

		[0x12] = A;
		return this.L97D70E();
	}

	public void L97D706()
	{
		A = [0x968B75 + X];
		
		if (N == 1)
			return this.L97D717();

		[0x12] = A;
	}

	public void L97D70E()
	{
		A = [0x968B81 + X];
		[0x14] = A;
		this.L97D779();
	}

	public void L97D717()
	{
		return;
	}

	public void L97D718()
	{
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L97D717();

		A &= 0x7FFF;
		this.L97D847();
		return;
	}

	public void L97D724()
	{
		A = [0x1B79];
		
		if (Z == 0)
			return this.L97D756();

		A = [0x0381];
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L97D6F7();

		A = [0x1B17];
		
		if (Z == 1)
			return this.L97D74E();

		A = [0x1BC7];
		
		if (Z == 1)
			return this.L97D741();

		A = [0x968B77 + X];
		
		if (N == 1)
			return this.L97D6F7();

	}

	public void L97D741()
	{
		A = 0x0280;
		[0x12] = A;
		A = 0x000A;
		[0x14] = A;
		this.L97D779();
	}

	public void L97D74E()
	{
		this.L97D801();
		this.L9688B6();
		return;
	}

	public void L97D756()
	{
		A = [0x0381];
		temp = A - 0x0001;
		
		if (Z == 0)
			return this.L97D706();

		A = [0x1B17];
		
		if (Z == 1)
			return this.L97D74E();

		A = 0x0320;
		[0x12] = A;
		A = 0x000A;
		[0x14] = A;
		this.L97D779();
		this.L97D801();
		this.L9688B6();
		return this.L97D717();
	}

	public void L97D779()
	{
		this.L97DA1B();
		A = [0x968B73 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L97D7A1();

		temp = A - 0x0002;
		
		if (Z == 1)
			return this.L97D79D();

		temp = A - 0x0003;
		
		if (Z == 1)
			return this.L97D79D();

		temp = A - 0x0004;
		
		if (Z == 1)
			return this.L97D79D();

		A = [0x1B9D];
		
		if (Z == 0)
			return this.L97D7A1();

		A = [0x968B73 + X];
	}

	public void L97D79D()
	{
		this.L97DAE3();
	}

	public void L97D7A1()
	{
		A = [0x968B75 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L97D7F5();

		this.L97D827();
		A = [0x1238 + Y];
		temp = A & 0x0800;
		
		if (Z == 1)
			return this.L97D7BB();

		A = 0x0000;
		[0x1B9D] = A;
	}

	public void L97D7BB()
	{
		A = [0x968B77 + X];
		temp = A - 0xFFFF;
		
		if (Z == 1)
			return this.L97D7DA();

		Stack.Push(Y);
		Stack.Push(X);
		A = [0x0261];
		this.L809977();
		A |= [0x968B77 + X];
		this.L809492();
		X = Stack.Pop();
		Y = Stack.Pop();
		[0x1B1B] = 0;
	}

	public void L97D7DA()
	{
		A = [0x968B79 + X];
		[0x1B21] = A;
		A = [0x1B17];
		
		if (Z == 1)
			return this.L97D7F3();

		C = 1;
		A -= [0x968B7B + X] - !C;
		
		if (N == 0)
			return this.L97D7F0();

		A = 0x0000;
	}

	public void L97D7F0()
	{
		[0x1B17] = A;
	}

	public void L97D7F3()
	{
		C = 0;
		return;
	}

	public void L97D7F5()
	{
		this.L97D801();
		A = 0x00E3;
		this.L8094BA();
		C = 1;
		return;
	}

	public void L97D801()
	{
		A = [0x03FC];
		
		if (Z == 1)
			return this.L97D826();

		this.L9095E0();
		A = 0x0001;
		A &= 0x00FF;
		A = (A >> 4) | (A << 4);
		A |= 0x00F8;
		this.L8094E2();
		A = 0x0004;
		A &= 0x00FF;
		A = (A >> 4) | (A << 4);
		A |= 0x00F8;
		this.L8094E2();
	}

	public void L97D826()
	{
		return;
	}

	public void L97D827()
	{
		this.L80CAE9();
		[0x1B2D] = Y;
		A = [0x1B35];
		[0x0B9C + Y] = A;
		[0x1B31] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		[0x1B33] = A;
		A = [0x1238 + Y];
		[0x1B2F] = A;
		return;
	}

	public void L97D847()
	{
		A <<= 1;
		X = A;
		return [(0xD84C + X)]();
	}

	public void L97DA1B()
	{
		A = [0x0265];
		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L97DA2D();

		A = [0x1B13];
		
		if (Z == 0)
			return this.L97DA2D();

		A = [0x1B17];
		
		if (Z == 1)
			return this.L97DA61();

	}

	public void L97DA2D()
	{
		[0x2E] = 0;
		A = [0x1B17];
		temp = A - [0x14];
		
		if (C == 1)
			return this.L97DA40();

		A = [0x1B13];
		temp = A - 0x0060;
		
		if (Z == 0)
			return this.L97DA40();

		[0x2E]++;
	}

	public void L97DA40()
	{
		A = [0x14];
		
		if (Z == 1)
			return this.L97DA64();

		A = [0x1B17];
		
		if (Z == 1)
			return this.L97DA64();

		C = 0;
		A += [0x2E] + C;
		A++;
		C = 0;
		A += 0x0004 + C;
		Stack.Push(A);
		A <<= 1;
		A <<= 1;
		A <<= 1;
		[0x16] = A;
		A = Stack.Pop();
		A <<= 1;
		C = 0;
		A += [0x16] + C;
		C = 0;
		A += [0x12] + C;
		X = A;
		return;
	}

	public void L97DA61()
	{
		X = [0x12];
		return;
	}

	public void L97DA64()
	{
		X = [0x1B13];
		
		if (N == 0)
			return this.L97DA6E();

		X = 0x0001;
		return this.L97DA76();
	}

	public void L97DA6E()
	{
		temp = X - 0x0061;
		
		if (C == 0)
			return this.L97DA76();

		X = 0x0060;
	}

	public void L97DA76()
	{
		A = [0x97DA82 + X];
		A &= 0x00FF;
		C = 0;
		A += [0x12] + C;
		X = A;
		return;
	}

	public void L97DAE3()
	{
		Stack.Push(X);
		A <<= 1;
		X = A;
		return [(0xDAEB + X)]();
	}

	public void L97DEDA()
	{
		A = [0x1004 + X];
		[0x1B35] = A;
		A = [0x1062 + X];
		[0x1B37] = A;
		A = [0x0CB6 + X];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x97DEF7 + X];
		[0x1B3B] = A;
		return this.L97E314();
	}

	public void L97DF19()
	{
		A = [0x1004 + X];
		[0x1B35] = A;
		A = [0x1062 + X];
		[0x1B37] = A;
		A = [0x0CB6 + X];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0x97DF36 + X];
		[0x1B3B] = A;
		return this.L97E314();
	}

	public void L97DF5C()
	{
		A = [0x1238 + X];
		temp = A & 0x0080;
		
		if (Z == 1)
			return this.L97DF67();

		return this.L97DF95();
	}

	public void L97DF67()
	{
		A = [0x1726 + Y];
		temp = A & 0x2000;
		
		if (Z == 1)
			return this.L97DFC3();

		A = [0x1B35];
		this.L809977();
		A |= 0x0066;
		this.L8094BA();
		A = [0x15A6 + Y];
		temp = A - [0x1B35];
		
		if (C == 0)
			return this.L97DF8A();

		A = 0x0055;
		return this.L97DF8D();
	}

	public void L97DF8A()
	{
		A = 0x0054;
	}

	public void L97DF8D()
	{
		[0x1B3B] = A;
		this.L97E314();
		return;
	}

	public void L97DF95()
	{
		A = [0x11DA + X];
		[0x22] = A;
		A++;
		[0x11DA + X] = A;
		A = [0x22];
		A &= 0x000F;
		
		if (Z == 1)
			return this.L97DFA8();

		return this.L97E02C();
	}

	public void L97DFA8()
	{
		A = 0x005E;
		[0x1B3B] = A;
		Stack.Push(Y);
		this.L97E314();
		A = [0x1B35];
		this.L809977();
		A |= 0x00D2;
		this.L8094BA();
		Y = Stack.Pop();
		return;
	}

	public void L97DFC3()
	{
		A = [0x117C + X];
		
		if (Z == 0)
			return this.L97DFD3();

		A = 0x005B;
		[0x1B3B] = A;
		this.L97E314();
		return;
	}

	public void L97DFD3()
	{
		A = [0x1238 + X];
		A &= 0x0007;
		temp = A - 0x0004;
		
		if (C == 0)
			return this.L97E000();

		A = [0x117C + X];
		temp = A - 0x0000;
		
		if (Z == 1)
			return this.L97E000();

		A = 0x0042;
		[0x1B3B] = A;
		Stack.Push(Y);
		this.L97E314();
		A = [0x1B35];
		this.L809977();
		A |= 0x00D2;
		this.L8094BA();
		Y = Stack.Pop();
	}

	public void L97E000()
	{
		Stack.Push(X);
		A = [0x14D6];
		A <<= 1;
		C = 0;
		A += [0x14D6] + C;
		X = A;
		A = [0x97E02E + X];
		[0x00] = A;
		A = [0x97E02F + X];
		[0x01] = A;
		X = Stack.Pop();
		this.L97E061();
		A = [[0x00] + Y];
		A &= 0x00FF;
		temp = A - 0x00FF;
		
		if (Z == 1)
			return this.L97E02C();

		[0x1B3B] = A;
		this.L97E314();
		return;
	}

	public void L97E02C()
	{
		C = 1;
		return;
	}

	public void L97E061()
	{
		[0x22] = Y;
		A = Y;
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x22] + C;
		A >>= 1;
		[0x22] = A;
		A = [0x1238 + X];
		A &= 0x0007;
		C = 0;
		A += [0x22] + C;
		Y = A;
		return;
	}

	public void L97E1F3()
	{
		A = [0x1238 + X];
		A &= 0x0007;
		A <<= 1;
		X = A;
		A = [0x97E238 + X];
		[0x1B3B] = A;
		A = [0x1BA3];
		temp = A - 0x0100;
		
		if (C == 0)
			return this.L97E225();

		A = [0x1504];
		temp = A - [0x1B37];
		
		if (C == 0)
			return this.L97E225();

		this.L97E3E0();
		A = [0x1B35];
		this.L809977();
		A |= 0x0062;
		this.L8094BA();
		return;
	}

	public void L97E225()
	{
		this.L97E380();
		A = [0x1B35];
		this.L809977();
		A |= 0x0062;
		this.L8094BA();
		return;
	}

	public void L97E248()
	{
		this.L80C92B();
		
		if (C == 0)
			return this.L97E24F();

		return;
	}

	public void L97E24F()
	{
		A = [0x1B35];
		this.L809977();
		A |= 0x0062;
		this.L8094BA();
		A = [0x1B3B];
		A <<= 1;
		X = A;
		A = [0x0387];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0x97E2C2 + X] + C;
		X = A;
		A = [0x97E2C2 + X];
		this.L80CB73();
		A = [0x1B35];
		[0x0B9C + Y] = A;
		[0x1004 + Y] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		[0x1062 + Y] = A;
		A = [0x97E2C4 + X];
		[0x11DA + Y] = A;
		C = 0;
		A = [0x197C];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0D14 + Y] = A;
		A = [0x197E];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0D72 + Y] = A;
		C = 0;
		A = [0x1988];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0DD0 + Y] = A;
		A = [0x198A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0E2E + Y] = A;
		C = 0;
		return;
	}

	public void L97E314()
	{
		this.L80C92B();
		
		if (C == 0)
			return this.L97E31B();

		return;
	}

	public void L97E31B()
	{
		A = [0x1B3B];
		this.L80CB73();
		A = [0x1B3D];
		[0x11DA + Y] = A;
		A = [0x12F4 + Y];
		A &= 0xF1FF;
		[0x12F4 + Y] = A;
		A = [0x1352 + Y];
		A &= 0xF1FF;
		[0x1352 + Y] = A;
		A = [0x1B35];
		[0x0B9C + Y] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		A = 0x0000;
		[0x0D14 + Y] = A;
		A = 0x0000;
		[0x0D72 + Y] = A;
		A = [0x1976];
		temp = A & 0x1000;
		
		if (Z == 0)
			return this.L97E375();

		C = 0;
		A = [0x1988];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0DD0 + Y] = A;
		A = [0x198A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0E2E + Y] = A;
		return this.L97E37E();
	}

	public void L97E375()
	{
		A = 0x0000;
		[0x0DD0 + Y] = A;
		[0x0E2E + Y] = A;
	}

	public void L97E37E()
	{
		C = 0;
		return;
	}

	public void L97E380()
	{
		this.L80C92B();
		
		if (C == 0)
			return this.L97E387();

		return;
	}

	public void L97E387()
	{
		A = [0x1B3B];
		this.L80CB73();
		A = [0x12F4 + Y];
		A &= 0xF1FF;
		[0x12F4 + Y] = A;
		A = [0x1352 + Y];
		A &= 0xF1FF;
		[0x1352 + Y] = A;
		A = [0x1B35];
		[0x0B9C + Y] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		C = 0;
		A = [0x197C];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0D14 + Y] = A;
		A = [0x197E];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0D72 + Y] = A;
		C = 0;
		A = [0x1988];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0DD0 + Y] = A;
		A = [0x198A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0E2E + Y] = A;
		C = 0;
		return;
	}

	public void L97E3E0()
	{
		this.L80CABF();
		
		if (C == 0)
			return this.L97E3E7();

		return;
	}

	public void L97E3E7()
	{
		A = [0x1B3B];
		this.L80CB73();
		A = [0x12F4 + Y];
		A &= 0xF1FF;
		[0x12F4 + Y] = A;
		A = [0x1352 + Y];
		A &= 0xF1FF;
		[0x1352 + Y] = A;
		A = [0x1B35];
		[0x0B9C + Y] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		C = 0;
		A = [0x197C];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0D14 + Y] = A;
		A = [0x197E];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0D72 + Y] = A;
		C = 0;
		A = [0x1988];
		A ^= 0xFFFF;
		A += 0x0001 + C;
		[0x0DD0 + Y] = A;
		A = [0x198A];
		A ^= 0xFFFF;
		A += 0x0000 + C;
		[0x0E2E + Y] = A;
		C = 0;
		return;
	}

	public void L97E440()
	{
		X = [0x14];
		A = [0x117C + X];
		temp = A - 0x0082;
		
		if (Z == 0)
			return this.L97E44D();

		return this.L97E4DD();
	}

	public void L97E44D()
	{
		temp = A - 0x0083;
		
		if (Z == 0)
			return this.L97E455();

		return this.L97E4DD();
	}

	public void L97E455()
	{
		temp = A - 0x0084;
		
		if (Z == 0)
			return this.L97E45D();

		return this.L97E4DD();
	}

	public void L97E45D()
	{
		temp = A - 0x0085;
		
		if (Z == 1)
			return this.L97E4DD();

		A = [0x1004 + X];
		[0x1B35] = A;
		A = [0x1062 + X];
		[0x1B37] = A;
		A = [0x1B35];
		temp = A - 0x0080;
		
		if (Z == 1)
			return this.L97E491();

		
		if (C == 1)
			return this.L97E4A3();

		A = [0x1B37];
		temp = A - 0x0054;
		
		if (Z == 1)
			return this.L97E487();

		
		if (C == 1)
			return this.L97E48C();

		A = 0x001C;
		return this.L97E4BA();
	}

	public void L97E487()
	{
		A = 0x0018;
		return this.L97E4BA();
	}

	public void L97E48C()
	{
		A = 0x0014;
		return this.L97E4BA();
	}

	public void L97E491()
	{
		A = [0x1B37];
		temp = A - 0x0054;
		
		if (C == 1)
			return this.L97E49E();

		A = 0x0000;
		return this.L97E4BA();
	}

	public void L97E49E()
	{
		A = 0x0010;
		return this.L97E4BA();
	}

	public void L97E4A3()
	{
		A = [0x1B37];
		temp = A - 0x0054;
		
		if (Z == 1)
			return this.L97E4B2();

		
		if (C == 1)
			return this.L97E4B7();

		A = 0x0004;
		return this.L97E4BA();
	}

	public void L97E4B2()
	{
		A = 0x0008;
		return this.L97E4BA();
	}

	public void L97E4B7()
	{
		A = 0x000C;
	}

	public void L97E4BA()
	{
		[0x1B3D] = A;
		A = 0x0045;
		[0x1B3B] = A;
		this.L97E314();
		
		if (C == 1)
			return this.L97E4DD();

		X = [0x14];
		A = [0x1296 + X];
		[0x1296 + Y] = A;
		A = [0x12F4 + X];
		[0x12F4 + Y] = A;
		A = [0x1352 + X];
		[0x1352 + Y] = A;
	}

	public void L97E4DD()
	{
		return;
	}

	public void L97E4DE()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x1866];
		
		if (N == 1)
			return this.L97E511();

		A = [0x1968];
		
		if (N == 1)
			return this.L97E511();

		this.L80C92B();
		
		if (C == 1)
			return this.L97E4F4();

		this.L97E516();
	}

	public void L97E4F4()
	{
		this.L80C92B();
		
		if (C == 1)
			return this.L97E4FD();

		this.L97E51B();
	}

	public void L97E4FD()
	{
		this.L80C92B();
		
		if (C == 1)
			return this.L97E506();

		this.L97E520();
	}

	public void L97E506()
	{
		this.L80C92B();
		
		if (C == 1)
			return this.L97E50F();

		this.L97E525();
	}

	public void L97E50F()
	{
		P = Stack.Pop();
		return;
	}

	public void L97E511()
	{
		[0x1B13] = 0;
		return this.L97E50F();
	}

	public void L97E516()
	{
		A = 0x0009;
		return this.L97E52A();
	}

	public void L97E51B()
	{
		A = 0x000A;
		return this.L97E52A();
	}

	public void L97E520()
	{
		A = 0x000B;
		return this.L97E52A();
	}

	public void L97E525()
	{
		A = 0x000C;
		return this.L97E52A();
	}

	public void L97E52A()
	{
		this.L80CB73();
		A = [0x1B35];
		[0x0B9C + Y] = A;
		A = [0x1B37];
		[0x0C58 + Y] = A;
		A = 0xFFFF;
		[0x12F4 + Y] = A;
		A = 0x0000;
		[0x1352 + Y] = A;
		return;
	}

	public void L97E57E()
	{
		A = [0x1866];
		
		if (N == 0)
			return this.L97E587();

		this.L97E5F7();
		return;
	}

	public void L97E587()
	{
		Stack.Push(B);
		Stack.Push(X);
		Stack.Push(K);
		B = Stack.Pop();
		A = [0x1B65];
		
		if (Z == 1)
			return this.L97E596();

		A--;
		A <<= 1;
		X = A;
		return [(0xE599 + X)]();
	}

	public void L97E596()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L97E5F7()
	{
		this.L9095E0();
		[0x1B65] = 0;
		[0x1B75] = 0;
		return;
	}

	public void L97F92E()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		[0x1B99] = 0;
		A = 0xFFFF;
		[0x1B97] = A;
		[0x1B91] = A;
		[0x1B8F] = A;
		[0x1B93] = A;
		[0x1B95] = A;
		A = [0x117C];
		
		if (N == 1)
			return this.L97F965();

		A = 0x0000;
		[0x12] = A;
		this.L97F9A4();
		
		if (C == 1)
			return this.L97F965();

		this.L97FB87();
		
		if (C == 1)
			return this.L97F965();

		this.L97FCC0();
		this.L97FDCF();
	}

	public void L97F965()
	{
		A = [0x117E];
		
		if (N == 1)
			return this.L97F983();

		A = 0x0002;
		[0x12] = A;
		this.L97F9A4();
		
		if (C == 1)
			return this.L97F983();

		this.L97FB87();
		
		if (C == 1)
			return this.L97F983();

		this.L97FCC0();
		this.L97FDCF();
	}

	public void L97F983()
	{
		A = [0x1180];
		
		if (N == 1)
			return this.L97F9A1();

		A = 0x0004;
		[0x12] = A;
		this.L97F9A4();
		
		if (C == 1)
			return this.L97F9A1();

		this.L97FB87();
		
		if (C == 1)
			return this.L97F9A1();

		this.L97FCC0();
		this.L97FDCF();
	}

	public void L97F9A1()
	{
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L97F9A4()
	{
		X = [0x12];
		A = [0x1238 + X];
		A &= 0x0800;
		
		if (Z == 1)
			return this.L97F9B0();

		C = 0;
		return;
	}

	public void L97F9B0()
	{
		A = [0x014C];
		A &= 0x0001;
		
		if (Z == 1)
			return this.L97F9BB();

		return this.L97FA3D();
	}

	public void L97F9BB()
	{
		A = [0x11B2];
		
		if (N == 1)
			return this.L97F9CB();

		A = 0x0036;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97F9CB();

		return;
	}

	public void L97F9CB()
	{
		A = [0x11C4];
		
		if (N == 1)
			return this.L97F9DB();

		A = 0x0048;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97F9DB();

		return;
	}

	public void L97F9DB()
	{
		A = [0x11B6];
		
		if (N == 1)
			return this.L97F9EB();

		A = 0x003A;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97F9EB();

		return;
	}

	public void L97F9EB()
	{
		A = [0x11C8];
		
		if (N == 1)
			return this.L97F9FB();

		A = 0x004C;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97F9FB();

		return;
	}

	public void L97F9FB()
	{
		A = [0x11BA];
		
		if (N == 1)
			return this.L97FA0B();

		A = 0x003E;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA0B();

		return;
	}

	public void L97FA0B()
	{
		A = [0x11CC];
		
		if (N == 1)
			return this.L97FA1B();

		A = 0x0050;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA1B();

		return;
	}

	public void L97FA1B()
	{
		A = [0x11BE];
		
		if (N == 1)
			return this.L97FA2B();

		A = 0x0042;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA2B();

		return;
	}

	public void L97FA2B()
	{
		A = [0x11D0];
		
		if (N == 1)
			return this.L97FA3B();

		A = 0x0054;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA3B();

		return;
	}

	public void L97FA3B()
	{
		C = 0;
		return;
	}

	public void L97FA3D()
	{
		A = [0x11C2];
		
		if (N == 1)
			return this.L97FA4D();

		A = 0x0046;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA4D();

		return;
	}

	public void L97FA4D()
	{
		A = [0x11B4];
		
		if (N == 1)
			return this.L97FA5D();

		A = 0x0038;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA5D();

		return;
	}

	public void L97FA5D()
	{
		A = [0x11C6];
		
		if (N == 1)
			return this.L97FA6D();

		A = 0x004A;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA6D();

		return;
	}

	public void L97FA6D()
	{
		A = [0x11B8];
		
		if (N == 1)
			return this.L97FA7D();

		A = 0x003C;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA7D();

		return;
	}

	public void L97FA7D()
	{
		A = [0x11CA];
		
		if (N == 1)
			return this.L97FA8D();

		A = 0x004E;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA8D();

		return;
	}

	public void L97FA8D()
	{
		A = [0x11BC];
		
		if (N == 1)
			return this.L97FA9D();

		A = 0x0040;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FA9D();

		return;
	}

	public void L97FA9D()
	{
		A = [0x11CE];
		
		if (N == 1)
			return this.L97FAAD();

		A = 0x0052;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FAAD();

		return;
	}

	public void L97FAAD()
	{
		A = [0x11C0];
		
		if (N == 1)
			return this.L97FABD();

		A = 0x0044;
		[0x14] = A;
		this.L97FABF();
		
		if (C == 0)
			return this.L97FABD();

		return;
	}

	public void L97FABD()
	{
		C = 0;
		return;
	}

	public void L97FABF()
	{
		X = [0x14];
		A = [0x0CB6 + X];
		A >>= 1;
		A >>= 1;
		A >>= 1;
		X = A;
		A = [0xF27A + X];
		[0x26] = A;
		[0x28] = A;
		Y = [0x12];
		A = [0x117C + Y];
		A <<= 1;
		X = A;
		A = [0x140E + Y];
		A <<= 1;
		A <<= 1;
		C = 0;
		A += [0xF29C + X] + C;
		X = A;
		A = [0xF29C + X];
		
		if (Z == 1)
			return this.L97FB26();

		A += [0x26] + C;
		[0x26] = A;
		A = [0xF29E + X];
		A += [0x28] + C;
		[0x28] = A;
		X = [0x14];
		A = [0x0CB6 + Y];
		C = 1;
		A -= [0x0CB6 + X] - !C;
		C = 0;
		A += 0x0040 + C;
		temp = A - 0x0080;
		
		if (C == 1)
			return this.L97FB26();

		A = [0x1004 + Y];
		C = 1;
		A -= [0x1004 + X] - !C;
		
		if (N == 0)
			return this.L97FB0F();

		A ^= 0xFFFF;
		A++;
	}

	public void L97FB0F()
	{
		temp = A - [0x26];
		
		if (C == 1)
			return this.L97FB26();

		A = [0x1062 + Y];
		C = 1;
		A -= [0x1062 + X] - !C;
		
		if (N == 0)
			return this.L97FB20();

		A ^= 0xFFFF;
		A++;
	}

	public void L97FB20()
	{
		temp = A - [0x28];
		
		if (C == 1)
			return this.L97FB26();

		return this.L97FB2A();
	}

	public void L97FB26()
	{
		C = 0;
		return;
	}

	public void L97FB2A()
	{
		[0x30] = 0;
		this.L80D279();
		X = [0x14];
		A = [0x111E + X];
		
		if (N == 0)
			return this.L97FB57();

		[0x1B99]++;
		A = 0xFFFF;
		[0x117C + X] = A;
		[0x1296 + X] = A;
		this.L97DEDA();
		A = [0x1B35];
		this.L809977();
		A |= 0x0065;
		this.L8094BA();
		[0x30]++;
	}

	public void L97FB57()
	{
		X = [0x12];
		A = [0x111E + X];
		
		if (N == 0)
			return this.L97FB85();

		A = 0xFFFF;
		[0x117C + X] = A;
		[0x1296 + X] = A;
		A = [0x30];
		
		if (Z == 0)
			return this.L97FB75();

		this.L97DF19();
		return this.L97FB75();
	}

	public void L97FB75()
	{
		A = [0x1B35];
		this.L809977();
		A |= 0x0062;
		this.L8094BA();
		C = 1;
		return;
	}

	public void L97FB85()
	{
		C = 0;
		return;
	}

	public void L97FB87()
	{
		X = [0x12];
		A = [0x0CB6 + X];
		temp = A - 0x0100;
		
		if (Z == 1)
			return this.L97FB93();

		C = 0;
		return;
	}

	public void L97FB93()
	{
		A = [0x1522];
		[0x24] = A;
		Y = 0x0000;
	}

	public void L97FB9B()
	{
		X = [0x17E6 + Y];
		A = [0x1726 + X];
		
		if (N == 1)
			return this.L97FBB7();

		temp = A & 0x0200;
		
		if (Z == 0)
			return this.L97FBAD();

		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L97FBB7();

	}

	public void L97FBAD()
	{
		[0x14] = X;
		Stack.Push(Y);
		this.L97FBBE();
		Y = Stack.Pop();
		
		if (C == 0)
			return this.L97FBB7();

		return;
	}

	public void L97FBB7()
	{
		Y++;
		Y++;
		[0x24]--;
		
		if (Z == 0)
			return this.L97FB9B();

		return;
	}

	public void L97FBBE()
	{
		X = [0x14];
		A = [0x1666 + X];
		A <<= 1;
		Y = A;
		A = [0x14D3];
		[0x00] = A;
		A = [0x14D4];
		[0x01] = A;
		A = [[0x00] + Y];
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		Y = 0x0000;
		A = [[0x00] + Y];
		Y++;
		A &= 0x00FF;
		[0x22] = A;
		X = [0x12];
		A = [0x1004 + X];
		[0x26] = A;
		A = [0x1062 + X];
		[0x28] = A;
		X = [0x14];
	}

	public void L97FBEF()
	{
		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FBFC();

		A &= 0x007F;
		return this.L97FBFF();
	}

	public void L97FBFC()
	{
		A |= 0xFF80;
	}

	public void L97FBFF()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		temp = A - [0x26];
		
		if (N == 0)
			return this.L97FC51();

		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FC14();

		A &= 0x007F;
		return this.L97FC17();
	}

	public void L97FC14()
	{
		A |= 0xFF80;
	}

	public void L97FC17()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		temp = A - [0x28];
		
		if (N == 0)
			return this.L97FC52();

		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FC2C();

		A &= 0x007F;
		return this.L97FC2F();
	}

	public void L97FC2C()
	{
		A |= 0xFF80;
	}

	public void L97FC2F()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		temp = A - [0x26];
		
		if (N == 1)
			return this.L97FC53();

		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FC44();

		A &= 0x007F;
		return this.L97FC47();
	}

	public void L97FC44()
	{
		A |= 0xFF80;
	}

	public void L97FC47()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		temp = A - [0x28];
		
		if (N == 1)
			return this.L97FC54();

		return this.L97FC5A();
	}

	public void L97FC51()
	{
		Y++;
	}

	public void L97FC52()
	{
		Y++;
	}

	public void L97FC53()
	{
		Y++;
	}

	public void L97FC54()
	{
		[0x22]--;
		
		if (Z == 0)
			return this.L97FBEF();

		C = 0;
		return;
	}

	public void L97FC5A()
	{
		A = [0x14];
		[0x18] = A;
		this.L80D3AC();
		this.L80D567();
		this.L80D52A();
		X = [0x12];
		Y = [0x14];
		[0x1B97] = Y;
		[0x1B8F] = X;
		A = [0x1238 + X];
		[0x1B91] = A;
		A = [0x1004 + X];
		[0x1B93] = A;
		A = [0x1062 + X];
		[0x1B95] = A;
		A = [0x1004 + X];
		[0x1B35] = A;
		A = [0x1062 + X];
		[0x1B37] = A;
		this.L97DF5C();
		X = [0x12];
		A = [0x117C + X];
		temp = A - 0x002D;
		
		if (Z == 1)
			return this.L97FCBE();

		temp = A - 0x002E;
		
		if (Z == 1)
			return this.L97FCBE();

		temp = A - 0x002F;
		
		if (Z == 1)
			return this.L97FCBE();

		A = [0x1238 + X];
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FCBE();

		A = 0xFFFF;
		[0x111E + X] = A;
		[0x117C + X] = A;
		[0x1296 + X] = A;
	}

	public void L97FCBE()
	{
		C = 1;
		return;
	}

	public void L97FCC0()
	{
		X = [0x12];
		A = [0x1238 + X];
		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L97FCCB();

		return;
	}

	public void L97FCCB()
	{
		A = [0x1B9D];
		
		if (Z == 0)
			return this.L97FCD1();

		return;
	}

	public void L97FCD1()
	{
		A = [0x1522];
		[0x24] = A;
		Y = 0x0000;
	}

	public void L97FCD9()
	{
		A = [0x24];
		X = [0x17E6 + Y];
		A = [0x1726 + X];
		
		if (N == 1)
			return this.L97FCF4();

		temp = A & 0x0200;
		
		if (Z == 0)
			return this.L97FCED();

		temp = A & 0x8000;
		
		if (Z == 0)
			return this.L97FCF4();

	}

	public void L97FCED()
	{
		[0x14] = X;
		Stack.Push(Y);
		this.L97FCFB();
		Y = Stack.Pop();
	}

	public void L97FCF4()
	{
		Y++;
		Y++;
		[0x24]--;
		
		if (Z == 0)
			return this.L97FCD9();

		return;
	}

	public void L97FCFB()
	{
		X = [0x14];
		A = [0x1626 + X];
		A <<= 1;
		Y = A;
		A = [0x14D3];
		[0x00] = A;
		A = [0x14D4];
		[0x01] = A;
		A = [[0x00] + Y];
		C = 0;
		A += [0x00] + C;
		[0x00] = A;
		Y = 0x0000;
		A = [[0x00] + Y];
		A &= 0x00FF;
		Y++;
		[0x22] = A;
	}

	public void L97FD1E()
	{
		X = [0x14];
		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FD2D();

		A &= 0x007F;
		return this.L97FD30();
	}

	public void L97FD2D()
	{
		A |= 0xFF80;
	}

	public void L97FD30()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		C = 1;
		A -= [0x1B9F] - !C;
		[0x26] = A;
		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FD47();

		A &= 0x007F;
		return this.L97FD4A();
	}

	public void L97FD47()
	{
		A |= 0xFF80;
	}

	public void L97FD4A()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		C = 1;
		A -= [0x1BA1] - !C;
		[0x28] = A;
		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FD61();

		A &= 0x007F;
		return this.L97FD64();
	}

	public void L97FD61()
	{
		A |= 0xFF80;
	}

	public void L97FD64()
	{
		C = 0;
		A += [0x15A6 + X] + C;
		C = 0;
		A += [0x1B9F] + C;
		[0x2A] = A;
		A = [[0x00] + Y];
		Y++;
		temp = A & 0x0080;
		
		if (Z == 0)
			return this.L97FD7B();

		A &= 0x007F;
		return this.L97FD7E();
	}

	public void L97FD7B()
	{
		A |= 0xFF80;
	}

	public void L97FD7E()
	{
		C = 0;
		A += [0x15E6 + X] + C;
		C = 0;
		A += [0x1BA1] + C;
		[0x2C] = A;
		X = [0x12];
		A = [0x0B9C + X];
		temp = A - [0x26];
		
		if (N == 1)
			return this.L97FDA2();

		temp = A - [0x2A];
		
		if (N == 0)
			return this.L97FDA2();

		A = [0x0C58 + X];
		temp = A - [0x28];
		
		if (N == 1)
			return this.L97FDA2();

		temp = A - [0x2C];
		
		if (N == 0)
			return this.L97FDA2();

		return this.L97FDAA();
	}

	public void L97FDA2()
	{
		[0x22]--;
		
		if (Z == 1)
			return this.L97FDA9();

		return this.L97FD1E();
	}

	public void L97FDA9()
	{
		return;
	}

	public void L97FDAA()
	{
		A = [0x22];
		Stack.Push(A);
		A = [0x24];
		Stack.Push(A);
		A = [0x14];
		[0x18] = A;
		A = [0x11DA + X];
		temp = A - 0xFFFF;
		
		if (Z == 0)
			return this.L97FDC0();

		this.L80D567();
	}

	public void L97FDC0()
	{
		this.L80D3AC();
		this.L80D52A();
		A = Stack.Pop();
		[0x24] = A;
		A = Stack.Pop();
		[0x22] = A;
		return;
	}

	public void L97FDCF()
	{
		X = [0x12];
		A = [0x0CB6 + X];
		temp = A - [0x1BA3];
		
		if (Z == 1)
			return this.L97FDDA();

		return;
	}

	public void L97FDDA()
	{
		A = [0x1004 + X];
		[0x26] = A;
		A = [0x1062 + X];
		[0x28] = A;
		Stack.Push(X);
		this.L94BC35();
		X = Stack.Pop();
		A = [0x2A];
		
		if (N == 1)
			return this.L97FE13();

		temp = A - 0x0200;
		
		if (C == 1)
			return this.L97FDF4();

		return;
	}

	public void L97FDF4()
	{
		temp = A - 0x0300;
		
		if (C == 0)
			return this.L97FE13();

		A = [0x0387];
		
		if (N == 1)
			return this.L97FE13();

		A = [0x1C];
		[0x1B35] = A;
		A = [0x1E];
		[0x1B37] = A;
		A = [0x14D6];
		[0x1B3B] = A;
		this.L97E248();
		return;
	}

	public void L97FE13()
	{
		A = [0x1238 + X];
		temp = A & 0x0800;
		
		if (Z == 0)
			return this.L97FE34();

		A = [0x1004 + X];
		[0x1B35] = A;
		A = [0x1062 + X];
		[0x1B37] = A;
		A = 0xFFFF;
		[0x117C + X] = A;
		[0x1296 + X] = A;
		this.L97E1F3();
	}

	public void L97FE34()
	{
		return;
	}

	public void L97FE35()
	{
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		[0x1B9B] = 0;
		A = [0x11B2];
		
		if (N == 1)
			return this.L97FE48();

		A = 0x0036;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE48()
	{
		A = [0x11B4];
		
		if (N == 1)
			return this.L97FE55();

		A = 0x0038;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE55()
	{
		A = [0x11B6];
		
		if (N == 1)
			return this.L97FE62();

		A = 0x003A;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE62()
	{
		A = [0x11B8];
		
		if (N == 1)
			return this.L97FE6F();

		A = 0x003C;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE6F()
	{
		A = [0x11BA];
		
		if (N == 1)
			return this.L97FE7C();

		A = 0x003E;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE7C()
	{
		A = [0x11BC];
		
		if (N == 1)
			return this.L97FE89();

		A = 0x0040;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE89()
	{
		A = [0x11BE];
		
		if (N == 1)
			return this.L97FE96();

		A = 0x0042;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FE96()
	{
		A = [0x11C0];
		
		if (N == 1)
			return this.L97FEA3();

		A = 0x0044;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEA3()
	{
		A = [0x11C2];
		
		if (N == 1)
			return this.L97FEB0();

		A = 0x0046;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEB0()
	{
		A = [0x11C4];
		
		if (N == 1)
			return this.L97FEBD();

		A = 0x0048;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEBD()
	{
		A = [0x11C6];
		
		if (N == 1)
			return this.L97FECA();

		A = 0x004A;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FECA()
	{
		A = [0x11C8];
		
		if (N == 1)
			return this.L97FED7();

		A = 0x004C;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FED7()
	{
		A = [0x11CA];
		
		if (N == 1)
			return this.L97FEE4();

		A = 0x004E;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEE4()
	{
		A = [0x11CC];
		
		if (N == 1)
			return this.L97FEF1();

		A = 0x0050;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEF1()
	{
		A = [0x11CE];
		
		if (N == 1)
			return this.L97FEFE();

		A = 0x0052;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FEFE()
	{
		A = [0x11D0];
		
		if (N == 1)
			return this.L97FF0B();

		A = 0x0054;
		[0x14] = A;
		this.L97FF0D();
	}

	public void L97FF0B()
	{
		B = Stack.Pop();
		return;
	}

	public void L97FF0D()
	{
		X = [0x14];
		A = [0x0CB6 + X];
		
		if (Z == 1)
			return this.L97FF15();

		return;
	}

	public void L97FF15()
	{
		A = [0x1004 + X];
		temp = A - 0x0018;
		
		if (C == 0)
			return this.L97FF33();

		temp = A - 0x00E8;
		
		if (C == 1)
			return this.L97FF33();

		A = [0x1062 + X];
		temp = A - 0x0018;
		
		if (C == 0)
			return this.L97FF33();

		temp = A - 0x00B0;
		
		if (C == 1)
			return this.L97FF33();

		this.L97FF34();
		return;
	}

	public void L97FF33()
	{
		return;
	}

	public void L97FF34()
	{
		[0x1B9B]++;
		A = [0x1B81];
		
		if (Z == 0)
			return this.L97FF79();

		A = [0x1B2B];
		
		if (Z == 0)
			return this.L97FF79();

		A = [0x1B79];
		
		if (Z == 0)
			return this.L97FF79();

		A = [0x1B7B];
		
		if (Z == 0)
			return this.L97FFB6();

		this.L80D6CA();
		X = [0x14];
		A = [0x1238 + X];
		A &= 0x0006;
		
		if (Z == 0)
			return this.L97FF68();

		A = 0x0000;
		[0x038F] = A;
		A = 0x00B4;
		this.L809492();
		return this.L97FF75();
	}

	public void L97FF68()
	{
		A = 0x0001;
		[0x038F] = A;
		A = 0x00CA;
		this.L809492();
	}

	public void L97FF75()
	{
		[0x038D] = 0;
		return;
	}

	public void L97FF79()
	{
		this.L97E440();
		A = 0x0066;
		this.L8094BA();
		Y = [0x14];
		A = [0x1238 + Y];
		A &= 0x0007;
		temp = A - 0x0003;
		
		if (C == 1)
			return this.L97FF92();

		return;
	}

	public void L97FF92()
	{
		A = 0x0000;
		[0x1B2B] = A;
		P |= 0x20;
		A = [0x4A];
		A &= 0xFD;
		[0x4A] = A;
		A = 0x20;
		[0x012E] = A;
		A = 0x40;
		[0x012D] = A;
		A = 0x80;
		[0x012C] = A;
		P &= ~0x20;
		this.L9095E0();
		return;
	}

	public void L97FFB6()
	{
		temp = A & 0xC000;
		
		if (Z == 0)
			return this.L97FFE8();

		Y = [0x14];
		A = [0x117C + Y];
		A <<= 1;
		X = A;
		C = 1;
		A = [0x1B7D];
		A -= [0x7E3DC3 + X] - !C;
		[0x1B7D] = A;
		A = [0x1B7F];
		A -= [0x7E40C3 + X] - !C;
		[0x1B7F] = A;
		A = 0x0066;
		this.L8094BA();
		A = 0x0011;
		[0x1B7B] = A;
		this.L97E440();
	}

	public void L97FFE8()
	{
		return;
	}

	public void L9BD1EC()
	{
		A = [0x197C];
		[0x12] = A;
		A = [0x197E];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDC];
		A -= [0x12] - !C;
		[0x7E5DDC] = A;
		A = [0x7E5DE4];
		A -= [0x14] - !C;
		[0x7E5DE4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DDE];
		A -= [0x12] - !C;
		[0x7E5DDE] = A;
		A = [0x7E5DE6];
		A -= [0x14] - !C;
		[0x7E5DE6] = A;
		A = [0x1988];
		[0x12] = A;
		A = [0x198A];
		[0x14] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEC];
		A -= [0x12] - !C;
		[0x7E5DEC] = A;
		A = [0x7E5DF4];
		A -= [0x14] - !C;
		[0x7E5DF4] = A;
		A = [0x14];
		Cpu.ROL();
		Cpu.ROR(0x14);
		Cpu.ROR(0x12);
		C = 1;
		A = [0x7E5DEE];
		A -= [0x12] - !C;
		[0x7E5DEE] = A;
		A = [0x7E5DF6];
		A -= [0x14] - !C;
		[0x7E5DF6] = A;
		A = [0x7E5DE4];
		C = 0;
		A += 0x00A0 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD2AE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x00E0 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD2AE();

		this.L9BD54D();
	}

	public void L9BD2AE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0004 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD2DE();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD2DE();

		this.L9BD54D();
	}

	public void L9BD2DE()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x00FC + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD30E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0003 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD30E();

		this.L9BD54D();
	}

	public void L9BD30E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD33E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD33E();

		this.L9BD594();
	}

	public void L9BD33E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0060 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD36E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0000 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD36E();

		this.L9BD594();
	}

	public void L9BD36E()
	{
		A = [0x7E5DE4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD39E();

		A = [0x7E5DF4];
		C = 0;
		A += 0x0080 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD39E();

		this.L9BD594();
	}

	public void L9BD39E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00E4 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD3CE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD3CE();

		this.L9BD4BF();
	}

	public void L9BD3CE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x002E + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD3FE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0005 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD3FE();

		this.L9BD4BF();
	}

	public void L9BD3FE()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x00B8 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD42E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x002E + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD42E();

		this.L9BD4BF();
	}

	public void L9BD42E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD45E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0066 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD45E();

		this.L9BD506();
	}

	public void L9BD45E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0080 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD48E();

		A = [0x7E5DF6];
		C = 0;
		A += 0x009C + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD48E();

		this.L9BD506();
	}

	public void L9BD48E()
	{
		A = [0x7E5DE6];
		C = 0;
		A += 0x0020 + C;
		A &= 0x01FF;
		[0xB0] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x0128;
		
		if (C == 1)
			return this.L9BD4BE();

		A = [0x7E5DF6];
		C = 0;
		A += 0x0040 + C;
		A &= 0x00FF;
		[0xB2] = A;
		C = 0;
		A += 0x0014 + C;
		temp = A - 0x00D0;
		
		if (C == 1)
			return this.L9BD4BE();

		this.L9BD506();
	}

	public void L9BD4BE()
	{
		return;
	}

	public void L9BD4BF()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD4CD();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD4CD()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD4F4();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD4F4()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2E87;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD506()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD514();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD514()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FB + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD53B();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD53B()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FB + C;
		[0x7801 + Y] = A;
		A = 0x2E9C;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD54D()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD55B();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD55B()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD582();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD582()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2ED5;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD594()
	{
		Stack.Push(B);
		Stack.Push(P);
		P &= ~0x30;
		Y = [0xA6];
		temp = Y - 0x01FD;
		
		if (C == 0)
			return this.L9BD5A2();

		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L9BD5A2()
	{
		A = Y;
		C = 0;
		A += 0x0004 + C;
		[0xA6] = A;
		P |= 0x20;
		A = 0x82;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0xB0];
		C = 0;
		A += 0x01FC + C;
		[0x7800 + Y] = A;
		temp = A & 0x0100;
		
		if (Z == 1)
			return this.L9BD5C9();

		X = [0x82B6 + Y];
		A = [0x00 + X];
		A |= [0x82B8 + Y];
		[0x00 + X] = A;
	}

	public void L9BD5C9()
	{
		A = [0xB2];
		C = 0;
		A += 0x01FC + C;
		[0x7801 + Y] = A;
		A = 0x2ED4;
		[0x7802 + Y] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

}
