public class SnesRom
{
	public void L008C3B_Reset()
	{
		I = 1;
		C = 0;
		temp = C; C = E; E = temp;
		return this.L808C42_Start();
	}








	public void R808202_WaitFor014BFlag1()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x30;
		A = 0x01;
		[0x014B] = A;
	}

	public void L80820D_Loop()
	{
		A = [0x014B];

		if (Z == 0)
			return this.L80820D_Loop();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808215_EnableVBlankIRQ()
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








	public void R808229_DisableVBlankIRQ()
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








	public void R80823D_Set0100Flag80()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A |= 0x80;
		[0x0100] = A;
		this.R808202_WaitFor014BFlag1();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808252_Clear0100Flag80()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0100];
		A &= 0x7F;
		[0x0100] = A;
		this.R808202_WaitFor014BFlag1();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R80827B_Clear013CAnd4200Flag10()
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








	public void R8082A3_Clear013CAnd4200Flag20()
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








	public void R808306_HandleEvents()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = [0x0154];

		if (Z == 1)
			return this.L808345_EventType0_Done();

		[0x0154] = 0;
		[0x420B] = 0;
		[0x420C] = 0;
		P &= ~0x30;

		// Word0152_NextEvent = 0;
		[0x0152] = 0;
		Y = 0x0000;
	}

	public void L808322_Loop()
	{
		// if (Y > 0x0100) Stop;
		temp = Y - 0x0100;

		if (C == 0)
			return this.L808329();
	}

	public void L808327_Stop()
	{
		return this.L808327_Stop();
	}

	public void L808329()
	{
		// if (EventType > 5) Stop;
		A = [0x0155 + Y];
		A &= 0x00FF;
		temp = A - 0x0005;

		if (C == 0)
			return this.L808336();
	}

	public void L808334_Stop()
	{
		return this.L808334_Stop();
	}

	public void L808336()
	{
		// FunctionTable[A * 2]();
		A <<= 1;
		X = A;
		return [(0x833B + X)]();
	}

	public byte[] FunctionTable80833B = new byte[]
	{
		0x45, 0x83,
		0x4D, 0x83,
		0x8B, 0x83,
		0xD7, 0x83,
		0x29, 0x84
	}

	public void L808345_EventType0_Done()
	{
		P |= 0x20;
		[0x0155] = 0;
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public void L80834D_EventType1()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2121] = A;
		[0x4310] = 0;
		A = 0x22;
		[0x4311] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 7
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0007 + C;
		Y = A;
		return this.L808322_Loop();
	}

	public void L80838B_EventType2()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2115] = A;
		A = [0x015C + Y];
		[0x2116] = A;
		A = [0x015D + Y];
		[0x2117] = A;
		A = 0x01;
		[0x4310] = A;
		A = 0x18;
		[0x4311] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 9;
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0009 + C;
		Y = A;
		return this.L808322_Loop();
	}

	public void L8083D7_EventType3()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x2115] = A;
		A = [0x015C + Y];
		[0x2116] = A;
		A = [0x015D + Y];
		[0x2117] = A;
		A = 0x81;
		[0x4310] = A;
		A = 0x39;
		[0x4311] = A;
		A = [0x2139];
		A = [0x213A];
		A = 0x02;
		[0x420B] = A;

		// Y += 9
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x0009 + C;
		Y = A;

		return this.L808322_Loop();
	}

	public void L808429_EventType4()
	{
		P |= 0x20;

		A = [0x0156 + Y];
		[0x4312] = A;
		A = [0x0157 + Y];
		[0x4313] = A;
		A = [0x0158 + Y];
		[0x4314] = A;
		A = [0x0159 + Y];
		[0x4315] = A;
		A = [0x015A + Y];
		[0x4316] = A;
		A = [0x015B + Y];
		[0x4310] = A;
		A = [0x015C + Y];
		[0x4311] = A;
		A = [0x015D + Y];
		[0x2115] = A;
		A = [0x015E + Y];
		[0x2116] = A;
		A = [0x015F + Y];
		[0x2117] = A;
		A = 0x02;
		[0x420B] = A;

		// Y += 11;
		P &= ~0x20;
		A = Y;
		C = 0;
		A += 0x000B + C;
		Y = A;

		return this.L808322_Loop();
	}








	public void R80850F_SetRam()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
	}

	public void L808515_Loop()
	{
		[0x7E0000 + X] = A;
		X++;
		X++;
		Y--;
		Y--;

		if (Z == 0)
			return this.L808515_Loop();

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808744()
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
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80875B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E2000, Length 0x0800, VRAM Control 0x80, VRAM Address 0x0000
		0x02, 0x00, 0x20, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x00
	}







	public void R808764()
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
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80877B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E2800, Length 0x0800, VRAM Control 0x80, VRAM Address 0x0800
		0x02, 0x00, 0x28, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x08
	}





	public void R808784()
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
		this.R8087A4_LoadDmaTransferRecord();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}

	public byte[] DmaTransferRecord80879B = new byte[]
	{
		// Type 0x02, RAM Address 0x7E3000, Length 0x0800, VRAM Control 0x80, VRAM Address 0x1C00
		0x02, 0x00, 0x30, 0x7E, 0x00, 0x08, 0x80, 0x00, 0x1C
	}








	public void R8087A4_LoadDmaTransferRecord()
	{
		Stack.Push(P);
		P &= ~0x30;

		// X = Word0152_NextEvent
		X = [0x0152];

		Y = 0x0000;
		P |= 0x20;

		// A = EventType
		A = [[0x00] + Y];
		Y++;

		// Write EventType To Event List
		[0x0155 + X] = A;

		// Event Type 0x01
		A--;

		if (Z == 0)
			return this.L8087BB();

		return this.L808822_EventType1();
	}

	public void L8087BB()
	{
		// Event Type 0x02
		A--;

		if (Z == 0)
			return this.L8087C1();

		return this.L8087CD_EventTypeOther();
	}

	public void L8087C1()
	{
		// Event Type 0x03
		A--;

		if (Z == 0)
			return this.L8087C7();

		return this.L8087CD_EventTypeOther();
	}

	public void L8087C7()
	{
		// Event Type 0x04
		A--;

		if (Z == 0)
			return this.L8087CD_EventTypeOther();

		return this.L8087F3_EventType4();
	}

	public void L8087CD_EventTypeOther()
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
		return this.L80883F_SetNextEvent();
	}

	public void L8087F3_EventType4()
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
		return this.L80883F_SetNextEvent();
	}

	public void L808822_EventType1()
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

	public void L80883F_SetNextEvent()
	{
		// Word0152_NextEvent = A;
		[0x0152] = A;

		// Flag0154 = 1;
		P |= 0x30;
		A = 0x01;
		[0x0154] = A;

		A = [0x02D6];

		if (N == 0)
			return this.L808852_Done();

		this.R808306_HandleEvents();
	}

	public void L808852_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void L808C42_Start()
	{
		P |= 0x20;

		// Screen Display (Blank)
		A = 0x80;
		[0x0100] = A;
		[0x2100] = A;

		A = 0x00;
		[0x7FF7] = A;

		P |= 0x30;

		// DMA
		[0x420B] = 0;
		[0x420C] = 0;

		// APU
		[0x2140] = 0;
		[0x2141] = 0;
		[0x2142] = 0;
		[0x2143] = 0;

		// Stack
		P &= ~0x30;
		X = 0x1FFF;
		S = X;

		// Direct Bank (0x0000)
		Y = 0x0000;
		Stack.Push(Y);
		D = Stack.Pop();

		// Data Bank (Program Bank)
		Stack.Push(K);
		B = Stack.Pop();

		return this.L808EE3_Start2();
	}








	public void R808C76_ResetRegisters()
	{
		Stack.Push(P);
		P |= 0x30;

		// Set Flag013C
		A = 0x01;
		[0x4200] = A;
		[0x013C] = A;

		// Enable PPU H/V Scanline Latch
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

		// ROM Speed (Fast)
		A = 0x01;
		[0x420D] = A;
		[0x0142] = A;

		P = Stack.Pop();

		return;
	}








	public void R808CC0_ResetPPU()
	{
		Stack.Push(P);
		P |= 0x30;

		// Screen Brightness (Blank)
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;

		// Sprite Size (8x8 / 16x16 / Name: 0 / Address : 1 << 14)
		A = 0x01;
		[0x2101] = A;
		[0x0101] = A;

		// Sprite Address (0x0000 / Priority : 1)
		[0x2102] = 0;
		[0x0102] = 0;

		A = 0x80;
		[0x2103] = A;
		[0x0103] = A;

		// Sprite Data
		[0x2104] = 0;
		[0x2104] = 0;

		// Background Mode (Mode 9)
		A = 0x09;
		[0x2105] = A;
		[0x0104] = A;

		// Mosaic Enable (Off)
		[0x2106] = 0;
		[0x0105] = 0;

		// Background 1 Tilemap Address (0x00 << 10)
		A = 0x00;
		[0x2107] = A;
		[0x0106] = A;

		// Background 2 Tilemap Address (0x08 << 10)
		A = 0x08;
		[0x2108] = A;
		[0x0107] = A;

		// Background 3 Tilemap Address (0x1C << 10)
		A = 0x1C;
		[0x2109] = A;
		[0x0108] = A;

		// Background 4 Tilemap Address (0x00 << 10)
		A = 0x00;
		[0x210A] = 0;
		[0x0109] = 0;

		// Background 1/2 Character Address (0x06 << 12 / 0x00 << 12)
		A = 0x06;
		[0x210B] = A;
		[0x010A] = A;

		// Background 3/4 Character Address (0x01 << 12 / 0x00 << 12)
		A = 0x01;
		[0x210C] = A;
		[0x010B] = A;

		// Background 1-4 H/V Scroll (0x00)
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

		// Video Port Control
		[0x2115] = 0;

		// Mode 7 Settings
		[0x211A] = 0;
		[0x010C] = 0;

		// Mode 7 Matrix
		[0x211B] = 0;
		[0x211C] = 0;
		[0x211D] = 0;
		[0x211E] = 0;

		// Mode 7 Center X/Y
		[0x211F] = 0;
		[0x2120] = 0;

		// Background 1/2 Window
		A = 0x00;
		[0x2123] = A;
		[0x010D] = A;

		// Background 3/4 Window
		A = 0x00;
		[0x2124] = A;
		[0x010E] = A;

		// Sprite/Color Window
		[0x2125] = 0;
		[0x011F] = 0;

		// Window 1 Left
		A = 0x00;
		[0x2126] = A;
		[0x0120] = A;

		// Window 1 Right
		A = 0xF8;
		[0x2127] = A;
		[0x0121] = A;

		// Window 2 Left
		[0x2128] = 0;
		[0x0122] = 0;

		// Window 2 Right
		[0x2129] = 0;
		[0x0123] = 0;

		// Background Window Mask
		[0x212A] = 0;
		[0x0124] = 0;

		// Sprite / Color Window Mask
		[0x212B] = 0;
		[0x0125] = 0;

		// Main Screen Background Enable
		A = 0x11;
		[0x212C] = A;
		[0x0126] = A;

		// Main Screen Background Mask Enable
		[0x212E] = A;
		[0x0128] = A;

		// Sub Screen Background Enable
		A = 0x02;
		[0x212D] = A;
		[0x0127] = A;

		// Sub Screen Background Mask Enable
		[0x212F] = A;
		[0x0129] = A;

		// Color Addition Select
		A = 0x02;
		[0x2130] = A;
		[0x012A] = A;

		// Color Math Designation
		A = 0xA1;
		[0x2131] = A;
		[0x012B] = A;

		// Fixed Color Data (R: 0)
		A = 0x20;
		[0x2132] = A;
		[0x012E] = A;

		// Fixed Color Data (G: 0)
		A = 0x40;
		[0x2132] = A;
		[0x012D] = A;

		// Fixed Color Data (B: 0)
		A = 0x80;
		[0x2132] = A;
		[0x012C] = A;

		// Screen Mode (None)
		A = 0x00;
		[0x2133] = A;
		[0x012F] = A;

		P = Stack.Pop();

		return;
	}








	public void R808E19_Insanity()
	{
		P &= ~0x30;
		A = 0x1C2F;
		this.R808E3F_SetRam2000();
		A = 0x1C2F;
		this.R808E52_SetRam2800();
		A = 0x1C2F;
		this.R808E65_SetRam3000();
		P |= 0x30;
		this.R808744();
		this.R808764();
		this.R808784();
		return;
	}








	public void R808E3F_SetRam2000()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2000;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E52_SetRam2800()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x2800;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E65_SetRam3000()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x3000;
		Y = 0x0800;
		this.R80850F_SetRam();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R808E78_MainLoop_2()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.R808EA7();

		// Value0257 = (Value0255 >= 5);
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
		// Value0261 = Value0259 + Value025D
		A = [0x0259];
		C = 0;
		A += [0x025D] + C;
		[0x0261] = A;

		// Value0263 = Value025B + Value025F
		A = [0x025B];
		C = 0;
		A += [0x025F] + C;
		[0x0263] = A;
		P = Stack.Pop();
		return;
	}








	public void R808EA7()
	{
		Stack.Push(P);
		P |= 0x20;

		// if (Ppu.LatchFlag == false) Skip;
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
		// Value0255_PPULatchTimer = Min(255, Value0255_PPULatchTimer + 1);
		[0x0255]++;

		if (Z == 0)
			return this.L808ED4();

		[0x0255]--;
		return this.L808ED4();
	}

	public void L808EE3_Start2()
	{
		P |= 0x30;
		A = 0xA1;
		[0x7FF5] = A;
		A = 0x0A;
		[0x7FF7] = A;
		P &= ~0x30;
		X = 0x01FE;
	}

	public void L808EF4_Loop()
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
			return this.L808EF4_Loop();

		return this.L808F49_Start3();
	}

	public void L808F49_Start3()
	{
		P |= 0x30;
		[0x4200] = 0;
		[0x013C] = 0;
		A = 0x8F;
		[0x2100] = A;
		[0x0100] = A;
		this.R808C76_ResetRegisters();
		this.R808CC0_ResetPPU();
		this.R808E19_Insanity();
		this.R809D46_InitializeObd1Ram();
		this.R809BAB_FillTable7800();
		this.R808215_EnableVBlankIRQ();
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
		this.R8CC0E8_ResetRegistersAndRam();
		this.R808252_Clear0100Flag80();
		P &= ~0x30;
		this.R80942D();
		P &= ~0x30;
		Y = 0x003C;
	}

	public void L808FA1_Loop()
	{
		this.R808202_WaitFor014BFlag1();
		Y--;

		if (Z == 0)
			return this.L808FA1_Loop();

		// Clear RAM
		P |= 0x30;
		A = 0x7E;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FB6_Loop()
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
			return this.L808FB6_Loop();

		P |= 0x30;
		A = 0x7F;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x30;
		X = 0x0FFE;
		A = 0x0000;
	}

	public void L808FF2_Loop()
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
			return this.L808FF2_Loop();

		Stack.Push(K);
		B = Stack.Pop();
		P |= 0x20;
		A = 0x0F;
		[0x0100] = A;
	}

	public void L80902F_Loop()
	{
		this.R808202_WaitFor014BFlag1();
		[0x0100]--;

		if (Z == 0)
			return this.L80902F_Loop();

		P &= ~0x20;
		this.R80823D_Set0100Flag80();
		A = 0x8000;
		[0x01] = A;
		A = 0x904E;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L809059_LoadEvents9069();
	}

	public byte[] DmaTransferRecord80904E = new byte[]
	{
		// Type 0x04, RAM Address 0x809077, Length 0x8000, DMA Control 0x08, DMA Address 0x2119, VRAM Control 0x80, VRAM Address 0x0000
		0x04, 0x77, 0x90, 0x80, 0x00, 0x80, 0x08, 0x19, 0x80, 0x00, 0x00
	}

	public void L809059_LoadEvents9069()
	{
		A = 0x8000;
		[0x01] = A;
		A = 0x9069;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L809074();
	}

	public byte[] DmaTransferRecord809069 = new byte[]
	{
		// Type 0x04, RAM Address 0x809076, Length 0x8000, DMA Control 0x08, DMA Address 0x2118, VRAM Control 0x00, VRAM Address 0x0000
		0x04, 0x76, 0x90, 0x80, 0x00, 0x80, 0x08, 0x18, 0x00, 0x00, 0x00
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
		this.R809559_InitializeRam();
		this.R808202_WaitFor014BFlag1();
	}

	public void L80908B_MainLoop()
	{
		P &= ~0x30;
		this.R8090A1_MainLoop_1();
		this.R808E78_MainLoop_2();
		this.R8090CD_MainLoop_3();
		this.R8090B8_MainLoop_4();
		this.R808202_WaitFor014BFlag1();
		return this.L80908B_MainLoop();
	}








	public void R8090A1_MainLoop_1()
	{
		this.R809570_Execute();
		this.R809A94();
		this.R809B30();
		this.R809FDF();
		P &= ~0x30;
		this.R809D46_InitializeObd1Ram();
		return;
	}








	public void R8090B8_MainLoop_4()
	{
		this.R809BAB_FillTable7800();
		this.R80A005();
		P &= ~0x30;
		A = [0x5A];
		[0x0265] = A;
		A = [0x52];
		[0x0267] = A;
		return;
	}








	public void R8090CD_MainLoop_3()
	{
		P &= ~0x30;
		Stack.Push(B);

		// X = Value026D * 3
		A = [0x026D];
		A <<= 1;
		A += [0x026D] + C;
		X = A;

		// if (Table809105[X + 2] == 0x7D) Done;
		P |= 0x20;
		A = [0x809107 + X];
		temp = A - 0x7D;

		if (Z == 1)
			return this.L8090F6_Done();

		[0x02] = A;
		Stack.Push(A);
		B = Stack.Pop();
		P &= ~0x20;
		A = [0x809105 + X];
		[0x00] = A;
		this.R809102_ExecutePointer24();
	}

	public void L8090F2_Done()
	{
		P &= ~0x30;
		B = Stack.Pop();
		return;
	}

	public void L8090F6_Done()
	{
		P &= ~0x20;
		A = [0x809105 + X];
		[0x026D] = A;
		return this.L8090F2_Done();
	}








	public void R809102_ExecutePointer24()
	{
		return [[0x0000]]();    //24-Bit Address
	}








	public byte[] FunctionPointerTable809105 = new byte[]
	{
		0x0C, 0x9F, 0x80,
		0xDE, 0x9C, 0x90,
		0x97, 0x9D, 0x90,
		0x1C, 0x9F, 0x80,
		0xF9, 0x9C, 0x90,
		0x4F, 0xAE, 0x8E,
		0x6E, 0xCB, 0x8E,
		0xBE, 0x98, 0x8E,
		0x67, 0xA2, 0x90,
		0x5F, 0xD1, 0x90,
		0xD4, 0xAC, 0x90,
		0x2D, 0x9F, 0x80,
		0x44, 0x81, 0x96,
		0xA1, 0x9D, 0x90,
		0x82, 0x9D, 0x90,
		0x10, 0x80, 0x8B,
		0x00, 0xC7, 0x94,
		0xE5, 0x9E, 0x90,
		0xE6, 0xA0, 0x80,
		0xED, 0xA0, 0x80,
		0x64, 0x8C, 0x91,
		0x82, 0xA7, 0x90,
		0x2F, 0xC2, 0x8C,
		0x3E, 0xC2, 0x8C,
		0x64, 0xC2, 0x8C,
		0x46, 0x9E, 0x90,
		0x40, 0x9F, 0x80,
		0xD6, 0xC9, 0x8C,
		0x56, 0xCA, 0x8C,
		0x08, 0x9F, 0x90,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xC2, 0x8E, 0x91,
		0xDD, 0xA0, 0x90,
		0xAE, 0xD2, 0x8C,
		0x4F, 0xA1, 0x90,
		0x1F, 0xC9, 0x8C,
		0x45, 0xC9, 0x8C,
		0x24, 0xA3, 0x90,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xAE, 0xD2, 0x8C,
		0xBC, 0x00, 0x7D,
		0x53, 0xD2, 0x8C,
		0x7E, 0xD2, 0x8C,
		0xAE, 0xD2, 0x8C
	}








	public void R80942D()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x30;

		// Flag0322 = 1;
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
		this.R8098E6();
		P |= 0x30;
		A = 0xFE;
	}

	public void L809452_Loop()
	{
		// Wait For APU Idle
		[0x2142] = A;
		temp = A - [0x2142];

		if (Z == 0)
			return this.L809452_Loop();

		P &= ~0x30;
		X = 0x005E;
	}

	public void L80945F_Loop()
	{
		[0x02D7 + X] = 0;
		X--;
		X--;

		if (N == 1)
			return this.L809468();

		return this.L80945F_Loop();
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

		// Flag0322 = 0;
		A = 0x0000;
		[0x0322] = A;

		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809492()
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
			return this.L8094B6_Done();

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

	public void L8094B6_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8094BA()
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
			return this.L8094DE_Done();

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

	public void L8094DE_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8094E2()
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
			return this.L809555_Done();

		Stack.Push(Y);
		X = [0x00];
		Stack.Push(X);
		X = [0x01];
		Stack.Push(X);
		X = A;
		A = [0x030B];

		if (Z == 0)
			return this.L80950E();

		this.R808229_DisableVBlankIRQ();
		this.R8097B2_APU();
		this.R808215_EnableVBlankIRQ();
		P &= ~0x30;
	}

	public void L80950E()
	{
		X = Stack.Pop();
		[0x01] = X;
		X = Stack.Pop();
		[0x00] = X;
		Y = Stack.Pop();
		return this.L809555_Done();
	}








	public void R809517()
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
			return this.L809555_Done();

		temp = A - 0x00E0;

		if (C == 0)
			return this.L809555_Done();

		temp = A - 0x00E5;

		if (C == 0)
			return this.L809534();

		[0x02F9] = X;
	}

	public void L809534()
	{
		A = [0x030B];

		if (Z == 0)
			return this.L809555_Done();

		A = [0x02F7];
		A &= 0x0002;

		if (Z == 0)
			return this.L809555_Done();
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

	public void L809555_Done()
	{
		X = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809559_InitializeRam()
	{
		Stack.Push(P);
		Stack.Push(B);
		Stack.Push(K);
		B = Stack.Pop();
		P &= ~0x20;
		Stack.Push(A);

		// Table02EB[0-2] = 0xFFFF
		A = 0xFFFF;
		[0x02EB] = A;
		[0x02EF] = A;
		[0x02F3] = A;

		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R809570_Execute()
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

	public void L809586_Loop()
	{
		// A = Table02EB[X];
		A = [0x02EB + X];

		// if (A >= 0) HandleEvent();
		if (N == 0)
			return this.L8095A2_HandleEvent();

		// else if (A == 0xFFFF) Skip();
		temp = A - 0xFFFF;

		if (Z == 1)
			return this.L8095AA_Skip();

		// else
		//	 A = (Abs(A) & 0xff) * 2;
		Stack.Push(A);
		A = Stack.Pop();
		A &= 0x00FF;
		A <<= 1;
		Y = X;
		X = A;

		//	Table02EB[X] = TableBA80C0[A];
		A = [0xBA80C0 + X];
		[0x02EB + Y] = A;
		X = Y;

		return this.L8095A7_Execute();
	}

	public void L8095A2_HandleEvent()
	{
		// Table02EB[X + 2] -= 1;
		[0x02ED + X]--;

		if (Z == 0)
			return this.L8095AA_Skip();
	}

	public void L8095A7_Execute()
	{
		this.R8095BB_Execute();
	}

	public void L8095AA_Skip()
	{
		// if (X == 8) Return;
		temp = X - 0x0005;

		if (C == 1)
			return this.L8095B5_Done();

		// X += 4;
		X++;
		X++;
		X++;
		X++;

		// Continue
		return this.L809586_Loop();
	}

	public void L8095B5_Done()
	{
		Y = Stack.Pop();
		X = Stack.Pop();
		A = Stack.Pop();
		B = Stack.Pop();
		P = Stack.Pop();
		return;
	}








	public void R8095BB_Execute()
	{
		Stack.Push(X);

		// Y = Table02EB[X];
		A = [0x02EB + X];
		Y = A;
	}

	public void L8095C0_Loop()
	{
		// A = ReadShort();
		this.R80968B_ReadShort();

		X = A;

		if (Z == 0)
			return this.L8095CB();

		A--;
		Y = A;
		return this.L809682_Done();
	}

	public void L8095CB()
	{
		// A = ReadShort();
		this.R80968B_ReadShort();

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
		temp = A & [0x031A];[0x031A] |= A;
	}

	public void L80961A()
	{
		A = [0x0318];
		this.R8096FB_Set031C();
	}

	public void L809620()
	{
		A |= [0x031A];
		return this.L809635();
	}

	public void L809625()
	{
		A = [0x02F9];
		this.R809517();
		return this.L809679();
	}

	public void L80962F()
	{
		this.R809492();
		return this.L809679();
	}

	public void L809635()
	{
		this.R8094BA();
		return this.L809679();
	}

	public void L80963B()
	{
		this.R809517();
		return this.L809679();
	}

	public void L809641()
	{
		this.R8094E2();
		return this.L809679();
	}

	public void L809647()
	{
		Y = A;
		return this.L809679();
	}

	public void L80964A()
	{
		this.R809690_APU();
		return this.L809679();
	}

	public void L80964F()
	{
		this.R809690_APU();
		A = [0x030B];

		if (Z == 0)
			return this.L809672();

		return this.L8095C0_Loop();
	}

	public void L80965A()
	{
		this.R809711_Set0402();
		return this.L8095C0_Loop();
	}

	public void L809660()
	{
		this.R809715();
		return this.L8095C0_Loop();
	}

	public void L809666()
	{
		A = X;
		A &= 0x00FF;
		A &= [0x02FB];

		if (Z == 0)
			return this.L809672();

		return this.L8095C0_Loop();
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
			return this.L809682_Done();

		return this.L8095C0_Loop();
	}

	public void L809682_Done()
	{
		// Table02EB[X + 2] = A;
		X = Stack.Pop();
		[0x02ED + X] = A;

		// Table02EB[X] = Y;
		A = Y;
		[0x02EB + X] = A;
		return;
	}








	public void R80968B_ReadShort()
	{
		A = [[0x00] + Y];
		Y++;
		Y++;
		return;
	}








	public void R809690_APU()
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
		this.R8097B2_APU();
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








	public void R8096FB_Set031C()
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








	public void R809711_Set0402()
	{
		[0x0402] = A;
		return;
	}








	public void R809715()
	{
		temp = A - 0xFFF1;

		if (Z == 0)
			return this.L80971F();

		this.R80973C();
		return this.L80973B_Done();
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

	public void L80973B_Done()
	{
		return;
	}








	public void R80973C()
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
		this.R94EB88_ReadCartridgeRam();
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

	public byte[] Table80979A = new byte[]
	{
		0x71, 0x77, 0x7D, 0x7E,
		0x72, 0x78, 0x82, 0x86,
		0x73, 0x79, 0x80, 0x87,
		0x74, 0x7A, 0x81, 0x88,
		0x75, 0x7B, 0x84, 0x7F,
		0x76, 0x7C, 0x83, 0x85
	}





	public void R8097B2_APU()
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

	public void L8097D8_Loop()
	{
		temp = Y - [0x2140];

		if (Z == 0)
			return this.L8097D8_Loop();

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
		A = [0xBA8205 + x];
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
		temp = A & [0x0301];[0x0301] &= ~A;
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

	public void L8098B7_Loop()
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
		return this.L8098B7_Loop();
	}








	public void R8098E6()
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


		if (F.BVS)
			return this.L8098FF();

		P = Stack.Pop();
		return;
	}








	public void R809A94()
	{
		Stack.Push(P);
		P |= 0x20;
		A = [0x030B];

		if (Z == 0)
			return this.L809ADF_Done();

		A = [0x0100];
		temp = A & 0x80;

		if (Z == 0)
			return this.L809ADF_Done();

		A ^= 0xFF;
		temp = A & 0x0F;

		if (Z == 0)
			return this.L809ADF_Done();

		A = [0x026B];

		if (Z == 1)
			return this.L809ADF_Done();

		A = [0x0269];
		A++;

		if (Z == 1)
			return this.L809ADF_Done();

		A--;

		if (Z == 0)
			return this.L809AE1();

		A = [0x53];
		temp = A & 0x40;

		if (Z == 1)
			return this.L809ADF_Done();

		A = [0x0266];
		temp = A & 0x80;

		if (Z == 1)
			return this.L809ADF_Done();

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

	public void L809ADF_Done()
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
			return this.L809ADF_Done();

		this.R809B58();
	}

	public void L809AF5()
	{
		A = [0x0266];
		temp = A & 0x90;

		if (Z == 1)
			return this.L809ADF_Done();

		[0x0269] = 0;
		return this.L809ADF_Done();
	}








	public void R809B30()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x030B];

		if (Z == 0)
			return this.L809B56_Done();

		A = [0x50];
		temp = A - 0x4080;

		if (Z == 0)
			return this.L809B56_Done();

		A = [0x58];
		temp = A & 0x4000;

		if (Z == 1)
			return this.L809B56_Done();

		[0x0255] = 0;
		[0x0257] = 0;
		A = 0x00FF;
		temp = A & [0x52];[0x52] |= A;
		A = 0x8000;
		temp = A & [0x5A];[0x5A] |= A;
	}

	public void L809B56_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void R809B58()
	{
		Stack.Push(P);
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		P |= 0x20;
		A = 0x81;
		[0x4200] = A;
		[0x013C] = A;
		P &= ~0x20;
		this.R80827B_Clear013CAnd4200Flag10();
		this.R8082A3_Clear013CAnd4200Flag20();
		P |= 0x20;
		[0x49] = 0;
		[0x4A] = 0;
		[0x0141] = 0;
		[0x0154] = 0;
		P &= ~0x20;
		[0x0152] = 0;
		this.R808202_WaitFor014BFlag1();
		[0x026B] = 0;
		[0x14CE] = 0;
		[0x14CC] = 0;
		A = 0x0002;
		[0x026D] = A;
		P = Stack.Pop();
		return;
	}








	public void R809BAB_FillTable7800()
	{
		Stack.Push(P);
		P &= ~0x20;

		// Pointer = ((WordA6 / 4) * 3) + FunctionTable809BC4;
		A = [0xA6];
		A >>= 1;
		[0x00] = A;
		A >>= 1;
		C = 0;
		A += [0x00] + C;
		C = 0;
		A += 0x9BC4 + C;
		[0x00] = A;

		// return Pointer(0xEF);
		P |= 0x20;
		A = 0xEF;
		return [(0x0000)]();
	}

	public byte[] FunctionTable809BC4 = new byte[]
	{
		0x8D, 0x01, 0x78,
		0x8D, 0x05, 0x78,
		0x8D, 0x09, 0x78,
		0x8D, 0x0D, 0x78,
		0x8D, 0x11, 0x78,
		0x8D, 0x15, 0x78,
		0x8D, 0x19, 0x78,
		0x8D, 0x1D, 0x78,
		0x8D, 0x21, 0x78,
		0x8D, 0x25, 0x78,
		0x8D, 0x29, 0x78,
		0x8D, 0x2D, 0x78,
		0x8D, 0x31, 0x78,
		0x8D, 0x35, 0x78,
		0x8D, 0x39, 0x78,
		0x8D, 0x3D, 0x78,
		0x8D, 0x41, 0x78,
		0x8D, 0x45, 0x78,
		0x8D, 0x49, 0x78,
		0x8D, 0x4D, 0x78,
		0x8D, 0x51, 0x78,
		0x8D, 0x55, 0x78,
		0x8D, 0x59, 0x78,
		0x8D, 0x5D, 0x78,
		0x8D, 0x61, 0x78,
		0x8D, 0x65, 0x78,
		0x8D, 0x69, 0x78,
		0x8D, 0x6D, 0x78,
		0x8D, 0x71, 0x78,
		0x8D, 0x75, 0x78,
		0x8D, 0x79, 0x78,
		0x8D, 0x7D, 0x78,
		0x8D, 0x81, 0x78,
		0x8D, 0x85, 0x78,
		0x8D, 0x89, 0x78,
		0x8D, 0x8D, 0x78,
		0x8D, 0x91, 0x78,
		0x8D, 0x95, 0x78,
		0x8D, 0x99, 0x78,
		0x8D, 0x9D, 0x78,
		0x8D, 0xA1, 0x78,
		0x8D, 0xA5, 0x78,
		0x8D, 0xA9, 0x78,
		0x8D, 0xAD, 0x78,
		0x8D, 0xB1, 0x78,
		0x8D, 0xB5, 0x78,
		0x8D, 0xB9, 0x78,
		0x8D, 0xBD, 0x78,
		0x8D, 0xC1, 0x78,
		0x8D, 0xC5, 0x78,
		0x8D, 0xC9, 0x78,
		0x8D, 0xCD, 0x78,
		0x8D, 0xD1, 0x78,
		0x8D, 0xD5, 0x78,
		0x8D, 0xD9, 0x78,
		0x8D, 0xDD, 0x78,
		0x8D, 0xE1, 0x78,
		0x8D, 0xE5, 0x78,
		0x8D, 0xE9, 0x78,
		0x8D, 0xED, 0x78,
		0x8D, 0xF1, 0x78,
		0x8D, 0xF5, 0x78,
		0x8D, 0xF9, 0x78,
		0x8D, 0xFD, 0x78,
		0x8D, 0x01, 0x78,
		0x8D, 0x05, 0x79,
		0x8D, 0x09, 0x79,
		0x8D, 0x0D, 0x79,
		0x8D, 0x11, 0x79,
		0x8D, 0x15, 0x79,
		0x8D, 0x19, 0x79,
		0x8D, 0x1D, 0x79,
		0x8D, 0x21, 0x79,
		0x8D, 0x25, 0x79,
		0x8D, 0x29, 0x79,
		0x8D, 0x2D, 0x79,
		0x8D, 0x31, 0x79,
		0x8D, 0x35, 0x79,
		0x8D, 0x39, 0x79,
		0x8D, 0x3D, 0x79,
		0x8D, 0x41, 0x79,
		0x8D, 0x45, 0x79,
		0x8D, 0x49, 0x79,
		0x8D, 0x4D, 0x79,
		0x8D, 0x51, 0x79,
		0x8D, 0x55, 0x79,
		0x8D, 0x59, 0x79,
		0x8D, 0x5D, 0x79,
		0x8D, 0x61, 0x79,
		0x8D, 0x65, 0x79,
		0x8D, 0x69, 0x79,
		0x8D, 0x6D, 0x79,
		0x8D, 0x71, 0x79,
		0x8D, 0x75, 0x79,
		0x8D, 0x79, 0x79,
		0x8D, 0x7D, 0x79,
		0x8D, 0x81, 0x79,
		0x8D, 0x85, 0x79,
		0x8D, 0x89, 0x79,
		0x8D, 0x8D, 0x79,
		0x8D, 0x91, 0x79,
		0x8D, 0x95, 0x79,
		0x8D, 0x99, 0x79,
		0x8D, 0x9D, 0x79,
		0x8D, 0xA1, 0x79,
		0x8D, 0xA5, 0x79,
		0x8D, 0xA9, 0x79,
		0x8D, 0xAD, 0x79,
		0x8D, 0xB1, 0x79,
		0x8D, 0xB5, 0x79,
		0x8D, 0xB9, 0x79,
		0x8D, 0xBD, 0x79,
		0x8D, 0xC1, 0x79,
		0x8D, 0xC5, 0x79,
		0x8D, 0xC9, 0x79,
		0x8D, 0xCD, 0x79,
		0x8D, 0xD1, 0x79,
		0x8D, 0xD5, 0x79,
		0x8D, 0xD9, 0x79,
		0x8D, 0xDD, 0x79,
		0x8D, 0xE1, 0x79,
		0x8D, 0xE5, 0x79,
		0x8D, 0xE9, 0x79,
		0x8D, 0xED, 0x79,
		0x8D, 0xF1, 0x79,
		0x8D, 0xF5, 0x79,
		0x8D, 0xF9, 0x79,
		0x8D, 0xFD, 0x79,
		0x28, 0x6B
	};






	public void R809D46_InitializeObd1Ram()
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








	public void R809F0C()
	{
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
		this.R80A1E2();
		P &= ~0x30;
		[0x026D]++;
		return;
	}


	public void R809F1C()
	{
		this.R839443();
		A = 0x0000;
		[0x1B0F] = A;
		[0x035D] = 0;
		[0x026D]++;
		return;
	}

	public void R809FDF()
	{
		Stack.Push(P);
		P &= ~0x30;
		A = [0x14CE];

		if (Z == 1)
			return this.L80A003_Done();

		A = [0x0265];
		temp = A & 0x1000;

		if (Z == 1)
			return this.L80A003_Done();

		A = [0x14CC];

		if (Z == 0)
			return this.L80A003_Done();

		[0x0265] = 0;
		A = [0x026D];
		[0x14CA] = A;
		A = 0x001B;
		[0x026D] = A;
	}

	public void L80A003_Done()
	{
		P = Stack.Pop();
		return;
	}








	public void R80A005()
	{
		A = [0x58];
		temp = A & 0x1000;

		if (Z == 0)
			return this.L80A00F();

		return this.L80A093_Done();
	}

	public void L80A00F()
	{
		A = [0x026D];
		temp = A - 0x001A;

		if (Z == 0)
			return this.L80A020_Done();

		A = [0x0371];
		A--;

		if (Z == 1)
			return this.L80A022();

		A--;

		if (Z == 1)
			return this.L80A022();

	}

	public void L80A020_Done()
	{
		return this.L80A093_Done();
	}

	public void L80A022()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
		A = [0x026D];
		temp = A - 0x001A;

		if (Z == 0)
			return this.L80A05C();

		this.R909993_ResetRam();
		this.R80A094_ResetRam();
		A = 0x8000;
		[0x01] = A;
		A = 0xA053;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		return this.L80A05C();
	}

	public byte[] DmaTransferRecord80A053 = new byte[]
	{
		// Type 0x02, RAM Address 0x7E3000, Length 0x0780, VRAM Control 0x80, VRAM Address 0x1000
		0x02, 0x00, 0x30, 0x7E, 0x80, 0x07, 0x80, 0x00, 0x10
	}

	public void L80A05C()
	{
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
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
		this.R80A0C6_ResetRam();
		P |= 0x20;
		A = [0x4A];
		Stack.Push(A);
		P &= ~0x20;
		this.R808202_WaitFor014BFlag1();
		P |= 0x20;
		A = Stack.Pop();
		[0x4A] = A;
		P &= ~0x20;
	}

	public void L80A093_Done()
	{
		return;
	}








	public void R80A094_ResetRam()
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








	public void R80A0C6_ResetRam()
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








	public void R80A1E2()
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








	public void R839443()
	{
		A = 0x4110;
		temp = A & [0x150C];[0x150C] &= ~A;
		return;
	}







	public void R8CC0E8_ResetRegistersAndRam()
	{
		P &= ~0x30;
		this.R80823D_Set0100Flag80();
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
		this.R8087A4_LoadDmaTransferRecord();
		A = 0x8C00;
		[0x01] = A;
		A = 0xC1D4;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		this.R808202_WaitFor014BFlag1();
		A = 0x0000;
		Y = 0x0800;
		X = 0x0000;
	}

	public void L8CC163_Loop()
	{
		[0x7E2000 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L8CC163_Loop();

		Y = 0x0050;
		X = 0x0000;
	}

	public void L8CC173_Loop()
	{
		A = [0x8CC1DB + X];
		[0x7E2318 + X] = A;
		X++;
		Y--;
		X++;
		Y--;

		if (Z == 0)
			return this.L8CC173_Loop();

		A = 0x8C00;
		[0x01] = A;
		A = 0xC1CB;
		[0x00] = A;
		this.R8087A4_LoadDmaTransferRecord();
		this.R808202_WaitFor014BFlag1();
		this.R808252_Clear0100Flag80();
		return;
	}

	public byte[] Table8CC1C2 = new byte[]
	{
		//02 E4 BF 8C 00 01 80 00 00
	}

	public byte[] Table8CC1CB = new byte[]
	{
		//02 00 20 7E 00 08 80 00 10
	}

	public byte[] Table8CC1D4 = new byte[]
	{
		//01 2B C2 8C 04 00 00
	}







	public void R908000_ResetRam()
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

	public void R9081B1_ResetRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R80823D_Set0100Flag80();
		this.R80827B_Clear013CAnd4200Flag10();
		this.R8082A3_Clear013CAnd4200Flag20();
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
		this.R808202_WaitFor014BFlag1();
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void L909CDE()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		this.R80823D_Set0100Flag80();
		this.R9081B1_ResetRam();
		this.R94E94E();
		this.R908000_ResetRam();
		[0x026D]++;
		P = Stack.Pop();
		I = 0;
		B = Stack.Pop();
		return;
	}

	public void R94E94E()
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
		this.R94E9F3();
		A = [0x12];
		temp = A - [0x706000];
		
		if (Z == 1)
			return this.L94E977();

	}

	public void L94E974()
	{
		this.R94E97A();
	}

	public void L94E977()
	{
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}

	public void R94E97A()
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
		this.R94E9F3();
		A = [0x12];
		[0x706000] = A;
		return;
	}

	public void R94E9F3()
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







	public void R909993_ResetRam()
	{
		Stack.Push(B);
		Stack.Push(P);
		Stack.Push(K);
		B = Stack.Pop();
		A = 0xFFFF;
		[0x037F] = A;
		X = 0x0216;
		this.R909ACF_ResetRam3000();
		X = 0x04C6;
		this.R909ACF_ResetRam3000();
		A = 0xFFFF;
		[0x02F3] = A;
		P = Stack.Pop();
		B = Stack.Pop();
		return;
	}








	public void R909ACF_ResetRam3000()
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








	public void R909D97()
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







	public void R94EB88_ReadCartridgeRam()
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

	public void L94EBBB_Done()
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
		return this.L94EBBB_Done();
	}
}
